#pragma checksum "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "679ac2a28878532c688fec2469d39629b42b4bd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_DetailsVehiculo), @"mvc.1.0.view", @"/Views/Usuarios/DetailsVehiculo.cshtml")]
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
#line 1 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\_ViewImports.cshtml"
using Taller_Mecanico.API;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\_ViewImports.cshtml"
using Taller_Mecanico.API.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"679ac2a28878532c688fec2469d39629b42b4bd6", @"/Views/Usuarios/DetailsVehiculo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c53d007af3dfddc1710a31d314c7da043324949", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_DetailsVehiculo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Taller_Mecanico.API.Data.Entities.Vehiculo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddHistoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditVehiculo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditHistoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailsHistoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DeleteDialog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css"" />
<h2>Historia</h2>

<div>
    <h4>Vehiculo</h4>
    <hr />
    <div class=""row"">
        <div class=""col-md-8"">
            <dl class=""row"">
                <dt class=""col-sm-3"">
                    ");
#nullable restore
#line 16 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.TipoVehiculo.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 19 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.TipoVehiculo.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 22 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.Marca.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.Marca.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 28 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 31 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 34 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 37 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 40 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.Linea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 43 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.Linea));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayNameFor(model => model.Observaciones));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-9\">\r\n                    ");
#nullable restore
#line 49 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
               Write(Html.DisplayFor(model => model.Observaciones));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1994, "\"", 2020, 1);
#nullable restore
#line 54 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
WriteAttributeValue("", 2000, Model.ImageFullPath, 2000, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 200px; height: 200px; max-width: 100%; height: auto;\" />\r\n        </div>\r\n    </div>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679ac2a28878532c688fec2469d39629b42b4bd612498", async() => {
                WriteLiteral("Adicionar Historia");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                                  WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679ac2a28878532c688fec2469d39629b42b4bd614782", async() => {
                WriteLiteral("Editar Vehículo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679ac2a28878532c688fec2469d39629b42b4bd617064", async() => {
                WriteLiteral("Regresar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                              WriteLiteral(Model.Usuario.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<br />

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">Historias</h3>
            </div>
            <div class=""panel-body"">
                <table class=""table table-hover table-responsive table-striped"" id=""MyTable"">
                    <thead>
                        <tr>
                            <th>
                                ");
#nullable restore
#line 76 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().FechaLocal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 79 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().Usuario.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 82 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().Kilometraje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 85 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().Obesersacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 88 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().DetallesCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 91 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().TotalLabor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 94 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().TotalRepuestos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 97 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                           Write(Html.DisplayNameFor(model => model.Historias.FirstOrDefault().Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 103 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                         foreach (var item in Model.Historias)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 107 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FechaLocal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 110 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Usuario.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 113 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Kilometraje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 116 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Obesersacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 119 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.DetallesCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 122 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.TotalLabor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 125 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.TotalRepuestos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 128 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679ac2a28878532c688fec2469d39629b42b4bd627487", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679ac2a28878532c688fec2469d39629b42b4bd629824", async() => {
                WriteLiteral("Detalle<i class=\"glyphicon glyphicon-align-justify\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 132 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <button data-id=\"");
#nullable restore
#line 133 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                                                Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-danger deleteItem\" data-toggle=\"modal\" data-target=\"#deleteDialog\">Borrar</button>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 136 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "679ac2a28878532c688fec2469d39629b42b4bd633106", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 147 "C:\Users\PERSONAL\source\repos\Proyectos2021\Taller_Mecanico\Taller_Mecanico.API\Views\Usuarios\DetailsVehiculo.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script src=""//cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js""></script>
    <script src=""/js/deleteDialog.js""></script>

    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#MyTable').DataTable({
                ""language"": {
                    ""url"": ""//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json""
                },
                ""aLengthMenu"": [
                    [25, 50, 100, 200, -1],
                    [25, 50, 100, 200, ""Todos""]
                ],
                ""order"": [[0, ""desc""]]
            });
            // Delete item
            sc_deleteDialog.openModal('deleteItem', true, 'btnYesDelete', '/Usuarios/DeleteHistoria/', false);
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Taller_Mecanico.API.Data.Entities.Vehiculo> Html { get; private set; }
    }
}
#pragma warning restore 1591
