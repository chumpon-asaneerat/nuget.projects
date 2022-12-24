#region Using

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

using System.Windows.Forms;

#endregion

namespace nuget.ML.Net.samples
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

        #region Loaded/Unloaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Button Handlers

        private void cmdSelectImage_Click(object sender, RoutedEventArgs e)
        {
            ChooseImageFile();
        }

        #endregion

        #region Private Methods

        private void ChooseImageFile()
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Jpeg image files (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            string fileName = string.Empty;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = fd.FileName;
            }
            fd.Dispose();

            if (!string.IsNullOrEmpty(fileName))
            {
                txtFileName.Text = fileName;

                var bmp = new BitmapImage(new Uri(fileName));
                imgSrc.Source = bmp;
            }
        }

        #endregion
    }
}
