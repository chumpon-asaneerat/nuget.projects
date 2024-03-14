#region Using

using Microsoft.Owin.Cors;
using Microsoft.Owin;
using Owin;
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
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;

#endregion

namespace nuget.Owin.WebServer.SelfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Run();
        }

        #endregion

        #region Private Methods

        private void Run()
        {

        }

        #endregion
    }

    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
