﻿Imports System.Web.Http
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

        RouteTable.Routes.MapHttpRoute("Api_v1.0",
                                      "Api_v1/{controller}/devkey/{devkey}",
                                      defaults:=New With {.value = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v1.0_devkey",
                                      "Api_v1/{controller}/{value}/devkey/{devkey}",
                                      defaults:=New With {.value = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v1.0_Type_devkey",
                                      "Api_v1/{controller}/{typ}/{value}/devkey/{devkey}",
                                      defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v1.0_Type_devkey_uservotes",
                                      "Api_v1/{controller}/{typ}/{value}/{userid}/devkey/{devkey}",
                                      defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .userid = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v1.0_Type_devkey_add",
                                     "Api_v1/{controller}/{typ}/devkey/{devkey}/uid/{uid}/title/{title}/review/{review}/age/{age}/category/{category}",
                                     defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional,
                                                         .devkey = System.Web.Http.RouteParameter.Optional,
                                                         .uid = System.Web.Http.RouteParameter.Optional,
                                                         .title = System.Web.Http.RouteParameter.Optional,
                                                         .review = System.Web.Http.RouteParameter.Optional,
                                                         .age = System.Web.Http.RouteParameter.Optional,
                                                        .category = System.Web.Http.RouteParameter.Optional
                                                        })
        RouteTable.Routes.MapHttpRoute("Api_v1.0_Type_devkey_addhighscore",
                                     "Api_v1/{controller}/{typ}/devkey/{devkey}/QuizID/{QuizID}/Userid/{Userid}/ModuleID/{ModuleID}/AntalRatt/{AntalRatt}/Datum/{Datum}/Tid/{Tid}",
                                     defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional,
                                                        .devkey = System.Web.Http.RouteParameter.Optional,
                                                         .QuizID = System.Web.Http.RouteParameter.Optional,
                                                         .Userid = System.Web.Http.RouteParameter.Optional,
                                                        .ModuleID = System.Web.Http.RouteParameter.Optional,
                                                        .AntalRatt = System.Web.Http.RouteParameter.Optional,
                                                        .Datum = System.Web.Http.RouteParameter.Optional,
                                                        .Tid = System.Web.Http.RouteParameter.Optional
                                                        })

        RouteTable.Routes.MapHttpRoute("Api_v2.0",
                                      "Api_v2/{controller}_v2/",
                                      defaults:=New With {.value = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v2.0_Type_page_devkey",
                                      "Api_v2/{controller}/{typ}/{value}/page/{page}/devkey/{devkey}",
                                      defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .page = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v2.0_Type_devkey",
                                      "Api_v2/{controller}/{typ}/{value}/devkey/{devkey}",
                                      defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})
        RouteTable.Routes.MapHttpRoute("Api_v2.0_Type_advancedSearch",
                                   "Api_v2/{controller}/{typ}/page/{page}/devkey/{devkey}",
                                      defaults:=New With {.typ = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})


    End Sub
End Class
