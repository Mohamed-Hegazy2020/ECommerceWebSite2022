#pragma checksum "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ce60ff6ffb0621f2c423d9463760f8b844bde51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoices_PrintOrders), @"mvc.1.0.view", @"/Views/Invoices/PrintOrders.cshtml")]
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
#line 1 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\_ViewImports.cshtml"
using MyECommerceWebSite2022;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\_ViewImports.cshtml"
using MyECommerceWebSite2022.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ce60ff6ffb0621f2c423d9463760f8b844bde51", @"/Views/Invoices/PrintOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92ffc6ad4e6893a356449355df03dd36ce3b4356", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoices_PrintOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyECommerceWebSite2022.ModelsView.InvoiceMasterViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/UserAssets/css/fontawesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/UserAssets/js/jquery-1.11.0.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_PrintLayout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5ce60ff6ffb0621f2c423d9463760f8b844bde514586", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ce60ff6ffb0621f2c423d9463760f8b844bde515700", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th style=\"width: 15%;\">\r\n                <h4>الطلبيات</h4>\r\n            </th>\r\n            <th style=\"text-align:right;\">\r\n");
            WriteLiteral(@"            </th>  
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
            </td>
        </tr>

    </tbody>

</table>

<table class=""table table-responsive"" style=""font-size:small;"">
    <thead>
        <tr>
            <th>
                ");
#nullable restore
#line 51 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.customerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 54 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.customerTel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 57 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.customerMobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 60 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.customerAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 63 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.paymentMethodName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 66 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.invoiceDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 69 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.InvoiceTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 72 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.CuruncyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 76 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.IsPayed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 79 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDeleverd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 85 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.customerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 92 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.customerTel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 95 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.customerMobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 98 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.customerAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 101 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.paymentMethodName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 104 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.invoiceDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 107 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.InvoiceTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 110 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.CuruncyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 113 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsPayed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 116 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsDeleverd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 119 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\Invoices\PrintOrders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MyECommerceWebSite2022.Resources.LocalizationService _localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyECommerceWebSite2022.ModelsView.InvoiceMasterViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591