using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_maestra : System.Web.UI.MasterPage
{

   
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
             procesarConsulta pc = new procesarConsulta();
        if (string.IsNullOrEmpty(TextBox1.Text+"") || string.IsNullOrEmpty(Password1.Value+""))
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Diligencie todos los campos";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "cerrando", "open('fast')", true);
            TextBox1.Text = "";
            Password1.Value = "";
            return;
        }
        string respuesta = pc.ejecuta("exec IniciarSesion '" + TextBox1.Text + "', '" + Password1.Value + "'");
        if (respuesta.Equals("1"))//el usuario invalido
        {
            Label1.Text = "La identificación es Incorrecta";
            Label1.ForeColor = System.Drawing.Color.Red;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "cerrando", "open('fast')", true);
            TextBox1.Text = "";            
            return;
        }
        else if (respuesta.Equals("2"))//contraseña invalida
        {
            Label1.Text = "Contraseña Incorrecta";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "cerrando", "open('fast')", true);
            Label1.ForeColor = System.Drawing.Color.Red;            
            Password1.Value = "";
            return;
        }
        else//todo perfecto
        {            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "IniciarS", "iniciarsesion('"+pc.nombre+"')", true);
            Session["nombre"] = pc.nombre;
        }
        TextBox1.Text = "";
        Password1.Value = "";        
    }
    protected void Button1_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void SessionAbandon()
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "IniciarS", "cerrarSesion()", true);
        Session["nombre"] = "";
    }
    protected void Unnamed_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["nombre"]+""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "IniciarS", "iniciarsesion('" + Session["nombre"]+ "')", true);
        }        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        Session["nombre"] = "";
    }
}
