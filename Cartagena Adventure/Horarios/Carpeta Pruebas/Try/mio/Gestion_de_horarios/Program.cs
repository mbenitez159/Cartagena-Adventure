using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ej_Interfaz_Proyecto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Formularios_1280x1024.FrmPrincipal_1280x1024());
           //Application.Run(new GestionHorario.GenerarHorario());
            //Application.Run(new Formularios_1280x1024.FrmGenerarHorario_1280x1024(null));
        }
    }
}
