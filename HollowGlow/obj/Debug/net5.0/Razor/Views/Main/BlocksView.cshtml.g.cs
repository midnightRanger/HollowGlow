#pragma checksum "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e0519cef900be55856fad053e42e403bb6a7e4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_BlocksView), @"mvc.1.0.view", @"/Views/Main/BlocksView.cshtml")]
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
#line 1 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\_ViewImports.cshtml"
using HollowGlow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\_ViewImports.cshtml"
using HollowGlow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e0519cef900be55856fad053e42e403bb6a7e4f", @"/Views/Main/BlocksView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b4555dd196741da3043fa38dbe3f47cc7aa61f3", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_BlocksView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HollowGlow.Models.BlockModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
  
    ViewBag.Title = "Все блокчейны";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card_block\">\r\n    \r\n");
#nullable restore
#line 8 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p> ID: ");
#nullable restore
#line 10 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p> Data: ");
#nullable restore
#line 11 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
                 Write(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p> Timestamp: ");
#nullable restore
#line 12 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
                      Write(item.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p> Nonce: ");
#nullable restore
#line 13 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
                  Write(item.Nonce);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p> Owner: ");
#nullable restore
#line 14 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
                  Write(item.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p> Hash: ");
#nullable restore
#line 15 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
                 Write(item.Hash);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 16 "C:\Users\Лев\source\repos\HollowGlow\HollowGlow\Views\Main\BlocksView.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HollowGlow.Models.BlockModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591