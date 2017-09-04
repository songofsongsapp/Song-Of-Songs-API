Imports System.Web.Services
Imports System.ComponentModel
Imports SOS.API.Declarations

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
'<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://api.songofsongs.co.uk/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class SongOfSongsAPIWebMethods
    Inherits System.Web.Services.WebService
    Implements SOS.API.Declarations.ISongofSongsAPI


#Region "Private Constants (test settings)"
    'Test Application Settings

    'we need to keep track of changes to API and will only support function partners with valid API. 
    Private Const t_APIVersion As Integer = 1 'Currently using version 1

    'Unique for each Partner API
    Private ApplicationGuid As New Guid("A5100EF8-B1D4-45D1-96DE-DDB5BE00531A") 'This is the demo guid. "A5100EF8-B1D4-45D1-96DE-DDB5BE00531A"

    'Type of Authentication
    Private Const t_AuthenticationType As AuthenticationType = AuthenticationType.UserNamePassword

    'test settings
    Private Const t_UserName As String = "demo"
    Private Const t_Password As String = "!demo!"
    Private Const t_UserAPIKey As String = "AnyStringYouWant"

    ' is the API On-line/off-line
    Private Const t_SystemStatus As SystemStatus = SystemStatus.Online

    Private Function t_settings() As PartnerSettingsDTO
        Dim settings As New PartnerSettingsDTO
        With settings
            .ApplicationName = "Song of Songs On-line Song Library"
            .ApplicationCopyright = "SOS On-line Song Library - Copyright 2017"
            .ApplicationDescription = "Access the On-line Song of Songs library."
            .ContactEmail = "support@songofsongs.co.uk"
            .ContactNumber = "+44 (0) 1582 807 239"
            .ImageIconUrl = "" 'need to upload a good Icon Image to Website
            .ImageUrl = "http://www.songofsongs.co.uk/wp-content/uploads/sites/3/2017/06/WebSiteLogo.png"
            .Website = "http://www.songofsongs.co.uk"
            .FaceBookUrl = "https://www.facebook.clom/songofsongsapp"
            .TwitterURL = "https://www.twitter.com/songofsongsapp"
        End With
        Return settings

    End Function

#End Region

#Region "Private Authentication Methods"
    Private Function IsApplicationValid(authToken As AuthTokenDTO) As Boolean
        'This to check that the service is connecting to the correct third party application.        
        Return authToken.ApplicationId = ApplicationGuid
    End Function

    Private Function IsAPIVersionValid(authToken As AuthTokenDTO) As Boolean
        'check the API version is valid.
        Return authToken.ApiVersion <= t_APIVersion
    End Function

    Private Function IsBanned(authToken As AuthTokenDTO) As Boolean
        'check the authToken and check everything including authToken.UniqueInstallaionId 
        'Maybe you have a selected list of users which can connect to Song of Songs or just an single installation of SOS
        'This is up to you, you might want to stop a selected user or client.
        Return False
    End Function

    Private Function CheckLogin(authToken As AuthTokenDTO) As Boolean
        Try
            'All Exceptions must be thrown from the Constants in SOS.API.Declarations.ExceptionMessages, this is so we can check expected responses, for exceptions.

            If IsAPIVersionValid(authToken) = False Then Throw New Exception(SOS.API.Declarations.ExceptionMessages.Invalid_API_Version)
            If IsApplicationValid(authToken) = False Then Throw New Exception(SOS.API.Declarations.ExceptionMessages.Invalid_Application_Id)
            If IsBanned(authToken) = True Then Throw New Exception(SOS.API.Declarations.ExceptionMessages.You_Have_Been_Banned)


            'Validate the Authentication Token
            'You only need to implement which AuthenticationType you are using, you don't need to do all types, this is just an example.
            Select Case t_AuthenticationType
                Case AuthenticationType.None
                    'this is for open system, i.e. partners that require no authentication. Could  be used for library's of songs which are public
                    Return True
                Case AuthenticationType.UserNamePassword

                    'this will hook into your authentication logic for user name & password
                    If authToken.UserName = t_UserName And authToken.Password = t_Password Then
                        Return True
                    Else
                        Throw New Exception(SOS.API.Declarations.ExceptionMessages.Invalid_Username_Or_Password)
                    End If
                Case AuthenticationType.ApiKey

                    ' If you want to just use a secret API for a user then just pass that as the user-name and valid on that
                    ' Throw a different exception so we know its just an API Authentication.
                    'Hook in to user API logic
                    If authToken.UserName = t_UserAPIKey Then
                        Return True
                    Else
                        Throw New Exception(SOS.API.Declarations.ExceptionMessages.Invalid_APIKey) 'different exception message constant
                    End If
            End Select

        Catch ex As Exception
            Throw ex
        End Try

        'should not get here
        Return False
    End Function

