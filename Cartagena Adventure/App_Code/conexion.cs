using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de conexion
/// </summary>
public class conexion
{
    private string miCadena = "Data Source=.;Initial Catalog=cartagena;Integrated Security=True";
    private SqlConnection c;
	public conexion()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public SqlConnection AbrirConexion()
    {
     c = new SqlConnection(miCadena);
        c.Open();
        return c;
    }
    public void CerrarConexion()
    {
        c.Close();
    }
}