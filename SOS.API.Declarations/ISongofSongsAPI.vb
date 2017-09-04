Option Strict On
Option Explicit On
Imports System.ComponentModel


'<Brain Dump>

' Write a test/web application that will allow partners to test their API Implementations, and it will test expected out comes from API calls, including Exception messages.

' I would recommend having two API  endpoints, both will have to be publicly available, one each for live / development.

' Test the live endpoints before any release of Song of Songs.

' Each of these endpoints will be stored in Song of Songs DataApi which will be downloaded when the user loads Song of Songs, this will allow us to 
' dynamically update endpoint/add/remove partners etc, so we will not required a release of Song of Songs, and the users get the latest partners.

' I will create dashboard so that partners can change their endpoints & updating settings

' Other Ideas could work like periodic checking of partner API's and auto checking partner API's' --if i ever need to do it, * overkill

' Method to parse text file and create Song Class with valid verse, chorus bridge etc.... I've got some code with does this for CCLI files.

' </Brain Dump>


Public Interface ISongofSongsAPI
    'Interface for Methods required for Song of Songs API

    'Get the API Version being used
    Function APIVersion() As Integer

    'Get the type of Authentication the partner is using, we can then display the correct UI
    Function GetAuthenticationType() As AuthenticationType

    'Get the Partner Settings to we can display details about the system.
    Function GetPartnerSettings() As PartnerSettingsDTO

    'To allow the Partners to turn off song of songs connection while they are maintaining their system, upgrade, scheduled downtime etc.
    Function CheckSystemStatus() As SystemStatus

    'Check to see if the user is valid. i.e. correct user name & password
    Function IsUserValid(authToken As AuthTokenDTO) As Boolean

    'Get all the services within the valid dates, does not need to return all the song data, but could return songs with just the names, no lyric information.
    'We will use he GetSong Method to get the lyric information. This will mean that we can list services with songs contained, but the request won't be huge.
    Function GetServices(authToken As AuthTokenDTO,
                         startDate As DateTime, endDate As DateTime,
                         pageIndex As Integer, noOfRecords As Integer) As Collections.Generic.List(Of ServiceDTO)

    'Get the total count of services within the date range, used for paging.
    Function GetServicesTotalCount(authToken As AuthTokenDTO,
                         startDate As DateTime, endDate As DateTime) As Integer

    'Get all the service details including songs.
    Function GetServiceDetails(authToken As AuthTokenDTO, serviceReferenceId As String) As ServiceDTO

    'Get a selected song fro third party by its reference id
    Function GetSong(authToken As AuthTokenDTO, songReferenceId As String) As SongDTO

    'Update the song details
    Function UpdateSong(authToken As AuthTokenDTO, song As SongDTO) As Boolean

    'Get all songs from third party system that the user has stored
    Function GetAllSongs(authToken As AuthTokenDTO) As Collections.Generic.List(Of SongDTO)


    'Is CLLI integrated into API, if true we will search CCLI through the third party partner, else we won't.
    Function IsCcliIntergrated(authToken As AuthTokenDTO) As Boolean

    'Search for a song, this could be used for future with CCLI integration, only used if 'IsCcliIntergrated' is true
    Function SearchCCLISongs(authToken As AuthTokenDTO,
                         searchTerm As String, pageIndex As Integer, noOfRecords As Integer) As Collections.Generic.List(Of SongDTO)



End Interface




<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Enum SystemStatus
    <System.Runtime.Serialization.DataMemberAttribute()> Offline
    <System.Runtime.Serialization.DataMemberAttribute()> Online
End Enum

<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")> Public Enum AuthenticationType
    <System.Runtime.Serialization.DataMemberAttribute()> None
    <System.Runtime.Serialization.DataMemberAttribute()> ApiKey
    <System.Runtime.Serialization.DataMemberAttribute()> UserNamePassword


End Enum





