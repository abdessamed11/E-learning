#pragma checksum "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cd9dcda614ae2158765ce3d8d8feea8ecb9bac6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_formations_Detail), @"mvc.1.0.view", @"/Views/formations/Detail.cshtml")]
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
#line 1 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\_ViewImports.cshtml"
using E_LEARNING;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\_ViewImports.cshtml"
using E_LEARNING.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cd9dcda614ae2158765ce3d8d8feea8ecb9bac6", @"/Views/formations/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a1d4696218131390bb71f3a5dc56b18c9c11ac", @"/Views/_ViewImports.cshtml")]
    public class Views_formations_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<E_LEARNING.Models.formation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_client.cshtml";
    var titre = ViewBag.categ;
    var len = ViewBag.Length;
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




<div class=""page-content bg-white"">
    <!-- inner page banner -->
    <div class=""page-banner ovbl-dark row"" style=""background-image:url(/assets/images/banner/banner3.jpg);"">
        <div class=""container"">
            <div class=""page-banner-entry "" >
                
                <h1 class=""text-white"" style=""text-transform:capitalize"">");
#nullable restore
#line 21 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                    Write(Html.DisplayFor(model=>model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- Breadcrumb row -->\r\n    <div class=\"breadcrumb-row\">\r\n        <div class=\"container row d-flex justify-content-between\">\r\n            <ul class=\"list-inline \">\r\n                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cd9dcda614ae2158765ce3d8d8feea8ecb9bac65966", async() => {
                WriteLiteral("Home");
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
            WriteLiteral("</li>\r\n                <li style=\"text-transform:capitalize\">Course ");
#nullable restore
#line 30 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                        Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n            <ul class=\"topbar-right\">\r\n                <li>");
#nullable restore
#line 33 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
               Write(Html.DisplayFor(model => model.Date.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 33 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                          Write(Html.DisplayFor(model => model.Date.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 33 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                      Write(Html.DisplayFor(model => model.Date.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                
            </ul>
        </div>
    </div>
    <!-- Breadcrumb row END -->
    <!-- inner page banner END -->
    <div class=""content-block"">
        <!-- About Us -->
        <div class=""section-area section-sp1"">
            <div class=""container"">
                <div class=""row d-flex flex-row-reverse"">
                    <div class=""col-lg-3 col-md-4 col-sm-12 m-b30"">
                        <div class=""course-detail-bx"">
                            <div class=""course-price"">
                                <del>$0.00</del>
                                <h4 class=""price"">Gratuit</h4>
                            </div>
                            <div class=""course-buy-now text-center"">
                                <a href=""#"" class=""btn radius-xl text-uppercase"">Buy Now This Courses</a>
                            </div>
                            <div class=""teacher-bx"">
                                <div class=""teacher-info"">
                     ");
            WriteLiteral("               <div class=\"teacher-thumb\">\r\n                                        <img src=\"/assets/images/testimonials/pic2.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 2340, "\"", 2346, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </div>\r\n                                    <div class=\"teacher-name\">\r\n                                        <h5 style=\"font-size:14px;text-transform:capitalize\">");
#nullable restore
#line 60 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                        Write(Html.DisplayFor(m => m.Student.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 60 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                                   Write(Html.DisplayFor(m => m.Student.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                        <span>Science Teacher</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""cours-more-info"">
                                <div class=""review"">
                                    <span>3 Review</span>
                                    <ul class=""cours-star"">
                                        <li class=""active""><i class=""fa fa-star""></i></li>
                                        <li class=""active""><i class=""fa fa-star""></i></li>
                                        <li class=""active""><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                    </ul>
                                </div>
                                <div class=""price categories"">
                 ");
            WriteLiteral("                   <span>Categories</span>\r\n                                    <h5 class=\"text-center h6 cours-star \" style=\"font-size:14px ;text-transform:capitalize\">");
#nullable restore
#line 78 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                        Write(Html.DisplayFor(model => model.categorie.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                    
                                </div>
                            </div>
                            <div class=""course-info-list scroll-page"">
                                <ul class=""navbar capitalize"">
");
#nullable restore
#line 84 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                     foreach (var item in titre)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a class=\"nav-link\" style=\"text-transform:capitalize\"");
            BeginWriteAttribute("href", " href=\"", 4336, "\"", 4354, 2);
            WriteAttributeValue("", 4343, "#", 4343, 1, true);
#nullable restore
#line 86 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
WriteAttributeValue("", 4344, item.Name, 4344, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"ti-zip\"></i>");
#nullable restore
#line 86 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 87 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class=""col-lg-9 col-md-8 col-sm-12"">
                        <div class=""courses-post"">
                            <div class=""ttr-post-media media-effect"">
                                <a href=""#""><img src=""assets/images/blog/default/thum1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 4856, "\"", 4862, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                            </div>
                            <div class=""ttr-post-info"">
                                <div class=""ttr-post-title "">
                                    <h2 style=""font-family: 'Roboto',sans-serif;text-transform:capitalize"" class=""post-title"">");
#nullable restore
#line 102 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                         Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                     \r\n                                </div>\r\n                                <div class=\"ttr-post-text capitalize\" style=\"font-family: \'open sans\',sans-serif;\">\r\n                                    <p > ");
#nullable restore
#line 106 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                    Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                        <div class=""courese-overview"" id=""overview"">
                            
                            <div class=""row"">
                                <div class=""col-md-12 col-lg-8"">
");
#nullable restore
#line 114 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                     foreach (var item in titre)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <h5 class=\"m-b5 capitalize\" style=\"font-family: \'Roboto\',sans-serif;text-transform:capitalize\"");
            BeginWriteAttribute("id", " id=\"", 6043, "\"", 6058, 1);
#nullable restore
#line 116 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
WriteAttributeValue("", 6048, item.Name, 6048, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 116 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3cd9dcda614ae2158765ce3d8d8feea8ecb9bac617736", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                      WriteLiteral(FileLocation.RetriveFileFromFolder);

#line default
#line hidden
#nullable disable
#nullable restore
#line 118 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                         WriteLiteral(item.ProfilePicture);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 118 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("                                        <p class=\"capitalize\" style=\"font-family: \'open sans\',sans-serif; margin-top:5px;\">");
#nullable restore
#line 120 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"
                                                                                                                      Write(item.Article_art);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 121 "C:\Users\Administrateur\OneDrive\Bureau\testtt\add status\E-LEARNING\Views\formations\Detail.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                              
                            </div>
                        </div>
                        

                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- contact area END -->

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<E_LEARNING.Models.formation> Html { get; private set; }
    }
}
#pragma warning restore 1591