
<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")>
Public Enum ErrorType As Integer
    <System.Runtime.Serialization.EnumMemberAttribute()> General = 0
    <System.Runtime.Serialization.EnumMemberAttribute()> InUse = 1
    <System.Runtime.Serialization.EnumMemberAttribute()> Security = 2
    <System.Runtime.Serialization.EnumMemberAttribute()> Concurrency = 3
End Enum

<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")>
Public Class SOSAPIException
    Inherits Notifier

    Public Sub New(ByVal message As String)
        MyBase.New()
        faultMessage = message
        Me.faultErrorType = ErrorType.General
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SOSAPIException" /> class.
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="referenceGUID">The reference GUID.</param>
    Public Sub New(ByVal message As String, ByVal referenceGUID As Guid)
        MyBase.New()
        faultReference = referenceGUID
        faultMessage = message
    End Sub

    Private faultMessage As String
    ''' <summary>
    ''' Gets or sets the message.
    ''' </summary>
    ''' <value>The message.</value>
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Message() As String
        Get
            Return faultMessage
        End Get
        Set(ByVal value As String)
            If (Object.ReferenceEquals(Me.faultMessage, value) <> True) Then
                Me.faultMessage = value
                Me.RaisePropertyChanged("Message")
            End If
        End Set
    End Property

    Private faultAction As String

    ''' <summary>
    ''' Gets or sets the action.
    ''' </summary>
    ''' <value>The action.</value>
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Action() As String
        Get
            Return faultAction
        End Get
        Set(ByVal value As String)
            If (Object.ReferenceEquals(Me.faultAction, value) <> True) Then
                Me.faultAction = value
                Me.RaisePropertyChanged("Action")
            End If
        End Set
    End Property


    Private faultReference As Guid
    ''' <summary>
    ''' Gets or sets the reference.
    ''' </summary>
    ''' <value>The reference.</value>
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property Reference() As Guid
        Get
            Return faultReference
        End Get
        Set(ByVal value As Guid)
            If (Me.faultReference.Equals(value) <> True) Then
                Me.faultReference = value
                Me.RaisePropertyChanged("Reference")
            End If
        End Set
    End Property


    Private faultErrorType As ErrorType

    ''' <summary>
    ''' Gets or sets the type of the error.
    ''' </summary>
    ''' <value>The type of the error.</value>
    <System.Runtime.Serialization.DataMemberAttribute()>
    Public Property ErrorType() As ErrorType
        Get
            Return faultErrorType
        End Get
        Set(ByVal value As ErrorType)
            If (Me.faultErrorType.Equals(value) <> True) Then
                Me.faultErrorType = value
                Me.RaisePropertyChanged("ErrorType")
            End If
        End Set
    End Property
End Class