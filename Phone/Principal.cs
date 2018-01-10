using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rUsuarios ru = new Registros.rUsuarios(); 
            ru.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cUsuarios cu = new Consultas.cUsuarios();
            cu.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rProductos rp = new UI.Registros.rProductos();
            rp.Show();    
        }
    }
}
