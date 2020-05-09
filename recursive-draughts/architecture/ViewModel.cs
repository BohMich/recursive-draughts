using System;
using System.ComponentModel;
using System.Windows.Input;

namespace recursive_draughts.architecture
{
    public class ViewModel : INotifyPropertyChanged
    { 
        private string display;
        private RelayCommand _commandStart;
        private RelayCommand _commandStartNewGame;
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
            //Make connection with draughts. 
        }
        public ViewModel()
        {
            display = "DISPLAY INITIALIZED";
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
