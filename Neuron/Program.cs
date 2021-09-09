using System;

namespace Neuron
{
    class Skin
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal experiance { get; private set; }
            // Сглаживание шага
            public decimal Smooth = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }

            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                experiance = expectedResult - actualResult;
                var correction = (experiance / actualResult) * Smooth;
                weight += correction;
            }
        }

        static void Main(string[] args)
        {
            decimal km = 100m;
            decimal milles = 62.1371m;

            Neuron ner = new Neuron();

            // Обучение

            int i = 0;
            do
            {
                i++;
                ner.Train(km, milles);
                Console.WriteLine($"Итерация: {i}\tОшибка\t{ner.experiance}");
            }
            while (ner.experiance > ner.Smooth || ner.experiance < -ner.Smooth);

            Console.WriteLine($"{ner.ProcessInputData(km)} miles in {km} kilometrs");
            Console.ReadLine();
        }
    }
}
