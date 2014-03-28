using Team537.Scouting.Viewer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=321224

namespace Team537.Scouting.Viewer
{
    using Team537.Scouting.Model;
    using Team537.Scouting.Viewer.ViewModels;

    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class TeamHub : Page
    {
        private NavigationHelper navigationHelper;
        private TeamHubViewModel defaultViewModel = new TeamHubViewModel();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public TeamHubViewModel DefaultViewModel
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

        public TeamHub()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }


        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var team = e.NavigationParameter as Team;
            if (team == null)
            {
                return;
            }

            this.defaultViewModel.Team = team;

            var teamNumber = team.Number;
            var schedule = team.Competition.Matches.Where(m => m.Blue1.Number == teamNumber || m.Blue2.Number == teamNumber || m.Blue3.Number == teamNumber
                || m.Red1.Number == teamNumber || m.Red2.Number == teamNumber || m.Red3.Number == teamNumber);

            foreach (var match in schedule)
            {
                this.defaultViewModel.Schedule.Add(match);
            }
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
