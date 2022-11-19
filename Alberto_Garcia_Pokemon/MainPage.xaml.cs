using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using MUXC = Microsoft.UI.Xaml.Controls;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Alberto_Garcia_Pokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            Control_volumen.Value = 50;
            OpeningTheme.Volume = 0.5;

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Version 1.0",
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintWrap = true,
                                }
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SecondaryTile myTile = new SecondaryTile("Favorito", "Dos", "Tres", new Uri("ms-appx:///Assets/Interfaz/logo.jpg"), Windows.UI.StartScreen.TileSize.Square150x150);
            myTile.DisplayName = "IPOkemon";
            myTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await myTile.RequestCreateAsync();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Snorlax ha evolucionado")
            .AddText("Puedes ver más información en IPOkemon")
            .AddInlineImage(new Uri("ms-appx:///Assets/Interfaz/Snorlax.jpg"))
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/Interfaz/logo.jpg"), ToastGenericAppLogoCrop.Circle)
            .Show();
        }

        private void botonPokedex_Click(object sender, RoutedEventArgs e)
        {
            VistaPrincipal.Visibility = Visibility.Collapsed;
            VistaCombate.Visibility = Visibility.Collapsed;
            VistaPokedex.Visibility = Visibility.Visible;
            
        }

        private void botonInicio_Click(object sender, RoutedEventArgs e)
        {
            VistaPrincipal.Visibility = Visibility.Visible;
            VistaPokedex.Visibility = Visibility.Collapsed;
            VistaCombate.Visibility = Visibility.Collapsed;
            
            
        }

        private void botonCombatir_Click(object sender, RoutedEventArgs e)
        {
            VistaPrincipal.Visibility = Visibility.Collapsed;
            VistaPokedex.Visibility = Visibility.Collapsed;
            VistaCombate.Visibility = Visibility.Visible;
            
            

            
        }

        private void configuración_click(object sender, RoutedEventArgs e)
        {
            VistaPrincipal.Visibility = Visibility.Collapsed;
            VistaPokedex.Visibility = Visibility.Collapsed;
            VistaCombate.Visibility = Visibility.Collapsed;
          
        }

        private void CambiarVolumen(object sender, RangeBaseValueChangedEventArgs e)
        {
           if(Control_volumen != null)
            {
                OpeningTheme.Volume = Control_volumen.Value /100 ;
            }
        }
    }
}
