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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Alberto_Garcia_Pokemon
{
    public sealed partial class VistaElemento : UserControl
    {
        DispatcherTimer dtCuracion;

        public VistaElemento()
        {
            this.InitializeComponent();

            Storyboard palCentro = (Storyboard)this.Resources["sbPalCentro"];
            palCentro.Begin();
            Storyboard sbGrimer = (Storyboard)this.Resources["sbGrimer"];
            sbGrimer.Begin();
            Storyboard sbEevee = (Storyboard)this.Resources["sbEevee"];
            sbEevee.Begin();
            Storyboard sbVoltorb = (Storyboard)this.Resources["sbVoltorb"];
            sbVoltorb.Begin();
            Storyboard sbElectrode = (Storyboard)this.Resources["sbElectrode"];
            sbElectrode.Begin();
            Storyboard sbDitto = (Storyboard)this.Resources["sbDitto"];
            sbDitto.Begin();
            Storyboard sbGolbat = (Storyboard)this.Resources["sbGolbat"];
            sbGolbat.Begin();

        }
        private void usarPocion(object sender, object e)
        {
            dtCuracion = new DispatcherTimer();
            dtCuracion.Interval = TimeSpan.FromMilliseconds(100);
            dtCuracion.Tick += subirVida;
            dtCuracion.Start();
            this.imPocion.Opacity = 0.5;
            Storyboard pocion = (Storyboard)this.Resources["sbPocion"];
            pocion.Begin();
        }

        private void usarPocionVeneno(object sender, object e)
        {
            Primer_Estado.Visibility = Visibility.Collapsed;
            this.imPocionVeneno.Opacity = 0.5;
            Storyboard pocion = (Storyboard)this.Resources["sbPocion"];
            pocion.Begin();
        }

        private void usarPocionFuego(object sender, object e)
        {
            Segundo_Estado.Visibility = Visibility.Collapsed;
            this.imPocionFuego.Opacity = 0.5;
            Storyboard pocion = (Storyboard)this.Resources["sbPocion"];
            pocion.Begin();
        }

        void subirVida(object sender, object e)
        {
            if (pbVida.Value <= 0)
            {
                Tercer_Estado.Visibility = Visibility.Collapsed;
            }
            if (pbVida.Value <= 20)
            {
                Cuarto_Estado.Visibility = Visibility.Collapsed;
            }

            this.pbVida.Value += 0.2;
            if (pbVida.Value >= 100)
            {
                this.dtCuracion.Stop();
                this.imPocion.Opacity = 0.0;
            }

        }

        void bajarVida(object sender, object e)
        {
            this.pbVida.Value -= 0.2;
            if (pbVida.Value <= 0)
            {
                Tercer_Estado.Visibility = Visibility.Visible;
                this.dtCuracion.Stop();
                Storyboard muerte = (Storyboard)this.Resources["sbMuerte"];
                muerte.Begin();
                this.imPocion.Opacity = 1;
            }
        }

        void bajarPocaVida(object sender, object e)
        {
            this.pbVida.Value -= 0.2;
            if (pbVida.Value <= 20)
            {
                Cuarto_Estado.Visibility = Visibility.Visible;
                this.dtCuracion.Stop();
                Storyboard pokerus = (Storyboard)this.Resources["sbPokerus"];
                pokerus.Begin();
                this.imPocion.Opacity = 1;
            }
        }


        private void BtnEvolucionar_Click(object sender, RoutedEventArgs e)
        {
            BtnEvolucionar.Visibility = Visibility.Collapsed;
            BtnDesenrollar.Visibility = Visibility.Visible;
            BtnAtaqueCuerpo.Visibility = Visibility.Visible;
            BtnGigacanon.Visibility = Visibility.Visible;
            BtnKamikaze.Visibility = Visibility.Visible;
            BtnpuñoFuego.Visibility = Visibility.Visible;
            Storyboard evolucion = (Storyboard)this.Resources["sbEvolucionar"];
            evolucion.Begin();
        }

        private void BtnKamikaze_Click(object sender, RoutedEventArgs e)
        {
            Storyboard kamikaze = (Storyboard)this.Resources["sbKamikaze"];
            kamikaze.Begin();
            dtCuracion = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(5)
            };
            dtCuracion.Tick += bajarVida;
            dtCuracion.Start();
        }

        private void BtnpuñoFuego_Click(object sender, RoutedEventArgs e)
        {
            Storyboard punoFuego = (Storyboard)this.Resources["sbpunoFuego"];
            punoFuego.Begin();
            Segundo_Estado.Visibility = Visibility.Visible;
            Storyboard quemado = (Storyboard)this.Resources["sbQuemado"];
            this.imPocionFuego.Opacity = 1;
            quemado.Begin();

        }

        private void BtnDesenrollar_Click(object sender, RoutedEventArgs e)
        {
            Storyboard desenrollar = (Storyboard)this.Resources["sbDesenrollar"];
            desenrollar.Begin();
            Primer_Estado.Visibility = Visibility.Visible;
            Storyboard veneno = (Storyboard)this.Resources["sbEnvenenado"];
            this.imPocionVeneno.Opacity = 1;
            veneno.Begin();
        }

        private void BtnGigacanon_Click(object sender, RoutedEventArgs e)
        {
            Storyboard hiperRayo = (Storyboard)this.Resources["sbHiperrayoSnorlax"];
            hiperRayo.Begin();
        }

        private void BtnAtaqueCuerpo_Click(object sender, RoutedEventArgs e)
        {
            Storyboard atSnorlax = (Storyboard)this.Resources["SbAtaqueSnorlax"];
            atSnorlax.Begin();
            dtCuracion = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(5)
            };
            dtCuracion.Tick += bajarPocaVida;
            dtCuracion.Start();
        }
    }
}
