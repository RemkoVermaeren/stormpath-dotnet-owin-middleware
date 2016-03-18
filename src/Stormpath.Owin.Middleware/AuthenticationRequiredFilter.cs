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
using System.Security.Claims;
using System.Threading.Tasks;
using Stormpath.Owin.Middleware.Internal;
using Stormpath.Owin.Middleware.Owin;
using Stormpath.SDK.Account;
using Stormpath.SDK.Logging;

namespace Stormpath.Owin.Middleware
{
    public class AuthenticationRequiredFilter
    {
        private readonly ILogger logger;

        public AuthenticationRequiredFilter()
            : this(null)
        {
        }

        public AuthenticationRequiredFilter(ILogger logger = null)
        {
            this.logger = logger;
        }

        public async Task<bool> Invoke(IDictionary<string, object> environment)
        {
            IOwinEnvironment context = new DefaultOwinEnvironment(environment);
            var stormpathUser = environment.Get<IAccount>(OwinKeys.StormpathUser);
            var claimsUser = environment.Get<ClaimsPrincipal>(OwinKeys.RequestUser);

            if (stormpathUser != null && claimsUser != null)
            {
                return true; // Authentication check succeeded
            }

            logger.Info("User attempted to access a protected endpoint with invalid credentials.");
            // Delete cookies

            var originalUri = context.Request.OriginalUri;
            var loginUri = $"{environment.Get<string>(OwinKeys.StormpathLoginUri)}?next={Uri.EscapeUriString(originalUri)}";

            if (ContentNegotiation.SelectBestContentType(environment, new string[] { "text/html", "application/json" }).Equals("text/html"))
            {
                context.Response.StatusCode = 302;
                context.Response.Headers.SetString("Location", loginUri);
                return false; // Authentication check failed
            }

            await JsonResponse.Unauthorized(context);
            return false; // Authentication check failed
        }
    }
}