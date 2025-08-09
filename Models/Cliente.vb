Public Class Cliente
    Inherits Persona
    Private _idCliente As Integer

    Public Sub New()
        MyBase.New()
        _idCliente = 0
    End Sub

    Public Property IdCliente As Integer
        Get
            Return _idCliente
        End Get
        Set(value As Integer)
            _idCliente = value
        End Set
    End Property
End Class