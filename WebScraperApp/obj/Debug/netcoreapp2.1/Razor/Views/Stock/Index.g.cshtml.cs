#pragma checksum "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bc2423c20c44b0158a366d8d6fae37538460977"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stock_Index), @"mvc.1.0.view", @"/Views/Stock/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stock/Index.cshtml", typeof(AspNetCore.Views_Stock_Index))]
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
#line 1 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/_ViewImports.cshtml"
using WebScraperApp;

#line default
#line hidden
#line 2 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/_ViewImports.cshtml"
using WebScraperApp.Models;

#line default
#line hidden
#line 2 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
using Humanizer;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bc2423c20c44b0158a366d8d6fae37538460977", @"/Views/Stock/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"413bb7a366cad8cc7b4fe0cc2d80956f80decd3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Stock_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StockViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkDone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
  
ViewData["Title"] = "View your Stock Portfolio";

#line default
#line hidden
            BeginContext(93, 73, true);
            WriteLiteral("<div class=\"panel panel-default stock-panel\">\n<div class=\"panel-heading\">");
            EndContext();
            BeginContext(167, 17, false);
#line 7 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
                      Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(184, 115, true);
            WriteLiteral("</div>\n<table class=\"table table-hover\">\n<thead>\n<tr>\n<td>&#x2714;</td>\n<td>Item</td>\n<td>Due</td>\n</tr>\n</thead>\n\n");
            EndContext();
#line 17 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
     foreach (var item in Model.Items)
    {

#line default
#line hidden
            BeginContext(344, 34, true);
            WriteLiteral("    <tr>\n        <td>\n            ");
            EndContext();
            BeginContext(378, 189, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c97639cb988c4c37a43ac42a4fe9c722", async() => {
                BeginContext(420, 109, true);
                WriteLiteral("\n                <input type=\"checkbox\" class=\"done-checkbox\">\n                <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 529, "\"", 545, 1);
#line 23 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
WriteAttributeValue("", 537, item.Id, 537, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(546, 14, true);
                WriteLiteral(">\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(567, 27, true);
            WriteLiteral("\n        </td>\n        <td>");
            EndContext();
            BeginContext(595, 10, false);
#line 26 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(605, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(624, 21, false);
#line 27 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
       Write(item.DueAt.Humanize());

#line default
#line hidden
            EndContext();
            BeginContext(645, 16, true);
            WriteLiteral("</td>\n    </tr>\n");
            EndContext();
#line 29 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
    }

#line default
#line hidden
            BeginContext(667, 58, true);
            WriteLiteral("</table>\n    <div class=\"panel-footer add-item-form\">\n    ");
            EndContext();
            BeginContext(726, 58, false);
#line 32 "/Users/jennypichardo/Desktop/visProjects/WebScraper/WebScraperApp/Views/Stock/Index.cshtml"
Write(await Html.PartialAsync("AddItemPartial", new StockItem()));

#line default
#line hidden
            EndContext();
            BeginContext(784, 18, true);
            WriteLiteral("\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StockViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
