using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Formulario inicial que arranca el siguiente formulario.
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// Constructor de la clase, inicializa componentes del formulario
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clic en el botón de iniciar, arranca el siguiente formulario y lo pone en pantalla y operativo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            BoardForm boardScreen = new BoardForm();
            boardScreen.Show();
            boardScreen.Activate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hecho por Manuel Melián Hernández.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}