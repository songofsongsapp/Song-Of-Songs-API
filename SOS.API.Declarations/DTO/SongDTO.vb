

'This is what makes up a Song Data Transfer Object to Song of Songs
<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Class SongDTO

    Public Sub New()
        MyBase.New
    End Sub

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property SongReferenceId As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property PropertyUniqueGuid As Guid
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Name As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property AltName As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property LastEdited As DateTime
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property LastEditBy As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CCLI As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Author As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property CopyrightHolder As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Year As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property VerseOrder As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse3 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse4 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse5 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse6 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse7 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse8 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse9 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Verse10 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus3 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus4 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus5 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus6 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus7 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus8 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus9 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Chorus10 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Tag1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Tag2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Tag3 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Bridge1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Bridge2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Bridge3 As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property PreChorus1 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property PreChorus2 As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property PreChorus3 As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Ending As String

    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Song_Keywords As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Song_Topics As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Song_OriginalKey As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Song_Tempo As String
    <System.Runtime.Serialization.DataMemberAttribute()> Public Property Song_TimeSignature As String


End Class
