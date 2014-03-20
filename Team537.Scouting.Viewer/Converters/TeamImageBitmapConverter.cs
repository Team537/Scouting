using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.Converters
{
    using Windows.Storage;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media.Imaging;

    public class TeamImageBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fileInfo = value as string;
            if (fileInfo != null)
            {
                var bi = new BitmapImage();

                // The file is being opened asynchronously but we return the BitmapImage immediately.
                this.SetImageSource(bi, fileInfo);
                return bi;
            }

            return null;
        }

        private async void SetImageSource(BitmapImage bitmapImage, string imagePath)
        {
            try
            {
                var frcFolder = await KnownFolders.PicturesLibrary.GetFolderAsync("FRC");
                var yearFolder = await frcFolder.GetFolderAsync("2014");
                var imageFile = await yearFolder.GetFileAsync(imagePath);

                await bitmapImage.SetSourceAsync(await imageFile.OpenReadAsync());
            }
            catch (Exception)
            {
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
