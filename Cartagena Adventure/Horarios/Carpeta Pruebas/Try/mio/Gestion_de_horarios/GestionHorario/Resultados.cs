using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.GestionHorario
{
    class Resultados
    {

        private string codigo;
        private string descripcion;
        private string competencia;
        private string duracion;

        public string ID_Competencia
        {
            set
            {
                this.competencia = value;
            }
            get {
                return competencia;
            }
        }


        public string Codigo
        {
            set
            {             
                this.codigo = value;
            }
            get
            {
                return codigo;
            }
        }

        public string Descripcion
        {
            set
            {
                this.descripcion = value;
            }
            get {
                return descripcion;
            }
        }

        public string Duracion
        {
            set
            {
                this.duracion = value;
            }
            get
            {
                return duracion;
            }
        }

    }
}
