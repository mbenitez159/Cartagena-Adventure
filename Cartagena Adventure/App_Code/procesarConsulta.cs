using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for procesarConsulta
/// </summary>
public class procesarConsulta
{
    conexion c = new conexion();
	public  procesarConsulta()
	{

    
    }
    public string nombre = "";
    public string ejecuta(string query)
    {       
        string devuelt = "";
        SqlCommand cm = new SqlCommand(query,c.AbrirConexion());
        SqlDataReader dr = cm.ExecuteReader();
        while (dr.Read())
        {
            devuelt = dr[0].ToString();
            nombre = dr[1].ToString();
        }
        c.CerrarConexion();
        return devuelt;
    }
}