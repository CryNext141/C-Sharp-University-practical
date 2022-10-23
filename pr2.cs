using Microsoft.VisualBasic;
using System;

//Милостивий ви пане(або пані,або хто б це не був),якщо ви розумієте цей код,то я вас привітаю,ви будете сидіти зімною в дурці:)
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

        int[] myArray = new int[c];
        int[] myArray2 = new int[c];

        Generate(ref myArray, a, b);
        Console.WriteLine("");
        Generate(ref myArray2, a-5, b+5);   
       
        
        Console.WriteLine("\r\nEnter the range from X to Y for the sum of even items: ");
        string item_one = Console.ReadLine();
        string item_two = Console.ReadLine();
        int Item_one = Convert.ToInt32(item_one);
        int Item_two = Convert.ToInt32(item_two);

        Sum(myArray , Item_one, Item_two);
        Ave(myArray);
        Arr3(myArray, myArray2);
        ArrConc(myArray, myArray2);
        MaxMin(myArray);
        NegPos(myArray);
        Dub(myArray);
        AveTrash(myArray, myArray2);

    }

    public static int[] Generate(ref int[] arr, int a, int b)
    {
        Random rnd = new Random();

        for (int i = 0; i < arr.Length; i++)
        {                                                           //Рандомайз для масива
            arr[i] = rnd.Next(a, b);                                //Те відчуття,коли С# має метод для вказання діапазону
            Console.WriteLine("[element_" + i + "_value_" + arr[i] + "],");
        }
        return arr;
    }

    public static void Sum(int[] arr,int a, int b)          //Завдання-1:Порахувати кількість та суму парних елементів масиву
    {
        int sum = 0;
        int k = 0;

        foreach ( int i in arr )
        {
            if (i % 2 == 0)
            {
                if (i >= a && i <= b)
                {
                    sum++;
                    k += i;
                }
            }
        }
        Console.WriteLine("\r\nTask-1"); 
        Console.Write(sum + ", " + k);
        Console.WriteLine("\r\n");
    }
    public static void Ave(int[] arr)                    //Завдання-2:Визначити середнє арифметичне елементів масиву та кількість елементів, що є більшими за середнє арифметичне
    {
        double aver = 0;
        int k = 0;

        foreach (int i in arr)
        {
            aver += i;
        }
        aver /= arr.Length;

        foreach (int i in arr)
        {
            if (i > aver)
                k++;
        }
        Console.WriteLine("Task-2");
        Console.WriteLine(aver + ", " + k);
    }
    public static void Arr3(int[] arr1, int[] arr2)     //Завдання-3:Утворити третій масив як попарну суму елементів двох масивів однакової довжини
    {
        int[] arr3 = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++) {

            arr3[i] = arr1[i] + arr2[i];
        }
        Console.WriteLine("\r\nTask-3");
        foreach (int i in arr3)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine("\r\n");
    }

    public static void ArrConc(int[] arr1, int[] arr2)  //Завдання-4:Утворити третій масив як конкатенацію двох масивів різної довжини
    {
        int[] arr3 = new int[arr1.Length + (arr2.Length - 3)];

        for (int i = 0; i < arr3.Length; i++)
        {
            if (i < arr1.Length)
            {
                arr3[i] = arr1[i];
            }
            if (i >= arr1.Length)
            {
                arr3[i] = arr2[i - arr1.Length];
            }
        }
        Console.WriteLine("Task-4");
        foreach (int i in arr3)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine("\r\n");
    }

    public static void MaxMin(int[] arr1)               //Завдання-5:В масиві поміняти місцями максимум та мінімум
                                                        //Роботоспроможність коду під великим питанням
    {
        /*int max = 0;
        int min = 0;

        for (int i = 1; i < arr1.Length; i++)
        {
            if (arr1[i] > arr1[i])
                max = i;
            if (arr1[min] < arr1[i])
                min = i;
        }
        int valMax = arr1[max];
        arr1[max] = arr1[min];
        arr1[min] = valMax;

        Console.WriteLine("Task-5");

        for (int i = 0; i < arr1.Length; ++i)
        {
            Console.Write(arr1[i] + ", ");
        }
        Console.WriteLine("\r\n");*/

        int min = arr1[0];
        int max = arr1[0];

        int imax = 0;
        int imin = 0;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] < min)
            {
                min = arr1[i];
                imin = i;
            }
            else if (arr1[i] > max)
            {
                max = arr1[i];
                imax = i;
            }
        }
        arr1[imin] = max;
        arr1[imax] = min;

        Console.WriteLine("Task-5");

        for (int i = 0; i < arr1.Length; ++i)
        {
            Console.Write(arr1[i] + ", ");
        }
        Console.WriteLine("\r\n");

    }

    public static void NegPos(int[] arr1)           //Завадання-6:Масив поділити на два масиви, з додатніх та від'ємних елементів
    {
        int[] neg_arr = new int[arr1.Length];
        int[] pos_arr = new int[arr1.Length];
        int k1 = 0, k2 = 0;

        foreach (int i in arr1)
        {
            if (i < 0)
            {
                neg_arr[k1] = i;
                k1++;
            }
            if (i >= 0)
            {
                pos_arr[k2] = i;
                k2++;
            }
        }
        Console.WriteLine("Task-6");
        Console.Write("Neg: ");

        foreach (int i in neg_arr)
        {
            if (i != 0)
            {
                Console.Write(i + ", ");
            }
        }
        Console.Write("Pos: ");

        foreach (int i in pos_arr)
        {
            if (i != 0) {
            Console.Write(i + ", "); }
        }
        Console.WriteLine("\r\n");
    }

    public static void Dub(int[] arr1)              //Завдання-7:З масиву видалити дублікати максимума та мінімума
    {                                               //Сам Люцифер був шоці,коли побачив умову цього таску
        int[] dublicat = arr1;                      //Код чесно взятий з StackOverflow

        int dubl_max = dublicat[0], dubl_min = dublicat[0];

        for (int i = 0; i < dublicat.Length; i++)
        {
            if (dubl_max < dublicat[i])
            {
                dubl_max = dublicat[i];
            }
            if (dubl_min > dublicat[i])
            {
                dubl_min = dublicat[i];
            }
        }

        int[] dublicat2 = new int[dublicat.Length];
        int d = 0, d1 = 0, d2 = 0;

        foreach (int x in dublicat)
        {
            if (x == dubl_min & d1 == 1 | x == dubl_max & d2 == 1)
                continue;
            if (x == dubl_min)
            {
                dublicat2[d] = x;
                d++;
                d1++;
                continue;
            }
            if (x == dubl_max)
            {
                dublicat2[d] = x;
                d++;
                d2++;
                continue;
            }
            else
            {
                dublicat2[d] = x;
                d++;
            }
        }

        Console.WriteLine("Task-7");
        Console.Write("Array without dublicats: ");

        foreach (int x in dublicat2)
        {
            if (x != 0)
            {
                Console.Write(x + ", ");
            }
        }
        Console.WriteLine("\r\n");
    }
    
    public static void AveTrash(int[] arr1, int[] arr2)     //Завдання-8:Визначити середні арифметичні двох масивів
    {                                                       //Утворити третій масив з елементів обидвох масивів, що знаходяться в межах між значеннямисередніх арифметичних
                                                            //начебто працює,але є в мене відчуття,що я сделяль щось не правильно
        int[] arra = arr1;
        int[] arrb = arr2;
        double sa = 0, sb = 0;

        foreach (int i in arra) {
            sa += i;
        }
            sa /= arra.Length;

        foreach (int i in arrb) {
            sb += i;
        }
            sb /= arrb.Length;
        
        int a, b;
        if (sa < sb)
        {
            a = (int)sa;
            b = (int)sb;
        }
        else
        {
            a = (int)sb;
            b = (int)sa;
        }

        int[] arrc = new int[arra.Length + arrb.Length];
        int count = 0;
        for (int i = 0; i < arrc.Length; i++)
        {
            if (i < arra.Length && arra[i] > a && arra[i] < b)
            {
                arrc[count] = arra[i];
                count++;
            }
            if (i >= arra.Length && arrb[i - arra.Length] > a && arrb[i - arra.Length] < b)
            {
                arrc[count] = arrb[i - arra.Length];
                count++;
            }
        }

        Console.WriteLine("Task-8");
        foreach (int i in arrc)
        {
            if (i != 0)
                Console.Write(i + ", ");
        }
        Console.Write("\r\n");
    }
}