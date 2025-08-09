<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Examen_II.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mb-3">
        <div class="col-md-4">

            <div class="form-group mb-3">
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="TxtApellido">Apellidos</label>
                <asp:TextBox ID="TxtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="txtEmail">Email</label>
                <asp:TextBox TextMode ="Email" ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="txtTelefono">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>

            <div class="form-group md-4">
                <asp:Button ID="btnCancelar" CssClass="btn btn-secundary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
    
        <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>

</asp:Content>
