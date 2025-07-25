using System.Numerics;

namespace RadiolocationLib
{
    public class Locator
    {
        public Emitter Emitter {  get; private set; }
        public Receiver Receiver { get; private set; }
        public Computer Computer { get; private set; }
        public Vector3 Position { get; private set; }
        public Locator(double frequancy)
        {
            Position = new Vector3(0, 0, 0);
            Receiver = new Receiver(Position, frequancy);
            Emitter = new Emitter(Position, frequancy, Receiver);
            Computer = new Computer(Receiver);
            Environment.Recievers.Add(Receiver);
            Receiver.RecievedRay += Computer.Execute;
        }
        public void Seek()
        {
            Emitter.Emit();
        }
    }
}
