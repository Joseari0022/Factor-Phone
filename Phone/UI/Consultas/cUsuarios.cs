using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace Phone.Consultas
{
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
            LlenarCombo();
        }

        public List<Usuarios> Lista { get; set; }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            BuscarSelecCombo();
            ConsultaUsuariodataGridView.DataSource = Lista;
        }

        private void LlenarCombo()
        {
            FiltrarcomboBox.Items.Insert(0, "Todo");
            FiltrarcomboBox.Items.Insert(1, "IdUsuarios");
            FiltrarcomboBox.Items.Insert(2, "NombresUsuarios");
            FiltrarcomboBox.Items.Insert(3, "Nombres");
            FiltrarcomboBox.Items.Insert(4, "Contrasena");
            FiltrarcomboBox.DataSource = FiltrarcomboBox.Items;
            FiltrarcomboBox.DisplayMember = "Todo";

            if (FiltrarcomboBox.Items.Count >= 1)
            {
                FiltrarcomboBox.SelectedIndex = -1;
            }
        }

        private bool ValidarTex()
        {
            if (string.IsNullOrEmpty(FiltrotextBox.Text))
            {
                cUsuarioerrorProvider.SetError(FiltrotextBox, "Por favor llenar");
                return false;
            }

            return true;
        }

        private void BuscarSelecCombo()
        {
            int Busqueda = Utilidades.ToInt(FiltrotextBox.Text);
            if (FiltrarcomboBox.SelectedIndex == 0)
            {
                Lista = UsuariosBll.ListarTodo();
                FiltrotextBox.Enabled = true;
            }

            else if (FiltrarcomboBox.SelectedIndex == 1)
            {
                if (!ValidarTex())
                {
                    MessageBox.Show("Por favor llenar ");
                }
                else
                {
                    Lista = UsuariosBll.Listar(u => u.IdUsuarios == Busqueda);
                }
            }

            else if (FiltrarcomboBox.SelectedIndex == 2)
            {
                if (!ValidarTex())
                {
                    MessageBox.Show("Por favor llenar ");
                }
                else
                {
                    Lista = UsuariosBll.Listar(u => u.NombreUsuarios == FiltrotextBox.Text);
                }
            }

            else if (FiltrarcomboBox.SelectedIndex == 3)
            {
                if (!ValidarTex())
                {
                    MessageBox.Show("Por favor llenar ");
                }
                else
                {
                    Lista = UsuariosBll.Listar(u => u.Nombres == FiltrotextBox.Text);
                }
            }

            else if (FiltrarcomboBox.SelectedIndex == 4)
            {
                if (!ValidarTex())
                {
                    MessageBox.Show("Por favor llenar ");
                }
                else
                {
                    Lista = UsuariosBll.Listar(u => u.Contrasena == FiltrotextBox.Text);
                }
            }

            ConsultaUsuariodataGridView.DataSource = Lista;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
           // ReportesUsuarios ru = new ReportesUsuarios(Lista);
            //ru.Show();
        }
    }
}
