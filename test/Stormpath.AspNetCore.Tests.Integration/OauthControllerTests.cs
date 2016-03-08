﻿// <copyright file="StormpathMiddlewareExtensions.cs" company="Stormpath, Inc.">
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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.TestHost;
using Stormpath.AspNetCore.Route;
using Xunit;

namespace Stormpath.AspNetCore.Tests.Integration
{
    public class OauthControllerTests
    {
        [Fact]
        public async Task Executes_password_grant_flow()
        {
            var client = CreateClient();

            var grantRequest = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["grant_type"] = "password",
                ["username"] = "foo",
                ["password"] = "bar"
            });

            var response = await client.PostAsync("/oauth/tokens", grantRequest);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // 400
        }

        private static HttpClient CreateClient(Func<HttpContext, Func<Task>, Task> finalizer = null)
        {
            var server = new TestServer(TestServer.CreateBuilder()
                .UseServices(services =>
                {
                    services.AddStormpath();
                })
                .UseStartup(app =>
                {
                    app.UseMiddleware<Oauth2Route>("/oauth/tokens");

                    if (finalizer != null)
                    {
                        app.Use(finalizer);
                    }
                }));

            return server.CreateClient();
        }
    }
}