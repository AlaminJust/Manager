#pragma checksum "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f66ca02458dc08c31bd15ed15d78071e321014f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageGroup_CostList), @"mvc.1.0.view", @"/Views/ManageGroup/CostList.cshtml")]
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
#line 1 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\_ViewImports.cshtml"
using LocalMealManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\_ViewImports.cshtml"
using LocalMealManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f66ca02458dc08c31bd15ed15d78071e321014f", @"/Views/ManageGroup/CostList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2989bf02620386e4ddc82b025093e33fb70305f", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageGroup_CostList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LocalMealManagement.ViewModel.CostViewModelList>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
  
    double TotalCost = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-striped table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th> AddedBy </th>\r\n            <th> Date </th>\r\n            <th> Description </th>\r\n            <th> Money </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td> ");
#nullable restore
#line 21 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
                Write(item.IdentityUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 22 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
                Write(item.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td> ");
#nullable restore
#line 23 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
                Write(item.Descriptions);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 24 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
                Write(item.Taka);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 26 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
            TotalCost += item.Taka;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <th> AddedBy </th>\r\n            <th> Date </th>\r\n            <th> Description </th>\r\n            <th> ");
#nullable restore
#line 34 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\ManageGroup\CostList.cshtml"
            Write(TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LocalMealManagement.ViewModel.CostViewModelList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
