using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Formulario_form_hereda_BusquedaH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "select h.nombre, h.imagenPortada as ImgPH, h.imagen1 as Img1H,ha.imagenPortada as ImgHA1, ha.imagen1 as ImgHA2,ha.codigo,ha.numeroAdultos,ha.numeroNiños,ha.camasDobles,cast(ha.precio as float)as precio ,cast( (ha.precio*0.16)as float) as Imp, cast(((ha.precio*1.16)+10000)as float) as total from HOTEL h, habitacion ha where h.codigo=ha.codigoHotel and ha.numeroAdultos=" + Session["adultos"] + " and ha.numeroNiños=" + Session["menores"] + "";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conexion c = new conexion();
        if (!string.IsNullOrEmpty(Session["nombre"]+""))
        {
            SqlCommand cm = new SqlCommand("insert into regstro ("+1+",'"+Session["entrada"]+"','"+Session["salida"]+"')",c.AbrirConexion());
            cm.ExecuteNonQuery();
            Label1.Text = "Registro exitoso";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "alert('Debe Iniciar sesión')", true); 
        }
    }
    protected void labelInfo_Load(object sender, EventArgs e)
    {
        
        if (Repeater1.Items.Count < 1)
        {
            
        }
    }
}