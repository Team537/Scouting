using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.ViewModels
{
    using System.Collections.ObjectModel;

    using Team537.Scouting.Model;

    public class MainPageViewModel : NotifyObject
    {
        public ObservableCollection<Competition> Competitions { get; private set; }

        public MainPageViewModel()
        {
            Competitions = new ObservableCollection<Competition>();
        }
    }
}
