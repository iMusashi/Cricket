using System.Windows;
using System.Windows.Controls;

namespace ScoreboardWPF
{
    /// <summary>
    /// Interaction logic for MatchDetails.xaml
    /// </summary>
    public partial class MatchDetails : UserControl
    {
        public MatchDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
