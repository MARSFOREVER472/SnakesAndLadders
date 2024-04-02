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

        // Posición y número entero de la posición actual del jugador.

        int position;
        int currentPosition;

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
            // A continuación se muestra la declaración "if" que verifica si los valores booleanos del jugador 1 y 2 están configurados en falso a priori...
            // Si es así, podemos hacer lo siguiente dentro de esta declaración...

            if (playerOneRound == false && playerTwoRound == false)
            {
                position = rand.Next(1, 7); // Genera un número al azar de entre ambos jugadores.
                txtPlayer.Content = "YOU ROLLED A " + position; // Muestra un número definido en el texto del jugador.
                currentPosition = 0; // Se ajusta a la posición actual en 0.

                // En la siguiente declaración a continuación vamos a comprobar si el número entero "i" es la posición actual del jugador en el juego.
                // Si dicho número mencionado anteriormente es menor o igual que 99, entonces vamos a hacer lo siguiente...

                if ((i + position) <= 99)
                {
                    playerOneRound = true; // Dentro de esta declaración, cambia la ronda del jugador a verdadero.
                    gameTimer.Start(); // Inicializa el temporizador.
                }
                else // En caso contrario...
                {
                    // Si la condición es "FALSA" entonces haces lo siguiente:

                    if (playerTwoRound == false)
                    {
                        // Chequea si la ronda del jugador 2 es falsa...

                        playerTwoRound = true; // Cambia la modalidad de la ronda del jugador 2 a verdadera.
                        opponentPosition = rand.Next(1, 7); // La posición de su rival será aleatoria.
                        txtOpponent.Content = " OPPONENT ROLLED A " + opponentPosition; // Muestra un número definido en el texto de su rival.
                        opponentCurrentPosition = 0; // La posición actual de su rival inicializa en 0.
                        gameTimer.Start(); // Inicializa el temporizador para su rival.
                    }
                    else // En caso contrario...
                    {
                        // Si la ronda del jugador 2 es definitivamente verdadera cuando...

                        gameTimer.Stop(); // Paraliza el temporizador para su rival.

                        // A ambos jugadores les cambiaría su valor booleana a "FALSA"...

                        playerOneRound = false; // Para el jugador.
                        playerTwoRound = false; // Para su rival.
                    }
                }
            }
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

            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/player.gif")); // Para el jugador.
            opponentImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/opponent.gif")); // Para la CPU.

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

                tileImages.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/" + images + ".jpg"));

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

            // Fuera del bucle de la placa principal, ahora podemos configurar el temporizador.

            gameTimer.Tick += GameTimerEvent; // Enlaza el evento del temporizador del juego al tic del temporizador.
            gameTimer.Interval = TimeSpan.FromSeconds(.2); // Con este temporizador marcará cada 0,2 segundos.

            // Configura el rectángulo del jugador.
            // El rectángulo del jugador tendrá 30 x 30 de alto y ancho respectivamente, tendrá también la imagen del jugador como relleno y por último un borde de 2 píxeles.

            player = new Rectangle
            {
                Height = 30, // Altura del rectángulo.
                Width = 30, // Ancho del rectángulo.
                Fill = playerImage, // Relleno del rectángulo del jugador.
                StrokeThickness = 2 // Lo hará 2 oportunidades.
            };

            // Configura el rectángulo de la CPU de la misma manera que el jugador.

            opponent = new Rectangle
            {
                Height = 30, // Altura del rectángulo.
                Width = 30, // Ancho del rectángulo.
                Fill = opponentImage, // Relleno del rectángulo del jugador.
                StrokeThickness = 2 // Lo hará 2 oportunidades.
            };

            // Agrega tanto al jugador como a la CPU al lienzo.

            MyCanvas.Children.Add(player);
            MyCanvas.Children.Add(opponent);

            // Ejecuta la función de mover las piezas y hace referencia al jugador y a la CPU dentro de ella.
            // Ésta también hace referencia a dónde queremos que el jugador y la CPU se coloquen al comienzo del juego.

            MoverPiezas(player, "box" + 0);
            MoverPiezas(opponent, "box" + 0);
        }

        // Vamos a crear otro método para el temporizador.

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Este es el evento del temporizador del juego este evento moverá al jugador y al oponente en el tablero.
            // En la declaración "if" a continuación, primero verificamos si el jugador de una ronda es verdadero y el jugador de dos rondas es falso.

            if (playerOneRound == true && playerTwoRound == false)
            {
                // Si esta condición es verdadera entonces haremos lo siguiente:

                // Compruebe si "i" es menor que el número total de piezas del tablero dentro de la lista de movimientos.

                if (i < Moves.Count)
                {
                    // En caso afirmativo, ahora compruebe si la posición actual es menor que la posición que generamos con la clase aleatoria.

                    if (currentPosition < position)
                    {
                        // Si es así, ahora agregamos 1 a la posición actual con cada marca.

                        currentPosition++;
                        i++; // Agrega 1 al "i" entero con cada marca.
                        MoverPiezas(player, "box" + i); // Actualiza la posición del jugador usando la función de mover las piezas.
                    }
                    else // En caso contrario...
                    {
                        // Si el jugador de la ronda 1 se establece en falso, haga lo siguiente:

                        playerTwoRound = true; // Ajusta a la ronda 2 del jugador en verdadero.

                        // Ahora ejecuta la "i", que es la posición del jugador a través de la función de chequear el tablero de serpientes y escaleras.

                        i = ChequearSerpientesYEscaleras(i);

                        // Actualiza la posición del jugador hacia la función de mover las piezas.

                        MoverPiezas(player, "box" + i);

                        // Ahora que hemos terminado la ronda del jugador, necesitamos configurar la CPU para que haga su propia posición.

                        opponentPosition = rand.Next(1, 7); // Genera un número aleatorio para la CPU.
                        txtOpponent.Content = "Opponent rolled a " + currentPosition; // Muestra el número aleatorio en la etiqueta de texto de la CPU.
                        opponentCurrentPosition = 0; // Establece la posición actual de la CPU en 0.
                        tempPos = i; // Ahora pasaremos el valor de i dentro del entero temporal.
                        txtPlayerPosition.Content = "Player is @ " + (tempPos + 1); // Muestra la posición actual del jugador en la etiqueta de posición del jugador.

                        // El tablero que estamos generando en el juego generará una pieza de tablero de 0 a 99, por lo que agregaremos 1 a la posición del número entero temporal para mostrar la información actual sobre dónde se encuentra el jugador en el tablero del juego.

                    }
                }

                // A continuación esta declaración "if" verificará si el jugador ha llegado a la parte superior del tablero.

                if (i == 99)
                {
                    // Si es así, detiene el tiempo del juego, se muestra un mensaje en la pantalla y cuando el jugador haga clic en el botón de "OK", ésta reiniciará el juego.

                    gameTimer.Stop();
                    MessageBox.Show("Game Over!, You Win" + Environment.NewLine + "Click OK to play again!");
                    RestartGame();
                }

                // La declaración "if" del jugador termina aquí.
            }

            // Esta sección a continuación es para el rival, esto sólo se ejecutará cuando la ronda del jugador 2 esté configurada en verdadero.

            if (playerTwoRound == true)
            {
                // Igual que antes, verificamos si la posición del rival es menor que los números del tablero.

                if (j < Moves.Count)
                {
                    // En caso afirmativo, estaremos comprobando si la posición actual del rival es menor que la posición generada por el sistema...
                    // ...y estamos comprobando si la CPU tiene más movimientos por delante, de esta manera podemos evitar que el rival pueda hacer movimientos de último minuto y permitir que el jugador se mueva después de su turno.

                    if (opponentCurrentPosition < currentPosition && j < (currentPosition + 101))
                    {
                        opponentCurrentPosition++; // Incrementa la posición previa del rival.
                        j++; // Incrementa la posición actual del rival.
                        MoverPiezas(opponent, "box" + j); // Muestra los movimientos a través del llamado de la función (MoverPiezas()).
                    }
                    else // En caso contrario...
                    {
                        // Si el rival ha tomado su turno entonces hacemos lo siguiente:

                        // 1.- Establece las rondas de los jugadores 1 y 2 en falso.

                        playerOneRound = false;
                        playerTwoRound = false;

                        // 2.- Comprobar la posición del rival con un llamado de la función (ChequearSerpientesYEscaleras()).

                        j = ChequearSerpientesYEscaleras(j);
                        MoverPiezas(opponent, "box" + j);

                        // 3.- Establecer posición del temporizador del rival y luego mostrarlo en pantalla.

                        tempPos = j;
                        txtOpponentPosition.Content = "OPPONENT IS @ " + (tempPos + 1);

                        // 4.- Detiene el temporizador.

                        gameTimer.Stop();
                    }

                }
            }
        }

        // Vamos a crear otro método que permita reiniciar el juego.

        private void RestartGame()
        {
            // Esta es la función de reiniciar el juego, restablecerá todo a los valores predeterminados cuando se ejecute.

            // Si las variables I y J volvemos a -1 y establecemos al jugador y al rival a la posición 0 en el tablero...

            i = -1;
            j = -1;

            MoverPiezas(player, "box" + 0); // Para mover al jugador en esa posición.
            MoverPiezas(opponent, "box" + 0); // Para mover al rival en esa posición.

            // Ajusta las posiciones actual y previa del jugador en 0.

            position = 0;
            currentPosition = 0;

            // Ajusta las posiciones actual y previa del rival en 0.

            opponentPosition = 0;
            opponentCurrentPosition = 0;

            // Ajusta a las rondas 1 y 2 del jugador en "false".

            playerOneRound = false;
            playerTwoRound = false;

            // Restablece las etiquetas de jugador y del rival a su contenido predeterminado.

            txtPlayer.Content = "YOU ROLLED A " + position;
            txtPlayerPosition.Content = "PLAYER IS @ 1";

            txtOpponent.Content = "OPPONENT ROLLED A " + opponentPosition;
            txtOpponentPosition.Content = "OPPONENT IS @ 1";

            // Detiene el temporizador.

            gameTimer.Stop();
        }

        // Vamos a crear otro método que permita verificar todo el tablero mediante números.

        private int ChequearSerpientesYEscaleras(int numero)
        {
            // 1.- Esta es la función de serpientes de control o escaleras.
            //     El objetivo de esta función es comprobar si el jugador...
            //     ...aterrizó en la parte inferior de una escalera o en la parte superior de la serpiente.

            // 2.- Esta función devolverá un número entero cuando se ejecute, es por eso que la hemos vinculado a los movimientos del jugador y del oponente.

            // 3.- Hay varias declaraciones "if" dentro de esta función y puede ver si el número que se pasa dentro de esta función...
            //     ...coincide con cualquiera de las condiciones if, cambiará el número a ese número final y lo devolverá al programa.

            // 4.- De esta manera podemos simplemente comprobar si el jugador ha aterrizado en una escalera y luego moverlo hasta donde termina la escalera...
            //     ...y si aterrizó en la serpiente, entonces podemos moverla hacia abajo hasta donde termina la serpiente.

            // 5.- Esta función está diseñada para el tablero que estamos usando en este proyecto.
            //     Si tiene otro tablero, es posible que deba cambiar estos números para que se adapten mejor a su tablero.

            // Condición 1 (Cuando el número de la condición es menor que el valor de retorno, entonces se paró frente a la escalera para avanzar):

            if (numero == 1) // Si hay una escalera en la casilla 1...
            {
                numero = 37; // Sube a la casilla número 37.
            }

            // Condición 2:

            if (numero == 6) // Si hay una escalera en la casilla 6...
            {
                numero = 13; // Entonces pasa a la casilla número 13.
            }

            // Condición 3:

            if (numero == 7) // Si hay una escalera en la casilla 7...
            {
                numero = 30; // Entonces pasa a la casilla número 30.
            }

            // Condición 4:

            if (numero == 14) // Si hay una escalera en la casilla 14...
            {
                numero = 25; // Entonces pasa a la casilla número 25.
            }

            // Condición 5 (En caso contrario, si el número de la condición es mayor que el valor de retorno...
            // ...entonces se encontró con una serpiente para retroceder en la casilla indicada donde se encuentra su cola):

            if (numero == 15) // Si hay una serpiente en la casilla 15...
            {
                numero = 5; // Entonces cae a la casilla número 5.
            }

            // Condición 6:

            if (numero == 20) // Si hay una escalera en la casilla 20...
            {
                numero = 41; // Entonces pasa a la casilla número 41.
            }

            // Condición 7:

            if (numero == 27) // Si hay una escalera en la casilla 27...
            {
                numero = 83; // Entonces pasa a la casilla número 83.
            }

            // Condición 8:

            if (numero == 35) // Si hay una escalera en la casilla 35...
            {
                numero = 43; // Entonces pasa a la casilla número 43.
            }

            // Condición 9:

            if (numero == 45) // Si hay una serpiente en la casilla 45...
            {
                numero = 24; // Entonces cae a la casilla número 24.
            }

            // Condición 10:

            if (numero == 48) // Si hay una serpiente en la casilla 48...
            {
                numero = 10; // Entonces cae a la casilla número 10.
            }

            // Condición 11:

            if (numero == 50) // Si hay una escalera en la casilla 50...
            {
                numero = 66; // Entonces pasa a la casilla número 66.
            }

            // Condición 12:

            if (numero == 61) // Si hay una serpiente en la casilla 61...
            {
                numero = 18; // Entonces cae a la casilla número 18.
            }

            // Condición 13:

            if (numero == 63) // Si hay una serpiente en la casilla 63...
            {
                numero = 59; // Entonces cae a la casilla número 59.
            }

            // Condición 14:

            if (numero == 70) // Si hay una escalera en la casilla 70...
            {
                numero = 90; // Entonces pasa a la casilla número 90.
            }

            // Condición 15:

            if (numero == 73) // Si hay una serpiente en la casilla 73...
            {
                numero = 52; // Entonces cae a la casilla número 52.
            }

            // Condición 16:

            if (numero == 77) // Si hay una escalera en la casilla 77...
            {
                numero = 97; // Entonces pasa a la casilla número 97.
            }

            // Condición 17:

            if (numero == 86) // Si hay una escalera en la casilla 86...
            {
                numero = 93; // Entonces avanza a la casilla número 93.
            }

            // Condición 18:

            if (numero == 88) // Si hay una serpiente en la casilla 88...
            {
                numero = 67; // Entonces cae a la casilla número 67.
            }

            // Condición 19:

            if (numero == 91) // Si hay una serpiente en la casilla 91...
            {
                numero = 87; // Entonces cae a la casilla número 87.
            }

            // Condición 20:

            if (numero == 94) // Si hay una serpiente en la casilla 94...
            {
                numero = 74; // Entonces cae a la casilla número 74.
            }

            // Condición 21:

            if (numero == 98) // Si hay una serpiente en la casilla 98...
            {
                numero = 79; // Entonces cae a la casilla número 79.
            }

            return numero;
        }

        // Vamos a crear otro método que permita mover las piezas o personajes del tablero.

        private void MoverPiezas(Rectangle player, string posName)
        {
            // - Con esta función moverá al jugador y a la CPU a través del tablero del juego.
            // - La forma en que lo hace es muy simple, hemos agregado los rectángulos del tablero a la lista de movimientos.
            // - Desde el bucle "foreach" de abajo podemos recorrer todos los rectángulos de esta lista.
            // - También estamos verificando si alguno de los rectángulos tiene el posName, si lo tienen, vincularemos el rect de aterrizaje con ese rectángulo que se encuentra dentro del ciclo "foreach".
            // - De esta manera podemos mover el rectángulo que se está pasando dentro de esta función y ejecutar el evento del temporizador para animarlo cuando ésta comienza.

            foreach (Rectangle rectangulo in Moves)
            {
                if (rectangulo.Name == posName)
                {
                    landingRec = rectangulo;
                }
            }

            // Las dos líneas aquí colocarán el objeto "player" que se pasa en esta función a la ubicación "landingRec".

            Canvas.SetLeft(player, Canvas.GetLeft(landingRec) + player.Width / 2); // Línea horizontal.
            Canvas.SetTop(player, Canvas.GetTop(landingRec) + player.Height / 2); // Línea vertical.
        }
    }
}
