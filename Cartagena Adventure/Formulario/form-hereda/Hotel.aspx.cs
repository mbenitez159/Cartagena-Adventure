using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Formulario_form_hereda_Hotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        for (int i = 1; i < 5; i++)
        {
            DropDownList1.Items.Add("" + i);
        } 
        for (int i = 0; i < 4; i++)
        {
            DropDownList2.Items.Add("" + i);
        }      
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = true;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "anadir('Ali')", true);

    }
    protected void Calendar1_Load(object sender, EventArgs e)
    {
       
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Calendar1.SelectedDate.ToString().Substring(0,10)) <DateTime.Today)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "alert('La fecha no puede ser menor a la fecha actual')", true); TextBox1.Text = "";
        }
        else
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString().Substring(0, 10);
        }        
        Calendar1.Visible = false;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(TextBox1.Text)>Calendar2.SelectedDate)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "alert('La fecha es superior a la selecionada en la fecha de partida')", true);TextBox2.Text = "";
        }else
	    {
            TextBox2.Text = Calendar2.SelectedDate.ToString().Substring(0, 10);
            Calendar2.Visible = false;
	    }
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox1.Text))
        {

                            Calendar2.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "anadir(Ali)", true);
            


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Información", "alert('Selecione la fecha de entrada')", true);
        }
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox1.Text + "") && !string.IsNullOrEmpty(TextBox2.Text + "")  && !string.IsNullOrEmpty(DropDownList1.Text+"")&& !string.IsNullOrEmpty(DropDownList2.Text+""))
        {
        Session["entrada"] = TextBox1.Text;
        Session["salida"] = TextBox2.Text;
        Session["valida"] = false;
        Session["adultos"] = DropDownList1.Text;
        Session["menores"] = DropDownList2.Text;
        
        Response.Redirect("../form-hereda/BusquedaH.aspx");
        }

       
    }
}