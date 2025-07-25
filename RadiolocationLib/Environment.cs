using System.Numerics;

namespace RadiolocationLib
{
    public static class Environment
    {
        public static double FadingCoefficient;
        public static List<Receiver> Recievers = new();
        public static void Transmit(Ray ray)
        {
            foreach (Receiver receiver in Recievers)
            {
                if (ray.origin.self != receiver)
                {
                    Decrease(ray, GetDistance(ray.origin, receiver));
                    receiver.Recieve(ray);
                }
            }
        }
        private static void Decrease(Ray ray, double distance)
        {
            double atmosphereDecrease = Math.Exp(-FadingCoefficient * distance);
            ray.Power = ray.Power * atmosphereDecrease;
        }
        private static double GetDistance(Emitter start, Receiver end)
        {
            return Vector3.Distance(start.Position, end.Position);
        }
    }
}
