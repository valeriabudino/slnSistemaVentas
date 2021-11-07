<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="WebApp.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <h3>Vendedor</h3>

                <asp:Label ID="lblNombre" runat="server" Text="Nombre: "> </asp:Label><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblApellido" runat="server" Text="Apellido: "> </asp:Label><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblDNI" runat="server" Text="DNI: "></asp:Label> <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblComision" runat="server" Text="Comision: "> </asp:Label><asp:TextBox ID="txtComision" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblId" runat="server" Text="Id: "></asp:Label> <asp:TextBox ID="txtId" runat="server"></asp:TextBox><br />


                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                <asp:Button ID="TraerVendedoresId" runat="server" Text="Traer vendedores por id" OnClick="TraerVendedoresId_Click" />
                <asp:Button ID="TraerVendedoresComision" runat="server" Text="Traer vendedores por comision" OnClick="TraerVendedoresComision_Click" />
                <asp:Button ID="ModificarVendedor" runat="server" Text="Modificar" OnClick="ModificarVendedor_Click" />
                <asp:Button ID="EliminarVendedor" runat="server" Text="Eliminar" OnClick="EliminarVendedor_Click" />

                <asp:GridView ID="gridVendedor" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
