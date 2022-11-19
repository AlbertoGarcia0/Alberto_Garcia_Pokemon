using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Alberto_Garcia_Pokemon
{
    public sealed partial class CombatePokemon : UserControl
    {
        
        DispatcherTimer dtCuracion;
         
        private int turno = 0;
        private int aleatorioProbabilidad;
        private int aleatorioAtaque;
        private int turnosPLuz = 0;
        private int hiperPocion = 3;
        private int curaTotal = 2;
        private int turnosDormido = 0;
        private Boolean dormido =false;
        private Boolean paralizado = false;
        private Boolean envenenado = false;
        Random random = new Random();
        public CombatePokemon()
        {
            this.InitializeComponent();
            Combate();
        }
        private void Combate()
        {
            
           
            if (turno %2 == 0)
            {

                if (VidaGengar.Value <= 0 || VidaElectrode.Value <=0)
                {
                    if(VidaGengar.Value <= 0)
                    {
                        comentario.Text = "Game Over, Gengar ha sido derrotado";
                    }
                    if(VidaElectrode.Value <=0)
                    {
                        comentario.Text = "Enorabuena, has ganado el combate";
                    }
                    TerminarCombate();
                    ActivarBotones();
                }else
                {
                    if (paralizado)
                    {
                        aleatorioProbabilidad = random.Next(1, 100);
                        if (aleatorioProbabilidad > 60)
                        {
                            comentario.Text = "Gengar está paralizado, no puede atacar";
                            turno++;
                            Combate();
                        }
                        else
                        {
                            if (turnosPLuz == 3)
                            {
                                turnosPLuz = 0;
                                comentario.Text ="El efecto de la pantalla de luz ha desaparecido";
                                
                            }
                            ActivarBotones();
                        }
                    }
                    else
                    {
                        if (turnosPLuz == 3)
                        {
                            turnosPLuz = 0;
                            comentario.Text= "El efecto de la pantalla de luz ha desaparecido";
                            
                        }
                        ActivarBotones();
                    }
                }
                
            }
            else
            {
                
                if (envenenado)
                {
                    VidaElectrode.Value -= 7.5;
                }
                    
                if( turnosDormido <= 2 && dormido)
                {
                    comentario.Text = "Electrode está dormido";
                    turnosDormido++;
                    turno++;
                    Combate();
                }
                else
                {
                    turnosDormido = 0;
                    dormido = false;
                    EstadoElectrode.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/Dormido.jpeg"));
                    EstadoElectrode.Visibility = Visibility.Collapsed;
                    TurnoRival();
                }
            }
        }


        private void TurnoRival()
        {
            aleatorioAtaque = random.Next(1, 5);
            if(aleatorioAtaque == 4 && turnosPLuz == 0)
            {
                turnosPLuz++;
            }
            if (aleatorioAtaque == 4 && (turnosPLuz > 0 && turnosPLuz < 3))
            {
                comentario.Text= "El movimiento Pantalla de Luz falló";
                turnosPLuz++;
            }
            else
            {
                switch (aleatorioAtaque)
                {
                    case 1:
                        comentario.Text= " El movimiento Placaje no afecta a Gengar";
                        break;

                    
                    case 2:
                        aleatorioProbabilidad = random.Next(1, 100);
                        Rayo.Opacity = 100; ;
                        Storyboard rayo = (Storyboard)Resources["Rayo1"];
                        rayo.Completed += FinRayo;
                        rayo.Begin();
                        
                        if (aleatorioProbabilidad >= 75)
                        {
                            EstadoGengar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/Paralizado.jpeg"));
                            EstadoGengar.Visibility = Visibility.Visible;
                            paralizado = true;
                        }

                        break;

                    
                    case 3:
                        aleatorioProbabilidad = random.Next(1, 100);
                        if (aleatorioProbabilidad > 90)
                        {
                            comentario.Text= "Electrode ha fallado el movimiento desenrrollar";
                        }
                        else
                        {
                            Desenrollar.Opacity = 100;
                            Storyboard desenrrollar = (Storyboard)Resources["Desenrollar1"];
                            desenrrollar.Completed += FinDesenrrollar;
                            desenrrollar.Begin();

                        }
                        break;

                    case 4:
                        PantallaLuz.Opacity = 100;
                        Storyboard pluz = (Storyboard)Resources["PantallaDeLuz"];
                        pluz.Completed += FinPantallaLuz;
                        pluz.Begin();
                        break;

                }
                
            }
            turno++;
            Combate();
        }


        private void AtaquePokemon(object sender, RoutedEventArgs e)
        {
            Atacar.Visibility = Visibility.Collapsed;
            Curar.Visibility= Visibility.Collapsed;
            BolaSombra.Visibility= Visibility.Visible;
            Hypnosis.Visibility= Visibility.Visible;
            ComeSueños.Visibility= Visibility.Visible;
            GasVenennoso.Visibility= Visibility.Visible;
        }
        private void CurarPokemon(object sender, RoutedEventArgs e)
        {
            Atacar.Visibility= Visibility.Collapsed;
            Curar.Visibility= Visibility.Collapsed;
            HiperPoción.Visibility= Visibility.Visible;
            CuraTotal.Visibility= Visibility.Visible;
            HiperPoción.IsEnabled = true;
            CuraTotal.IsEnabled = true;
        }
        private void UsarHiperPoción(object sender, RoutedEventArgs e)
        {
            
            dtCuracion = new DispatcherTimer();
            dtCuracion.Interval = TimeSpan.FromMilliseconds(15);
            if(hiperPocion == 0)
            {
                comentario.Text= "No te quedan más hiperpociones";
                DesabilitarCurar();
                turno++;
                Combate();
                
            }
            else
            {
                if (VidaGengar.Value == 100)
                {
                    comentario.Text= "La vida de Gengar está al máximo";
                    DesabilitarCurar();
                    turno++;
                    Combate();
                }
                else
                {
                    HiperPoción.IsEnabled = false;
                    CuraTotal.IsEnabled = false;
                    hiperPocion--;
                    dtCuracion.Start();
                    dtCuracion.Tick += curar;


                }
            }
            
        }
        private void curar(object sender, object e)
        {
            if (VidaGengar.Value == 100)
            {
                dtCuracion.Stop();
                DesabilitarCurar();
                turno++;
                Combate();
            }
            else { VidaGengar.Value += 0.5; }
            
        }
        private void UsarCuraTotal(object sender, RoutedEventArgs e)
        {
            if (!paralizado)
            {
                comentario.Text= "Gengar no tiene un estado desfavorable";             
            }
            else
            {
                if(curaTotal == 0)
                {
                    comentario.Text = "No te quedan más cura totales";
                }
                else
                {
                    
                    EstadoGengar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/corazon.png"));
                    EstadoGengar.Visibility = Visibility.Collapsed;
                    curaTotal--;
                }
               
            }
            HiperPoción.IsEnabled = false;
            CuraTotal.IsEnabled = false;
            DesabilitarCurar();
            turno++;
            Combate();
        }
        private void VidaGengar_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
        private void UsarBolaSombra(object sender, RoutedEventArgs e)
        {
            DesabilitarBotones();
            BSombra.Opacity = 100;
            Storyboard bsombra = (Storyboard)this.Resources["BSombra1"];
            bsombra.Completed += FinBolaSombra;
            bsombra.Begin();
        }
        private void FinBolaSombra( object sender, object e)
        {
            BSombra.Opacity = 0;
            if (turnosPLuz>0 && turnosPLuz < 3)
            {
                VidaElectrode.Value -= 15;
                turnosPLuz++;
            }
            else
            {
                VidaElectrode.Value -= 30;
            }
            turno++;
            Combate();

        }
        private void UsarHipnosis(object sender, RoutedEventArgs e)
        {
            DesabilitarBotones();
            if (dormido)
            {
                comentario.Text = "Electrode ya estaba dormido";
                turno++;
                Combate();
            }
            else
            {
                aleatorioAtaque = random.Next(1, 100);
                if(aleatorioAtaque <= 60)
                {
                    Hipnosis2.Opacity = 100;
                    Storyboard hipnosis = (Storyboard)this.Resources["Hipnosis"];
                    hipnosis.Completed += FinHipnosis;
                    hipnosis.Begin();
                }else
                {
                    comentario.Text = "El ataque Hipnosis ha fallado";
                    turno++;
                    Combate();
                }
            }
            
        }
        private void FinHipnosis(object sender, object e)
        {
            if (turnosPLuz > 0 && turnosPLuz < 3)
            { 
                turnosPLuz++; 
            }
            Hipnosis2.Opacity = 0;

            EstadoElectrode.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/Dormido.jpeg"));
            EstadoElectrode.Visibility = Visibility.Visible;
            dormido = true;
            turnosDormido++;
            turno++;
            Combate();

        }
        private void UsarComeSueños(object sender, RoutedEventArgs e)
        {
            DesabilitarBotones();
            if (!dormido)
            {
                comentario.Text = "¡Electrode no está dormido!";
                turno++;
                Combate();
            }
            else
            {

                ComeSueños2.Opacity = 100;
                Storyboard comesueños = (Storyboard)this.Resources["ComeSueños1"];
                comesueños.Completed += FinComeSueños;
                comesueños.Begin();
            }
        }
        private void FinComeSueños (object sender, object e)
        {
            ComeSueños2.Opacity = 0;
            if ( turnosPLuz > 0 && turnosPLuz < 3)
            {
                VidaElectrode.Value -= 20;
                turnosPLuz++;
            }
            else
            {
                VidaElectrode.Value -= 40;
            }
            turno++;
            Combate();
        }
        private void UsarGasVenenoso(object sender, RoutedEventArgs e)
        {
            DesabilitarBotones();
            if (!dormido && !envenenado)
            {
                GasVenenoso1.Opacity = 100;
                Storyboard gasvenenoso = (Storyboard)this.Resources["GasVenenoso"];
                gasvenenoso.Completed += FinGasvenenoso;
                gasvenenoso.Begin();
            }
            else if (dormido)
            {
                comentario.Text = "¡Electrode está dormido!";
                turno++;
                Combate();
            }
            else if(envenenado)
            {
                comentario.Text = "Electrode ya está envenenado";
                turno++;
                Combate();
            }
        }
        private void FinGasvenenoso (object sender, object e)
        {
            GasVenenoso1.Opacity = 0;
            
            EstadoElectrode.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/Envenenado.png"));
            EstadoElectrode.Visibility = Visibility.Visible;
            turno++;
            Combate();
        }
        private void FinRayo(object sender, object e)
        {
            VidaGengar.Value -= 30;
            Rayo.Opacity = 0;
        } 
        private void FinDesenrrollar(object sender, object e)
        {
            VidaGengar.Value -= 15;
            Desenrollar.Opacity = 0;
        }
        private void FinPantallaLuz(object sender, object e)
        {
            PantallaLuz.Opacity = 0;
        }
        private void DesabilitarBotones()
       {
            BolaSombra.Visibility = Visibility.Collapsed;
            Hypnosis.Visibility = Visibility.Collapsed;
            ComeSueños.Visibility = Visibility.Collapsed;
            GasVenennoso.Visibility = Visibility.Collapsed;
       }
        private void DesabilitarCurar()
        {
            HiperPoción.Visibility = Visibility.Collapsed;
            CuraTotal.Visibility = Visibility.Collapsed;
        }
        private void ActivarBotones()
        {
            Atacar.Visibility = Visibility.Visible;
            Curar.Visibility = Visibility.Visible;
        }
        private void TerminarCombate()
        {
            EstadoGengar.Visibility = Visibility.Collapsed;
            EstadoGengar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/corazon.png"));
            EstadoElectrode.Visibility = Visibility.Collapsed;
            EstadoElectrode.Source = new BitmapImage(new Uri("ms-appx:///Assets/Interfaz/corazon.png"));
            dormido =false;
            paralizado = false;
            envenenado = false;
            VidaElectrode.Value = 100;
            VidaGengar.Value = 100;
            hiperPocion = 3;
            curaTotal = 2;
            turno = 0;
            turnosDormido = 0;
            turnosPLuz = 0;
            
        } 
       
    }
}
