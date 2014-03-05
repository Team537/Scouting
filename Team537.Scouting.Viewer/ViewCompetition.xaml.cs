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
    using System.Threading.Tasks;

    using Windows.UI.Popups;

    using Team537.Scouting.Model;
    using Team537.Scouting.Viewer.Data;
    using Team537.Scouting.Viewer.ViewModels;

    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class ViewCompetition : Page
    {
        private NavigationHelper navigationHelper;
        private ViewCompetitionViewModel defaultViewModel = new ViewCompetitionViewModel();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ViewCompetitionViewModel DefaultViewModel
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

        public ViewCompetition()
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
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (this.defaultViewModel.Competition != null)
            {
                return;
            }

            var competition = e.NavigationParameter as Competition;

            if (competition == null)
            {
                var dialog = new MessageDialog("Invalid Competition Selected");
                await dialog.ShowAsync();
                return;
            }

            if (!competition.Matches.Any() || !competition.Teams.Any())
            {
                competition = await CompetitionDataStorage.LoadCompetition(competition);
            }

            this.defaultViewModel.Competition = competition;
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

        private void TeamsGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var team = e.ClickedItem as Team;
            this.Frame.Navigate(typeof(TeamDetails), team);
        }

        private void AddTeamButton_OnClick(object sender, RoutedEventArgs e)
        {
            var team = new Team();
            this.defaultViewModel.Competition.Teams.Add(team);
            this.Frame.Navigate(typeof(TeamDetails), team);
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            CompetitionDataStorage.SaveCompetition(this.defaultViewModel.Competition);
        }
    }
}
