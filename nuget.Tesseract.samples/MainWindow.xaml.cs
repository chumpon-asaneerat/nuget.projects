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

using Tesseract;

namespace nuget.Tesseract.samples
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

        #region Button Handlers

        private void cmdBrowse_Click(object sender, RoutedEventArgs e)
        {
            ChooseImage();
        }

        private void cmdScan_Click(object sender, RoutedEventArgs e)
        {
            ScanImage();
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            ClearOutputText();
        }

        #endregion

        #region Private Methods

        private void ChooseImage()
        {
            string fileName = string.Empty;
            var fd = new OpenFileDialog();
            fd.Filter = "Jpg Images|*.jpg;*.jpeg|Png Images|*.png";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = fd.FileName;
            }
            fd.Dispose();
            fd = null;

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                img.Source = new BitmapImage(new Uri(fileName));
            }

            txtFileName.Text = fileName;
        }

        private void WriteText(string text = null)
        {
            string line = string.Empty;
            if (null != text)
            {
                line += text.Trim();
            }
            line += Environment.NewLine;
            txtOutput.Text += line;
        }

        private void ClearOutputText()
        {
            txtOutput.Text = string.Empty;
        }

        private void ScanImage()
        {
            try
            {
                string fileName = txtFileName.Text;
                using (var engine = new TesseractEngine(@"./tessdata", "tha", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(fileName))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            WriteText(string.Format("Mean confidence: {0}", page.GetMeanConfidence()));
                            WriteText(string.Format("Text (GetText): \r\n{0}", text));
                            WriteText("Text (iterator):");

                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();
                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    WriteText("<BLOCK>");
                                                }

                                                WriteText(iter.GetText(PageIteratorLevel.Word));
                                                WriteText(" ");

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    WriteText();
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                WriteText();
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }
        }

        #endregion
    }
}
