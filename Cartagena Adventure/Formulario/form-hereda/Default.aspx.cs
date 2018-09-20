using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_form_hereda_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.guiatodo.com.co/Sitio/cartagena/la_torre_del_reloj");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://espanol.pacinfra.com/portfolio/puerto-bahia/");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://contenido.homeaway.com.co/post/135449811381/playas-cartagena");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.colombia.travel/es/a-donde-ir/caribe/cartagena-de-indias/actividades/el-castillo-de-san-felipe");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.colombia.travel/es/a-donde-ir/caribe/cartagena-de-indias/actividades/muelle-de-los-pegasos");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.colombia.travel/es/a-donde-ir/caribe/cartagena-de-indias/actividades/fuerte-de-san-fernando-de-bocachica");
    }
}