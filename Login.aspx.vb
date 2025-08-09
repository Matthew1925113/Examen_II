Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Function VerificarCredenciales(cliente As Cliente) As Boolean
        Dim clientes As New Cliente() With {
            .Email = txtEmail.Text,
            .Contrasena = txtPass.Text
        }

        Dim clienteRepo As New ClienteRepository()
        Return clienteRepo.VerificarCredenciales(clientes)
    End Function

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim cliente As New Cliente() With {
            .Email = txtEmail.Text,
            .Contrasena = txtPass.Text
        }

        If VerificarCredenciales(cliente) Then
            Response.Redirect("Clientes.aspx")
        Else
            lblError.Text = "Credenciales inválidas"
            lblError.Visible = True
        End If
    End Sub
End Class