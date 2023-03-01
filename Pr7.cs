using System;
namespace Main
{
    //Я встиг повернутися в шкільні часи поки писав цей код,що це взагалі ці ваші дроби?
    public class Task
        //В планах було зробити ввід значень з клавіатури,а також вибір операції...Але я так хочу спати
    {
        static void Main(string[] args)
        {
            Fraction deniminator = new Fraction(/*5*/1, /*7*/2);
            Fraction numerator = new Fraction(1, /*4*/3);  
            Fraction reduc = new Fraction(8, 8);

            Console.WriteLine($"Addition: {deniminator + numerator}");
            Console.WriteLine($"Subtraction: {deniminator - numerator}");
            Console.WriteLine($"Multiplication: {deniminator * numerator}");
            Console.WriteLine($"Division: {deniminator / numerator}");
            Console.WriteLine($"Reduction: {reduc.reductionFraction()}");
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

        private static int getGCD(int num1, int num2) //Метод який ретурнить НСД
        {
            return num2 == 0 ? num1 : getGCD(num2, num1 % num2); //Люблю тернарний оператор
        }


        private static int getLCM(int num1, int num2) //Метод який ретурнить НСК
        {
            return num1 * num2 / getGCD(num1, num2);
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
