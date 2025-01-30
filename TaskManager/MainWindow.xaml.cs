using System.Windows;
using ViewModel;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.Create.CreateDatabase();
            this.DataContext = new TareaViewModel();
        }
    }    
}