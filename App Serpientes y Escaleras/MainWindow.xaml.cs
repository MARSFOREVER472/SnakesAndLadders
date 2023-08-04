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
    /// Encuentra las imágenes @ mooict.com y busca el juego de serpientes y escaleras.

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
            SetupGame(); // Ejecuta la función de configuración del juego desde adentro de este constructor.
        }

        // Evento para hacer click en todo el Canvas de la interfaz.

        private void OnClickEvent(object sender, MouseButtonEventArgs e)
        {
            // EN INSTANTES...
        }

        // Vamos a crear un nuevo método para realizar algunos ajustes al juego.

        private void SetupGame()
        {
            // Esta es la función de configuración del juego.
            // En esta función configuraremos el tablero de juego, el jugador y la CPU.
            // Para poder crear el tablero, primero necesitamos crear 3 variables locales a continuación.

            int leftPos = 10; // La Variable leftPos nos ayudará a posicionar los cuadros de derecha a izquierda.
            int topPos = 583; // La Variable topPos nos ayudará a posicionar los cuadros de abajo hacia arriba.
            int a = 0; // Un número entero nos ayudará a colocar 10 casillas seguidas.

            // Las dos líneas a continuación importan las imágenes para el jugador y la CPU y las adjuntan al pincel de imagen que creamos anteriormente.

            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/player.gif")); // Para el jugador.
            opponentImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/opponent.gif")); // Para la CPU.

            // Este es el bucle principal "for" en donde haremos el tablero del juego.
            // Con este bucle se ejecutará 100 veces dentro de esta función.
            // Y esto funcionará así porque necesitamos 100 mosaicos para que este juego funcione correctamente.

            for (int i = 0; i < 100; i++)
            {
                // Primero incrementamos el entero de las imágenes que creamos en el programa anterior.

                images++;

                // Crea un nuevo pincel de imagen llamado "tileImages", esto adjuntará una imagen a los rectángulos para el tablero.

                ImageBrush tileImages = new ImageBrush();

                // Importa las imágenes del rectángulo del tablero dentro de las imágenes del mosaico.
                // Dentro del nuevo "Uri" puede ver que estamos agregando el número entero de imágenes allí también, esto se debe a que tenemos nombres de imágenes de 0.jpg a 99.jpg.
                // Así que a medida que el bucle vaya aumentando, el entero de esta imagen también aumentará y podremos capturar todas las imágenes para el tablero.

                tileImages.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + images + ".jpg"));

                // Debajo estamos creando un nuevo rectángulo llamado "box".
                // Con este rectángulo tendrá 60 x 60 de alto y ancho respectivamente, el relleno son las imágenes de los mosaicos y un borde negro alrededor de ellas.

                Rectangle box = new Rectangle
                {
                    Height = 60,  // Altura del elemento.
                    Width = 60, // Ancho del elemento.
                    Fill = tileImages, // Para los rellenos del mosaico.
                    Stroke = Brushes.Black, // Dibuja los cuadros en un pincel negro.
                    StrokeThickness = 1 // El grosor del trazo será delgado (1).
                };

                // Necesitamos identificar el rectángulo creado en este bucle, por lo que le daremos a cada cuadro un nombre único.

                box.Name = "box" + i.ToString(); // Nombre para cada cuadro.
                this.RegisterName(box.Name, box); // Registra el nombre dentro de la app en WPF.

                Moves.Add(box); // Agrega el cuadro recién creado a la lista de rectángulos de movimientos.

                // A continuación estaremos haciendo un algoritmo que necesitamos para colocar los 10 cuadros en cada fila.
                // Haremos los cuadros de izquierda a derecha, luego lo moveremos hacia arriba e invertiremos este proceso.
                // Recuerda que el entero "a" controla cómo colocamos los cuadros hacia abajo, por lo que debemos tener en cuenta que se puede controlar dentro de este ciclo.

                // Si "a" es igual a 10.

                if (a == 10)
                {
                    // Esto sucederá de cuando vayamos posicionado 10 casillas de izquierda a derecha.

                    topPos -= 60; // En ese caso, reduzca 60 del entero topPos.
                    a = 30; // Cambia el valor de "a" hacia 30, ya que recién lo estamos haciendo esto para mover las casillas de derecha a izquierda.
                }

                // Si "a" es igual a 20.

                if (a == 20)
                {
                    topPos -= 60; // Nuevamente, se reduce a 60 del entero topPos.
                    a = 0; // Ajusta al entero "a" en 0.
                }

                // Si "a" es mayor que 20.

                if (a > 20)
                {
                    // Si el valor de "a" es mayor que 20 entonces podemos realizar este proceso.
                    // Esta instrucción "if" nos ayudará a posicionar los cuadros de derecha a izquierda.

                    a--; // Reduce a 1 por cada ciclo.
                    Canvas.SetLeft(box, leftPos); // Establece el cuadro dentro del lienzo por el valor del entero leftPos.
                    leftPos -= 60; // Reduce a 60 desde la posición izquierda de cada ciclo.
                }

                // Si "a" es menor que 10.

                if (a < 10)
                {
                    // Esto sucederá cuando queramos colocar los cuadros de izquierda a derecha.
                    // Si el valor de "a" es menor que 10.

                    a++; // Agrega a 1 a un número entero por cada ciclo.
                    Canvas.SetLeft(box, leftPos); // Establece la posición izquierda del cuadro en el valor del entero leftPos.
                    leftPos += 60; // Suma por 60 al entero leftPos.
                    Canvas.SetLeft(box, leftPos); // Establece la posición izquierda del cuadro en el valor del entero leftPos.
                }

                Canvas.SetTop(box, topPos); // Establece la posición superior de la caja en el valor del entero topPos por cada ciclo.

                MyCanvas.Children.Add(box); // Finalmente agrega el cuadro a la pantalla del lienzo.

                // Fin del ciclo "for".

            }
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
