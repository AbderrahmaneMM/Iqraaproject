//using ObjCRuntime;
using Microsoft.Maui.Controls;
using System.Diagnostics.Metrics;
using Plugin.Maui.Audio;
//using AVFoundation;
namespace Iqraaproject;

public partial class kissa : ContentPage
{
    private IAudioManager audioManager;
    private IAudioPlayer audioPlayer;

    int p = 0;
    int v = 1;
    public string f { get; set; }
    public string s { get; set; }
    public int x { get; set; }

    public kissa( string f, string s,int stop, IAudioManager audioManager)
    {
        
        InitializeComponent();
        //InitializeAudioPlayer();
        this.audioManager = audioManager;
        this.f = f;
        this.s = s;
        this.x=stop;
        Paga(this.f, this.s,p);
      
        
              if (p > 0)Audio.IsEnabled = true;
        }
   
    public async void Paga(string f ,string s ,int p )
    {
        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(s+" ("+v+").ogg"));
        safha.Source = "C:\\Users\\DELL\\source\\repos\\Iqraaproject\\Iqraaproject\\Resources\\Images\\"+f+"\\"+s+" ("+p+").jpg";
    }
    
    private void Updatecount()
    {
        string cs = p.ToString();
        l.Text = $"{p}الصفحة رقم";
    }
    private  void strt_Clicked(object sender, EventArgs e)
    {
        audioPlayer?.Pause();
        if (p == 0)
        {
           Audio.IsEnabled= true;
            p= 1;
            Updatecount();
            Paga(this.f, this.s, p);
        }
        else
        {
            Audio.IsEnabled = false;
            p = 0;
            Updatecount();
            Paga(this.f, this.s, p);
        }
    }

    private void Home_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new MainPage(audioManager));
        audioPlayer.Stop();
    }

    private void next_Clicked(object sender, EventArgs e)
    {
        audioPlayer?.Pause();
        pres.IsEnabled = true; Audio.IsEnabled = true;
        if (p < x)
        {
         if ( p>0 && v<=x ) { v++; }
            p++;
            Updatecount();
            Paga(this.f, this.s, p);
        }
        else
        {
            next.IsEnabled = false;
            l.Text = $"الصفحة {p}الاخيرة";
        }
      
    }

    private void pres_Clicked(object sender, EventArgs e)
    {
        audioPlayer?.Pause();
        next.IsEnabled = true;
        Audio.IsEnabled = true;
        if (p>0)
        {
            if ( v >1) { v--; }
            p--;
            Updatecount();
            Paga(this.f, this.s, p);
        }
        else
        {
            pres.IsEnabled = false;
           
        }
    }

    private async void Audio_Clicked(object sender, EventArgs e)
    {  
        audioPlayer.Play();
        Pause.IsEnabled = true;
        repeat.IsEnabled = true;
    }

    private async void Pause_Clicked(object sender, EventArgs e)
    {
        if (audioPlayer.IsPlaying) { audioPlayer.Pause(); }
    }

    private async void repeat_Clicked(object sender, EventArgs e)
    {
       if(audioPlayer.IsPlaying) { audioPlayer.Stop();}
    }
}