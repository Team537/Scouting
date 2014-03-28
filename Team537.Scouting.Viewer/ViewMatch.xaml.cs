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
    using Team537.Scouting.Model;
    using Team537.Scouting.Viewer.ViewModels;

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ViewMatch : Page
    {

        private NavigationHelper navigationHelper;
        private ViewMatchViewModel defaultViewModel = new ViewMatchViewModel();

        private int numberOfMatches = 5;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ViewMatchViewModel DefaultViewModel
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


        public ViewMatch()
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
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var match = e.NavigationParameter as Match;
            if (match == null)
            {
                return;
            }

            this.defaultViewModel.Match = match;
            this.LoadMatches(0);
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void LoadMatches(int matches)
        {
            this.defaultViewModel.Match.Red1.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Red1, matches);
            this.defaultViewModel.Match.Red2.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Red2, matches);
            this.defaultViewModel.Match.Red3.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Red3, matches);

            this.defaultViewModel.Match.Blue1.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Blue1, matches);
            this.defaultViewModel.Match.Blue2.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Blue2, matches);
            this.defaultViewModel.Match.Blue3.MatchSummaryData = MatchSummaryData2014.Calculate(this.defaultViewModel.Match.Blue3, matches);
        }

        private void MatchCountSlider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var source = sender as Slider;
            if (source == null)
            {
                return;
            }

            this.LoadMatches((int)source.Value);
        }

        private void TeamDetailsClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var team = button.DataContext as Team;
            if (team == null)
            {
                return;
            }

            team.Competition = this.defaultViewModel.Match.Competition;
            this.Frame.Navigate(typeof(TeamHub), team);
        }
    }
}
