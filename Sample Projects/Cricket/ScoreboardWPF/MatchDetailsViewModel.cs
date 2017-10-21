using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardWPF
{
    class MatchDetailsViewModel
    {
        public string score { get; set; }

        public string team1 { get; set; }

        public string team2 { get; set; }

        public bool CloseAction { get; set; }

        internal void UpdateDetails(Tuple<string, string, string> tplMatchDetails)
        {
            score = tplMatchDetails.Item1;
            team1 = tplMatchDetails.Item2;
            team2 = tplMatchDetails.Item3;
        }

        public DelegateCommand CloseCommand
        {
            get
            {
                return new DelegateCommand(CloseCommand_Execute);
            }
        }


        public MatchDetailsViewModel()
        {

        }

        internal void CloseCommand_Execute(object arg)
        {
            CloseAction = true;
        }
    }
}
