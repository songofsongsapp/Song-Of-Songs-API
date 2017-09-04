
' This is what makes up a Service Data Transfer Object to Song of Songs
<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Class ServiceDTO

    Public Sub New()
        MyBase.New
    End Sub


    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ServiceReferenceId As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ServiceTitle As String

    'When the Services was last updated
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property LastEdited As DateTime

    'Who edited the service last
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property LastEditedUser As String

    'When the Service Happens
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Datetime As DateTime
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property TypeOfService As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Leader As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Speaker As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property WorshipLeader As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property SoundTech As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ScreenTech As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property LightingTech As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property VideoTech As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CameraTech1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CameraTech2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CameraTech3 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CameraTech4 As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property WelcomeTeam As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Warden As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property WardenAssistant1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property WardenAssistant2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property RefreshmentTeam As String


    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Songs As Generic.List(Of SongDTO)
End Class