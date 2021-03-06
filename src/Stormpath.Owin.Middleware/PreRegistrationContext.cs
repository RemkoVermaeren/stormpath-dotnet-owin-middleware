﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stormpath.Owin.Abstractions;
using Stormpath.SDK.Account;

namespace Stormpath.Owin.Middleware
{
    public sealed class PreRegistrationContext : HandlerContext
    {
        public PreRegistrationContext(IOwinEnvironment environment, IAccount account)
            : base(environment)
        {
            Account = account;
        }

        public PreRegistrationContext(IOwinEnvironment environment, IAccount account, IDictionary<string, string> postData)
            : base(environment)
        {
            Account = account;
            PostData = new ReadOnlyDictionary<string, string>(postData);
        }

        public IAccount Account { get; }

        public IReadOnlyDictionary<string, string> PostData { get; }

        public IAccountCreationActions AccountStore { get; set; }

        public string OrganizationNameKey { get; set; }

        public IAccountCreationOptions Options { get; set; }

        public PreRegistrationResult Result { get; set; }
    }
}
