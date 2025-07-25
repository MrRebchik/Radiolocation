using System.Numerics;

namespace RadiolocationLib
{
    public class Absorber
    {
        public Vector3 Position {  get; private set; }
        public double efficientDiffusionArea;
        public Emitter Emitter {  get; private set; }
        public Receiver Receiver { get; private set; }
        public Absorber(Vector3 position)
        {
            Position = position;
            Receiver = new Receiver(Position, 1);
            Emitter = new Emitter(Position, 1, Receiver);
            Environment.Recievers.Add(Receiver);
            Receiver.RecievedRay += Reflect;
        }
        private void Reflect(Ray ray)
        {
            Ray reflected = DecreaseRay(ray);
            Emitter.Emit(reflected);
        }
        private Ray DecreaseRay(Ray ray)
        {
            return new Ray(Emitter, ray.Power *= efficientDiffusionArea, ray.Frequancy, ray.Duration);
        }
    }
}
