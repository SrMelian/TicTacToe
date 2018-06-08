using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TicTacToe
{
    /// <summary>
    /// Clase con la lógica del juego
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Tipo de dato que hará de comunicador entre la clase Game y la clase del formulario BoardForm
        /// </summary>
        public struct Bridge
        {
            /// <summary>
            /// Valor de X en la tabla para asignar ficha
            /// </summary>
            public int X;

            /// <summary>
            /// Valor de Y en la tabla para asignar ficha
            /// </summary>
            public int Y;

            /// <summary>
            /// Variable contenedor de victoria de jugador. True si el jugador ha ganado
            /// </summary>
            public bool WinPlayer;

            /// <summary>
            /// Variable contenedor de victoria de la máquina. True si la máquina ha ganado
            /// </summary>
            public bool WinMachine;
        }


        /// <summary>
        /// Objeto de la clase Bridge que hace de conexión entre la clase formulario BoardForm, y la clase Game
        /// </summary>
        public Bridge ObjectBridge;

        /// <summary>
        /// Tabla con las posiciones del tablero, y jugadas temporales.
        /// </summary>
        private char[,] _tableBoard = new char[3, 3];

        /// <summary>
        /// Constructor de la clase Game
        /// </summary>
        public Game()
        {
            InitializeTable();
            //Primer movimiento, en caso de ser la máquina, será en el centro
            ObjectBridge.X = 1;
            ObjectBridge.Y = 1;
            ObjectBridge.WinMachine = false;
            ObjectBridge.WinPlayer = false;
        }

        /// <summary>
        /// Inicializamos la tabla de tablero de tipo caractéres de juego, con guiones
        /// </summary>
        private void InitializeTable()
        {
            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                for (int j = 0; j <= _tableBoard.Rank; j++)
                    _tableBoard[i, j] = '-';
            }
        }

        /// <summary>
        /// Escribe en la tabla de char, la llamamos cuando mueva el jugador o la máquina
        /// </summary>
        /// <param name="pos">Posición extraída de propiedad Name del botón</param>
        /// <param name="token">Falso si es un O, y verdadero si es un X</param>
        public void WriteTable(string pos, bool token)
        {
            int x = Convert.ToInt32(pos.Substring(1, 1));
            int y = Convert.ToInt32(pos.Substring(2, 1));

            if (token)
                _tableBoard[x, y] = 'x';
            else
                _tableBoard[x, y] = 'o';
        }

        /// <summary>
        /// Comprueba si alguno de los jugadores gana.
        /// </summary>
        /// <returns>0 si gana máquina, 1 si gana jugador, -1 si aún no hay jugada ganadora</returns>
        public int CheckWin()
        {
            // Diagonal "\"
            if (_tableBoard[0, 0] == _tableBoard[1, 1] &&
                _tableBoard[0, 0] == _tableBoard[2, 2] &&
                _tableBoard[0, 0] == 'x')
            {
                ObjectBridge.WinPlayer = true;
                return (1);
            }
            if (_tableBoard[0, 0] == _tableBoard[1, 1] &&
                _tableBoard[0, 0] == _tableBoard[2, 2] &&
                _tableBoard[0, 0] == 'o')
            {
                ObjectBridge.WinMachine = true;
                return (0);
            }

            //Diagonal "/"
            if (_tableBoard[2, 0] == _tableBoard[1, 1] &&
                _tableBoard[2, 0] == _tableBoard[0, 2] &&
                _tableBoard[2, 0] == 'x')
            {
                ObjectBridge.WinPlayer = true;
                return (1);
            }
            if (_tableBoard[2, 0] == _tableBoard[1, 1] &&
                _tableBoard[2, 0] == _tableBoard[0, 2] &&
                _tableBoard[2, 0] == 'o')
            {
                ObjectBridge.WinMachine = true;
                return (0);
            }

            //Horizontal
            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                int contx = 0;
                int conto = 0;

                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[j, i] == 'x')
                    {
                        contx++;
                    }
                    else if (_tableBoard[j, i] == 'o')
                    {
                        conto++;
                    }
                    if (contx == 3)
                    {
                        ObjectBridge.WinPlayer = true;
                        return (1);
                    }
                    if (conto == 3)
                    {
                        ObjectBridge.WinMachine = true;
                        return (0);
                    }
                }
            }

            //Vertical
            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                int contx = 0;
                int conto = 0;

                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[i, j] == 'x')
                    {
                        contx++;
                    }
                    else if (_tableBoard[i, j] == 'o')
                    {
                        conto++;
                    }
                    if (contx == 3)
                    {
                        ObjectBridge.WinPlayer = true;
                        return (1);
                    }
                    if (conto == 3)
                    {
                        ObjectBridge.WinMachine = true;
                        return (0);
                    }
                }
            }
            return (-1);
        }

        /// <summary>
        /// Método que nos dice si el tablero está lleno, llamando este método junto a CheckWin, obtendremos por descarte la opción de empate
        /// </summary>
        /// <returns>Falso si el tablero tiene huecos vacíos, true si el tablero está lleno</returns>
        public bool FullBoard()
        {
            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[i, j] == '-')
                        return (false);
                }
            }
            return (true);
        }

        /// <summary>
        /// Método conjuno de finalización para la comprobación ficticia del minimax
        /// </summary>
        /// <returns>Devuelve true si el tablero está lleno o si alguno de los jugadores ha ganado</returns>
        private bool EndMatch()
        {
            return (FullBoard() || CheckWin() != -1);
        }

        /// <summary>
        /// Cerebro que decide el movimiento de máquina.
        ///  Lo que hacemos es recorrer todas las celdas del tablero, y si no están marcadas, las marcamos, y a continuación hacemos la primera llamada recursiva al método MIN del algoritmo minimax. Esta función nos devolverá el valor del nodo hoja mas alto que ha encontrado el algoritmo minimax al ejecutarse partiendo de que la CPU ha marcado esa casilla concreta. Si ese resultado es mejor que el que llevamos almacenado hasta el momento, almacenamos la casilla que habíamos marcado. Antes de probar con otra casilla, hay que desmarcarla porque estamos modificando las casillas del tablero del juego para generar el árbol de soluciones y queremos dejarlo en su estado original.
        /// </summary>
        /// <returns>Retorna el objeto de clase Bridge con la jugada lista para que la máquina la ejecute</returns>
        public Bridge MoveMachineBridge()
        {
            //Variables para almacenar posiciones y valor, más óptimo para la máquina o más pejudicial para el jugador
            int x = 0; //Posición x de la tabla
            int y = 0; //Posición y de la tabla
            int v = Int32.MinValue; 
            int aux;

            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[i, j] == '-')
                    {
                        _tableBoard[i, j] = 'o';
                        aux = Min();
                        if (aux > v)
                        {
                            v = aux;
                            x = i;
                            y = j;
                        }
                        _tableBoard[i, j] = '-';
                    }
                }
            }

            ObjectBridge.X = x;
            ObjectBridge.Y = y;
            return (ObjectBridge);
        }

        /// <summary>
        /// El método MAX es idéntico, salvo que esta vez el último jugador que marcó alguna casilla fue la CPU, asi que comprobamos si ha ganado o empatado la partida. Después recorremos como siempre las casillas del tablero buscando las vacías. Y que esta vez estamos simulando ser la CPU, por lo que buscaremos el nodo hoja con el valor más alto (1, que indica victoria).
        /// </summary>
        /// <returns>Devolverá el valor máximo de todas las llamadas</returns>
        private int Max()
        {
            if (EndMatch())
                if (CheckWin() != -1)
                {
                    ObjectBridge.WinPlayer = false;
                    return (-1);
                }
                else
                    return (0);

            int v = Int32.MinValue;
            int aux;

            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[i, j] == '-')
                    {
                        _tableBoard[i, j] = 'o';
                        aux = Min();
                        if (aux > v)
                            v = aux;
                        _tableBoard[i, j] = '-';
                    }
                }
            }
            return (v);
        }

        /// <summary>
        /// Este algoritmo es el encargado de simular el turno del jugador humano, y lo que nos interesa es minimizar su resultado, es decir, que no gane o por lo menos que empate la partida.
        /// Sabemos que cuando se llame este algoritmo, el último jugador en marcar el tablero fue la CPU, asi que comprobamos si ha ganado o empatado el juego. En esos casos, estaríamos en un nodo hoja, y devolvemos alguno de los valores 1 ó 0 que ya he descrito. Si no es nodo hoja, entonces con un for recorremos las casillas y marcamos la primera que veamos libre, simulando ser el jugador humano, y llamando a continuación al método MAX. Llamamos a MAX porque en el siguiente turno le tocará jugar a la CPU, y nos interesa maximizar su resultado.
        /// ¿Y por qué nos quedamos con el valor mínimo? Pues porque estamos simulando el turno del jugador humano, y suponemos que este jugador moverá para GANAR la partida, que es un nodo hoja con el valor -1.
        /// Así pues, notar que el algoritmo minimax supondrá que el rival(en nuestro caso, el jugador humano) siempre hará el mejor movimiento posible, o dicho de otro modo, el movimiento que más nos perjudique(al jugador CPU).
        /// Notar que el último paso del bucle for es desmarcar la casilla marcada en esa vuelta, para dejar el array de casillas tal y como estaba.
        /// </summary>
        /// <returns>Davolverá el valor mínimo</returns>
        private int Min()
        {
            if (EndMatch())
                if (CheckWin() != -1)
                {
                    ObjectBridge.WinMachine = false;
                    return (1);
                }
                else
                    return (0);

            int v = Int32.MaxValue;
            int aux;

            for (int i = 0; i <= _tableBoard.Rank; i++)
            {
                for (int j = 0; j <= _tableBoard.Rank; j++)
                {
                    if (_tableBoard[i, j] == '-')
                    {
                        _tableBoard[i, j] = 'x';
                        aux = Max();
                        if (aux < v)
                            v = aux;
                        _tableBoard[i, j] = '-';
                    }
                }
            }
            return (v);
        }
    }
}