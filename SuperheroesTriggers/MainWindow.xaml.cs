using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SuperheroesTriggers
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum cambiaPag { anterior = -1, siguiente = 1, actual = 0 }
        private int numActualSuperheroe = 1;
        List<Superheroe> superheroes;
        Superheroe superheroe;
        public MainWindow()
        {
            InitializeComponent();

            superheroe = new Superheroe
            {
                // Marcamos predeterminado el RadioButton de Héroe
                Heroe = true
            };
            superheroes = Superheroe.GetSamples();
            ActualizaVista(cambiaPag.actual);
            nuevoSuperheroe.DataContext = superheroe;
        }

        private void ActualizaVista(cambiaPag tipo)
        {
            numActualSuperheroe += (int)tipo;
            numerosTextBlock.Text = numActualSuperheroe + "/" + superheroes.Count.ToString();
            nombreSuperheroeTextBock.Text = superheroes[numActualSuperheroe - 1].Nombre;
            contenedorSuperheroe.DataContext = superheroes[numActualSuperheroe - 1];
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            superheroes.Add(superheroe);

            // Mensaje con icono
            MessageBox.Show("Superhéroe insertado con éxito",
                            "Superhéroes",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            ActualizaVista(cambiaPag.actual);
            superheroe = new Superheroe
            {
                // Marcamos predetirmado el RadioButton de Heroe
                Heroe = true
            };
            nuevoSuperheroe.DataContext = superheroe;
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            nombreSuperheroeTextBox.Text = "";
            rutaTextBox.Text = "";
            heroesRadioButton.IsChecked = true;
            villanoRadioButton.IsChecked = false;
            vengadoresChecBox.IsChecked = false;
            xMenChecBox.IsChecked = false;
        }

        private void Siguiente_Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (numActualSuperheroe < superheroes.Count)
                ActualizaVista(cambiaPag.siguiente);
        }

        private void Anterior_Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (1 < numActualSuperheroe)
                ActualizaVista(cambiaPag.anterior);
        }
    }
}
