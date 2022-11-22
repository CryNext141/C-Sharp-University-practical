using Microsoft.VisualBasic;
using System;
using System.Data;

public class Task
{
    public static void Main(string[] args)
    {
        int a = -17;
        int b = 32;
        int l = 10;

        int[] myArray = new int[l];

        Generate(ref myArray, a, b);

        int[] sortedArray = QuickSort(myArray, 0, myArray.Length - 1);

        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.WriteLine("[element_" + i + "_value_" + sortedArray[i] + "],");
        }

    }

    public static int[] Generate(ref int[] arr, int a, int b)
    {
        Random rnd = new Random();

        for (int i = 0; i < arr.Length; i++)
        {                                                           
            arr[i] = rnd.Next(a, b);                                
            Console.WriteLine("[element_" + i + "_value_" + arr[i] + "],");
        }
        Console.WriteLine();

        return arr;
    }


    public static int[] QuickSort(int[] arr, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)       //Вихід з рекурсії
        {
            return arr;
        }

        int pivotIndex = PivotIndex(arr, minIndex, maxIndex);

        QuickSort(arr, minIndex, pivotIndex - 1);
        QuickSort(arr, pivotIndex + 1, maxIndex);

        return arr;
    }

    public static int PivotIndex(int[] arr, int minIndex, int maxIndex)     //Метод для знаходження півоти
    {
        int pivot = minIndex - 1;       //Значення півоти == останій елемент масиву

        for (int i = minIndex; i <= maxIndex; i++)
        {
            if (arr[i] < arr[maxIndex])
            {
                pivot++;
                Swap(ref arr[pivot], ref arr[i]);
            }
        }

        pivot++;        //Кладемо останій елемент масиву,на місце півоти
        Swap(ref arr[pivot], ref arr[maxIndex]);

        return pivot;
    }

    public static void Swap(ref int leftIndex, ref int rightIndex)      //Метод для перестановки
    {
        int temp = leftIndex;

        leftIndex = rightIndex;
        rightIndex = temp;
    }
}

 



    