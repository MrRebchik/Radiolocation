using System.Numerics;

namespace RadiolocationLib
{
    public class Emitter
    {
        public Vector3 Position { get; private set; }
        public double Power;
        public double Frequancy { get; private set; }
        public double Duration = 0.003;
        public Receiver? self {  get; private set; }

        public Emitter(Vector3 position, double frequancy, Receiver? _self = null)
        {
            self = _self;
            Frequancy = frequancy;
            Position = position;
        }
        public void Emit()
        {
            Environment.Transmit(GenerateRay());
        }
        public void Emit(Ray ray)
        {
            Environment.Transmit(ray);
        }
        public Ray GenerateRay()
        {
            return new Ray(this, Power, Frequancy, Duration);
        }
    }
}
