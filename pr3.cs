using Microsoft.VisualBasic;
using System;

//Звідси починається магія
public class Task
{
    public static void Main(string[] args)
    {

        //Блок для введення даних
        Console.WriteLine("Enter array length and range from X to Y: ");
        string one = Console.ReadLine();
        string two = Console.ReadLine();
        string three = Console.ReadLine();
        int c = Convert.ToInt32(one);
        int a = Convert.ToInt32(two);
        int b = Convert.ToInt32(three);

        Boolean rev = false;

        int[] myArray = new int[c];
        Generate(ref myArray, a, b);
        BubbleSort(myArray,rev);
        InsertionSort(myArray,rev);
        SelectionSort(myArray,rev);
    }

    public static int[] Generate(ref int[] arr, int a, int b)
    {
        Random rnd = new Random();

        for (int i = 0; i < arr.Length; i++)
        {                                                       //Рандомайз для масива
            arr[i] = rnd.Next(a, b);
            Console.Write("[cell_" + i + "_value_" + arr[i] +"]" + ",");
        }
        Console.WriteLine("\r\n");
        return arr;
    }
    public static void BubbleSort(int[] arr,Boolean rev) //Бульбашковий метод
    {
        int temp = 0;

        for (int write = 0; write < arr.Length; write++)
        {
            for (int sort = 0; sort < arr.Length - 1; sort++)
            {
                if (arr[sort] > arr[sort + 1])
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }

        if (rev==false)
        {
            Console.WriteLine("Bubble sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
        else if (rev==true)
        {
            Console.WriteLine("Reverse Bubble sort:");
            Array.Reverse(arr);  
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
    }  

    public static void InsertionSort(int[] arr,Boolean rev) //Сортування методом вставки
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }

        if (rev == false)
        {
            Console.WriteLine("\r\nInsertion sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
        else if (rev == true)
        {
            Console.WriteLine("\r\nReverse Insertion sort:");
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
    }

    public static void SelectionSort(int[] arr,Boolean rev) //Сортування методом вибором
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min_idx = i;
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;

            int temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }

        if (rev == false)
        {
            Console.WriteLine("\r\nSelection sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
        else if (rev == true)
        {
            Console.WriteLine("\r\nReverse Selection sort:");
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[cell_" + i + "_value_" + arr[i] + "]" + ",");
            }
        }
    }
}

