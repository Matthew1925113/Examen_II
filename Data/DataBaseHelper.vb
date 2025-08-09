Imports System.Data.SqlClient

Public Class DataBaseHelper
    Private ReadOnly _connectionString As String = ConfigurationManager.ConnectionStrings("ClientesDB").ConnectionString

    Public ReadOnly Property ConnectionString As String
        Get
            Return _connectionString
        End Get
    End Property

End Class
