using Microsoft.VisualBasic;
using System;
using System.Data;
//Код працює з Божою силою
public class Task
{
    public static void Main(string[] args)
    {
        int row = 4;
        int col = 5;
        int c = -10;
        int d = 20;
        int steps = 2;

        int[,] myArray = new int[row, col];

        Generate(ref myArray, c, d);

        int[,] myArray1 = (int[,])myArray.Clone();
        int[,] myArray2 = (int[,])myArray.Clone();
        int[,] myArray3 = (int[,])myArray.Clone();
        int[,] myArray4 = (int[,])myArray.Clone();

        One(myArray, steps);
        Two(myArray1);
        Three(myArray1);
        Four(myArray2);
        Five(myArray3);
        Eight(myArray4);
    }

    public static int[,] Generate(ref int[,] arr, int c, int d)
    {
        Random rnd = new Random();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = rnd.Next(c, d);
            }
        }
        Print(arr);
        return arr;
    }

    public static void Print(int[,] arr)            //Метод для виведення матриці згідно заданого формату
    {
        Console.Write("        ");

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            Console.Write("{0, 10}", "Стовпець");
            Console.Write("{0,3}", i + 1);
        }
        Console.WriteLine();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write("Рядок " + (i + 1));
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("{0, 13}", arr[i, j], "\t");
            }
            Console.WriteLine("");
        }
    }
    public static void One(int[,] arr, int steps)           //Завдання-1:Виконати циклічний зсув матриці на k позицій вправо та на k догори,порожні місця заповнити нулями
    {
        Console.WriteLine();

        if (steps > arr.GetLength(0) || steps > arr.GetLength(1)) //Блок для перевірки,щоб кроки,на які необхідно змістити матрицю не були більшими за розмір матриці
        {
            int[,] newarr = new int[arr.GetLength(0), arr.GetLength(1)];
            Print(newarr);
            return;
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = arr.GetLength(1) - 1; j > (arr.GetLength(1) - steps - 1); j--)
            {
                arr[i, j] = 0;
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0, k = 0; k < arr.GetLength(1); j++)
            {
                int temp_0 = arr[i, j];

                for (int x = (j + steps) % arr.GetLength(1); x != j; x = (x + steps) % arr.GetLength(1), k++) //Знайшов цю формулу на якомусь бородатому форумі
                {
                    int temp_1 = arr[i, x];
                    arr[i, x] = temp_0;
                    temp_0 = temp_1;
                }
                arr[i, j] = temp_0;
                k++;
            }
        }

        for (int i = steps; i < arr.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
            {
                arr[i - steps, j] = arr[i, j];
            }
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            for (int j = arr.GetLength(0) - 1; j > (arr.GetLength(0) - steps - 1); j--)
            {
                arr[j, i] = 0;
            }
        }
        Print(arr);
    }
    public static void Two(int[,] arr)          //Завдання-2:Знайти суму елементів матриці, розміщених після третього елемента кожного рядка
    {
        Console.WriteLine();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int sum = 0;
            Console.Write("Сума рядка " + (i + 1));
            for (int j = 3; j < arr.GetLength(1); j++)
            {
                sum += arr[i, j];
            }

            Console.Write("{0, 8}", sum, "\t");
            Console.WriteLine("");
        }
    }
    public static void Three(int[,] arr)            //Завдання-3:Відняти від елементів кожного рядка матриці середнє арифметичне рядка
    {
        Console.WriteLine();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int sum = 0;
            int ave = 0;

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                sum += arr[i, j];
            }

            ave = sum / arr.GetLength(1);

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] -= ave;
            }
        }
        Print(arr);
    }

    public static void Four(int[,] arr)         //Завдання-4:Знайти максимальні елементи в матриці та видалити з матриці всі рядки та стовпці, що містять їх
                                                //Чесно,я взагалі без поняття як цей блок коду працює
                                                //В С# важко проводити маніпуляції над матрицями,тому було прийнято рішення піти шляхом костилів
                                                //Напишіть ось тут ,скільки ви потратили годин розбираючись в цьому коді: ---
    {
        Console.WriteLine();

        int max = arr[0, 0];
        int[,] new_arr = new int[arr.GetLength(0), arr.GetLength(1)];
        int[] r_max = new int[arr.GetLength(0)];
        int[] c_max = new int[arr.GetLength(1)];

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            r_max[i] = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                c_max[j] = 0;
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                }
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (max == arr[i, j])
                {
                    r_max[i] = 1;
                    c_max[j] = 1;
                }
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (r_max[i] == 1 || c_max[j] == 1)
                {
                    new_arr[i, j] = 0;
                }
                else
                {
                    new_arr[i, j] = arr[i, j];
                }
            }
        }

        Console.Write("          ");
        Console.Write("Матриця пiсля видалення рядка i стовпця з максимальним елементом");
        Console.WriteLine();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (r_max[i] == 1 | c_max[j] == 1)
                {
                    continue;
                }
                else
                {
                    Console.Write("        ");
                    Console.Write("{0, 9}", new_arr[i, j], "\t");
                }
            }
            if (r_max[i] == 0)
            {
                Console.WriteLine();
            }
        }
    }

    public static void Five(int[,] arr)         //Завдання-5:Поміняти стовпці, з максимальним i мінімальним елементами, місцями
    {
        Console.WriteLine();
        int min = 0;
        int max = 0;
        min = colMin(arr);
        max = colMax(arr);

        int buf = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            buf = arr[i, min];
            arr[i, min] = arr[i, max];
            arr[i, max] = buf;
        }
        Print(arr);
    }

    public static int colMin(int[,] arr)        //Метод для знаходження стовпця з мінімальним елементом
    {
        int mini = 0;
        int minj = 0;

        for (int i = 0; i < arr.GetLength(0); ++i)
        {
            for (int j = 0; j < arr.GetLength(1); ++j)
            {
                if (arr[mini, minj] > arr[i, j])
                {
                    mini = i;
                    minj = j;
                }
            }
        }
        return minj;
    }
    public static int colMax(int[,] arr)        //Метод для знаходження стовпця з максимальним елементом
    {
        int maxi = 0;
        int maxj = 0;

        for (int i = 0; i < arr.GetLength(0); ++i)
        {
            for (int j = 0; j < arr.GetLength(1); ++j)
            {
                if (arr[maxi, maxj] < arr[i, j])
                {
                    maxi = i;
                    maxj = j;
                }
            }
        }
        return maxj;
    }

    public static void Eight(int[,] arr)            //Завдання-8:Поміняти місцями рядок і стовпчик з максимумом та рядок і стовпчик з мінімумом
    {
        Console.WriteLine();

        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;

        int max = arr[0,0], min = arr[0,0];

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (max < arr[i, j])
                {
                    max = arr[i, j];
                }
                else if (min > arr[i, j])
                {
                    min = arr[i,j];
                }
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (max == arr[i,j])
                {
                    a = i;
                    b = j;
                }
                else if (min == arr[i,j])
                {
                    c = i;
                    d = j;
                }
            }
        }

        int[,] newarr = new int[1,1];

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (j == b)
                {
                    newarr[0,0] = arr[i,j];
                    arr[i,j] = arr[i,d];
                    arr[i,d] = newarr[0,0];
                }
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (i == a)
                {
                    newarr[0,0] = arr[i,j];
                    arr[i,j] = arr[c,j];
                    arr[c,j] = newarr[0,0];
                }
            }
        }
        Print(arr);
    }
}