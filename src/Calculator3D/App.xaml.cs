using System.Windows;

namespace Calculator3D
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
