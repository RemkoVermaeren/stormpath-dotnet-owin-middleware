﻿// <copyright file="ProviderConfiguration.cs" company="Stormpath, Inc.">
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

namespace Stormpath.Owin.Abstractions.Configuration
{
    public sealed class ProviderConfiguration
    {
        public ProviderConfiguration(
            string clientId,
            string clientSecret,
            string callbackPath,
            string callbackUri,
            string scope)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            CallbackUri = callbackUri;
            CallbackPath = callbackPath;
            Scope = scope;
        }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string CallbackUri { get; }

        public string CallbackPath { get; }

        public string Scope { get; }
    }
}
