using Code_Yggdrasil.Core;
using Code_Yggdrasil.MVVM.Views.ContentPages;
using Code_Yggdrasil.MVVM.Views.PopUpPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Code_Yggdrasil.MVVM.ViewModels
{
    class OverseerViewModel : ObservableObject
    {

        #region POP UP BAR VARIABLES
        private double _popUpBarWidth;

        public double popUpBarWidth
        {
            get { return _popUpBarWidth; }
            set { _popUpBarWidth = value; OnPropertyChanged(); }
        }

        public RelayCommand togglePopUpCommand { get; set; }
        #endregion


        #region PAGE SET UP
        private object _currentContentPage;

        public object CurrentContentPage
        {
            get { return _currentContentPage; }
            set { _currentContentPage = value; OnPropertyChanged(); }
        }

        private object _currentPopUpPage;

        public object CurrentPopUpPage
        {
            get { return _currentPopUpPage; }
            set { _currentPopUpPage = value; OnPropertyChanged(); }
        }


        public RelayCommand Navigate { get; set; }

        Dictionary<string, object> myPages = new Dictionary<string, object>();
        Dictionary<string, object> myBars = new Dictionary<string, object>();

        private AssetsPage _assetsPage { get; set; }
        private CalendarPage _calendarPage { get; set; }
        private DashBoardPage _dashBoardPage { get; set; }
        private ProjectPage _projectsPage { get; set; }
        private ToDoPage _toDoPage { get; set; }
        private UserPage _usersPage { get; set; }

        private UserBar _userBar { get; set; }
        private ProjectBar _projectBar { get; set; }

        #endregion


        public OverseerViewModel()
        {
            // Sets the initial variable and command to control the pop up bar
            #region Popupbar
            popUpBarWidth = 180f;
            togglePopUpCommand = new RelayCommand(TogglePopUpBar, CanTogglePopUpBar);
            #endregion

            // Sets up the pages for navigation and initialises values
            #region Navigation
            // Defines the pages
            _assetsPage = new AssetsPage{DataContext = this};
            myPages.Add("Assets", _assetsPage);

            _calendarPage = new CalendarPage{DataContext = this};
            myPages.Add("Calendar", _calendarPage);

            _dashBoardPage = new DashBoardPage{DataContext = this};
            myPages.Add("DashBoard", _dashBoardPage);

            _projectsPage = new ProjectPage{DataContext = this};
            myPages.Add("Projects", _projectsPage);

            _toDoPage = new ToDoPage{DataContext = this};
            myPages.Add("ToDo", _toDoPage);

            _usersPage = new(){DataContext = this};
            myPages.Add("Users", _usersPage);

            _userBar = new() { DataContext=this};
            myBars.Add("Users", _userBar);

            _projectBar = new() { DataContext=this};
            myBars.Add("Projects", _projectBar);

            CurrentContentPage = myPages["Users"];
            CurrentPopUpPage = myBars["Users"];
            Navigate = new RelayCommand(navigate, canNavigate);
            #endregion

        }


        /// <summary>
        /// Switches between the states of the popupbar [widths]
        /// </summary>
        /// <param name="parameter"></param>
        private void TogglePopUpBar(object parameter)
        {
            if (popUpBarWidth == 180f)
            {
                popUpBarWidth = 2f;
            }else { popUpBarWidth = 180f; }
        }

        /// <summary>
        /// Tells the relay command whether the bar can be toggled
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool CanTogglePopUpBar(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Facilitates navigation through the pages
        /// </summary>
        /// <param name="parameter"></param>
        private void navigate(object parameter)
        {
            string key = (string)parameter;
            if(key == null) { return; }

            CurrentContentPage = myPages[key];
            if (myBars.ContainsKey(key)) { CurrentPopUpPage = myBars[key]; }
        }

        /// <summary>
        /// Tells the relay command whether pages can be navigated
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private bool canNavigate(object parameter)
        {
            return true;
        }
    }

}
