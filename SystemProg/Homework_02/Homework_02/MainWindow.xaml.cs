using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            var configurator = new AlgorithmConfigurator("Main", 20, 1000);

            ThreadPool.QueueUserWorkItem(_ => FibonacciSearch(configurator, cancellationTokenSource.Token));
            ThreadPool.QueueUserWorkItem(_ => FactorialSearch(configurator, cancellationTokenSource.Token));
            ThreadPool.QueueUserWorkItem(_ => PrimeSearch(configurator, cancellationTokenSource.Token));
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void FibonacciSearch(AlgorithmConfigurator configurator, CancellationToken cancellationToken)
        {
            AddTextToOutput($"Fibonacci search started for algorithm: {configurator.Name}");

            for (int i = 0; i < configurator.Count && !cancellationToken.IsCancellationRequested; i++)
            {
                int fibNumber = CalculateFibonacci(i);
                AddTextToOutput($"Fibonacci number: {fibNumber}");

                Thread.Sleep(configurator.Delay);
            }
        }

        private int CalculateFibonacci(int n)
        {
            if (n <= 1)
                return n;
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }

        private void FactorialSearch(AlgorithmConfigurator configurator, CancellationToken cancellationToken)
        {
            AddTextToOutput($"Factorial search started for algorithm: {configurator.Name}");

            int factorial = 1;
            for (int i = 1; i <= configurator.Count && !cancellationToken.IsCancellationRequested; i++)
            {
                factorial *= i;
                AddTextToOutput($"Factorial {i} = {factorial}");

                Thread.Sleep(configurator.Delay);
            }
        }

        private void PrimeSearch(AlgorithmConfigurator configurator, CancellationToken cancellationToken)
        {
            AddTextToOutput($"Prime number search started for algorithm: {configurator.Name}");

            int num = 2;
            while (configurator.Count > 0 && !cancellationToken.IsCancellationRequested)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    AddTextToOutput($"Prime number: {num}");

                    configurator.Count--;
                    Thread.Sleep(configurator.Delay);
                }
                num++;
            }
        }

        private void AddTextToOutput(string text)
        {
            Dispatcher.Invoke(() =>
            {
                OutputTextBox.AppendText($"{text}{Environment.NewLine}");
            });
        }
    }

    public class AlgorithmConfigurator
    {
        public string Name { get; }
        public int Count { get; set; }
        public int Delay { get; }

        public AlgorithmConfigurator(string name, int count, int delay)
        {
            Name = name;
            Count = count;
            Delay = delay;
        }
    }
}