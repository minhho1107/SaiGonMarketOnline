#pragma checksum "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8400d1573257447cdd7c1ecff91ec4bd25868793"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_ListProductsSearchPartial), @"mvc.1.0.view", @"/Views/Search/ListProductsSearchPartial.cshtml")]
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
#line 1 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\_ViewImports.cshtml"
using BH_Online;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\_ViewImports.cshtml"
using BH_Online.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8400d1573257447cdd7c1ecff91ec4bd25868793", @"/Views/Search/ListProductsSearchPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4eab23fbfe83bec8ecce07562113896752defd55", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_ListProductsSearchPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml"
 if (Model != null)
{
    foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 9 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml"
           Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 12 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml"
           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>");
#nullable restore
#line 15 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml"
           Write(item.Price.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 19 "C:\Users\HELLO DELL\OneDrive\Documents\BH-Online\BH-Online\Views\Search\ListProductsSearchPartial.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591