#End Region


    <WebMethod()> Public Function IsUserValid(authToken As AuthTokenDTO) As Boolean Implements ISongofSongsAPI.IsUserValid
        Try
            'Check to see if the login AuthTeken is valid
            Return CheckLogin(authToken)
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    <WebMethod()> Public Function GetServices(authToken As AuthTokenDTO, startDate As Date, endDate As Date, pageIndex As Integer, noOfRecords As Integer) As List(Of ServiceDTO) Implements ISongofSongsAPI.GetServices
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Get Services Logic

        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try

        Throw ErrorMethods.HandleException(New NotImplementedException)

    End Function

    <WebMethod()> Public Function GetServicesTotalCount(authToken As AuthTokenDTO, startDate As Date, endDate As Date) As Integer Implements ISongofSongsAPI.GetServicesTotalCount
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Get the Total number of services in range


        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try

        Throw ErrorMethods.HandleException(New NotImplementedException)
    End Function

    <WebMethod()> Public Function GetServiceDetails(authToken As AuthTokenDTO, serviceReferenceId As String) As ServiceDTO Implements ISongofSongsAPI.GetServiceDetails
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Get the service details for the Service ReferenceId

        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try


        Throw ErrorMethods.HandleException(New NotImplementedException)
    End Function

    <WebMethod()> Public Function GetSong(authToken As AuthTokenDTO, songReferenceId As String) As SongDTO Implements ISongofSongsAPI.GetSong
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Get the Song by Song Reference Id
            Return SOSServiceElement.GetSong(songReferenceId)
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    Public Function UpdateSong(authToken As AuthTokenDTO, song As SongDTO) As Boolean Implements ISongofSongsAPI.UpdateSong

        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Update the Song details in the system
            Return True
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    <WebMethod()> Public Function GetAllSongs(authToken As AuthTokenDTO) As List(Of SongDTO) Implements ISongofSongsAPI.GetAllSongs
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'Get a list of all songs in the system, the minimum we need is 
            'song name 
            'reference id, 
            'Last Edited date

            'we can look up songs data using another API method

            Return SOSServiceElement.GetDataAllSongs
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    <WebMethod()> Public Function IsCcliIntergrated(authToken As AuthTokenDTO) As Boolean Implements ISongofSongsAPI.IsCcliIntergrated
        Try
            CheckLogin(authToken)
            'This hasn't been Implemented yet as no partners have CCLI accounts'
            'for future use.
            Return False
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
        Return False
    End Function

    <WebMethod()> Public Function SearchCCLISongs(authToken As AuthTokenDTO, searchTerm As String, pageIndex As Integer, noOfRecords As Integer) As List(Of SongDTO) Implements ISongofSongsAPI.SearchCCLISongs
        Try
            'check authToen is valid
            CheckLogin(authToken)

            'This hasn't been Implemented yet as no partners have CCLI accounts'
            'for future use.
        Catch ex As Exception
            ErrorMethods.HandleException(ex)
        End Try
        Throw ErrorMethods.HandleException(New NotImplementedException)
    End Function


    <WebMethod()> Public Function APIVersion() As Integer Implements ISongofSongsAPI.APIVersion
        Try
            Return t_APIVersion
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    ' Which type of Authentication the partner is using
    <WebMethod()> Public Function GetAuthenticationType() As AuthenticationType Implements ISongofSongsAPI.GetAuthenticationType
        Try
            Return t_AuthenticationType
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    <WebMethod()> Public Function CheckSystemStatus() As SystemStatus Implements ISongofSongsAPI.CheckSystemStatus
        Try
            Return t_SystemStatus
        Catch ex As Exception
            Throw ErrorMethods.HandleException(ex)
        End Try
    End Function

    <WebMethod()> Public Function GetPartnerSettings() As PartnerSettingsDTO Implements ISongofSongsAPI.GetPartnerSettings
        Return t_settings()
    End Function


End Class

