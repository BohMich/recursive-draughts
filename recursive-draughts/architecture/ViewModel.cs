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
        private string display;     //textbased representation of the board.
        private string output;      //textblock which outputs current game state.
        private string input;       //textbox which takes player's input.
        
        private RelayCommand _commandStart;
        private RelayCommand _commandStartNewGame;
        private RelayCommand _commandSendRequest;

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
        public ICommand cmdSendRequest
        {
            get
            {
                if (_commandSendRequest == null)
                {
                    _commandSendRequest = new RelayCommand(o => { SendUserInput(); }, o => true);
                }
                return _commandSendRequest;
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
            Output = "Welcome to draughts by Mike. \n Please choose your action.";
        }
        private void SendUserInput()
        { 
            Output = Input;


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
        public string Output
        {
            get { return output; }
            set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }
        public string Input
        {
            get { return input; }
            set
            {
                input = value;
                OnPropertyChanged("Input");
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
