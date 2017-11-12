using DirectShowLib;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turret.Camera
{
    class CameraBase
    {
        public DsDevice[] GetCameras()
        {
            DsDevice[] _SystemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            return _SystemCameras;
        }
    }
}
