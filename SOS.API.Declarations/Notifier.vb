
Imports System.ComponentModel

<Serializable, Runtime.Serialization.DataContractAttribute([Namespace]:="http://api.songofsongs.co.uk/")>
Public Class Notifier
    Implements INotifyPropertyChanged

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")>
    Protected Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
        If (Not (propertyChanged) Is Nothing) Then
            RaiseEvent propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class