using UniversityModule;

namespace UniversityProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            University university = new University("King Danilo University");
            PrintChooseMenu(university.UniversityName);

            bool exit = false;
            while (!exit)
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter group name: ");
                        string groupName = Console.ReadLine();
                        university.CreateGroup(groupName);
                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        int groupId = int.Parse(Console.ReadLine());
                        university.DeleteGroup(groupId);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        university.AddStudentToGroup(groupId, studentName);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Console.Write("Enter student ID: ");
                        int studentId = int.Parse(Console.ReadLine());
                        university.DeleteStudentFromGroup(groupId, studentId);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        university.ChangeStudentName(studentId, newName);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Enter student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter subject: ");
                        string subject = Console.ReadLine();
                        Console.Write("Enter grade: ");
                        int grade = int.Parse(Console.ReadLine());
                        university.AddGradeToStudent(studentId, subject, grade);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Console.Write("Enter subject: ");
                        subject = Console.ReadLine();
                        university.AddSubjectToGroup(groupId, subject);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Console.Write("Enter subject: ");
                        subject = Console.ReadLine();
                        university.RemoveSubjectFromGroup(groupId, subject);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 9:
                        Console.Clear();
                        Console.Write("Enter student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        university.DisplayStudentInformation(studentId);
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 10:
                        Console.Clear();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        int count = university.GetNumberOfStudentsInGroup(groupId);
                        Console.WriteLine($"Number of students in group: {count}");
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 11:
                        Console.Clear();
                        count = university.GetTotalNumberOfStudents();
                        Console.WriteLine($"Total number of students in university: {count}");
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 12:
                        Console.Clear();
                        university.DisplayUniversityInformation();
                        Console.WriteLine("\nBack to main menu ==> 15");
                        break;
                    case 0:
                        exit = true;
                        break;
                    case 15:
                        PrintChooseMenu(university.UniversityName);
                        break;
                    default:
                        break;
                }
            }

        }
        public static void PrintChooseMenu(string universityName)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the management system students of {universityName}\n");    
            Console.WriteLine("1. Add group");
            Console.WriteLine("2. Remove group");
            Console.WriteLine("3. Add student to group");
            Console.WriteLine("4. Remove student from group");
            Console.WriteLine("5. Change student name");
            Console.WriteLine("6. Add grade to student");
            Console.WriteLine("7. Add subject to group");
            Console.WriteLine("8. Remove subject from group");
            Console.WriteLine("9. Display student info");
            Console.WriteLine("10. Get student count in group");
            Console.WriteLine("11. Get total number of students in university");
            Console.WriteLine("12. Display university information");
            Console.WriteLine("0. Exit");
        }
    }
}