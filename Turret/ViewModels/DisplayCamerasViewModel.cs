using DirectShowLib;
using Emgu.CV;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turret.CameraModel;

namespace Turret.ViewModels
{
    class DisplayCamerasViewModel : ViewModelBase, IModalDialogViewModel
    {
        public bool? DialogResult { get { return false; } }

        private ObservableCollection<MyDataItem> myItem = new ObservableCollection<MyDataItem>();
        public ObservableCollection<MyDataItem> MyItem { get { return myItem; } }

        private ObservableCollection<Camera> camera = new ObservableCollection<Camera>();
        public ObservableCollection<Camera> Capture { get { return camera; } }


        public DisplayCamerasViewModel()
        {
            var cameras = GetCamera.GetAllSystemCameras();
            int cameraIndex = 0;

            //var c1 = new Camera(0);

            foreach (var c in cameras)
            {
                camera.Add(new Camera(cameraIndex++));
            }


            myItem.Add(new MyDataItem("BensVal1"));
            myItem.Add(new MyDataItem("BensVal2"));
            myItem.Add(new MyDataItem("BensVal3"));

            
        }

    }
}
