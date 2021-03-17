using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia;
using HieloCalculator.ViewModel;

namespace HieloCalculator
{   

    public class MainWindow : Window{

        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new HieloViewModel();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }
    }
    }