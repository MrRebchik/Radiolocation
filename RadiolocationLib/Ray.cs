namespace RadiolocationLib
{
    public class Ray
    {
        public double Power;
        public double Frequancy;
        public double Duration;
        public Emitter origin { get; private set; }
        public Ray(Emitter _origin, double power, double frequancy, double duration)
        {
            origin = _origin;
            Power = power;
            Frequancy = frequancy;
            Duration = duration;
        }
        public double Wavelength()
        {
            return Consts.SpeedOfLight / Frequancy;
        }
    }
}
