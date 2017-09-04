

'This is Authentication Data Transfer Object Token 
<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Class AuthTokenDTO
    'username as string  - User name/email of the user your logging in as or Users API Key
    'password as string - Password for the above user, to validate the user has permission
    'UniqueInstallationId as Guid - unique Guid for each installation, to help you monitor where requests as coming from
    'ApplicationId as Guid - Each partner will be given a Guid.

    Public Sub New()
        MyBase.New
    End Sub

    ' This is the User name, or User API Key.
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property UserName As String
    ' This is the Password
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Password As String
    'This is the Third Party's Application Guid, Given by SongOfSongs.
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ApplicationId As Guid
    'Currently Version 1
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ApiVersion As Integer = 1
    'This is a guid for each installation of Song of Songs
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property UniqueInstallationId As Guid

End Class