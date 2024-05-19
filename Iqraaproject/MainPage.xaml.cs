using Plugin.Maui.Audio;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
//using Android.Media;
//using Android.AdServices.AdIds;
namespace Iqraaproject
{
    public partial class MainPage : ContentPage
    {   
        private IAudioManager audioManager;

        public string f { get; set; }
        public string s { get; set; }
        public int stop {  get; set; }
        public IAudioManager AudioManager { get; set; }
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }
      
        private void Layla_Clicked(object sender, EventArgs e)
        {
            
            f ="rouge"; s ="lila"; stop = 16;
            Navigation.PushAsync(new kissa(f, s,stop,audioManager));
        }

        private void Arnab_Clicked(object sender, EventArgs e)
        {

            f = "torture"; s = "Arnab"; stop = 25;
            Navigation.PushAsync(new kissa(f, s, stop, audioManager));
        }

        private void Namla_Clicked(object sender, EventArgs e)
        {

            f = "sigale"; s = "Namla"; stop = 8;
            Navigation.PushAsync(new kissa(f, s, stop, audioManager));
        }


    }

}
