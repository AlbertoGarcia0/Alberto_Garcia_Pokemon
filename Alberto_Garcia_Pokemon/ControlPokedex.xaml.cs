using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Alberto_Garcia_Pokemon
{
    public sealed partial class ControlPokedex : UserControl
    {
        public ControlPokedex()
        {
            this.InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Golbat.Opacity = 0;
            Ditto.Opacity = 0;
            Electrode.Opacity = 0;
            Voltorb.Opacity = 0;
            Grimer.Opacity = 0;
            Eevee.Opacity = 0;
            Snorlax.Opacity = 0;
            Munchlax.Opacity = 0;
            Gengar.Opacity = 0;

            string pathAux;
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            path = path.Replace("\\bin\\Debug\\", "");



            botonListBoxArriba.IsEnabled = false;
            botonListBoxAbajo.IsEnabled = false;


            //Todos los pokemon
            if (cmbTipo.SelectedIndex == 0)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 8)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Golbat.Opacity = 100;
                    pathAux = path + "/Assets/Media/Golbat.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Le encanta chuparles la sangre a los seres vivos. En ocasiones comparte la preciada colecta con otros congéneres hambrientos.";
                }

                if (listBoxPokedex.SelectedIndex == 1)
                {
                    Ditto.Opacity = 100;
                    pathAux = path + "/Assets/Media/Ditto.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Redistribuye las células de su cuerpo para cobrar la apariencia de lo que ve, pero vuelve a la normalidad al relajarse.";
                }

                if (listBoxPokedex.SelectedIndex == 2)
                {
                    Electrode.Opacity = 100;
                    pathAux = path + "/Assets/Media/Electrode.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Almacena tal cantidad de energía eléctrica en su cuerpo que el más leve impacto puede provocar una gran explosión.";
                }

                if (listBoxPokedex.SelectedIndex == 3)
                {
                    Voltorb.Opacity = 100;
                    pathAux = path + "/Assets/Media/Voltorb.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Se dice que se camufla como una Poké Ball. Al más mínimo estímulo se autodestruirá.";
                }

                if (listBoxPokedex.SelectedIndex == 4)
                {
                    Grimer.Opacity = 100;
                    pathAux = path + "/Assets/Media/Grimer.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Está hecho de lodo endurecido. Pocos se atreven a tocarlo debido a su pestilencia y composición nociva. Allá por donde pasa no crece la hierba.";
                }

                if (listBoxPokedex.SelectedIndex == 5)
                {
                    Eevee.Opacity = 100;
                    pathAux = path + "/Assets/Media/Eevee.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Es capaz de alterar la composición de su cuerpo para adaptarse al entorno.";
                }

                if (listBoxPokedex.SelectedIndex == 6)
                {
                    Snorlax.Opacity = 100;
                    pathAux = path + "/Assets/Media/Snorlax.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "No se encuentra satisfecho hasta haber ingerido 400 kg de comida cada día. Cuando acaba de comer, se queda dormido.";
                }

                if (listBoxPokedex.SelectedIndex == 7)
                {
                    Munchlax.Opacity = 100;
                    pathAux = path + "/Assets/Media/Munchlax.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Atiborrarse de comida es su fijación. Como no le hace ascos a nada, puede ingerir alimentos podridos sin inmutarse.";
                }
                if (listBoxPokedex.SelectedIndex == 8)
                {
                    Gengar.Opacity = 100;
                    pathAux = path + "/Assets/Media/Gengar.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Las noches de luna llena, a este Pokémon le gusta imitar las sombras de la gente y burlarse de sus miedos.";
                }
            }

            //Tipo normal
            if (cmbTipo.SelectedIndex == 1)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 3)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }


                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Ditto.Opacity = 100;
                    pathAux = path + "/Assets/Media/Ditto.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Redistribuye las células de su cuerpo para cobrar la apariencia de lo que ve, pero vuelve a la normalidad al relajarse.";
                }

                if (listBoxPokedex.SelectedIndex == 1)
                {
                    Eevee.Opacity = 100;
                    pathAux = path + "/Assets/Media/Eevee.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Es capaz de alterar la composición de su cuerpo para adaptarse al entorno.";
                }

                if (listBoxPokedex.SelectedIndex == 2)
                {
                    Snorlax.Opacity = 100;
                    pathAux = path + "/Assets/Media/Snorlax.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "No se encuentra satisfecho hasta haber ingerido 400 kg de comida cada día. Cuando acaba de comer, se queda dormido.";
                }

                if (listBoxPokedex.SelectedIndex == 3)
                {
                    Munchlax.Opacity = 100;
                    pathAux = path + "/Assets/Media/Munchlax.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Atiborrarse de comida es su fijación. Como no le hace ascos a nada, puede ingerir alimentos podridos sin inmutarse.";
                }
            }
            //Tipo electrico
            if (cmbTipo.SelectedIndex == 2)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 1)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }


                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Electrode.Opacity = 100;
                    pathAux = path + "/Assets/Media/Electrode.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Almacena tal cantidad de energía eléctrica en su cuerpo que el más leve impacto puede provocar una gran explosión.";
                }

                if (listBoxPokedex.SelectedIndex == 1)
                {
                    Voltorb.Opacity = 100;
                    pathAux = path + "/Assets/Media/Voltorb.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Se dice que se camufla como una Poké Ball. Al más mínimo estímulo se autodestruirá.";
                }
            }
            //Tipo Veneno
            if (cmbTipo.SelectedIndex == 3)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 2)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }


                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Golbat.Opacity = 100;
                    pathAux = path + "/Assets/Media/Golbat.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Le encanta chuparles la sangre a los seres vivos. En ocasiones comparte la preciada colecta con otros congéneres hambrientos.";
                }

                if (listBoxPokedex.SelectedIndex == 1)
                {
                    Grimer.Opacity = 100;
                    pathAux = path + "/Assets/Media/Grimer.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Está hecho de lodo endurecido. Pocos se atreven a tocarlo debido a su pestilencia y composición nociva. Allá por donde pasa no crece la hierba.";
                }
                if (listBoxPokedex.SelectedIndex == 2)
                {
                    Gengar.Opacity = 100;
                    pathAux = path + "/Assets/Media/Gengar.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Las noches de luna llena, a este Pokémon le gusta imitar las sombras de la gente y burlarse de sus miedos.";
                }
            }
            //Tipo Volador
            if (cmbTipo.SelectedIndex == 4)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }


                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Golbat.Opacity = 100;
                    pathAux = path + "/Assets/Media/Golbat.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Le encanta chuparles la sangre a los seres vivos. En ocasiones comparte la preciada colecta con otros congéneres hambrientos.";
                }

            }
            //Tipo Fantasma
            if (cmbTipo.SelectedIndex == 5)
            {

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxArriba.IsEnabled = false;
                }
                else
                {
                    botonListBoxArriba.IsEnabled = true;
                }

                if (listBoxPokedex.SelectedIndex == 0)
                {
                    botonListBoxAbajo.IsEnabled = false;
                }
                else
                {
                    botonListBoxAbajo.IsEnabled = true;
                }


                if (listBoxPokedex.SelectedIndex == 0)
                {
                    Gengar.Opacity = 100;
                    pathAux = path + "/Assets/Media/Gengar.mp3";
                    meSonido.Source = new System.Uri(pathAux.ToString());
                    caracteristicasPokemon.Text = "Las noches de luna llena, a este Pokémon le gusta imitar las sombras de la gente y burlarse de sus miedos.";
                }

            }
        }

        private void botonSonido_Click(object sender, RoutedEventArgs e)
        {
            meSonido.Play();
            
        }

        private void botonListBoxArriba_Click(object sender, RoutedEventArgs e)
        {
            listBoxPokedex.SelectedIndex = (listBoxPokedex.SelectedIndex - 1);
        }

        private void botonListBoxAbajo_Click(object sender, RoutedEventArgs e)
        {
            listBoxPokedex.SelectedIndex = (listBoxPokedex.SelectedIndex + 1);
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Todos los tipos
            botonListBoxArriba.IsEnabled = false;
            botonListBoxAbajo.IsEnabled = false;

            if (cmbTipo.SelectedIndex == 0)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Golbat");
                listBoxPokedex.Items.Add("Ditto");
                listBoxPokedex.Items.Add("Electrode");
                listBoxPokedex.Items.Add("Voltorb");
                listBoxPokedex.Items.Add("Grimer");
                listBoxPokedex.Items.Add("Eevee");
                listBoxPokedex.Items.Add("Snorlax");
                listBoxPokedex.Items.Add("Munchlax");
                listBoxPokedex.Items.Add("Gengar");

            }
            //Tipo normal
            if (cmbTipo.SelectedIndex == 1)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Ditto");
                listBoxPokedex.Items.Add("Eevee");
                listBoxPokedex.Items.Add("Snorlax");
                listBoxPokedex.Items.Add("Munchlax");
            }
            //Tipo electrico
            if (cmbTipo.SelectedIndex == 2)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Electrode");
                listBoxPokedex.Items.Add("Voltorb");
            }
            //Tipo veneno
            if (cmbTipo.SelectedIndex == 3)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Golbat");
                listBoxPokedex.Items.Add("Grimer");
                listBoxPokedex.Items.Add("Gengar");

            }
            //Tipo Volador
            if (cmbTipo.SelectedIndex == 4)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Golbat");
            }
            //Tipo Volador
            if (cmbTipo.SelectedIndex == 5)
            {
                listBoxPokedex.SelectedIndex = -1;
                listBoxPokedex.Items.Clear();
                listBoxPokedex.Items.Add("Gengar");
            }
        }

    }
}
