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
        static List<int[]> Reverse(List<int[]> list)
        {
            foreach (int[] elem in list)
            {
                int a = elem[0];
                elem[0] = elem[1];
                elem[1] = a;
            }
            return list;
        }
        static int BinarySearch(int left, int right, int value, List<int[]> list)
        {
            while (left < right)
            {
                int middle = left + (right - 1) / 2;
                if (list[middle][1] - value <= 0)
                {
                    left = middle + 1;
                }
                else
                    right = middle;
            }
            return
                right;
        }
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int[] nd = new int[str.Length];
            for (int i = 0; i < nd.Length; i++)
            {
                nd[i] = Convert.ToInt32(str[i]);
            }
            List<int[]> inputList = new List<int[]>();
            for (int i = 0; i < nd[0]; i++)
            {
                string[] inputStr = ((i + 1).ToString() + " " + Console.ReadLine()).Split(' ');
                int[] input = new int[inputStr.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    input[j] = Convert.ToInt32(inputStr[j]);
                }
                inputList.Add(input);
            }
            int average = nd[1];
            var sortedList = inputList.OrderBy(x => x[1]).ToList();
            ShowList(sortedList);
            List<int[]> output = new List<int[]>();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i][1] == average)
                    break;
                else
                {
                    int ind = BinarySearch(i + 1, inputList.Count, average - inputList[i][1], inputList);
                    int[] arr = new int[2];
                    arr[0] = inputList[ind][0];
                    arr[1] = average - inputList[i][1];
                    output[inputList[i][0] - 1] = arr;
                    inputList[ind][1] -= average - inputList[i][1];
                    inputList[i][1] = average;
                }
            }
            ShowList(output);
        }
    }
}

