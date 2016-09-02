﻿// <copyright file="LogoutRoute.cs" company="Stormpath, Inc.">
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

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Stormpath.Owin.Abstractions;
using Stormpath.Owin.Middleware.Internal;
using Stormpath.SDK.Account;
using Stormpath.SDK.Client;
using Stormpath.SDK.Error;
using Stormpath.SDK.Jwt;
using Stormpath.SDK.Logging;

namespace Stormpath.Owin.Middleware.Route
{
    public class LogoutRoute : AbstractRoute
    {
        protected override async Task<bool> PostHtmlAsync(IOwinEnvironment context, IClient client, ContentType bodyContentType, CancellationToken cancellationToken)
        {
            await HandleLogout(context, client, cancellationToken);

            await HttpResponse.Redirect(context, _configuration.Web.Logout.NextUri);
            return true;
        }

        protected override async Task<bool> PostJsonAsync(IOwinEnvironment context, IClient client, ContentType bodyContentType, CancellationToken cancellationToken)
        {
            await HandleLogout(context, client, cancellationToken);

            await JsonResponse.Ok(context);
            return true;
        }

        private async Task HandleLogout(IOwinEnvironment context, IClient client, CancellationToken cancellationToken)
        {
            var account = context.Request[OwinKeys.StormpathUser] as IAccount;

            var preLogoutContext = new PreLogoutContext(context, account);
            await _handlers.PreLogoutHandler(preLogoutContext, cancellationToken);

            // Remove user from request
            context.Request[OwinKeys.StormpathUser] = null;

            string[] rawCookies;
            context.Request.Headers.TryGetValue("Cookie", out rawCookies);
            var cookieParser = new CookieParser(rawCookies, _logger);

            await RevokeTokens(client, cookieParser, cancellationToken);
            
            DeleteCookies(context, cookieParser);

            var postLogoutContext = new PostLogoutContext(context, account);
            await _handlers.PostLogoutHandler(postLogoutContext, cancellationToken);
        }

        private async Task RevokeTokens(IClient client, CookieParser cookieParser, CancellationToken cancellationToken)
        {
            var accessToken = cookieParser.Get(_configuration.Web.AccessTokenCookie.Name);
            var refreshToken = cookieParser.Get(_configuration.Web.RefreshTokenCookie.Name);

            var deleteAccessTokenTask = Task.FromResult(false);
            var deleteRefreshTokenTask = Task.FromResult(false);

            string jti;
            if (IsValidJwt(accessToken, client, out jti))
            {
                try
                {
                    var accessTokenResource = await client.GetAccessTokenAsync($"/accessTokens/{jti}", cancellationToken);
                    deleteAccessTokenTask = accessTokenResource.DeleteAsync(cancellationToken);
                }
                catch (ResourceException rex)
                {
                    _logger.Info(rex.DeveloperMessage, source: nameof(RevokeTokens));
                }
            }

            if (IsValidJwt(refreshToken, client, out jti))
            {
                try
                {
                    var refreshTokenResource = await client.GetRefreshTokenAsync($"/refreshTokens/{jti}", cancellationToken);
                    deleteRefreshTokenTask = refreshTokenResource.DeleteAsync(cancellationToken);
                }
                catch (ResourceException rex)
                {
                    _logger.Info(rex.DeveloperMessage, source: nameof(RevokeTokens));
                }
            }

            try
            {
                await Task.WhenAll(deleteAccessTokenTask, deleteRefreshTokenTask);
            }
            catch (ResourceException rex)
            {
                _logger.Info(rex.DeveloperMessage, source: nameof(RevokeTokens));
            }
        }

        private static bool IsValidJwt(string jwt, IClient client, out string jti)
        {
            jti = null;

            if (string.IsNullOrEmpty(jwt))
            {
                return false;
            }

            try
            {
                var parsed = client.NewJwtParser()
                    .SetSigningKey(client.Configuration.Client.ApiKey.Secret, Encoding.UTF8)
                    .Parse(jwt);
                jti = parsed.Body.Id;
                return true;
            }
            catch (InvalidJwtException)
            {
                return false;
            }
        }

        private void DeleteCookies(IOwinEnvironment context, CookieParser cookieParser)
        {
            if (cookieParser.Contains(_configuration.Web.AccessTokenCookie.Name))
            {
                Cookies.DeleteTokenCookie(context, _configuration.Web.AccessTokenCookie, _logger);
            }
            if (cookieParser.Contains(_configuration.Web.RefreshTokenCookie.Name))
            {
                Cookies.DeleteTokenCookie(context, _configuration.Web.RefreshTokenCookie, _logger);
            }
        }
    }
}
