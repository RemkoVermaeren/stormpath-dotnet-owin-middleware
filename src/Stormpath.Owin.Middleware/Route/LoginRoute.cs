﻿// <copyright file="LoginRoute.cs" company="Stormpath, Inc.">
// Copyright (c) 2016 Stormpath, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using Stormpath.Owin.Common;
using Stormpath.Owin.Common.ViewModelBuilder;
using Stormpath.Owin.Middleware.Internal;
using Stormpath.Owin.Middleware.Model;
using Stormpath.Owin.Middleware.Model.Error;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using Stormpath.SDK.Error;
using Stormpath.SDK.Oauth;

namespace Stormpath.Owin.Middleware.Route
{
    public class LoginRoute : AbstractRoute
    {
        protected override async Task<bool> GetHtmlAsync(IOwinEnvironment context, IClient client, CancellationToken cancellationToken)
        {
            var queryString = QueryStringParser.Parse(context.Request.QueryString);

            var viewModelBuilder = new ExtendedLoginViewModelBuilder(
                _configuration.Web,
                ChangePasswordRoute.ShouldBeEnabled(_configuration),
                VerifyEmailRoute.ShouldBeEnabled(_configuration),
                queryString,
                null);
            var loginViewModel = viewModelBuilder.Build();

            await RenderViewAsync(context, _configuration.Web.Login.View, loginViewModel, cancellationToken);
            return true;
        }

        private async Task<IOauthGrantAuthenticationResult> HandleLogin(IClient client, string login, string password, CancellationToken cancellationToken)
        {
            var application = await client.GetApplicationAsync(_configuration.Application.Href, cancellationToken);

            var passwordGrantRequest = OauthRequests.NewPasswordGrantRequest()
                .SetLogin(login)
                .SetPassword(password)
                .Build();

            var passwordGrantAuthenticator = application.NewPasswordGrantAuthenticator();

            var grantResult = await passwordGrantAuthenticator
                .AuthenticateAsync(passwordGrantRequest, cancellationToken);

            return grantResult;
        }

        protected override async Task<bool> PostHtmlAsync(IOwinEnvironment context, IClient client, CancellationToken cancellationToken)
        {
            var queryString = QueryStringParser.Parse(context.Request.QueryString);

            var requestBody = await context.Request.GetBodyAsStringAsync(cancellationToken);
            var formData = FormContentParser.Parse(requestBody);

            var login = formData.GetString("login");
            var password = formData.GetString("password");

            bool missingLoginOrPassword = string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password);
            if (missingLoginOrPassword)
            {
                var viewModelBuilder = new ExtendedLoginViewModelBuilder(
                    _configuration.Web,
                    ChangePasswordRoute.ShouldBeEnabled(_configuration),
                    VerifyEmailRoute.ShouldBeEnabled(_configuration),
                    queryString,
                    formData);
                var loginViewModel = viewModelBuilder.Build();
                loginViewModel.Errors.Add("The login and password fields are required.");

                await RenderViewAsync(context, _configuration.Web.Login.View, loginViewModel, cancellationToken);
                return true;
            }

            try
            {
                var grantResult = await HandleLogin(client, login, password, cancellationToken);

                Cookies.AddCookiesToResponse(context, client, grantResult, _configuration);
            }
            catch (ResourceException rex)
            {
                var viewModelBuilder = new ExtendedLoginViewModelBuilder(
                    _configuration.Web,
                    ChangePasswordRoute.ShouldBeEnabled(_configuration),
                    VerifyEmailRoute.ShouldBeEnabled(_configuration),
                    queryString,
                    formData);
                var loginViewModel = viewModelBuilder.Build();
                loginViewModel.Errors.Add(rex.Message);

                await RenderViewAsync(context, _configuration.Web.Login.View, loginViewModel, cancellationToken);
                return true;
            }

            var nextUri = _configuration.Web.Login.NextUri;

            var nextUriFromQueryString = queryString.GetString("next");
            if (!string.IsNullOrEmpty(nextUriFromQueryString))
            {
                nextUri = nextUriFromQueryString;
            }

            return await HttpResponse.Redirect(context, nextUri);
        }

        protected override Task<bool> GetJsonAsync(IOwinEnvironment context, IClient client, CancellationToken cancellationToken)
        {
            var viewModelBuilder = new LoginViewModelBuilder(_configuration.Web.Login);
            var loginViewModel = viewModelBuilder.Build();

            return JsonResponse.Ok(context, loginViewModel);
        }

        protected override async Task<bool> PostJsonAsync(IOwinEnvironment context, IClient client, CancellationToken cancellationToken)
        {
            var bodyString = await context.Request.GetBodyAsStringAsync(cancellationToken);
            var body = Serializer.Deserialize<LoginPostModel>(bodyString);
            var login = body?.Login;
            var password = body?.Password;

            bool missingLoginOrPassword = string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password);
            if (missingLoginOrPassword)
            {
                return await Error.Create(context, new BadRequest("Missing login or password."), cancellationToken);
            }

            var grantResult = await HandleLogin(client, login, password, cancellationToken);
            // Errors will be caught up in AbstractRouteMiddleware

            Cookies.AddCookiesToResponse(context, client, grantResult, _configuration);

            var token = await grantResult.GetAccessTokenAsync(cancellationToken);
            var account = await token.GetAccountAsync(cancellationToken);

            var sanitizer = new ResponseSanitizer<IAccount>();
            var responseModel = new
            {
                account = sanitizer.Sanitize(account)
            };

            return await JsonResponse.Ok(context, responseModel);
        }
    }
}
