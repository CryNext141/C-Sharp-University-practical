namespace SubClassForm
{
  
    public class Form
    {
        public string name{ get; set; }
        public int birthday { get; set; }
        public string hobby { get; set; }
        public bool freeMan { get; set; }
        public int salary { get; set; }

        public Form (string name, int birthday, string hobby, bool freeMan, int salary)
        {
            this.name = name;
            this.birthday = birthday;
            this.hobby = hobby;
            this.freeMan = freeMan;
            this.salary = salary;
        }
        public void aboutMyself()
        {
            string m;
            if (this.freeMan)
            {
                m = "Married";
            }
            else
            {
                m = "Lonely";
            }

            Console.Write("Name: " + name + ", ");
            Console.Write("Date of birth: " + birthday + ", ");
            Console.Write("Hobby: " + hobby + ", " );
            Console.Write("Family status: " + m + ", ");
            Console.Write("Salary: " + salary+ " ");
        }  
    }
}