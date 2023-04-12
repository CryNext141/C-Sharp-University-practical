using GroupModule;
using StudentModule;
namespace UniversityModule
{
    public class University
    {
        private static int nextGroupId = 0;
        private static int nextStudentId = 0;

        public string UniversityName { get; set; }
        public List<Group> Groups { get; set; }

        public University(string universityName)
        {
            UniversityName = universityName;
            Groups = new List<Group>();
        }

        public void CreateGroup(string name)
        {

            Group group = new Group(nextGroupId++, name);
            Groups.Add(group);
            Console.WriteLine($"Group created with ID: {group.Id}");
        }

        public void DeleteGroup(int id)
        {
            Group group = Groups.Find(g => g.Id == id);
            if (group != null)
            {
                Groups.Remove(group);
                Console.WriteLine($"Group with ID: {id} deleted");
            }
            else
            {
                Console.WriteLine($"Group with ID: {id} not found");
            }
        }

        public void AddStudentToGroup(int groupId, string name)
        {
            Group group = Groups.Find(g => g.Id == groupId);
            if (group != null)
            {
                Student student = new Student(nextStudentId++, name);
                group.Students.Add(student);
                Console.WriteLine($"Student added to group with ID: {student.Id}");
            }
            else
            {
                Console.WriteLine($"Group with ID: {groupId} not found");
            }
        }

        public void DeleteStudentFromGroup(int groupId, int studentId)
        {
            Group group = Groups.Find(g => g.Id == groupId);
            if (group != null)
            {
                Student student = group.Students.Find(s => s.Id == studentId);
                if (student != null)
                {
                    group.Students.Remove(student);
                    Console.WriteLine($"Student with ID: {studentId} deleted from group");
                }
                else
                {
                    Console.WriteLine($"Student with ID: {studentId} not found in group");
                }
            }
            else
            {
                Console.WriteLine($"Group with ID: {groupId} not found");
            }
        }

        public void ChangeStudentName(int studentId, string newName)
        {
            foreach (Group group in Groups)
            {
                Student student = group.Students.Find(s => s.Id == studentId);
                if (student != null)
                {
                    student.Name = newName;
                    Console.WriteLine($"Student with ID: {studentId} name changed to {newName}");
                    return;
                }
            }
            Console.WriteLine($"Student with ID: {studentId} not found");
        }

        public void AddGradeToStudent(int studentId, string subject, int grade)
        {
            if (grade < 0 || grade > 5)
            {
                Console.WriteLine("Invalid grade. Grade must be between 0 and 5.");
                return;
            }

            foreach (Group group in Groups)
            {
                Student student = group.Students.Find(s => s.Id == studentId);
                if (student != null)
                {
                    if (!group.Subjects.Contains(subject))
                    {
                        Console.WriteLine($"Subject {subject} not found in group.");
                        return;
                    }

                    if (!student.Grades.ContainsKey(subject))
                    {
                        student.Grades[subject] = new List<int>();
                    }
                    student.Grades[subject].Add(grade);
                    return;
                }
                else
                {
                    Console.WriteLine($"Student with ID: {studentId} not found");
                }
            }
        }
        public void AddSubjectToGroup(int groupId, string subject)
        {
            Group group = Groups.Find(g => g.Id == groupId);
            if (group != null)
            {
                if (!group.Subjects.Contains(subject))
                {
                    group.Subjects.Add(subject);
                }
            }
            else
            {
                Console.WriteLine($"Group with ID: {groupId} not found");
            }
        }

        public void RemoveSubjectFromGroup(int groupId, string subject)
        {
            Group group = Groups.Find(g => g.Id == groupId);
            if (group != null)
            {
                if (group.Subjects.Contains(subject))
                {
                    group.Subjects.Remove(subject);
                }
            }
            else
            {
                Console.WriteLine($"Group with ID: {groupId} not found");
            }
        }

        public int GetNumberOfStudentsInGroup(int groupId)
        {
            Group group = Groups.Find(g => g.Id == groupId);
            if (group != null)
            {
                return group.Students.Count;
            }
            else
            {
                Console.WriteLine($"Group with ID: {groupId} not found");
                return 0;
            }
        }

        public int GetTotalNumberOfStudents()
        {
            int count = 0;
            foreach (Group group in Groups)
            {
                count += group.Students.Count;
            }
            return count;
        }

        public void DisplayStudentInformation(int studentId)
        {
            foreach (Group group in Groups)
            {
                Student student = group.Students.Find(s => s.Id == studentId);
                if (student != null)
                {
                    Console.WriteLine($"ID: {student.Id}");
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine("Grades:");
                    foreach (KeyValuePair<string, List<int>> entry in student.Grades)
                    {
                        Console.Write($"{entry.Key}: ");
                        foreach (int grade in entry.Value)
                        {
                            Console.Write($"{grade} ");
                        }
                        Console.WriteLine();
                    }
                    return;
                }
            }
            Console.WriteLine($"Student with ID: {studentId} not found");
        }

        public void DisplayUniversityInformation()
        {
            Console.WriteLine("University Information:");
            Console.WriteLine($"Total number of groups: {Groups.Count}");
            Console.WriteLine($"Total number of students: {GetTotalNumberOfStudents()}");
            foreach (Group group in Groups)
            {
                Console.WriteLine($"Group ID: {group.Id}");
                Console.WriteLine($"Group name: {group.Name}");
                Console.WriteLine($"Number of students: {group.Students.Count}");
                Console.WriteLine("Subjects:");
                foreach (string subject in group.Subjects)
                {
                    Console.WriteLine(subject);
                }
            }
        }
    }
}
