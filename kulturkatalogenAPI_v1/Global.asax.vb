Imports System.Web.Http
Imports System.Web.Http.Cors
Imports System.Web.Routing
Imports System.Web.SessionState
Imports WebApiContrib.Formatting.Jsonp

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Att tänka på är att man inte ska skicka med ?callback=? i anropet för då returneras: /**/ typeof Test === 'function' && 
        GlobalConfiguration.Configuration.AddJsonpFormatter()
        'System.Web.Mvc.AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configuration.EnableCors()

        ' ''Använd denna för att alltid köra json lite skum formatering dock-------------------------------------------------
        'Dim json = GlobalConfiguration.Configuration.Formatters.JsonFormatter
        'json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
        'GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter)

        'Använd denna för att få json response men måste då skicka med ?type=json i urlen-------------------------------------------------
        GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
           New System.Net.Http.Formatting.QueryStringMapping("type", "json", New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")))


        'Använd denna för att få XML response men måste då skicka med ?type=xml i urlen-------------------------------------------------
        'GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
        '    New System.Net.Http.Formatting.QueryStringMapping("type", "xml", New System.Net.Http.Headers.MediaTypeHeaderValue("application/xml")))

        RouteTable.Routes.MapHttpRoute("Api_v2.0",
                                      "Api_v2/{controller}_v2/",
                                      defaults:=New With {.value = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Type_page_devkey",
                                      "Api_v2/{controller}/{cmd}/id/{id}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .id = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_updateparam_devkey",
                                      "Api_v2/{controller}/{cmd}/id/{id}/uid/{uid}/val/{val}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .id = System.Web.Http.RouteParameter.Optional, .uid = System.Web.Http.RouteParameter.Optional, .val = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})


        RouteTable.Routes.MapHttpRoute("Api_v2.0_arrangemangslist_devkey",
                                      "Api_v2/{controller}/{cmd}/uid/{uid}/typ/{arrstatus}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .uid = System.Web.Http.RouteParameter.Optional, .arrstatus = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_arrangemangssearch_devkey",
                                      "Api_v2/{controller}/{cmd}/uid/{uid}/typ/{arrstatus}/val/{val}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .uid = System.Web.Http.RouteParameter.Optional, .arrstatus = System.Web.Http.RouteParameter.Optional, .val = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Log_crud_devkey",
                                      "Api_v2/{controller}/add/devkey/{devkey}",
                                      defaults:=New With {.devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Log_crudDel_devkey",
                                      "Api_v2/{controller}/{userid}/del/{arrid}/devkey/{devkey}",
                                      defaults:=New With {.userid = System.Web.Http.RouteParameter.Optional, .arrid = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Log_crudAddDel_devkey",
                                      "Api_v2/{controller}/{cmd}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Type_utovare_devkey",
                                      "Api/{controller}/{cmd}/val/{val}/devkey/{devkey}",
                                      defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .val = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v2.0_UPLOAD",
                                      "Api/{controller}/devkey/{devkey}",
                                      defaults:=New With {.devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_UPLOAD233",
                                     "Api/{controller}/t/{japp}/devkey/{devkey}",
                                     defaults:=New With {.japp = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v3.0_Type_utovare_devkey",
                                     "Api_v3/{controller}/{cmd}/val/{val}/devkey/{devkey}",
                                     defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .val = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v3.0_Type_utovarelistning_devkey",
                                     "Api_v3/{controller}/{cmd}/user/{usr}/val/{val}/devkey/{devkey}",
                                     defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .usr = System.Web.Http.RouteParameter.Optional, .val = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v3.0_Type_utovaredelete_devkey",
                                     "Api_v3/{controller}/{cmd}/user/{usr}/devkey/{devkey}",
                                     defaults:=New With {.cmd = System.Web.Http.RouteParameter.Optional, .usr = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

    End Sub
End Class
