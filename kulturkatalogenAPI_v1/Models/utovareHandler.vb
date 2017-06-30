Imports kulturkatalogenUtovare
Public Class utovareHandler
    Public Function getutovareautocompletelist(searchstr As String) As utovaredataInfo

        Dim retobj As New utovaredataInfo
        Dim utovareobj As New utovareMainController
        Try
            retobj.Utovarelist = utovareobj.getutovarebyautocomplete(searchstr)
            retobj.antalutovare = retobj.Utovarelist.Count
            retobj.Status = "autocomplete levererar för denna sökning: " & searchstr
        Catch ex As Exception
            retobj.Status = "Något blev fel vid autocomplete!"
        End Try
        Return retobj
    End Function


End Class
