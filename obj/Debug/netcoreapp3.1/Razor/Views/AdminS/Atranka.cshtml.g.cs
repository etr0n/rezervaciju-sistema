#pragma checksum "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e1a861be0cb8815c15b3e170dc88d417e4aba4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminS_Atranka), @"mvc.1.0.view", @"/Views/AdminS/Atranka.cshtml")]
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
#line 1 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\_ViewImports.cshtml"
using GrozioSalonuISCF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\_ViewImports.cshtml"
using GrozioSalonuISCF.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e1a861be0cb8815c15b3e170dc88d417e4aba4e", @"/Views/AdminS/Atranka.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca1ab469728769639ad66763f2f3e5b01cba1f95", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminS_Atranka : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrozioSalonuISCF.Models.Paslauga>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Atranka", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
  
    ViewData["Title"] = "Atrinkti salonus";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Salonų atrinkimas</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e1a861be0cb8815c15b3e170dc88d417e4aba4e4281", async() => {
                WriteLiteral("\r\n    <div class=\"form-actions no-color\">\r\n        <p>\r\n            Atrinkti pagal pavadinimą: <input type=\"text\" name=\"SearchString\"");
                BeginWriteAttribute("value", " value=\"", 379, "\"", 413, 1);
#nullable restore
#line 15 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
WriteAttributeValue("", 387, ViewData["CurrentFilter"], 387, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <input type=\"submit\" value=\"Atrinkti\" class=\"btn btn-default\" /> |\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e1a861be0cb8815c15b3e170dc88d417e4aba4e5174", async() => {
                    WriteLiteral("Rodyti viską");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n");
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
            WriteLiteral(@"
<br />
<table class=""table"">
    <thead>
        <tr>
            <th>
                Miestas
            </th>
            <th>
                Salonas
            </th>
            <th>
                Pavadinimas
            </th>
            <th>
                Kaina
            </th>
            <th>
                Trukmė
            </th>
            <th>
                Tipas
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 47 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.Salonas.Miestas.pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.Salonas.pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.kaina));

#line default
#line hidden
#nullable disable
            WriteLiteral(" &euro;\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.trukme));

#line default
#line hidden
#nullable disable
            WriteLiteral(" val\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaslaugosTipas.pavadinimas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Norte\Documents\GitHub\rezervaciju-sistema\Views\AdminS\Atranka.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrozioSalonuISCF.Models.Paslauga>> Html { get; private set; }
    }
}
#pragma warning restore 1591
