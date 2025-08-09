Imports Microsoft.Ajax.Utilities

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected clientes As New ClienteRepository
    Protected Sub cargarClientes()
        Dim cliente As DataTable = clientes.GetClientes()
        grvDatos.DataSource = cliente
        grvDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarClientes()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If IDCliente.Value.IsNullOrWhiteSpace Then
            'Agregar
            Dim cliente As New Cliente() With {
                    .Nombre = TxtNombre.Text,
                    .Apellidos = TxtApellidos.Text,
                    .Email = txtEmail.Text,
                    .Telefono = Convert.ToInt32(txtTelefono.Text).ToString(),
                    .Contrasena = txtPass.Text
                }
            Dim resultado As String = clientes.InsertarCliente(cliente)
            lblError.Text = resultado
            cargarClientes()
        Else
            'Actualizar
            Dim cliente As New Cliente() With {
                    .Nombre = TxtNombre.Text,
                    .Apellidos = TxtApellidos.Text,
                    .Email = txtEmail.Text,
                    .Telefono = Convert.ToInt32(txtTelefono.Text).ToString()
                }
            Dim resultado As String = clientes.ActualizarCliente(IDCliente.Value, cliente)
            lblError.Text = resultado
            limpiarCampos()
            cargarClientes()
            IDCliente.Value = " "
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        limpiarCampos()
    End Sub

    Protected Sub limpiarCampos()
        TxtNombre.Text = String.Empty
        TxtApellidos.Text = String.Empty
        txtEmail.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtPass.Text = String.Empty
    End Sub

    Protected Sub grvDatos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index = grvDatos.SelectedIndex
        Dim ClienteID As Integer = Convert.ToInt32(grvDatos.SelectedDataKey.Value)

        If index >= 0 Then
            Dim row = grvDatos.Rows(index)
            Dim cliente As New Cliente() With {
                 .Nombre = row.Cells(3).Text,
                 .Apellidos = row.Cells(4).Text,
                 .Email = row.Cells(5).Text,
                 .Telefono = row.Cells(6).Text,
                 .Contrasena = row.Cells(7).Text
             }
            IDCliente.Value = row.Cells(2).Text
            TxtNombre.Text = cliente.Nombre
            TxtApellidos.Text = cliente.Apellidos
            txtEmail.Text = cliente.Email
            txtTelefono.Text = cliente.Telefono
            txtPass.Text = cliente.Contrasena

        End If
    End Sub

    Protected Sub grvDatos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim idCliente As Integer = Convert.ToInt32(grvDatos.DataKeys(e.RowIndex).Value)
        Dim resultado As String = clientes.EliminarCliente(idCliente)
        lblError.Text = resultado
        cargarClientes()
    End Sub
End Class