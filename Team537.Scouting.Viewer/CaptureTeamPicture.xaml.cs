using Team537.Scouting.Viewer.Common;
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
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Team537.Scouting.Viewer
{
    using Windows.Devices.Enumeration;
    using Windows.Media.Capture;
    using Windows.Media.MediaProperties;
    using Windows.Storage;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Media.Imaging;

    using Team537.Scouting.Model;
    using Team537.Scouting.Viewer.ViewModels;

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CaptureTeamPicture : Page
    {
        private MediaCapture mediaCapture;
        private NavigationHelper navigationHelper;
        private TeamDetailsViewModel defaultViewModel = new TeamDetailsViewModel();

        private int currentDevice;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public TeamDetailsViewModel DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public CaptureTeamPicture()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var team = e.NavigationParameter as Team;
            if (team == null)
            {
                var dialog = new MessageDialog("Invalid Team Selected");
                await dialog.ShowAsync();
                return;
            }

            this.defaultViewModel.Team = team;

            this.LoadCamera();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            await mediaCapture.StopPreviewAsync();
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void CaptureButton_OnClick(object sender, RoutedEventArgs e)
        {
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage
            var filename = string.Format("Team{0}.jpg", this.defaultViewModel.Team.Number);

            var frcFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("FRC", CreationCollisionOption.OpenIfExists);
            var yearFolder = await frcFolder.CreateFolderAsync("2014", CreationCollisionOption.OpenIfExists);

            var file = await yearFolder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);

            // take photo
            await mediaCapture.CapturePhotoToStorageFileAsync(imgFormat, file);

            // Get photo as a BitmapImage
            this.defaultViewModel.Team.ImagePath = file.Name;

            // go back to team
            NavigationHelper.GoBack();
        }

        private async void SwitchButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.LoadCamera();
        }

        private async void LoadCamera()
        {
            if (mediaCapture != null)
            {
                await mediaCapture.StopPreviewAsync();
            }

            var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            currentDevice = (currentDevice + 1) % devices.Count;

            mediaCapture = new MediaCapture();
            await mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings { VideoDeviceId = devices[currentDevice].Id });

            PicturePreview.Source = this.mediaCapture;
            await mediaCapture.StartPreviewAsync();
        }
    }
}
