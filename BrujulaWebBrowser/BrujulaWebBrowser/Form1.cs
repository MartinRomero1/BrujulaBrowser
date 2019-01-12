using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrujulaWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarPaginaWeb();
        }
        private void MostrarPaginaWeb() // funcion que muestra la web de la barra de dir
        {
            webBrowser1.Navigate(cmb_dir.Text);
            btn_ir.Enabled = false; //deshabilito boton ir y la barra de dir mientras carga
            cmb_dir.Enabled = false;
            StatusLabel1.Text = "Cargando";
            cmb_dir.Items.Add(cmb_dir.Text); // Agrega pagina mostrada a combobox 
            ProgressBar1.ProgressBar.Value = 0;
        }


        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programado por Martín Romero. Aún en desarrollo");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btn_ir.Enabled = true; // habilito boton ir y la barra de dir una vez que cargó
            cmb_dir.Enabled = true;
            StatusLabel1.Text = "Listo";
        }

        private void cmb_dir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== (char)ConsoleKey.Enter) //valida si la tecla presionada es Enter
            {
                MostrarPaginaWeb();
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0 && ProgressBar1.ProgressBar.Value <=100)
            {
                try
                {
                    ProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                }
                catch
                {
                    MessageBox.Show("error de progressbar pendiente");
                }
            }
        }
    }
}
