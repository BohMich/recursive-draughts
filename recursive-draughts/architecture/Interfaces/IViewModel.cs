using System.ComponentModel;
using System.Windows.Input;

namespace recursive_draughts.architecture
{
    public interface IViewModel
    {
        ICommand cmdStartExecution { get; }
        ICommand cmdStartNewGame { get; }
        string Display { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}