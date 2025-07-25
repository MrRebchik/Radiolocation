using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Axes;
using RadiolocationLib;

namespace RaiolocationVisualizer
{
    public partial class Form1 : Form
    {
        private readonly PlotView plotView = new PlotView();
        private readonly PlotModel plotModel = new PlotModel();
        private readonly LineSeries series = new LineSeries();

        private double y;
        private void SetValue(double input)
        {
            y = input;
        }

        public Form1()
        {
            InitializeComponent();
            plotView.Dock = DockStyle.Fill;
            Controls.Add(plotView);
            plotModel.Series.Add(series);
            plotView.Model = plotModel;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plotModel.Axes.Clear();
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Ёффективна€ площадь антенны" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "ћаксимальна€ дальность обнаружени€" });

            series.Color = OxyColors.Blue;
            series.StrokeThickness = 2;
            CalculateAndPlot();
        }

        private void CalculateAndPlot()
        {
            RadiolocationLib.Environment.FadingCoefficient = 0.0000001;
            Locator locator = new(10000000000); //10 √√ц
            Absorber absorber = new(new System.Numerics.Vector3(20000, 750, 0));
            locator.Receiver.EfficientAntennaArea = 0.1; // 0.1 м^2
            locator.Receiver.MinimalVisibleSignal = 0.000000000000001;
            locator.Computer.Calculated += SetValue;
            absorber.efficientDiffusionArea = 0.01;//F-22 Raptor
            locator.Emitter.Power = 19000;

            for (double i = 0.001; i < 1.2; i += 0.001)
            {
                //locator.Emitter.Power = i * 1000;// к¬т
                locator.Receiver.EfficientAntennaArea = i;
                locator.Seek();
                double y = this.y;

                series.Points.Add(new DataPoint(i, y));
                if (y > absorber.Position.X)
                    break;
            }
            plotModel.InvalidatePlot(true);
        }
    }
}
