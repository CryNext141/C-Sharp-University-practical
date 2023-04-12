namespace StudentModule
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, List<int>> Grades { get; set; }

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
            Grades = new Dictionary<string, List<int>>();
        }

    }
}
