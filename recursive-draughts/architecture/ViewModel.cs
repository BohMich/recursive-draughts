using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;

namespace recursive_draughts.architecture
{
    public class ViewModel : INotifyPropertyChanged
    { 
        private string display;
        private RelayCommand _commandStart;
        private RelayCommand _commandStartNewGame;

        private IDraughts _draughts;

        public ICommand cmdStartExecution
        {
            get
            {
                if(_commandStart == null)
                {
                    _commandStart = new RelayCommand(o => { HandleTestClick(); } , o => true);
                }
                return _commandStart;
            }
        }
        public ICommand cmdStartNewGame
        {
            get
            {
                if (_commandStartNewGame == null)
                {
                    _commandStartNewGame = new RelayCommand(o => { StartNewGame(); }, o => true);
                }
                return _commandStartNewGame;
            }
        }

        private void HandleTestClick()
        {
            Display = "test1";
        }
        private void StartNewGame()
        {
            _draughts.StartNewGame();
            Display = ResetDisplay();
        }

        private string ResetDisplay()
        {
            var fields = _draughts.GetFields();
            string display = "";
            
            for(int y = 0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    if(fields[x,y].Pawn != null)
                    {
                        display += " ";
                        display += fields[x, y].Pawn.Colour;
                        display += " ";
                    }
                    else
                    {
                        display += " _ ";
                    }
                }
                display += "\n";
            }

            StringBuilder temp = new StringBuilder();
            temp.Insert(0,display);
            temp.Replace(Team._COLOURS[0].ToString(), "O");
            temp.Replace(Team._COLOURS[1].ToString(), "X");

            display = temp.ToString();

            return display;
        }

        public ViewModel()
        {
            display = "DISPLAY INITIALIZED";
            _draughts = new Draughts();
        }


        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
    }

    
 

}
