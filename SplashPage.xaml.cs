using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            // Configura um temporizador para esperar 3 segundos e, em seguida, navegar para a próxima página.
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                // Navega para a próxima página após 3 segundos.
                Navigation.PushAsync(new Login());
                return false; // Retorna false para parar o temporizador.
            });
        }

    }
}