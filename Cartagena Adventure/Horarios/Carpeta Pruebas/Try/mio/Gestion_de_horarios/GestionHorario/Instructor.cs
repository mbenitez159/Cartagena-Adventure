using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Ej_Interfaz_Proyecto.GestionHorario
{
    class Instructor
    {
        private string identificacion;
        private string nombre;
        private string direccion;
        private string telefono;
        private string celular;
        private string email;
        private string tipo;
        private string profesion;
        private string expcontrato;

        public string ExpContrato
        {
            set
            {
                this.expcontrato = value;
            }
            get
            {
                return expcontrato;
            }
        }
        public string Identificacion
        {
            set
            {
                this.identificacion = value;
            }
            get {
                return identificacion;
            }
        }

        public string Nombre
        {
            set
            {
                this.nombre = value;
            }
            get
            {
                return nombre;
            }
        }

        public string Direccion
        {
            set
            {
                this.direccion = value;
            }
        }

        public string Telefono
        {
            set
            {
                this.telefono = value;
            }
            get
            {
                return telefono;
            }
        }

        public string Celular
        {
            set
            {
                this.celular = value;
            }
            get
            {
                return celular;
            }
        }

        public string Email
        {
            set
            {
                this.email = value;
            }
            get
            {
                return email;
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

        public string Profesion
        {
            set
            {
                this.profesion = value;
            }
            get
            {
                return profesion;
            }
        }

    }
}
