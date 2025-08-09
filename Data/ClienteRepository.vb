Imports System.Data.SqlClient

Public Class ClienteRepository

    Public Sub New()
        ' Constructor vacío
    End Sub
    Public Function GetClientes() As DataTable
        Dim dt As New DataTable()
        Dim connectionString As String = New DataBaseHelper()._connectionString
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT * FROM Clientes", connection)
            Using reader As SqlDataReader = command.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Function InsertarCliente(cliente As Cliente) As String
        Dim connectionString As String = New DataBaseHelper()._connectionString
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO Clientes (Nombre, Apellidos, Email, Telefono, Contrasena) VALUES (@Nombre, @Apellidos, @Email, @Telefono, @Contrasena)", connection)
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos)
            command.Parameters.AddWithValue("@Email", cliente.Email)
            command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            command.Parameters.AddWithValue("@Contrasena", cliente.Contrasena)
            command.ExecuteNonQuery()
        End Using
        Return "Cliente insertado correctamente."
    End Function

    Public Function ActualizarCliente(id As String, cliente As Cliente) As String
        Dim connectionString As String = New DataBaseHelper()._connectionString
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("UPDATE Clientes SET Nombre = @Nombre, Apellidos = @Apelidos,Email = @Email, Telefono = @Telefono, Contrasena = @Contrasena WHERE ClienteId = @ClienteId", connection)
            command.Parameters.AddWithValue("@ClienteId", id)
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            command.Parameters.AddWithValue("@Apelidos", cliente.Apellidos)
            command.Parameters.AddWithValue("@Email", cliente.Email)
            command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            command.Parameters.AddWithValue("@Contrasena", cliente.Contrasena)
            command.ExecuteNonQuery()
        End Using
        Return "Cliente actualizado correctamente."
    End Function

    Public Function EliminarCliente(idCliente As Integer) As String
        Dim connectionString As String = New DataBaseHelper()._connectionString
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("DELETE FROM Clientes WHERE ClienteId = @IdCliente", connection)
            command.Parameters.AddWithValue("@IdCliente", idCliente)
            command.ExecuteNonQuery()
        End Using
        Return "Cliente eliminado correctamente."
    End Function

    Public Function VerificarCredenciales(cliente As Cliente)
        Dim connectionString As String = New DataBaseHelper()._connectionString
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT  Email,Contrasena  FROM Clientes WHERE Email = @Email AND Contrasena = @Contrasena", connection)
            command.Parameters.AddWithValue("@Email", cliente.Email)
            command.Parameters.AddWithValue("@Contrasena", cliente.Contrasena)
            Dim reader As SqlDataReader = command.ExecuteReader()
            Return reader.HasRows
        End Using
    End Function
End Class
