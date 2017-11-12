using MvvmDialogs;
using log4net;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Input;
using System.Xml.Linq;
using Turret.Views;
using Turret.Utils;
using Turret.Camera;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Turret.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Parameters
        private readonly IDialogService DialogService;

        /// <summary>
        /// Title of the application, as displayed in the top bar of the window
        /// </summary>
        public string Title
        {
            get { return "Turret"; }
        }
        #endregion

        public Mat MainWindow
        {
            get
            {
                Mat image = new Mat(100, 400, DepthType.Cv8U, 3);
                image.SetTo(new Bgr(255, 255, 255).MCvScalar);
                CvInvoke.PutText(image, "Hello, World", new System.Drawing.Point(10, 50), FontFace.HersheyPlain, 3.0, new Bgr(255, 0, 0).MCvScalar);
                return image;
            }
        }

    #region Constructors
    public MainViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new DialogService();
        }

        #endregion

        #region Methods

        #endregion

        #region Commands
        public RelayCommand<object> SampleCmdWithArgument { get { return new RelayCommand<object>(OnSampleCmdWithArgument); } }

        public ICommand SaveAsCmd { get { return new RelayCommand(OnSaveAsTest, AlwaysFalse); } }
        public ICommand SaveCmd { get { return new RelayCommand(OnSaveTest, AlwaysFalse); } }
        public ICommand OpenCmd { get { return new RelayCommand(OnOpenTest, AlwaysTrue); } }
        public ICommand ShowAboutDialogCmd { get { return new RelayCommand(OnShowAboutDialog, AlwaysTrue); } }
        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, AlwaysTrue); } }

        private bool AlwaysTrue() { return true; }
        private bool AlwaysFalse() { return false; }

        private void OnSampleCmdWithArgument(object obj)
        {
            // TODO
        }

        private void OnSaveAsTest()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "Save As",
                Filter = "Sample (.xml)|*.xml",
                CheckFileExists = false,
                OverwritePrompt = true
            };

            bool? success = DialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                // Do something
                Log.Info("Saving file: " + settings.FileName);
            }
        }
        private void OnSaveTest()
        {
            // TODO
        }
        private void OnOpenTest()
        {
            var cb = new CameraBase();
            var cameras = cb.GetCameras();

            foreach(var c in cameras)
            {

            }


        }
        private void OnShowAboutDialog()
        {
            Log.Info("Opening About dialog");
            AboutViewModel dialog = new AboutViewModel();
            var result = DialogService.ShowDialog<About>(this, dialog);
        }
        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
        #endregion

        #region Events

        #endregion
    }
}
