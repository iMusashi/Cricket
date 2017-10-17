using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;

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
        List<string> lst = new List<string>();


        //Is this Pattern Matching?
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
            var unique_id = ((Datum)dgMatches.SelectedItem).unique_id;
            objscoreboardbl.DownloadCricketInfo(unique_id);
        }
    }


}
