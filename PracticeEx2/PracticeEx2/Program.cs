using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace PracticeEx2
{
    class Program
    {
        static void ShowList(List<int[]> list)
        {
            foreach (int[] elem in list)
            {
                foreach (int el in elem)
                {
                    Console.Write(el + " ");
                }
                Console.Write("\n");
            }
        }
        static int n, average;
        static int BinarySearch(int left, int right, int value, List<int[]> list)
        {
            while (left < right)
            {
                int middle = left + (right - left) / 2;
                if (list[middle][1] - value <= 0)
                {
                    left = middle + 1;
                }
                else
                    right = middle;
            }
            return right;
        }
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int[] nd = new int[str.Length];
            for (int i = 0; i < nd.Length; i++)
            {
                nd[i] = Convert.ToInt32(str[i]);
            }
            n = nd[0];
            average = nd[1];
            List<int[]> inputList = new List<int[]>();
            List<int[]> outputList = new List<int[]>();
            int[] empty = new int[] { 0, 0 };
            for (int i = 0; i < n; i++)
                outputList.Add(empty);
            for (int i = 0; i < n; i++)
            {
                int curd = Convert.ToInt32(Console.ReadLine());
                if (curd != average)
                {
                    int first = i + 1;
                    int second = curd;
                    int[] arr = new int[] {first, second };
                    inputList.Add(arr);
                }
            }
            var sortedList = inputList.OrderBy(x => x[1]).ToList();
            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i][1] == average)
                    break;
                else
                {
                    int ind = BinarySearch(i + 1, sortedList.Count, average - sortedList[i][1], sortedList);
                    int first = sortedList[ind][0];
                    int second = average - sortedList[i][1];
                    int[] arr = new int[] { first, second };
                    outputList[sortedList[i][0] - 1] = arr;
                    sortedList[ind][1] -= (average - sortedList[i][1]);
                    sortedList[i][1] = average;
                }
            }
            ShowList(outputList);
            Console.ReadLine();
        }
    }
}