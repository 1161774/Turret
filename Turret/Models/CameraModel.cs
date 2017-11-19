using DirectShowLib;
using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Turret.CameraModel
{
    public struct GetCamera
    {
        public static DsDevice[] GetAllSystemCameras()
        {
            DsDevice[] _SystemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            return _SystemCameras;
        }
    }

    public class Camera : DependencyObject
    {
        Capture capture;
        Timer t;
        public Mat Frame
        {
            get { return (Mat)GetValue(FrameProperty); }
            set { SetValue(FrameProperty, value); }
        }

        public static readonly DependencyProperty FrameProperty =
            DependencyProperty.Register("Frame", typeof(Mat), typeof(Camera));

        public Camera(int index)
        {
            Frame = new Mat();
            capture = new Capture(index);
            t = new Timer(GetNewFrame, new object(), 100, 100);
        }

        private void GetNewFrame(object state)
        {
            Frame = capture.QueryFrame();
        }

    }

    public class MyDataItem : DependencyObject
    {
        public string MyText
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(MyDataItem), new UIPropertyMetadata(""));

        public MyDataItem(string val)
        {
            MyText = val;
        }
    }
}
