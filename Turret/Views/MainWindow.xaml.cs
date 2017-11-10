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
using System.Reflection;
using log4net;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.WPF;

namespace Turret.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainView_Closing;
        }

        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
                if (((MainViewModel)(this.DataContext)).Data.IsModified)
                if (!((MainViewModel)(this.DataContext)).PromptSaveBeforeExit())
                {
                    e.Cancel = true;
                    return;
                }
            */
            Log.Info("Closing App");
        }

        private void image1_Initialized(object sender, EventArgs e)
        {
            Mat image = new Mat(100,400, DepthType.Cv8U, 3);
            image.SetTo(new Bgr(255, 255, 255).MCvScalar);
            CvInvoke.PutText(image, "Hello, World", new System.Drawing.Point(10, 50), FontFace.HersheyPlain, 3.0, new Bgr(255, 0, 0).MCvScalar);

            image1.Source = BitmapSourceConvert.ToBitmapSource(image);
        }
    }
}
