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

            do
            {
                buildMenu();

                try
                {
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
                        case "7": minTotalScore(student_grades);
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (selection != "x");
        }

        static void buildMenu()
        {
            Console.WriteLine();
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
            
            try
            {
                string id = "", name = "", sex = "";
                float quiz1 = 0, quiz2 = 0, assignment = 0, midterm = 0, final = 0;

                do
                {
                    id = getId();

                    if (studGrades.findStudent(id))
                    {
                        Console.WriteLine("Student Id already exists: {0}", id);
                    }
                } while (studGrades.findStudent(id));

                name = getName();

                sex = getSex();

                quiz1 = getQuiz1();

                quiz2 = getQuiz2();

                assignment = getAssignment();

                midterm = getMidterm();
                
                final = getFinal();

                if (!studGrades.addStudent(id, name, sex, quiz1, quiz2, assignment, midterm, final))
                {
                    Console.WriteLine("Unable to add student");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to view.");
                    return;
                }
                studentGrades.showAllStudents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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

            try
            {

                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to view.");
                    return;
                }

                string id = getId();

                if (!studentGrades.findStudent(id))
                {
                    Console.WriteLine("Student Not Found: {0}", id);
                    return;
                }

                studentGrades.showStudent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to update.");
                    return;
                }

                string id = getId();
                string fieldToUpdate = "";
                string[] fieldChoices = new string[7]{"1","2","3","4","5","6","7"};
                if (!studentGrades.findStudent(id))
                {
                    Console.WriteLine("Student Not Found: {0}", id);
                    return;
                }

                studentGrades.showStudent(id);

                do
                {
                    Console.WriteLine("Which field do you want to update?");
                    Console.WriteLine("\t1. NAME: ");
                    Console.WriteLine("\t2. SEX: ");
                    Console.WriteLine("\t3. QUIZ 1 SCORE: ");
                    Console.WriteLine("\t4. QUIZ 2 SCORE: ");
                    Console.WriteLine("\t5. ASSIGNMENT SCORE: ");
                    Console.WriteLine("\t6. MID-TERM SCORE: ");
                    Console.WriteLine("\t7. FINAL SCORE: ");
                    fieldToUpdate = Console.ReadLine();
                    if (!fieldChoices.Contains(fieldToUpdate))
                    {
                        Console.WriteLine("Please choose 1-7.");
                    }
                } while (!fieldChoices.Contains(fieldToUpdate));

                if (fieldToUpdate == "1")
                {
                    string updVal = getName();
                    studentGrades.updateStudentName(id, updVal);
                }
                if (fieldToUpdate == "2")
                {
                    string updVal = getSex();
                    studentGrades.updateStudentSex(id, updVal);
                }
                if (fieldToUpdate == "3")
                {
                    float updVal = getQuiz1();
                    studentGrades.updateStudentQuiz1(id, updVal);
                }
                if (fieldToUpdate == "4")
                {
                    float updVal = getQuiz2();
                    studentGrades.updateStudentQuiz2(id, updVal);
                }
                if (fieldToUpdate == "5")
                {
                    float updVal = getAssignment();
                    studentGrades.updateStudentAssignment(id, updVal);
                }
                if (fieldToUpdate == "6")
                {
                    float updVal = getMidterm();
                    studentGrades.updateStudentMidterm(id, updVal);
                }
                if (fieldToUpdate == "7")
                {
                    float updVal = getFinal();
                    studentGrades.updateStudentFinal(id, updVal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to view.");
                    return;
                }

                string id = getId();

                if (!studentGrades.findStudent(id))
                {
                    Console.WriteLine("Student Not Found: {0}", id);
                    return;
                }

                studentGrades.showStudentAvg(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to view.");
                    return;
                }

                studentGrades.showMaxStudentScore();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to view.");
                    return;
                }

                studentGrades.showMinStudentScore();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

            try
            {
                if (!studentGrades.hasStudents())
                {
                    Console.WriteLine("There are no students to delete.");
                    return;
                }

                string id = getId();

                if (!studentGrades.findStudent(id))
                {
                    Console.WriteLine("Student Not Found: {0}", id);
                    return;
                }

                studentGrades.deleteStudent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void sortStudents(Student_Grades studentGrades)
        {
            
            if (!studentGrades.hasStudents())
            {
                Console.WriteLine("There are no students to sort.");
                return;
            }

            studentGrades.sortStudents();
        }

        static string getId()
        {
            string id = "";

            do
            {
                Console.WriteLine("Enter Student's ID: ");
                id = Console.ReadLine();
                if (id == "")
                {
                    Console.WriteLine("Student ID cannot be blank.");
                }
            } while (id == "");

            return id;
        }

        static string getName()
        {
            string name = "";

            do
            {
                Console.WriteLine("Enter Student's Name: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("Student Name cannot be blank.");
                }
            } while (name == "");

            return name;
        }

        static string getSex()
        {
            string sex = "";

            do
            {
                Console.WriteLine("Enter Student's Sex(m/f): ");
                sex = Console.ReadLine();
                if (sex == "")
                {
                    Console.WriteLine("Student Name cannot be blank.");
                }
                else if (sex != "m" && sex != "M" && sex != "f" && sex != "F")
                {
                    Console.WriteLine("Please enter M for Male or F for Female.");
                }
            } while (sex != "m" && sex != "M" && sex != "f" && sex != "F");

            return sex.ToUpper();
        }

        static float getQuiz1()
        {
            string input = "";
            float quiz1 = 0, f = 0;

            do
            {
                input = "";
                Console.WriteLine("Enter Student's Quiz 1 Score: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out f))
                {
                    quiz1 = f;
                }
                else
                {
                    if (input == "")
                    {
                        quiz1 = f;
                        input = f.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numeric value.");
                    }
                }
            } while (!float.TryParse(input, out f));

            return quiz1;
        }

        static float getQuiz2()
        {
            string input = "";
            float quiz2 = 0, f = 0;

            do
            {
                input = "";
                Console.WriteLine("Enter Student's Quiz 2 Score: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out f))
                {
                    quiz2 = f;
                }
                else
                {
                    if (input == "")
                    {
                        quiz2 = f;
                        input = f.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numeric value.");
                    }
                }
            } while (!float.TryParse(input, out f));

            return quiz2;
        }

        static float getAssignment()
        {
            string input = "";
            float assignment = 0, f = 0;

            do
            {
                input = "";
                Console.WriteLine("Enter Student's Assignment Score: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out f))
                {
                    assignment = f;
                }
                else
                {
                    if (input == "")
                    {
                        assignment = f;
                        input = f.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numeric value.");
                    }
                }
            } while (!float.TryParse(input, out f));

            return assignment;
        }

        static float getMidterm()
        {
            string input = "";
            float midterm = 0, f = 0;

            do
            {
                input = "";
                Console.WriteLine("Enter Student's Midterm Score: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out f))
                {
                    midterm = f;
                }
                else
                {
                    if (input == "")
                    {
                        midterm = f;
                        input = f.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numeric value.");
                    }
                }
            } while (!float.TryParse(input, out f));

            return midterm;
        }

        static float getFinal()
        {
            string input = "";
            float final = 0, f = 0;

            do
            {
                input = "";
                Console.WriteLine("Enter Student's Final Score: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out f))
                {
                    final = f;
                }
                else
                {
                    if (input == "")
                    {
                        final = f;
                        input = f.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numeric value.");
                    }
                }
            } while (!float.TryParse(input, out f));

            return final;
        }
    }
}
