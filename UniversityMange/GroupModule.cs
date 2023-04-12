using StudentModule;


namespace GroupModule
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<string> Subjects { get; set; }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
            Students = new List<Student>();
            Subjects = new List<string>();
        }

        //public void DisplayGroupInformation()
        //{
        //    Console.WriteLine("Group Information:");
        //    Console.WriteLine($"Group ID: {Id}");
        //    Console.WriteLine($"Group name: {Name}");
        //    Console.WriteLine($"Number of students: {Students.Count}");
        //    Console.WriteLine("Subjects:");
        //    foreach (string subject in Subjects)
        //    {
        //        Console.WriteLine(subject);
        //    }
        //}
    }
}
