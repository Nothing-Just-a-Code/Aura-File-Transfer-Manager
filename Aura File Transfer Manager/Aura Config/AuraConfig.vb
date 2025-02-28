Imports Newtonsoft.Json
Public Class AuraConfig
    <JsonProperty("RunAtStartup")> Public Property RunAtStartup As Boolean = True
    <JsonProperty("CheckForUpdate")> Public Property CheckForUpdateAtStartup As Boolean = True
    <JsonProperty("Theme")> Public Property Theme As String = "Blue Velvet"

    <JsonProperty("SaveTransferLogs")> Public Property SaveLogs As Boolean = True
    <JsonProperty("FirstRun")> Public Property IsFirstRun As Boolean = True

End Class
