using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Task
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("Enter the queue length");

        int N = Convert.ToInt32(Console.ReadLine());

        Console.Write("Choose an action:\r\n1 - Fill the queue with random numbers\r\n\r\n2 - Start manually adding items to the queue");
        Console.WriteLine("\r\n");
        int Action = Convert.ToInt32(Console.ReadLine());

        Queue<int> Queue = initQueue(N);

        bool isCorretTrue = false;

        do
        {
            switch (Action)
            {
                case 1:
                    addRandom(Queue, N);
                    isCorretTrue = true;
                    goto case 0;

                case 2:
                    addManually(Queue, N);
                    isCorretTrue = true;
                    goto case 0;

                case 0:
                    Options(Queue);
                    break;

                default:
                    Console.WriteLine("Choose the correct action\r\n");
                    Action = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        } while (!isCorretTrue);
    }

    public static void Options(Queue<int> Queue)        //Метод для вибору дії
    {
        bool isCorrectInput = false;
        do
        {
            Console.WriteLine("\r\n---------------------------------------------------------");
            Console.WriteLine("3 - Remove a certain number of elements from the queue\r\n\r\n4 - Show the number of items in the queue\r\n\r\n5 - Stop the program");
            Console.WriteLine("---------------------------------------------------------");
            int Action2 = Convert.ToInt32(Console.ReadLine());

            switch (Action2)
            {
                case 3:
                    remove(Queue);
                    break;

                case 4:
                    count(Queue);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        } while (!isCorrectInput);

    }

    public static Queue<int> initQueue(int l)       // Метод для ініціалізація черги
    {
        Queue<int> elements = new Queue<int>();
        
    return elements;
    }


    public static Queue<int> print(Queue<int> queue)
    {
        foreach (int item in queue)
        {
            Console.Write(item + ", ");
        }

    return queue;
    }
    
    public static Queue<int> addRandom(Queue<int> queue,int l)      //Рандомне заповнення черги
    {
        Random rand = new Random();

        for (int i = 0; i < l; i++)
        {
            queue.Enqueue(rand.Next(1, 10));
        }

        Console.WriteLine();

        print(queue);

    return queue;
    }

    public static Queue<int> addManually(Queue<int> queue,int l)      //Ручнний ввід значень черги
    {
        for (int i = 0; i < l; i++)
        {
            queue.Enqueue(Convert.ToInt32(Console.ReadLine()));
        }

        print(queue);

    return queue;
    }

    public static Queue<int> remove(Queue<int> queue)       //Видалення елементів з черги
    {
        Console.WriteLine("How many queue items you want to delete?\r\n");
        int c = Convert.ToInt32(Console.ReadLine());
        bool isCorrectTrue = false;

        do
        {
            if (queue.Count < c)
            {
                Console.WriteLine("Enter the correct number\r\n");
                c = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                isCorrectTrue = true;
            }
            
        } while (!isCorrectTrue);

        for (int i = 0; i < c; i++)
        {
            queue.Dequeue();
        }
        print(queue);

    return queue;
    }

    public static Queue<int> count(Queue<int> queue)        //Повернення кількості елементів в черзі
    {
        Console.WriteLine("Elements in the queue - " + queue.Count);

    return queue;
    }
}
