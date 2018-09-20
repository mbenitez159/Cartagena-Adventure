using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formulario_form_hereda_iniciarSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void registrar(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox6.Text) && !string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text) && !string.IsNullOrEmpty(TextBox4.Text) && !string.IsNullOrEmpty(TextBox5.Text) && !string.IsNullOrEmpty(DropDownList1.Text) && !string.IsNullOrEmpty(TextBox7.Text) && !string.IsNullOrEmpty(TextBox8.Text))
	{
        if (!TextBox7.Text.Equals(TextBox8.Text))
        {
            Label10.Text = "Las contraseñas no coinciden";
            return;
        }

		         conexion c= new conexion();
        SqlCommand cm = new SqlCommand("insert into Usuario values('" + TextBox6.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + "," + TextBox5.Text + ",'" + DropDownList1.Text + "','" + TextBox7.Text + "')", c.AbrirConexion());
        cm.ExecuteNonQuery();
        Label10.Text = "¡Registro Exitoso!";
    }
        else
        {
            Label10.Text = "Diligencie todos los campos";
        }

    }
}