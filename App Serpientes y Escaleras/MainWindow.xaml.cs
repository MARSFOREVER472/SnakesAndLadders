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

namespace App_Serpientes_y_Escaleras
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
