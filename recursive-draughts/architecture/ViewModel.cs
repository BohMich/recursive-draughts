using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;
using recursive_draughts.architecture.DataObjects;

namespace recursive_draughts.architecture
{
    public class ViewModel : INotifyPropertyChanged, IViewModel
    {
        private string display;
        private RelayCommand _commandStart;
        private RelayCommand _commandStartNewGame;

        private IDraughts _draughts;

        public ICommand cmdStartExecution
        {
            get
            {
                if (_commandStart == null)
                {
                    _commandStart = new RelayCommand(o => { HandleTestClick(); }, o => true);
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

            display += ("  ");
            for (int i = 0; i < 10; i++)
            {
                display += ("  ");
                display += (i.ToString());
                display += (" ");
            }

            display += "\n";
            for (int y = 0; y < 10; y++)
            {
                display += (y);
                display += (" | ");
                for (int x = 0; x < 10; x++)
                {

                    if (fields[x, y].Pawn != null)
                    {

                        display += fields[x, y].Pawn.Colour;

                    }
                    else
                    {
                        display += "_";
                    }
                    display += (" | ");
                }
                display += "\n";
            }

            display += ("  ");
            for (int i = 0; i < 10; i++)
            {
                display += ("  ");
                display += (i.ToString());
                display += (" ");
            }

            StringBuilder temp = new StringBuilder();
            temp.Insert(0, display);
            temp.Replace(Team._COLOURS[0].ToString(), "0");
            temp.Replace(Team._COLOURS[1].ToString(), "#");

            display = temp.ToString();

            return display;
        }

        public ViewModel(IDraughts draughts)
        {
            display = "DISPLAY INITIALIZED";
            _draughts = draughts;
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }




}
