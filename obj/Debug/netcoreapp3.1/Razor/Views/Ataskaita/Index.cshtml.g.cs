#pragma checksum "C:\Users\edruk\Documents\GitHub\rezervaciju-sistema\Views\Ataskaita\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c986c1fc09b315e5aec402a5676d004642286839"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ataskaita_Index), @"mvc.1.0.view", @"/Views/Ataskaita/Index.cshtml")]
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
#line 1 "C:\Users\edruk\Documents\GitHub\rezervaciju-sistema\Views\_ViewImports.cshtml"
using GrozioSalonuISCF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\edruk\Documents\GitHub\rezervaciju-sistema\Views\_ViewImports.cshtml"
using GrozioSalonuISCF.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c986c1fc09b315e5aec402a5676d004642286839", @"/Views/Ataskaita/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca1ab469728769639ad66763f2f3e5b01cba1f95", @"/Views/_ViewImports.cshtml")]
    public class Views_Ataskaita_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\edruk\Documents\GitHub\rezervaciju-sistema\Views\Ataskaita\Index.cshtml"
  Html.BeginForm("CreateDocument", "Ataskaita", FormMethod.Get);
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <p>Čia galite gauti savo salonų išlaidų ataskaitą pfd formatu. </p>\r\n        </div>\r\n        <div>\r\n            <input type=\"submit\" value=\"Ataskaita\" style=\"width:150px;height:27px\" />\r\n        </div>\r\n");
#nullable restore
#line 9 "C:\Users\edruk\Documents\GitHub\rezervaciju-sistema\Views\Ataskaita\Index.cshtml"
    }
    Html.EndForm();

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
