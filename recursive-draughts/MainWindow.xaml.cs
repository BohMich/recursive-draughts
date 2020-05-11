using recursive_draughts.architecture;
using Autofac;
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

namespace recursive_draughts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IViewModel _viewModel;

        public MainWindow()
        {
            //Autofac IoC container initialization
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _viewModel = scope.Resolve<IViewModel>();
            }

            InitializeComponent();

            DataContext = _viewModel;
        }


        
    }
}
