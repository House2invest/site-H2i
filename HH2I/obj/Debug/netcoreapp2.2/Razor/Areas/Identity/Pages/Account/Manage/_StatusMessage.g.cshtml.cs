#pragma checksum "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "023e183b80988183cff64854315cd7f5397aa7ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(House2Invest.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage__StatusMessage), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/Manage/_StatusMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Identity/Pages/Account/Manage/_StatusMessage.cshtml", typeof(House2Invest.Areas.Identity.Pages.Account.Manage.Areas_Identity_Pages_Account_Manage__StatusMessage))]
namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\_ViewImports.cshtml"
using House2Invest.Areas.Identity;

#line default
#line hidden
#line 1 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using House2Invest.Areas.Identity.Pages.Account;

#line default
#line hidden
#line 2 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using House2Invest;

#line default
#line hidden
#line 4 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using House2Invest.Data;

#line default
#line hidden
#line 5 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using House2Invest.Models;

#line default
#line hidden
#line 6 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#line 7 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using House2Invest.Models.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using House2Invest.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"023e183b80988183cff64854315cd7f5397aa7ea", @"/Areas/Identity/Pages/Account/Manage/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"497b3ea44ae66ed24abfbfb3a86d14d2f6be41a6", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b490f6bc841164de2062ed368c3de2d94c154641", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47cfca344f107940b61d96c71e640ae6b3301607", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";

#line default
#line hidden
            BeginContext(134, 109, true);
            WriteLiteral("    <section class=\"py-5\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 243, "\"", 300, 4);
            WriteAttributeValue("", 251, "alert", 251, 5, true);
            WriteAttributeValue(" ", 256, "alert-", 257, 7, true);
#line 8 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
WriteAttributeValue("", 263, statusMessageClass, 263, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 282, "alert-dismissible", 283, 18, true);
            EndWriteAttribute();
            BeginContext(301, 182, true);
            WriteLiteral(" role=\"alert\">\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n                    ");
            EndContext();
            BeginContext(484, 5, false);
#line 10 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
               Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(489, 78, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
            EndContext();
#line 15 "C:\Users\je_el\source\repos\HH2I\HH2I\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591