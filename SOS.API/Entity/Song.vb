
'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class SOSServiceElement

    'this is the location of the Song of Songs XML files
    Private Const XMLSongsPath As String = "c:\songofsongs\data\SongLibrary\"

    Public Shared Function GetSong(songReferenceId As String) As API.Declarations.SongDTO
        Dim SOSServiceElement As SOSServiceElement = SOSServiceElement.GetData(New Guid(songReferenceId))
        Dim output As New API.Declarations.SongDTO
        With output
            .AltName = SOSServiceElement.AltElementName
            .Author = SOSServiceElement.Author
            .Bridge1 = SOSServiceElement.Bridge1
            .Bridge2 = SOSServiceElement.Bridge2
            .Bridge3 = SOSServiceElement.Bridge3
            .CCLI = SOSServiceElement.CCLI
            .Chorus1 = SOSServiceElement.Chorus1
            .Chorus2 = SOSServiceElement.Chorus2
            .Chorus3 = SOSServiceElement.Chorus3
            .Chorus4 = SOSServiceElement.Chorus4
            .Chorus5 = SOSServiceElement.Chorus5
            .Chorus6 = SOSServiceElement.Chorus6
            .Chorus7 = SOSServiceElement.Chorus7
            .Chorus8 = SOSServiceElement.Chorus8
            .Chorus9 = SOSServiceElement.Chorus9
            .Chorus10 = SOSServiceElement.Chorus10
            .CopyrightHolder = SOSServiceElement.CopyrightHolder
            .Ending = SOSServiceElement.Ending
            .LastEditBy = SOSServiceElement.LastEditBy
            .LastEdited = SOSServiceElement.LastEdited
            .Name = SOSServiceElement.ElementName
            .PreChorus1 = SOSServiceElement.PreChorus1
            .PreChorus2 = SOSServiceElement.PreChorus2
            .PreChorus3 = SOSServiceElement.PreChorus3
            .PropertyUniqueGuid = SOSServiceElement.PropertyUniqueGuid
            .SongReferenceId = SOSServiceElement.SongReferenceId
            .Song_OriginalKey = SOSServiceElement.Song_OriginalKey
            .Song_Tempo = SOSServiceElement.Song_Tempo
            .Song_TimeSignature = SOSServiceElement.Song_TimeSignature
            .Song_Topics = SOSServiceElement.Song_Topics
            .Tag1 = SOSServiceElement.Tag1
            .Tag2 = SOSServiceElement.Tag2
            .Tag3 = SOSServiceElement.Tag3
            .Verse1 = SOSServiceElement.Verse1
            .Verse2 = SOSServiceElement.Verse2
            .Verse3 = SOSServiceElement.Verse3
            .Verse4 = SOSServiceElement.Verse4
            .Verse5 = SOSServiceElement.Verse5
            .Verse6 = SOSServiceElement.Verse6
            .Verse7 = SOSServiceElement.Verse7
            .Verse8 = SOSServiceElement.Verse8
            .Verse9 = SOSServiceElement.Verse9
            .Verse10 = SOSServiceElement.Verse10
            .VerseOrder = SOSServiceElement.VerseOrder
            .Year = SOSServiceElement.Year
        End With
        Return output
    End Function

    Public Shared Function GetDataAllSongs() As List(Of SOS.API.Declarations.SongDTO)

        Dim result As New List(Of SOS.API.Declarations.SongDTO)

        Dim Output As SOSServiceElement = Nothing
        For Each fileItem In IO.Directory.GetFiles(XMLSongsPath)
            Try
                Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(SOSServiceElement))
                'Path to song XML Files 
                Using file As New System.IO.StreamReader(fileItem)
                    Output = DirectCast(reader.Deserialize(file), SOSServiceElement)
                End Using

                result.Add(New API.Declarations.SongDTO With {.Name = Output.ElementName,
                           .SongReferenceId = Output.PropertyUniqueGuid.ToString,
                           .PropertyUniqueGuid = Output.PropertyUniqueGuid,
                           .LastEdited = Output.LastEdited
                           })
            Catch
                'if not file is not found then return nothing, don't error as check 
                'if each file exist on large song library's has a hit, and most of the time
                'the file will exist and where it doesn't handled by BL
            End Try
        Next
        Return result
    End Function

    Private Shared Function GetData(ByVal propertyUniqueGuid As Guid) As SOSServiceElement
        If propertyUniqueGuid = Nothing Or propertyUniqueGuid = Guid.Empty Then Return Nothing
        Dim Output As SOSServiceElement = Nothing
        Try
            Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(SOSServiceElement))
            'Path to song XML Files 
            Using file As New System.IO.StreamReader(String.Format(XMLSongsPath & "{0}.xml", propertyUniqueGuid.ToString))
                Output = DirectCast(reader.Deserialize(file), SOSServiceElement)
            End Using
        Catch
            'if not file is not found then return nothing, don't error as check 
            'if each file exist on large song library's has a hit, and most of the time
            'the file will exist and where it doesn't handled by BL
        End Try
        Return Output
    End Function

    Public Property SongReferenceId As String
    Public Property PropertyUniqueGuid As Guid
    Public Property ElementName As String
    Public Property AltElementName As String
    Public Property LastEdited As DateTime
    Public Property LastEditBy As String

    Public Property CCLI As String
    Public Property Author As String
    Public Property CopyrightHolder As String
    Public Property Year As String
    Public Property VerseOrder As String

    Public Property Verse1 As String
    Public Property Verse2 As String
    Public Property Verse3 As String
    Public Property Verse4 As String
    Public Property Verse5 As String
    Public Property Verse6 As String
    Public Property Verse7 As String
    Public Property Verse8 As String
    Public Property Verse9 As String
    Public Property Verse10 As String
    Public Property Chorus1 As String
    Public Property Chorus2 As String
    Public Property Chorus3 As String
    Public Property Chorus4 As String
    Public Property Chorus5 As String
    Public Property Chorus6 As String
    Public Property Chorus7 As String
    Public Property Chorus8 As String
    Public Property Chorus9 As String
    Public Property Chorus10 As String
    Public Property Tag1 As String
    Public Property Tag2 As String
    Public Property Tag3 As String
    Public Property Bridge1 As String
    Public Property Bridge2 As String
    Public Property Bridge3 As String

    Public Property PreChorus1 As String
    Public Property PreChorus2 As String
    Public Property PreChorus3 As String

    Public Property Ending As String

    Public Property Song_Keywords As String
    Public Property Song_Topics As String
    Public Property Song_OriginalKey As String
    Public Property Song_Tempo As String
    Public Property Song_TimeSignature As String
End Class

