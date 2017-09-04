Imports System.ServiceModel
Imports SOS.API.Declarations

Public Class ErrorMethods


    Public Shared Function HandleException(ByVal exception As Exception) As ServiceModel.FaultException(Of SOSAPIException)


        Dim logReferance As Guid
        Dim innerException As Exception
        Try
            logReferance = New Guid ' Create a unique guid for the exception
            innerException = ObtainActualException(exception)


            Return ObtainFaultException(innerException, logReferance)
        Catch ex As Exception
            Return ObtainFaultException(ex, Guid.Empty)
        End Try

    End Function

    Private Shared Function ObtainFaultException(innerException As Exception, logReferance As Guid) As System.ServiceModel.FaultException(Of SOSAPIException)
        Try
            Return New System.ServiceModel.FaultException(Of SOSAPIException)(ObtainException(innerException, logReferance), innerException.Message)
        Catch ex As Exception
            'we have some database error,just return the message without GUID
            Return New System.ServiceModel.FaultException(Of SOSAPIException)(New SOSAPIException(ex.Message))
        End Try
    End Function

    Private Shared Function ObtainException(ByVal innerException As Exception, ByVal logReference As Guid) As SOSAPIException
        Dim fault As SOSAPIException

        Try
            fault = New SOSAPIException(innerException.Message, logReference)

            Return fault
        Catch ex As Exception
            'we have some database error,just return the message without GUID
            Return New SOSAPIException(ex.Message)
        End Try
    End Function


    Private Shared Function ObtainActualException(ByVal mainException As Exception) As Exception
        If mainException.InnerException IsNot Nothing Then
            Return ObtainActualException(mainException.InnerException)
        Else
            Return mainException
        End If
    End Function


End Class
