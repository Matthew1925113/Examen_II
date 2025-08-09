Public Class Cliente
    Inherits Persona
    Private _idCliente As Integer
    Private _contrasena As Integer


    Public Sub New()
        MyBase.New()
        _idCliente = 0
        _contrasena = 0
    End Sub

    Public Property IdCliente As Integer
        Get
            Return _idCliente
        End Get
        Set(value As Integer)
            _idCliente = value
        End Set
    End Property
    Public Property Contrasena As Integer
        Get
            Return _contrasena
        End Get
        Set(value As Integer)
            _contrasena = value
        End Set
    End Property
End Class