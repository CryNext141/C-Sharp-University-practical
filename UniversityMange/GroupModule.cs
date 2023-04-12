using StudentModule;

namespace GroupModule
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<string> Subjects { get; set; }

        public Group(int id, string name)
        {
            ID = id;
            Name = name;
            Students = new List<Student>();
            Subjects = new List<string>();
        }

    }
}
