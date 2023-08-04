using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace App_Serpientes_y_Escaleras
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle landingRec; // El landingRec ayudará a identificar los rectángulos en el tablero.

        Rectangle player; // Rectángulo del jugador.
        Rectangle opponent; // Rectángulo del CPU.

        List<Rectangle> Moves = new List<Rectangle>(); // Lista de rectángulos para almacenar las piezas del tablero.
        DispatcherTimer gameTimer = new DispatcherTimer(); // Nueva instancia del temporizador de despachador llamado gameTimer.

        ImageBrush playerImage = new ImageBrush(); // Pincel de imagen para importar la imagen GIF del jugador y adjuntarla al rectángulo del jugador.
        ImageBrush opponentImage = new ImageBrush(); // Pincel de imagen para importar la imagen GIF de la CPU y adjuntarla al rectángulo de la CPU.

        // Las variables de tipo int I y J respectivamente se usarán para el jugador y la CPU.
        // Ellos mismos ayudarán en donde el jugador y la CPU están en el tablero.
        // El valor predeterminado cuando se carga el juego está configurado en -1 para ambos.

        int i = -1;
        int j = -1;

        // Su posición y la posición actual de la CPU.

        int opponentPosition;
        int opponentCurrentPosition;

        // Este entero de imágenes se usará para mostrar las imágenes del tablero cuando las creemos.

        int images = -1;

        // Se usará una nueva instancia de clase aleatoria llamada 'rand' para calcular las tiradas de dados en el juego.

        Random rand = new Random();

        // Los dos booleanos que determinarán a quién le toca en el juego.

        bool playerOneRound, playerTwoRound;

        // Este entero mostrará la posición actual del jugador y el oponente a la GUI.

        int tempPos;


        // Clase inicial de la interfaz.
        public MainWindow()
        {
            InitializeComponent(); // Llamado del método inicial.
            SetupGame(); // Llamado del método anterior.
        }

        // Evento para hacer click en todo el Canvas de la interfaz.

        private void OnClickEvent(object sender, MouseButtonEventArgs e)
        {
            // EN INSTANTES...
        }

        // Vamos a crear un nuevo método para realizar algunos ajustes al juego.

        private void SetupGame()
        {
            // EN INSTANTES...
        }

        // Vamos a crear otro método que permita reiniciar el juego.

        private void RestartGame()
        {
            // EN INSTANTES...
        }

        // Vamos a crear otro método que permita verificar todo el tablero mediante números.

        private int ChequearSerpientesYEscaleras(int numero)
        {
            // Hay que retornar este método con una variable ya declarada.

            return numero;
        }

        // Vamos a crear otro método que permita mover las piezas o personajes del tablero.

        private void MoverPiezas(Rectangle player, string posName)
        {
            // EN INSTANTES...
        }
    }
}
