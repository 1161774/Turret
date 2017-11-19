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

        public ObservableCollection<Mat> Frame;
        public ObservableCollection<MyDataItem> MyItem { get { return myItem; } }

        public DisplayCamerasViewModel()
        {
            myItem.Add(new MyDataItem("BensVal1"));
            myItem.Add(new MyDataItem("BensVal2"));
            myItem.Add(new MyDataItem("BensVal3"));
            //Camera camera = new Camera();
            //Frame.Add(camera.Frame);
            //camera.StartCapture();
        }

    }
}
