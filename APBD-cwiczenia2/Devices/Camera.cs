namespace APBD_cwiczenia2.Devices
{
    public class Camera(int id, string name, decimal rentalPrice, string description, int mpx, bool hasVideoRecording) : Device(id, name, rentalPrice, description)
    {
        public int Megapixels { get; } = mpx;
        public bool HasVideoRecording { get; } = hasVideoRecording;
        public override string ToString()
        {
            return $"{BasePrint()} {mpx}mpx, Can record: {(HasVideoRecording ? "yes" : "no")}";
        }
    }
}
