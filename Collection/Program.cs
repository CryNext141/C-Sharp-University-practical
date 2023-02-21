using System;
using Microsoft.Data.SqlClient;
using SubClassForm;

public class Task
{
    public static void Main(string[] args)
    {
        //Не бийте сильно за такі назви
        Form retardOne = new Form("Kolinsky", 1994, "Gaming", true, 1500);
        Form retardTwo = new Form("Alex", 2000, "Music", true, 870);
        Form retardThree = new Form("Alex", 2003, "Aircraft", false, 110);
        Form retardFour = new Form("Jonathan", 1994, "Weapon", true, 23);

        string[] name = new string[] { retardOne.name, retardTwo.name, retardThree.name, retardFour.name };

        var marriList = new List<bool>()
        {
            retardOne.freeMan,
            retardTwo.freeMan,
            retardThree.freeMan,
            retardFour.freeMan
        };

        var duplicate = new List<string>()
        {
            retardOne.name,
            retardTwo.name,
            retardThree.name,
            retardFour.name
        };


        Print();
        avgSalary(retardOne.salary + retardTwo.salary + retardThree.salary + retardFour.salary);
        marriCount(marriList);
        //duplicateNames(duplicate);
        duplicatesName1(name);

        void Print()
        {
            retardOne.aboutMyself();
            Console.WriteLine();
            retardTwo.aboutMyself();
            Console.WriteLine();
            retardThree.aboutMyself();
            Console.WriteLine();
            retardFour.aboutMyself();
            Console.WriteLine();
        }

        void avgSalary(int salary)  //Середня зарплата
        {
            Console.WriteLine();
            double avg = salary / 4;
            Console.WriteLine("Average salary: " + avg);
        }

        void marriCount(List<bool> married)  //Знаходжу кількість одружених 
        {
            int k = 0;

            foreach (var item in married)
            {
                if (item)
                {
                    k++;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("How many married: " + k);
        }

        /*void duplicateNames(List<string> duplicate) //Знаю, знаю, знаю...Я без поняття як це зробити не використовуючи щось з колекції або без масива(що теж є колекцією)
        {
            Dictionary<string, int> freqMap = duplicate.GroupBy(x => x)
                                            .Where(g => g.Count() > 1)
                                            .ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine("Duplicate names are: " + String.Join(",", freqMap));
        }*/

        bool duplicatesName1(string[] arr)
        {
            {
                var duplicates = arr
                 .GroupBy(p => p)
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Key);

                Console.WriteLine("Duplicate names are: " + String.Join(",", duplicates));

                return (duplicates.Count() > 0);

            }

        }

    } 
}
