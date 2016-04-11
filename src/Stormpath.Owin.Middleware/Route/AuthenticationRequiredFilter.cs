﻿// <copyright file="StormpathMiddleware.GetUser.cs" company="Stormpath, Inc.">
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stormpath.Configuration.Abstractions;
using Stormpath.Configuration.Abstractions.Model;
using Stormpath.Owin.Common;
using Stormpath.Owin.Middleware.Internal;
using Stormpath.Owin.Middleware.Owin;
using Stormpath.SDK.Account;
using Stormpath.SDK.Logging;

namespace Stormpath.Owin.Middleware.Route
{
    public sealed class AuthenticationRequiredFilter
    {
        private readonly ILogger logger;

        public AuthenticationRequiredFilter(ILogger logger)
        {
            this.logger = logger;
        }

        public Task<bool> InvokeAsync(IDictionary<string, object> environment)
        {
            IOwinEnvironment context = new DefaultOwinEnvironment(environment);
            var configuration = environment.Get<StormpathConfiguration>(OwinKeys.StormpathConfiguration);
            var authenticatedUser = environment.Get<IAccount>(OwinKeys.StormpathUser);
            var authenticationScheme = environment.Get<string>(OwinKeys.StormpathUserScheme);

            var getAcceptHeaderFunc = new Func<string>(() => context.Request.Headers.GetString("Accept"));
            var getRequestPathFunc = new Func<string>(() => context.Request.Path);
            var deleteCookieAction = new Action<WebCookieConfiguration>(cookie => Cookies.Delete(context, cookie));
            var setStatusCodeAction = new Action<int>(code => context.Response.StatusCode = code);
            var redirectAction = new Action<string>(location => context.Response.Headers.SetString("Location", location));

            var handler = new AuthenticationRequiredBehavior(
                configuration.Web,
                getAcceptHeaderFunc,
                getRequestPathFunc,
                deleteCookieAction,
                setStatusCodeAction,
                redirectAction);

            if (handler.IsAuthorized(authenticationScheme, AuthenticationRequiredBehavior.AnyScheme, authenticatedUser))
            {
                return Task.FromResult(true); ; // Authentication check succeeded
            }

            logger.Info("User attempted to access a protected endpoint with invalid credentials.");

            handler.OnUnauthorized();
            return Task.FromResult(false); // Authentication check failed
        }
    }
}