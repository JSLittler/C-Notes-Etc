#pragma checksum "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40fb047aa3f43479b1cd81c0f83f4ad91d42f0c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NotesApp_Index), @"mvc.1.0.view", @"/Views/NotesApp/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NotesApp/Index.cshtml", typeof(AspNetCore.Views_NotesApp_Index))]
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
#line 1 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\_ViewImports.cshtml"
using notesAppProject;

#line default
#line hidden
#line 2 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\_ViewImports.cshtml"
using notesAppProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40fb047aa3f43479b1cd81c0f83f4ad91d42f0c8", @"/Views/NotesApp/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"528394ec85d11b6d32322f74af29cd0085329b74", @"/Views/_ViewImports.cshtml")]
    public class Views_NotesApp_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(47, 43, true);
            WriteLiteral("\r\n<h3 class=\"username\" aria-pressed=\"true\">");
            EndContext();
            BeginContext(91, 16, false);
#line 6 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
                                    Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(107, 393, true);
            WriteLiteral(@"'s   Dashboard <a href=""/NotesApp/SignOut"" class=""btn btn-outline-info homebutton"" role=""button"" aria-pressed=""true"">Sign Out</a></h3>


<style type =""text/css"">
    .row {
        width: 100%
    }
     .column {
         background: lightblue;
         width: 45%;
         text-align: center;
         margin: 10px;
     }
</style>
<div class=""row"">
    <div class=""column"" >");
            EndContext();
            BeginContext(501, 16, false);
#line 21 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
                    Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(517, 45, true);
            WriteLiteral("\'s Notes App</div>\r\n    <div class=\"column\" >");
            EndContext();
            BeginContext(563, 16, false);
#line 22 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
                    Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(579, 72, true);
            WriteLiteral("\'s News App</div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"column\">");
            EndContext();
            BeginContext(652, 16, false);
#line 26 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
                   Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(668, 46, true);
            WriteLiteral("\'s Weather App</div>\r\n    <div class=\"column\">");
            EndContext();
            BeginContext(715, 16, false);
#line 27 "C:\Users\JLittler\Desktop\soloProjects\C-Notes-Etc\notesAppProject\notesAppProject\Views\NotesApp\Index.cshtml"
                   Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(731, 28, true);
            WriteLiteral("\'s Radio App</div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
