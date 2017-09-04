<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Class PartnerSettingsDTO

    Public Sub New()
        MyBase.New
    End Sub

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ApplicationName As String ' Partners Name
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ApplicationDescription As String ' a description of the partners Application
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ApplicationCopyright As String ' a copyright of the partners Application
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Website As String ' Website for Partners Application
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ContactNumber As String 'Contact Number for Partner
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ContactEmail As String ' Partner Email
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property SupportEmail As String ' Partner Support Email
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ImageUrl As String ' This is a larger image with we can use to display
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property ImageIconUrl As String 'This is a image which Song of Songs can use
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property TwitterURL As String 'Link to your twitter account
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property FaceBookUrl As String 'Link to your facebook account

End Class
