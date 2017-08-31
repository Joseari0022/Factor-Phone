using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace Phone.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Utilidades.ToInt(IdtextBox.Text);
            Usuarios usuario = UsuariosBll.Buscar(u => u.IdUsuarios == id);
            if (usuario != null)
            {
                NombreUsuariotextBox.Text = usuario.NombreUsuarios;
                NombretextBox.Text = usuario.Nombres;
                ContrasenatextBox.Text = ConfirmarContrasenatextBox.Text = usuario.Contrasena;
            }
            else
            {
                MessageBox.Show("No existe!!!");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdtextBox.Clear();
            NombreUsuariotextBox.Clear();
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            ConfirmarContrasenatextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = null;
            if (!Validar())
            {
                MessageBox.Show("LLenar campos por favor");
            }
            else if (ContrasenatextBox.Text.Equals(ConfirmarContrasenatextBox.Text))
            {
                usuario = Llenar();
                if (UsuariosBll.Guardar(usuario))
                    MessageBox.Show("Guardado con exito!!!");
                else
                    MessageBox.Show("No guardado!!!");
            }
            else
            {
                UsuarioerrorProvider.SetError(ContrasenatextBox, "La contraseña no coinciden");
                UsuarioerrorProvider.SetError(ConfirmarContrasenatextBox, "La contraseña no coinciden");
                ContrasenatextBox.Clear();
                ConfirmarContrasenatextBox.Clear();
            }
            Limpiar();
        }

        private Usuarios Llenar()
        {
            Usuarios usuario = new Usuarios();
            usuario.NombreUsuarios = NombreUsuariotextBox.Text;
            usuario.Nombres = NombretextBox.Text;
            usuario.Contrasena = ContrasenatextBox.Text;
            return usuario;
        }

        private bool Validar()
        {
            bool cambio = true;
            if ((string.IsNullOrEmpty(NombreUsuariotextBox.Text)) || (string.IsNullOrEmpty(NombretextBox.Text)) || (string.IsNullOrEmpty(ContrasenatextBox.Text)) || (string.IsNullOrEmpty(ConfirmarContrasenatextBox.Text)))
            {
                UsuarioerrorProvider.SetError(NombreUsuariotextBox, "Ingrese el nombre de usuario");
                UsuarioerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                UsuarioerrorProvider.SetError(ContrasenatextBox, "Ingrese la contraseña");
                UsuarioerrorProvider.SetError(ConfirmarContrasenatextBox, "Ingrese la contraseña correcta");
                cambio = false;
            }
            return cambio;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Utilidades.ToInt(IdtextBox.Text);
            Usuarios usuario = UsuariosBll.Buscar(u => u.IdUsuarios == id);
            if (usuario != null)
            {
                if (UsuariosBll.Eliminar(usuario))
                    MessageBox.Show("Usuario eliminado!!!");
                else
                    MessageBox.Show("Usuario no eliminado!!!");
            }
            else
                MessageBox.Show("Usuario no existente!!!");
            Limpiar();
        }
    }
}
