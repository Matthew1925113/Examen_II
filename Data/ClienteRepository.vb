Imports System.Data.SqlClient

Public Class ClienteRepository
    Dim connectionString As String = New DataBaseHelper().ConnectionString

    Public Function GetClientes() As List(Of Cliente)
        Dim clientes As New List(Of Cliente)()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("SELECT * FROM Clientes", connection)
            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim cliente As New Cliente()
                    cliente.IdCliente = reader("ClienteId")
                    cliente.Nombre = reader("Nombre")
                    cliente.Email = reader("Email")
                    cliente.Telefono = reader("Telefono")
                    cliente.Contrasena = reader("Contrasena")
                    clientes.Add(cliente)
                End While
            End Using
        End Using
        Return clientes
    End Function

    Public Sub InsertarCliente(cliente As Cliente)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)", connection)
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            command.Parameters.AddWithValue("@Email", cliente.Email)
            command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub ActualizarCliente(cliente As Cliente)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("UPDATE Clientes SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE IdCliente = @IdCliente", connection)
            command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente)
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            command.Parameters.AddWithValue("@Email", cliente.Email)
            command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub EliminarCliente(idCliente As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("DELETE FROM Clientes WHERE IdCliente = @IdCliente", connection)
            command.Parameters.AddWithValue("@IdCliente", idCliente)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function VerificarCredenciales(cliente As Cliente) As Boolean
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
