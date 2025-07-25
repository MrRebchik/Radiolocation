using System.Numerics;

namespace RadiolocationLib
{
    public class Receiver
    {
        public double EfficientAntennaArea;
        public double MinimalVisibleSignal;
        public double Frequancy {  get; private set; }
        public double Wavelength => Consts.SpeedOfLight / Frequancy;
        public double Gain => 4 * Math.PI * EfficientAntennaArea / Math.Pow(Wavelength, 2);
        public Vector3 Position {  get; private set; }
        public event Action<Ray> RecievedRay;
        public Receiver(Vector3 position, double frequancy)
        {
            Position = position;
            Frequancy = frequancy;
        }
        public void Recieve(Ray ray)
        {
            RecievedRay?.Invoke(ray);
        }
    }
}
