#pragma checksum "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/Shared/Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92af3a76f2212f499cea35ad10d8d419420e08d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using _9jaTips.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using _9jaTips.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using _9jaTips.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using _9jaTips.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using _9jaTips.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/_ViewImports.cshtml"
using Humanizer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92af3a76f2212f499cea35ad10d8d419420e08d2", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfc94fa66321aa62eca9c15f5d47a27955677fed", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h4 class=\"text-center\">");
#nullable restore
#line 31 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/Shared/Error.cshtml"
                               Write(ViewBag.ErrorTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h4 class=\"text-center\">");
#nullable restore
#line 32 "/Users/ogbaragodwin/Projects/9jaTips/9jaTips.Web/Views/Shared/Error.cshtml"
                               Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
