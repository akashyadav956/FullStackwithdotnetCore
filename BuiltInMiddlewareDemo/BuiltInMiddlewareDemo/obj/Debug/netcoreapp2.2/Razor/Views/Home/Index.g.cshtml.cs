#pragma checksum "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65a5b58800fe8c2a116580e48ac03097eef3a956"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\_ViewImports.cshtml"
using BuiltInMiddlewareDemo;

#line default
#line hidden
#line 2 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\_ViewImports.cshtml"
using BuiltInMiddlewareDemo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65a5b58800fe8c2a116580e48ac03097eef3a956", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5542fe0450f216d65c6260f5a2f231704441e72d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 194, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n\r\n    <h3> ");
            EndContext();
            BeginContext(240, 15, false);
#line 9 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\Home\Index.cshtml"
    Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(255, 25, true);
            WriteLiteral("</h3>\r\n\r\n    <h4> Name:  ");
            EndContext();
            BeginContext(281, 16, false);
#line 11 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\Home\Index.cshtml"
           Write(ViewBag.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(297, 25, true);
            WriteLiteral("</h4>\r\n\r\n    <h4> Age:   ");
            EndContext();
            BeginContext(323, 11, false);
#line 13 "D:\FSD_Tranning\DotNetCore\BuiltInMiddlewareDemo\BuiltInMiddlewareDemo\Views\Home\Index.cshtml"
           Write(ViewBag.Age);

#line default
#line hidden
            EndContext();
            BeginContext(334, 17, true);
            WriteLiteral("</h4>\r\n\r\n</div>\r\n");
            EndContext();
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
