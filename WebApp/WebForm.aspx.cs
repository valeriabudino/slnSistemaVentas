using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos.Admin;
using Datos.Models;

namespace WebApp
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarVendedores();
        }

        protected void EliminarVendedor_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdminVendedor.Eliminar(id);
            if (filasAfectadas > 0)
            {
                mostrarVendedores();
            }
        }

        protected void TraerVendedoresId_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            gridVendedor.DataSource = AdminVendedor.TraerPorID(id);
            gridVendedor.DataBind();
        }

        protected void TraerVendedoresComision_Click(object sender, EventArgs e)
        {
            decimal comision = Convert.ToDecimal(txtComision.Text);
            gridVendedor.DataSource = AdminVendedor.TraerPorComision(comision);
            gridVendedor.DataBind();
        }

        protected void ModificarVendedor_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Id=Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text)

            };

            int filasAfectadas = AdminVendedor.Modificar(vendedor);

            if (filasAfectadas > 0)
            {
                mostrarVendedores();
            }
        }
        private void mostrarVendedores()
        {
            gridVendedor.DataSource = AdminVendedor.Listar();
            gridVendedor.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text)
            };
            int filasAfectadas = AdminVendedor.Insertar(vendedor);
            if (filasAfectadas > 0)
            {
                mostrarVendedores();
            }

        }
    }
}