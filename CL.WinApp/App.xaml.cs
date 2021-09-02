using CL.Model;
using System.Windows;

namespace CL.WinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager LeManager { get; private set; } = new Manager(new Stub.Stub());

        public App()
        {
            LeManager.LoadData();
        }
    }
}
