namespace Stormpath.Owin.Views.Precompiled
{
#line 1 "ForgotPassword.cshtml"
using System

#line default
#line hidden
    ;
#line 2 "ForgotPassword.cshtml"
using System.Linq

#line default
#line hidden
    ;
#line 3 "ForgotPassword.cshtml"
using Stormpath.Owin.Abstractions

#line default
#line hidden
    ;
    using System.Threading.Tasks;

    public class ForgotPassword : BaseView<Stormpath.Owin.Abstractions.ViewModel.ForgotPasswordFormViewModel>
    {
        #line hidden
        public ForgotPassword()
        {
        }

        #pragma warning disable 1998
        public override async Task ExecuteAsync()
        {
            WriteLiteral(@"
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class=""no-js lt-ie9 lt-ie8 lt-ie7""> <![endif]-->
<!--[if IE 7]>         <html class=""no-js lt-ie9 lt-ie8""> <![endif]-->
<!--[if IE 8]>         <html class=""no-js lt-ie9""> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang=""en"" class=""no-js"">
<!--<![endif]-->
<head>
    <meta charset=""utf-8"">
    <title>Forgot Your Password?</title>
    <meta content=""Forgot your password? No worries!"" name=""description"">
    <meta content=""width=device-width"" name=""viewport"">
    <link href=""//fonts.googleapis.com/css?family=Open+Sans:300italic,300,400italic,400,600italic,600,700italic,700,800italic,800"" rel=""stylesheet"" type=""text/css"">
    <link href=""//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css"" rel=""stylesheet"">
    <style>
        html,
body {
  height: 100%;
}

@media (max-width: 767px) {
  html,
  body {
    padding: 0 4px;
  }
}

body {
  margin-left: auto;
  margin-right: auto;
}

body,
div,
p,
a,
label {
  font-family: 'Open Sans';
  font-size: 14px;
  font-weight: 400;
  color: #484848;
}

a {
  color: #0072dd;
}

p {
  line-height: 21px;
}

.container {
  max-width: 620px;
}

.logo {
  margin: 34px auto 25px auto;
  display: block;
}

.btn-sp-green {
  height: 45px;
  line-height: 22.5px;
  padding: 0 40px;
  color: #fff;
  font-size: 17px;
  background: -webkit-linear-gradient(#42c41a 50%, #2dbd00 50%);
  background: linear-gradient(#42c41a 50%, #2dbd00 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#2dbd00, endColorstr=#42c41a);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#2dbd00, endColorstr=#42c41a)';
}

.btn-sp-green:hover,
.btn-sp-green:focus {
  color: #fff;
  background: -webkit-linear-gradient(#43cd1a 50%, #2ec700 50%);
  background: linear-gradient(#43cd1a 50%, #2ec700 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#2ec700, endColorstr=#43cd1a);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#2ec700, endColorstr=#43cd1a)';
}

.btn-social {
  height: 37px;
  line-height: 18.5px;
  color: #fff;
  font-size: 16px;
  border-radius: 3px;
}

.btn-social:hover,
.btn-social:focus {
  color: #fff;
}

.btn-facebook {
  background: -webkit-linear-gradient(#4c6fc5 50%, #3d63c0 50%);
  background: linear-gradient(#4c6fc5 50%, #3d63c0 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#3d63c0, endColorstr=#4c6fc5);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#3d63c0, endColorstr=#4c6fc5)';
}

.btn-facebook:hover,
.btn-facebook:focus {
  color: #fff;
  background: -webkit-linear-gradient(#4773de 50%, #3767db 50%);
  background: linear-gradient(#4773de 50%, #3767db 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#3767db, endColorstr=#4773de);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#3767db, endColorstr=#4773de)';
}

.btn-google {
  background: -webkit-linear-gradient(#e05b4b 50%, #dd4b39 50%);
  background: linear-gradient(#e05b4b 50%, #dd4b39 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#dd4b39, endColorstr=#e05b4b);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#dd4b39, endColorstr=#e05b4b)';
}

.btn-google:hover,
.btn-google:focus {
  color: #fff;
  background: -webkit-linear-gradient(#ea604e 50%, #e8503c 50%);
  background: linear-gradient(#ea604e 50%, #e8503c 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#e8503c, endColorstr=#ea604e);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#e8503c, endColorstr=#ea604e)';
}

.btn-linkedin {
  background: -webkit-linear-gradient(#007cbc 50%, #0077B5 50%);
  background: linear-gradient(#007cbc 50%, #0077B5 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#007cbc, endColorstr=#0077B5);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#007cbc, endColorstr=#0077B5)';
}

.btn-linkedin:hover,
.btn-linkedin:focus {
  color: #fff;
  background: -webkit-linear-gradient(#007cbc 50%, #0077B5 50%);
  background: linear-gradient(#007cbc 50%, #0077B5 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#007cbc, endColorstr=#0077B5);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#007cbc, endColorstr=#0077B5)';
}

.btn-github {
  background: -webkit-linear-gradient(#848282 50%, #7B7979 50%);
  background: linear-gradient(#848282 50%, #7B7979 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#848282, endColorstr=#7B7979);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#848282, endColorstr=#7B7979)';
}

.btn-github:hover,
.btn-github:focus {
  color: #fff;
  background: -webkit-linear-gradient(#8C8888 50%, #848080 50%);
  background: linear-gradient(#8C8888 50%, #848080 50%);
  filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0, startColorstr=#8C8888, endColorstr=#848080);
  -ms-filter: 'progid:DXImageTransform.Microsoft.gradient (GradientType=0, startColorstr=#8C8888, endColorstr=#848080)';
}

.btn-register {
  font-size: 16px;
}

.form-control {
  font-size: 15px;
  box-shadow: none;
}

.form-control::-webkit-input-placeholder {
  color: #aaadb0;
}

.form-control::-moz-placeholder {
  color: #aaadb0;
}

.form-control:-ms-input-placeholder {
  color: #aaadb0;
}

.form-control::placeholder {
  color: #aaadb0;
}

.form-control:focus {
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075), 0 0 6px rgba(0, 132, 255, 0.4);
}

.view .header {
  padding: 34px 0;
}

.view .header,
.view .header a {
  font-weight: 300;
  font-size: 21px;
}

.view input[type='text'],
.view input[type='password'],
.view input[type='email'],
.view input[type='color'],
.view input[type='date'],
.view input[type='datetime']
.view input[type='datetime-local'],
.view input[type='email'],
.view input[type='month'],
.view input[type='number'],
.view input[type='range'],
.view input[type='search'],
.view input[type='tel'],
.view input[type='time'],
.view input[type='url'],
.view input[type='week']{
  background-color: #f6f6f6;
  height: 45px;
}

.view a.forgot,
.view a.to-login {
  float: right;
  padding: 17px 0;
  font-size: 13px;
}

.view form button {
  display: block;
  float: right;
  margin-bottom: 25px;
}

.view form label {
  height: 45px;
  line-height: 45px;
}

.box {
  box-shadow: 0 0px 3px 1px rgba(0, 0, 0, 0.1);
  border: 1px solid #cacaca;
  border-radius: 3px;
  padding: 0 30px;
}

.sp-form .has-error,
.sp-form .has-error .help-block {
  color: #ec3e3e;
  font-weight: 600;
}

.sp-form .has-error input[type='text'],
.sp-form .has-error input[type='password'] {
  border-color: #ec3e3e;
}

.sp-form .form-group {
  margin-bottom: 21px;
}

.sp-form input[type='text'],
.sp-form input[type='password'] {
  position: relative;
}

.sp-form .help-block {
  font-size: 12px;
  position: absolute;
  top: 43px;
}

.verify-view .box {
  padding-bottom: 30px;
}

.verify-view .box .header {
  padding-bottom: 20px;
}

.unverified-view .box {
  padding-bottom: 30px;
}

.unverified-view .box .header {
  padding-bottom: 25px;
}

.login-view .box {
  background-color: #f6f6f6;
  padding: 0;
}

.login-view label {
  margin-bottom: 7px;
}

.login-view .header p {
  margin-top: 2em;
}

.login-view .email-password-area {
  background-color: white;
  border-top-left-radius: 3px;
  border-bottom-left-radius: 3px;
}

@media (min-width: 767px) {
  .login-view .email-password-area {
    padding: 0 30px;
  }
}

.login-view .email-password-area label {
  height: 14px;
  line-height: 14px;
}

.login-view .email-password-area input[type='checkbox'] {
  visibility: hidden;
}

.login-view .email-password-area input[type='checkbox'] + label {
  position: relative;
  padding-left: 8px;
  line-height: 16px;
  font-size: 13px;
}

.login-view .email-password-area input[type='checkbox'] + label:after {
  position: absolute;
  left: -16px;
  width: 16px;
  height: 16px;
  border: 1px solid #cacaca;
  background-color: #f6f6f6;
  content: '';
}

.login-view .email-password-area input[type='checkbox']:checked + label:after {
  background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDowRTVBQUVGMzJEODBFMjExODQ2N0NBMjk4MjdCNDBCNyIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo0RTY4NUM4NURGNEYxMUUyQUE5QkExOTlGODU3RkFEOCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo0RTY4NUM4NERGNEYxMUUyQUE5QkExOTlGODU3RkFEOCIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjQxNDQ4M0NEM0JERkUyMTE4MEYwQjNBRjIwMUNENzQxIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOkZDMEMxNjY2OUVCMUUyMTFBRjVDQkQ0QjE5MTNERDU2Ii8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+3YY4qgAAALlJREFUeNpi/P//PwMlgImBQjDwBrCgCwQHB+NUfObMGT9mZuboe/fuheM0ABu4fv060/fv32cBNTNycHBE4nUBNs0/f/7cAWSeMzQ0rCA5DICaNwKj+qGRkVEFUYF47ty5GWfPns2EsjsYGRlFgM5OJzoQ//37t5eLi2sRMMDec3Jypn79+lVXX1//H9HRaGJisvr379/nuLm5lwKdP9vMzOwZyekAaEA3EF8G4hZCYcQ4mhcYAAIMAJGST/dDIpNQAAAAAElFTkSuQmCC);
  background-position: -1px -1px;
}

@media (min-width: 767px) {
  .login-view .email-password-area.small {
    border-right: 1px solid #cacaca;
  }

  .login-view .email-password-area.small .group-email {
    margin-bottom: 21px;
  }
}

@media (max-width: 767px) {
  .login-view .email-password-area.small {
    border-bottom: 1px solid #cacaca;
    border-bottom-left-radius: 0;
    border-bottom-right-radius: 0;
  }
}

.login-view .email-password-area.large {
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px;
}

@media (min-width: 767px) {
  .login-view .email-password-area.large {
    padding: 0 50px;
  }

  .login-view .email-password-area.large .group-login label,
  .login-view .email-password-area.large .group-password label {
    height: 45px;
    line-height: 45px;
  }
}

.login-view .social-area {
  border-top-right-radius: 3px;
  border-bottom-right-radius: 3px;
  padding: 0 20px;
  position: relative;
  padding-bottom: 20px;
  background-color: #f6f6f6;
}

.login-view .social-area .header {
  margin-bottom: -6px;
}

@media (max-width: 767px) {
  .login-view .social-area .header {
    padding: 0px;
  }
}

.login-view .social-area button {
  display: block;
  width: 100%;
  margin-bottom: 15px;
}

.login, .register { display: table; }
.va-wrapper { display: table-cell; width: 100%; vertical-align: middle; }
.custom-container { display: table-row; height: 100%; }
    </style>
    <!--[if lt IE 9]>
     <script src='https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js'></script>
     <script src='https://oss.maxcdn.com/libs/respond.js/1.4.2/resp");
            WriteLiteral("ond.min.js\'></script>\r\n    <![endif]-->\r\n</head>\r\n<body class=\"login\">\r\n    <div class=\"container custom-container\">\r\n        <div class=\"va-wrapper\">\r\n            <div class=\"view login-view container\">\r\n");
#line 34 "ForgotPassword.cshtml"
                

#line default
#line hidden

#line 34 "ForgotPassword.cshtml"
                 if (Model.Status.Equals("invalid_sptoken", StringComparison.OrdinalIgnoreCase))
                {

#line default
#line hidden

            WriteLiteral(@"                    <div class=""row"">
                        <div class=""alert alert-warning invalid-sp-token-warning"">
                            <p>
                                The password reset link you tried to use is no longer valid.
                                Please request a new link from the form below.
                            </p>
                        </div>
                    </div>
");
#line 44 "ForgotPassword.cshtml"
                }

#line default
#line hidden

            WriteLiteral(@"                <div class=""box row"">
                    <div class=""email-password-area col-xs-12 large col-sm-12"">
                        <div class=""header"">
                            <span>
                                Forgot your password?
                            </span>
                            <p>
                                Enter your email address below to reset your password. You will
                                be sent an email which you will need to open to continue. You may
                                need to check your spam folder.
                            </p>
                        </div>

");
#line 58 "ForgotPassword.cshtml"
                        

#line default
#line hidden

#line 58 "ForgotPassword.cshtml"
                         if (Model.Errors.Any())
                        {

#line default
#line hidden

            WriteLiteral("                            <div class=\"alert alert-danger bad-login\">\r\n");
#line 61 "ForgotPassword.cshtml"
                                

#line default
#line hidden

#line 61 "ForgotPassword.cshtml"
                                 foreach (var error in Model.Errors)
                                {

#line default
#line hidden

            WriteLiteral("                                    <p>");
#line 63 "ForgotPassword.cshtml"
                                  Write(error);

#line default
#line hidden
            WriteLiteral("</p>\r\n");
#line 64 "ForgotPassword.cshtml"
                                }

#line default
#line hidden

            WriteLiteral("                            </div>\r\n");
#line 66 "ForgotPassword.cshtml"
                        }

#line default
#line hidden

            WriteLiteral("\r\n                        <form method=\"post\" role=\"form\"");
            BeginWriteAttribute("action", " action=\"", 3087, "\"", 3120, 1);
#line 68 "ForgotPassword.cshtml"
WriteAttributeValue("", 3096, Model.ForgotPasswordUri, 3096, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(" class=\"login-form form-horizontal\">\r\n                            <input");
            BeginWriteAttribute("name", " name=\"", 3193, "\"", 3231, 1);
#line 69 "ForgotPassword.cshtml"
WriteAttributeValue("", 3200, StringConstants.StateTokenName, 3200, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(" type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3246, "\"", 3271, 1);
#line 69 "ForgotPassword.cshtml"
WriteAttributeValue("", 3254, Model.StateToken, 3254, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(@"/>

                            <div class=""form-group group-email"">
                                <label class=""col-sm-4"">Email</label>
                                <div class=""col-sm-8"">
                                    <input placeholder=""Email"" required name=""email"" type=""email"" class=""form-control"">
                                </div>
                            </div>
                            <div>
                                <button type=""submit"" class=""login btn btn-login btn-sp-green"">Send Email</button>
                            </div>
                        </form>
                    </div>
                </div>
");
#line 83 "ForgotPassword.cshtml"
                

#line default
#line hidden

#line 83 "ForgotPassword.cshtml"
                 if (Model.LoginEnabled)
                {

#line default
#line hidden

            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 4023, "\"", 4045, 1);
#line 85 "ForgotPassword.cshtml"
WriteAttributeValue("", 4030, Model.LoginUri, 4030, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(" class=\"forgot\">Back to Log In</a>\r\n");
#line 86 "ForgotPassword.cshtml"
                }

#line default
#line hidden

            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js\"></script>\r\n    <script src=\"//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js\"></script>\r\n</body>\r\n</html>");
        }
        #pragma warning restore 1998
    }
}
