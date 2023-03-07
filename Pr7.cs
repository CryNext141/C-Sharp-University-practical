using System;
namespace Main
{
    //Я встиг повернутися в шкільні часи поки писав цей код,що це взагалі ці ваші дроби?
    public class Task
    {
        static void Main(string[] args)
        {
            Fraction deniminator =  Fraction.getFraction();
            Fraction numerator = Fraction.getFraction();
            Fraction reduc = Fraction.getFraction();
            Console.Clear();

            Fraction.Print("0");
            Fraction.Options(deniminator, numerator, reduc);
        }
    }
    class Fraction
    {
        public int numerator { get; }
        public int denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) //Перевірка чи знаменник != 0
            {
                throw new ArgumentException("Знаменник не може дорівнювати 0!");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        //Знаю,що в умові сказано назвати методи аля addition,но я пішов шляхом перевантаженням операторів
        //Тим більше,що на сайтів майків є хороший приклад з дробами

        public static Fraction operator +(Fraction num1, Fraction num2) //Метод який ретурнить суму
        {
            int lcm = getLCM(num1.denominator, num2.denominator);
            int numerator = (num1.numerator * lcm / num1.denominator) + (num2.numerator * lcm / num2.denominator);

            return new Fraction(numerator, lcm).reductionFraction();
        }


        public static Fraction operator -(Fraction num1, Fraction num2) //Метод який ретурнить різницю
        {
            int lcm = getLCM(num1.denominator, num2.denominator);
            int numerator = (num1.numerator * lcm / num1.denominator) - (num2.numerator * lcm / num2.denominator);

            return new Fraction(numerator, lcm).reductionFraction();
        }


        public static Fraction operator *(Fraction num1, Fraction num2) //Метод який ретурнить добуток
        {
            int numerator = num1.numerator * num2.numerator;
            int denominator = num1.denominator * num2.denominator;

            return new Fraction(numerator, denominator).reductionFraction();
        }


        public static Fraction operator /(Fraction num1, Fraction num2) //Метод який ретурнить частку
        {
            if (num2.numerator == 0)
            {
                throw new DivideByZeroException("Ти дурачок? Ти серйозно збирвася ділити на 0??");
            }
            int numerator = num1.numerator * num2.denominator;
            int denominator = num1.denominator * num2.numerator;

            return new Fraction(numerator, denominator).reductionFraction();
        }


        public Fraction reductionFraction() //Метод який ретурнить скорочений дріб
        {
            int gcd = getGCD(numerator, denominator);

            return new Fraction(numerator / gcd, denominator / gcd);
        }


        public static int getGCD(int num1, int num2) //Метод який ретурнить НСД
        {
            return num2 == 0 ? num1 : getGCD(num2, num1 % num2); //Люблю тернарний оператор
        }


        public static int getLCM(int num1, int num2) //Метод який ретурнить НСК
        {
            return num1 * num2 / getGCD(num1, num2);
        }


        public static Fraction getFraction() //Метод який приймає ввід значень від юзера
        {
            string? inputFraction = Console.ReadLine(); //Треба було ще написати валідацію,але мені так лінь це робити

            String[] inputSplit = inputFraction.Split("/"); //Запихуємо в масив знаменник та чисельник без символа "/"
             
            int denFra = Convert.ToInt32(inputSplit[0]);
            int numFra = Convert.ToInt32(inputSplit[1]);

            return new Fraction (denFra, numFra);
        }

        public static void Options(Fraction num1, Fraction num2, Fraction num3) //Метод для вибору дії
        {
            bool isCorrectInput = false;
            do
            {
                ConsoleKeyInfo type = Console.ReadKey(true);
                Console.Clear();
                string? res;

                switch (type.Key)
                {
                    case ConsoleKey.Add:
                        res = (num1 + num2).ToString();
                        Print(res);
                        break;

                    case ConsoleKey.Subtract:
                        res = (num1 - num2).ToString();
                        Print(res);
                        break;

                    case ConsoleKey.Multiply:
                        res = (num1 * num2).ToString();
                        Print(res);
                        break;

                    case ConsoleKey.Divide:
                        res = (num1 / num2).ToString();
                        Print(res);
                        break;

                    case ConsoleKey.R:
                        res = (num3.reductionFraction()).ToString();
                        Print(res);
                        break;

                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;

                    default:
                        Print("0");
                        break;
                }
            } while (!isCorrectInput);
        }

        public static void Print(string result)
        {
            Console.WriteLine("###########################");
            Console.WriteLine("###                     ###");
            Console.WriteLine($"###            {result,-9}###");
            Console.WriteLine("###                     ###");
            Console.WriteLine("###########################");
            Console.WriteLine("###########################");
            Console.WriteLine("##|||##|||##|||##|||##|||##");
            Console.WriteLine("#| + || - || * || / || R |#");
            Console.WriteLine("##|||##|||##|||##|||##|||##");
            Console.WriteLine("###########################");
            Console.WriteLine("####|Placeholder|##########");
            Console.WriteLine("####|Placeholder|##########");
            Console.WriteLine("####|Placeholder|##########");
            Console.WriteLine("###########################");
            Console.WriteLine("##############|E - Exit|###");
            Console.WriteLine("###########################");
        }

        public override string ToString() //Написав це аби в термінал виводило числа,а не "Main.Fraction"
        {
            if (numerator == 0)
            {
                return "0";
            }
            if (denominator == 1)
            {
                return numerator.ToString();
            }

            return $"{numerator}/{denominator}";
        }

    }
}
