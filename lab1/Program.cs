using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[20];
            int n = array.Length;
            array[0] = 0;
            for (int i = 1; i < n; i++)
            {
                array[i] = 10 - rand.Next(20);
            }
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine(" ");
            var proiz = 1;
            for (int i = 1; i < n; i += 2)
            {
                proiz *= array[i];
            }

            var index1 = 0;
            var index2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == 0)
                {
                    index1 = i;
                    break;
                }

            }
            for (int i = (n - 1); i >= 0; i--)
            {
                if (array[i] == 0)
                {
                    index2 = i;
                    break;
                }

            }
            Console.WriteLine("Индекс первого нуля: " + index1);
            Console.WriteLine("Индекс последнего нуля: " + index2);
            var sum = 0;
            for (int i = index1; i < index2; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Произведение элементов массива с четными номерами: " + proiz);
            Console.WriteLine("Сумма элементов массива, расположенных между первым и последним нулевыми элементами: " + sum);

            Array.Sort(array, (x, y) => (x >= 0 && y < 0) ? -1 : ((x < 0 && y >= 0) ? 1 : 0));

            Console.WriteLine("Преобразованный массив:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.ReadLine();
        }
    }
}
