#pragma checksum "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\User\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "109c7d3444508aa5b33479f4695215d92a1fadaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_About), @"mvc.1.0.view", @"/Views/User/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"109c7d3444508aa5b33479f4695215d92a1fadaa", @"/Views/User/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92ffc6ad4e6893a356449355df03dd36ce3b4356", @"/Views/_ViewImports.cshtml")]
    public class Views_User_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyECommerceWebSite2022.ModelsView.CompanyDataViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/UserAssets/img/about-hero.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("About Hero"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\User\About.cshtml"
  
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<title>");
#nullable restore
#line 6 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\User\About.cshtml"
  Write(_localizer.GetLocalizedHtmlString("About"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</title>\r\n\r\n<section class=\"bg-success py-5\" style=\"padding-top:70px !important;\">\r\n    <div class=\"container\">\r\n        <div class=\"row align-items-center py-5\">\r\n            <div class=\"col-md-8 text-white\">\r\n                <h1>");
#nullable restore
#line 12 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\User\About.cshtml"
               Write(_localizer.GetLocalizedHtmlString("About"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <p>");
#nullable restore
#line 13 "F:\sys programs\Traning progects\MyECommerceWebSite2022\Views\User\About.cshtml"
               Write(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en"? Model.AboutDescreptionEn : Model.AboutDescreptionAr);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "109c7d3444508aa5b33479f4695215d92a1fadaa5306", async() => {
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
            WriteLiteral(@"
            </div>
        </div>
    </div>
</section>
<!-- Close Banner -->
<!-- Start Section -->
<section class=""container py-5"">
    <div class=""row text-center pt-5 pb-3"">
        <div class=""col-lg-6 m-auto"">
            <h1 class=""h1"">Our Services</h1>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                Lorem ipsum dolor sit amet.
            </p>
        </div>
    </div>
    <div class=""row"">

        <div class=""col-md-6 col-lg-3 pb-5"">
            <div class=""h-100 py-5 services-icon-wap shadow"">
                <div class=""h1 text-success text-center""><i class=""fa fa-truck fa-lg""></i></div>
                <h2 class=""h5 mt-4 text-center"">Delivery Services</h2>
            </div>
        </div>

        <div class=""col-md-6 col-lg-3 pb-5"">
            <div class=""h-100 py-5 services-icon-wap shadow"">
                <div class=""h1 text-success text-center""><i class=""fas fa-exchange-alt""></i></div>
  ");
            WriteLiteral(@"              <h2 class=""h5 mt-4 text-center"">Shipping & Return</h2>
            </div>
        </div>

        <div class=""col-md-6 col-lg-3 pb-5"">
            <div class=""h-100 py-5 services-icon-wap shadow"">
                <div class=""h1 text-success text-center""><i class=""fa fa-percent""></i></div>
                <h2 class=""h5 mt-4 text-center"">Promotion</h2>
            </div>
        </div>

        <div class=""col-md-6 col-lg-3 pb-5"">
            <div class=""h-100 py-5 services-icon-wap shadow"">
                <div class=""h1 text-success text-center""><i class=""fa fa-user""></i></div>
                <h2 class=""h5 mt-4 text-center"">24 Hours Service</h2>
            </div>
        </div>
    </div>
</section>
<!-- End Section -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyECommerceWebSite2022.ModelsView.CompanyDataViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591