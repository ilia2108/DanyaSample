using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace danya_MediaSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var Now = DateTime.Now;
            txt_Date.Text = $"Today is\n{Now.Day}.{Now.Month}.{Now.Year}";
            if(Now.Year == 2018 && Now.Month == 3 && Now.Day == 18)
            {
                txt_Date.Text += "\nСЕГОДНЯ ВЫБОРЫ!!";    
                Media.AudioCategory = Windows.UI.Xaml.Media.AudioCategory.Media;
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Media");
                StorageFile sf = await Folder.GetFileAsync("SampleMedia.mp3");
                Media.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
                Media.Play();
            }
        }
    }
}
