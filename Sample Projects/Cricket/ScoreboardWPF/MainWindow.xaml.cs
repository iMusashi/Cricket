using System;
using System.Windows;

namespace ScoreboardWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void dlgRootObject(IRootObject iro);

        private ScoreboardBL _objscoreboardbl;

        internal ScoreboardBL objscoreboardbl
        {
            get
            {
                if (_objscoreboardbl == null)
                    _objscoreboardbl = new ScoreboardBL(UpdateCricInfo);
                return _objscoreboardbl;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            objscoreboardbl.DownloadCricketInfo();
        }


        //Is this Pattern Expression/Contravariance?
        void UpdateCricInfo(IRootObject IRO)
        {
            if(IRO is RootObject scoreboardBO)
            {
                ModifyScoreboardBO(ref scoreboardBO);
                dgMatches.ItemsSource = scoreboardBO.data;
            }
            else if(IRO is RootObjectScore rscoreboardBO)
            {
                ModifyScoreboardBO(ref rscoreboardBO);
                ((Datum)dgMatches.SelectedItem).description = rscoreboardBO.description;
            }
        }

        void UpdateCricInfo(RootObject scoreboardBO)
        {
            ModifyScoreboardBO(ref scoreboardBO);
            dgMatches.ItemsSource = scoreboardBO.data;
        }

        void UpdateCricInfo(RootObjectScore scoreboardBO)
        {
            ModifyScoreboardBO(ref scoreboardBO);
            ((Datum)dgMatches.SelectedItem).description = scoreboardBO.description;
        }

        private void ModifyScoreboardBO(ref RootObject scoreboardBO)
        {
            foreach(var val in scoreboardBO.data)
            {
                string[] replacestrings = new string[] {"1", "2", "3", "4", "5", "6", "7", "8",
                    "9", "0", "/", "*", "&amp;"};
                string inputtitle = val.title;
                string[] tempttl = inputtitle.Split(replacestrings, StringSplitOptions.RemoveEmptyEntries);
                val.title = String.Join("", tempttl);
            }
        }

        private void ModifyScoreboardBO(ref RootObjectScore scoreboardBO)
        {
                string[] replacestrings = new string[] {"1", "2", "3", "4", "5", "6", "7", "8",
                    "9", "0", "/", "*", "&amp;"};
                string input = scoreboardBO.description;
                string[] temp = input.Split(replacestrings, StringSplitOptions.RemoveEmptyEntries);
                scoreboardBO.description = String.Join("", temp);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            //Find unique id of the selected row.
            var unique_id = ((Datum)dgMatches.SelectedItem).unique_id;
            //Download information related to selected match id.
            RootObjectScore rosMatchDetails = objscoreboardbl.DownloadCricketInfo(unique_id);

            var tplMatchDetails = Tuple.Create(rosMatchDetails.description, rosMatchDetails.team1, rosMatchDetails.team2);

            var objMatchDetailsViewModel = new MatchDetailsViewModel();
            objMatchDetailsViewModel.UpdateDetails(tplMatchDetails);

            dgMatches.Visibility = Visibility.Collapsed;
            ucMatchDetails.Visibility = Visibility.Visible;
        }
    }


}
