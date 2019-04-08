using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G00303598_PROJECT_19.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
		public CameraPage ()
		{
			InitializeComponent ();
		}

        private async void BtnTakePhoto_Clicked(object sender, EventArgs e)
        {
            // Camera functionality
            // https://github.com/jamesmontemagno/MediaPlugin

            await CrossMedia.Current.Initialize();
            

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                // Specify directory here
                // Directory = "Sample",
                // Name = "test.jpg"
                SaveToAlbum = true
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

        }
    }
}