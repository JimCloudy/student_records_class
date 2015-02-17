using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_records_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[20];
            int itemCount = 0;

            string selection = "";

            while (selection != "x")
            {
                buildMenu();

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": addStudent(students, ref itemCount);
                        break;
                    case "2": deleteStudent(students, ref itemCount);
                        break;
                    case "3": updateStudent(students, itemCount);
                        break;
                    case "4": viewAllStudents(students, itemCount);
                        break;
                    case "5": averageScore(students, itemCount);
                        break;
                    case "6": maxTotalScore(students, itemCount);
                        break;
                    case "7": minTotalScore(students, itemCount);
                        break;
                    case "8": viewStudent(students, itemCount);
                        break;
                    case "9": bubbleSortDesc(students, itemCount);
                        break;
                    case "x": break;
                    default: Console.WriteLine("Your selection is not valid: {0}", selection);
                        break;

                }
            }
        }

        static void buildMenu()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student Record");
            Console.WriteLine();
            Console.WriteLine("2. Delete Student Record");
            Console.WriteLine();
            Console.WriteLine("3. Update Student Record");
            Console.WriteLine();
            Console.WriteLine("4. View All Student Records");
            Console.WriteLine();
            Console.WriteLine("5. Calculate An Average Of A Selected Student's Scores");
            Console.WriteLine();
            Console.WriteLine("6. Show Student Who Gets The Max Total Score");
            Console.WriteLine();
            Console.WriteLine("7. Show Student Who Gets The Min Total Score");
            Console.WriteLine();
            Console.WriteLine("8. Find Student By ID");
            Console.WriteLine();
            Console.WriteLine("9. Sort Records By Total Scores");
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice: ");
        }

        static void addStudent(Student[] st, ref int i)
        {
            if (i > 19)
            {
                return;
            }

            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tADD STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student's ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Student's Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student's Sex: ");
            string sex = Console.ReadLine();
            Console.WriteLine("Enter Student's Quiz 1 Score: ");
            float quiz1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Quiz 2 Score: ");
            float quiz2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Assignment Score: ");
            float assignment = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Mid-Term Score: ");
            float midterm = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Final Score: ");
            float final = float.Parse(Console.ReadLine());

            st[i] = new Student(id,name,sex,quiz1,quiz2,assignment,midterm,final);

            i++;
        }

        static void viewAllStudents(Student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tVIEW ALL STUDENTS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Info For Student ID: {0}", stud[x].Id);
                Console.WriteLine("\tNAME: {0}", stud[x].Name);
                Console.WriteLine("\tSEX: {0}", stud[x].Sex);
                Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[x].Quiz1);
                Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[x].Quiz2);
                Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[x].Assignment);
                Console.WriteLine("\tMID-TERM SCORE: {0}", stud[x].Midterm);
                Console.WriteLine("\tFINAL SCORE: {0}", stud[x].Final);
                Console.WriteLine("\tTOTAL SCORE: {0}", stud[x].Total);
                Console.WriteLine();
            }
        }

        static void viewStudent(Student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tVIEW STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            Console.WriteLine("Info For Student ID: {0}", stud[x].Id);
            Console.WriteLine("\tNAME: {0}", stud[x].Name);
            Console.WriteLine("\tSEX: {0}", stud[x].Sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[x].Quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[x].Quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[x].Assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[x].Midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[x].Final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[x].Total);
            Console.WriteLine();
        }

        static void updateStudent(Student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tUPDATE STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            Console.WriteLine("Which field do you want to update?");
            Console.WriteLine("\t1. NAME: ");
            Console.WriteLine("\t2. SEX: ");
            Console.WriteLine("\t3. QUIZ 1 SCORE: ");
            Console.WriteLine("\t4. QUIZ 2 SCORE: ");
            Console.WriteLine("\t5. ASSIGNMENT SCORE: ");
            Console.WriteLine("\t6. MID-TERM SCORE: ");
            Console.WriteLine("\t7. FINAL SCORE: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Enter Student's Name: ");
                stud[x].Name = Console.ReadLine();
            }
            if (input == "2")
            {
                Console.WriteLine("Enter Student's Sex: ");
                stud[x].Sex = Console.ReadLine();
            }
            if (input == "3")
            {
                Console.WriteLine("Enter Student's Quiz 1 Score: ");
                input = Console.ReadLine();
                stud[x].Quiz1 = Convert.ToSingle(input);
            }
            if (input == "4")
            {
                Console.WriteLine("Enter Student's Quiz 2 Score: ");
                input = Console.ReadLine();
                stud[x].Quiz2 = Convert.ToSingle(input);
            }
            if (input == "5")
            {
                Console.WriteLine("Enter Student's Assignment Score: ");
                input = Console.ReadLine();
                stud[x].Assignment = Convert.ToSingle(input);
            }
            if (input == "6")
            {
                Console.WriteLine("Enter Student's Mid-Term Score: ");
                input = Console.ReadLine();
                stud[x].Midterm = Convert.ToSingle(input);
            }
            if (input == "7")
            {
                Console.WriteLine("Enter Student's Final Score: ");
                input = Console.ReadLine();
                stud[x].Final = Convert.ToSingle(input);
            }

            stud[x].addTotal();
        }

        static void averageScore(Student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tSTUDENT AVERAGE SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            float avg = 0;
            avg = stud[x].Total / 5;
            Console.WriteLine("The Average Score For Student {0} is: {1}", id, avg);
        }

        static void maxTotalScore(Student[] stud, int count)
        {
            float max = -1;
            string maxId = "";
            for (int x = 0; x < count; x++)
            {
                if (stud[x].Total > max)
                {
                    max = stud[x].Total;
                    maxId = stud[x].Id;
                }
            }
            int index = findIndex(stud, maxId, count);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMAX STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Info For Student ID: {0}", stud[index].Id);
            Console.WriteLine("\tNAME: {0}", stud[index].Name);
            Console.WriteLine("\tSEX: {0}", stud[index].Sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[index].Quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[index].Quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[index].Assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[index].Midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[index].Final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[index].Total);
            Console.WriteLine();

        }

        static void minTotalScore(Student[] stud, int count)
        {
            float min = 999;
            string minId = "";
            for (int x = 0; x < count; x++)
            {
                if (stud[x].Total < min)
                {
                    min = stud[x].Total;
                    minId = stud[x].Id;
                }
            }
            int index = findIndex(stud, minId, count);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMIN STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Info For Student ID: {0}", stud[index].Id);
            Console.WriteLine("\tNAME: {0}", stud[index].Name);
            Console.WriteLine("\tSEX: {0}", stud[index].Sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[index].Quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[index].Quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[index].Assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[index].Midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[index].Final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[index].Total);
            Console.WriteLine();

        }

        static void deleteStudent(Student[] stud, ref int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tDELETE STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }

            if (x == count - 1)
            {
                stud[x].Id = null;
                stud[x].Name = null;
                stud[x].Sex = null;
                stud[x].Quiz1 = 0;
                stud[x].Quiz2 = 0;
                stud[x].Assignment = 0;
                stud[x].Midterm = 0;
                stud[x].Final = 0;
                stud[x].addTotal();

                count--;
                return;
            }

            for (int y = x + 1; y < count; y++)
            {
                stud[y - 1] = stud[y];
            }

            stud[count - 1].Id = null;
            stud[count - 1].Name = null;
            stud[count - 1].Sex = null;
            stud[count - 1].Quiz1 = 0;
            stud[count - 1].Quiz2 = 0;
            stud[count - 1].Assignment = 0;
            stud[count - 1].Midterm = 0;
            stud[count - 1].Final = 0;
            stud[count - 1].addTotal();

            count--;

        }

        static void bubbleSortDesc(Student[] stud, int count)
        {
            Student temp = new Student();

            for (int x = 0; x < count; x++)
            {
                for (int y = count - 1; y > x; y--)
                {
                    if (stud[y].Total > stud[x].Total)
                    {
                        temp = stud[x];
                        stud[x] = stud[y];
                        stud[y] = temp;
                    }
                }
            }
        }

        static int findIndex(Student[] stud, string id, int count)
        {
            for (int x = 0; x < count; x++)
            {
                if (stud[x].Id == id)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
