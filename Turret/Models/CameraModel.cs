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
    public class Camera
    {

        private Capture capture;
        private Mat _frame = new Mat();
        private Timer t;

        public Mat Frame
        {
            get
            {
                if (_frame == null) return new Mat();
                return _frame;
            }
        }
        public Camera()
        {
            capture = new Capture();
        }

        public Camera(int index)
        {
            capture = new Capture(index);
        }

        public Camera(string source)
        {
            capture = new Capture(source);
        }

        public void StartCapture()
        {
            t = new Timer(timerThread, new object(), 100, 100);
        }

        private void timerThread(object state)
        {
            _frame = capture.QueryFrame();
        }

        public void StopCapture()
        {
            t.Dispose();
        }

        public static DsDevice[] GetAllSystemCameras()
        {
            DsDevice[] _SystemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            return _SystemCameras;
        }
    }


    public class MyDataItem : DependencyObject
    {
        public string MyText
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(MyDataItem), new UIPropertyMetadata(""));

        public MyDataItem(string val)
        {
            MyText = val;
        }
    }

    public class MyOtherDataItem : DependencyObject
    {
        // Note how the TitleProperty is a DependencyProperty, and the Title CLR property is
        // here just for convenience. The string itself is not stored in the object, it's
        // stored in the WPF framework.

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MyDataItem), new UIPropertyMetadata(""));

        public MyOtherDataItem(string title)
        {
            Title = title;
        }
    }
}
