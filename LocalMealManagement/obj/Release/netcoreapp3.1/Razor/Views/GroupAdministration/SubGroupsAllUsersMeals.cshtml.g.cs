#pragma checksum "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b53cf53019d4e32fbff8b93bee7f5f4d30c1f601"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GroupAdministration_SubGroupsAllUsersMeals), @"mvc.1.0.view", @"/Views/GroupAdministration/SubGroupsAllUsersMeals.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b53cf53019d4e32fbff8b93bee7f5f4d30c1f601", @"/Views/GroupAdministration/SubGroupsAllUsersMeals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2989bf02620386e4ddc82b025093e33fb70305f", @"/Views/_ViewImports.cshtml")]
    public class Views_GroupAdministration_SubGroupsAllUsersMeals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LocalMealManagement.ViewModel.MealModelWithUserNameView>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
  
    double Dinnar = 0, Lunch = 0, Morning = 0;
    ViewData["Title"] = "SubGroupsAllUsersMeals";
    var groupByUsername = from s in Model
                          group s by s.IdentityUser.UserName
                          into g
                          select new
                          {
                              UserName = g.Key,
                              Dinnar = g.Sum(x => x.Dinnar),
                              Lunch = g.Sum(x => x.Lunch),
                              Morning = g.Sum(x => x.Morning)
                          };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-striped table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>Username</th>\r\n            <th>Morning</th>\r\n            <th>Dinnar</th>\r\n            <th>Lunch</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
         foreach (var meal in groupByUsername)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
               Write(meal.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
               Write(meal.Morning);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
               Write(meal.Dinnar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
               Write(meal.Lunch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
            Dinnar += (double)meal.Dinnar;
            Lunch += (double)meal.Lunch;
            Morning += (double)meal.Morning;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <th>Username</th>\r\n            <th>");
#nullable restore
#line 45 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
           Write(Morning);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 46 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
           Write(Dinnar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 47 "C:\Users\BS359\source\repos\LocalMealManagement\LocalMealManagement\Views\GroupAdministration\SubGroupsAllUsersMeals.cshtml"
           Write(Lunch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LocalMealManagement.ViewModel.MealModelWithUserNameView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
