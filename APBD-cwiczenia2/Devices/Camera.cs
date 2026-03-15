namespace APBD_cwiczenia2.Devices
{
    public class Camera(int mpx, bool hasVideoRecording) : Device
    {
        public int Megapixels { get; set; } = mpx;
        public bool HasVideoRecording { get; set; } = hasVideoRecording;
    }
}
