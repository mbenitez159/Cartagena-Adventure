using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.GestionHorario
{
    class Competencias
    {

        private string codigo;
        private string descripcion;
        private string id_programa;
        private string duracion;
        private string trimestre;
        private string tipo;

        public string ID_Programa
        {
            set
            {
                this.id_programa = value;
            }
            get {
                return id_programa;
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
            get
            {
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
        public string Trimestre
        {
            set
            {
                this.trimestre = value;
            }
            get
            {
                return trimestre;
            }
        }
        public string Tipo
        {
            set
            {
                this.tipo = value;
            }
            get
            {
                return tipo;
            }
        }
    }
}
