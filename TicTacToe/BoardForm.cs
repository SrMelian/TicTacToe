using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TicTacToe
{
    /// <summary>
    /// Clase donde sucede la partida, tablero.
    /// </summary>
    public partial class BoardForm : Form
    {
        /// <summary>
        /// Objeto de clase Game, que ejecuta la lógica del juego
        /// </summary>
        public Game Game1;

        /// <summary>
        /// Tabla de botones
        /// </summary>
        public Button[,] TableB;

        /// <summary>
        /// Constructor de la clase BoardForm
        /// </summary>
        public BoardForm()
        {
            InitializeComponent();
            TableB = new[,] {   { B00, B01, B02 } ,
                                { B10, B11, B12 } ,
                                { B20, B21, B22 }
                            };
        }

        /// <summary>
        /// Dibuja la ficha del jugador en el botón que ha seleccionado. A su vez llama a la función de dibujar la ficha de la máquina para que el movimiento sea automático.
        /// </summary>
        public void button_ClickX(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackgroundImage = Properties.Resources.x2;
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
            clickedButton.Enabled = false;

            Game1.WriteTable(clickedButton.Name, true);
            if (CheckEnd())
                return;

            Game1.MoveMachineBridge();
            button_ClickO(Game1.ObjectBridge.X, Game1.ObjectBridge.Y);
        }

        /// <summary>
        /// Método para dibujar la ficha de la máquina.
        /// </summary>
        /// <param name="x">Coordenada donde se va a dibujar la ficha</param>
        /// <param name="y">Coordenada donde se va a dibujar la ficha</param>
        public void button_ClickO(int x, int y)
        {
            Button chosenButton = TableB[x, y];
            chosenButton.BackgroundImage = Properties.Resources.o;
            chosenButton.BackgroundImageLayout = ImageLayout.Stretch;
            chosenButton.Enabled = false;

            Game1.WriteTable(chosenButton.Name, false);
            CheckEnd();
        }

        /// <summary>
        /// Carga del formulario con el tablero. Pregunta por el primer movimiento y lo ejecuta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Game1 = new Game();

            DialogResult turnResult = MessageBox.Show("¿Quieres mover primero?", "Primer movimiento", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            if (turnResult == DialogResult.No)
                button_ClickO(Game1.ObjectBridge.X, Game1.ObjectBridge.Y);
        }

        /// <summary>
        /// Método agrupador de las comprobaciones de finalización del juego y mensajes.
        /// </summary>
        private bool CheckEnd()
        {
            if (Game1.FullBoard())
            {
                MessageBox.Show("Han empatado.");

                Close();
                return(true);
            }
            Game1.CheckWin();
            if (Game1.ObjectBridge.WinPlayer)
            {
                MessageBox.Show("Has ganado.");

                Close();
                return(true);
            }
            else if (Game1.ObjectBridge.WinMachine)
            {
                MessageBox.Show("Has perdido.");

                Close();
                return(true);
            }
            return (false);
        }
    }
}
