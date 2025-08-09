Public Class Persona
    Protected _nombre As String
    Protected _apellidos As String
    Protected _email As String
    Protected _telefono As String

    Public Sub New()
        _nombre = String.Empty
        _apellidos = String.Empty
        _email = String.Empty
        _telefono = String.Empty
    End Sub

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property Apellidos As String
        Get
            Return _apellidos
        End Get
        Set(value As String)
            _apellidos = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
End Class
