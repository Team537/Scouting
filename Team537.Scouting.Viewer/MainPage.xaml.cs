﻿using Team537.Scouting.Viewer.Common;
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

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace Team537.Scouting.Viewer
{
    using Team537.Scouting.Model;
    using Team537.Scouting.Viewer.ViewModels;

    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;
        private MainPageViewModel defaultViewModel = new MainPageViewModel();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public MainPageViewModel DefaultViewModel
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

        public MainPage()
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
            var competition = new Competition
                                  {
                                      Name = "Crossroads Regional",
                                      Location = "Terre Haute, IN",
                                      ImagePath = "Assets/Competitions/crossroads.jpg"
                                  };

            //competition.Matches.Add(new Match { MatchNumber = 1, MatchType = MatchType.Practive });

            //competition.Teams.Add(new Team { Number = 48, Name = "Delphi Corporation/Nordson XALOY & Warren G. Harding High School", ImagePath = null });
            //competition.Teams.Add(new Team { Number = 71, Name = "School City of Hammond/Caterpillar/City of Hammond & School City of Hammond", ImagePath = null });
            //competition.Teams.Add(new Team { Number = 128, Name = "American Electric Power/Grandview Heights Marble Cliff Education Foundation & Grandview Heights High School", ImagePath = null });
            //competition.Teams.Add(new Team { Number = 537, Name = "Charger Robotics", ImagePath = null });

            this.defaultViewModel.Competitions.Add(competition);
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

        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedCompetition = e.ClickedItem as Competition;
            this.Frame.Navigate(typeof(ViewCompetition), selectedCompetition);
        }
    }
}