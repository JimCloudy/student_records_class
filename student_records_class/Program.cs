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
            Student_Grades student_grades = new Student_Grades();

            string selection = "";

            while (selection != "x")
            {
                buildMenu();

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": addStudent(student_grades);
                        break;
                    case "2": deleteStudent(student_grades);
                        break;
                    case "3": updateStudent(student_grades);
                        break;
                    case "4": viewAllStudents(student_grades);
                        break;
                    case "5": averageScore(student_grades);
                        break;
                    case "6": maxTotalScore(student_grades);
                        break;
                    case "7":minTotalScore(student_grades);
                        break;
                    case "8": viewStudent(student_grades);
                        break;
                    case "9": sortStudents(student_grades);
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

        static void addStudent(Student_Grades studGrades)
        {
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

            studGrades.addStudent(id, name, sex, quiz1, quiz2, assignment, midterm, final);

        }

        static void viewAllStudents(Student_Grades studentGrades)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tVIEW ALL STUDENTS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();

            studentGrades.showAllStudents();
            
        }

        static void viewStudent(Student_Grades studentGrades)
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
            if (!studentGrades.findStudent(id))
            {
                Console.WriteLine("Student Not Found: {0}", id);
                return;
            }

            studentGrades.showStudent(id);
            
        }

        static void updateStudent(Student_Grades studentGrades)
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
            if (!studentGrades.findStudent(id))
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
                string updVal = Console.ReadLine();
                studentGrades.updateStudentName(id, updVal);
            }
            if (input == "2")
            {
                Console.WriteLine("Enter Student's Sex: ");
                string updVal = Console.ReadLine();
                studentGrades.updateStudentSex(id, updVal);
            }
            if (input == "3")
            {
                Console.WriteLine("Enter Student's Quiz 1 Score: ");
                float updVal = float.Parse(Console.ReadLine());
                studentGrades.updateStudentQuiz1(id, updVal);
            }
            if (input == "4")
            {
                Console.WriteLine("Enter Student's Quiz 2 Score: ");
                float updVal = float.Parse(Console.ReadLine());
                studentGrades.updateStudentQuiz2(id, updVal);
            }
            if (input == "5")
            {
                Console.WriteLine("Enter Student's Assignment Score: ");
                float updVal = float.Parse(Console.ReadLine());
                studentGrades.updateStudentAssignment(id, updVal);
            }
            if (input == "6")
            {
                Console.WriteLine("Enter Student's Mid-Term Score: ");
                float updVal = float.Parse(Console.ReadLine());
                studentGrades.updateStudentMidterm(id, updVal);
            }
            if (input == "7")
            {
                Console.WriteLine("Enter Student's Final Score: ");
                float updVal = float.Parse(Console.ReadLine());
                studentGrades.updateStudentFinal(id, updVal);
            }
        }

        static void averageScore(Student_Grades studentGrades)
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
            if (!studentGrades.findStudent(id))
            {
                return;
            }

            studentGrades.showStudentAvg(id);
            
        }

        static void maxTotalScore(Student_Grades studentGrades)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMAX STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();

            studentGrades.showMaxStudentScore();
        }

        static void minTotalScore(Student_Grades studentGrades)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMIN STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();

            studentGrades.showMinStudentScore();
        }

        static void deleteStudent(Student_Grades studentGrades)
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
            if (!studentGrades.findStudent(id))
            {
                return;
            }

            studentGrades.deleteStudent(id);

        }

        static void sortStudents(Student_Grades studentGrades)
        {
            studentGrades.sortStudents();
        }
    }
}
