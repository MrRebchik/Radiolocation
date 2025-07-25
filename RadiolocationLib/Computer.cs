namespace RadiolocationLib
{
    public class Computer
    {
        public event Action<double> Calculated;
        public double simplifiedMaxDetectRange {  get; private set; }
        public double requiredEmitterPower {  get; private set; }
        Receiver Receiver;
        public Computer(Receiver receiver)
        {
            Receiver = receiver;
        }
        public void Execute(Ray ray)
        {
            simplifiedMaxDetectRange = Math.Sqrt(Math.Sqrt( 
                ray.Power * Receiver.Gain * Receiver.EfficientAntennaArea / 
                ( Math.Pow( 4 * Math.PI , 2) * Receiver.MinimalVisibleSignal ) ));
            Calculated?.Invoke(simplifiedMaxDetectRange);
        }
    }
}

