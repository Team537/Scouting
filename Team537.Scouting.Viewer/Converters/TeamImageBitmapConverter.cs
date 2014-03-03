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
            var frcFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("FRC", CreationCollisionOption.OpenIfExists);
            var yearFolder = await frcFolder.CreateFolderAsync("2014", CreationCollisionOption.OpenIfExists);
            var imageFile = await yearFolder.GetFileAsync(imagePath);

            await bitmapImage.SetSourceAsync(await imageFile.OpenReadAsync());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
