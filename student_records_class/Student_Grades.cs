using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_records_class
{
    class Student_Grades
    {
        struct Student
        {
            private string id;
            private string name;
            private string sex;
            private float quiz1;
            private float quiz2;
            private float assignment;
            private float midterm;
            private float final;

            public string Id
            {
                get { return this.id; }
                set { this.id = value; }
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public string Sex
            {
                get { return this.sex; }
                set { this.sex = value; }
            }

            public float Quiz1
            {
                get { return this.quiz1; }
                set { this.quiz1 = value; }
            }

            public float Quiz2
            {
                get { return this.quiz2; }
                set { this.quiz2 = value; }
            }

            public float Assignment
            {
                get { return this.assignment; }
                set { this.assignment = value; }
            }

            public float Midterm
            {
                get { return this.midterm; }
                set { this.midterm = value; }
            }

            public float Final
            {
                get { return this.final; }
                set { this.final = value; }
            }

            public float Total
            {
                get { return this.quiz1 + this.quiz2 + this.assignment + this.midterm + this.final; }
            }

            public override string ToString()
            {
                string data = String.Format("Info For Student ID: {0}", this.id);
                data += String.Format("\n\tNAME: {0}", this.name);
                data += String.Format("\n\tSEX: {0}", this.sex);
                data += String.Format("\n\tQUIZ 1 SCORE: {0}", this.quiz1);
                data += String.Format("\n\tQUIZ 2 SCORE: {0}", this.quiz2);
                data += String.Format("\n\tASSIGNMENT SCORE: {0}", this.assignment);
                data += String.Format("\n\tMID-TERM SCORE: {0}", this.midterm);
                data += String.Format("\n\tFINAL SCORE: {0}", this.final);
                data += String.Format("\n\tTOTAL SCORE: {0}", this.Total);
                data += String.Format("\n");
                return data;
            }

            public override bool Equals(Object obj)
            {
                if(obj == null || GetType() !=  obj.GetType())
                {
                    return false;
                }

                Student stud = (Student)obj;

                if (stud.Id == null)
                {
                    return false;
                }

                return this.id.Equals(stud.Id);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        private List<Student> students = new List<Student>();

        public bool addStudent(string id, string name, string sex, float quiz1, float quiz2, float assignment, float midterm, float final)
        {
            Student newStud = new Student();

            newStud.Id = id;
            newStud.Name = name;
            newStud.Sex = sex;
            newStud.Quiz1 = quiz1;
            newStud.Quiz2 = quiz2;
            newStud.Assignment = assignment;
            newStud.Midterm = midterm;
            newStud.Final = final;

            this.students.Add(newStud);

            return true;
        }

        public void updateStudentName(string studId, string updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Name = updValue;
            this.students[index] = temp; 
        }

        public void updateStudentSex(string studId, string updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Sex = updValue;
            this.students[index] = temp;             
        }

        public void updateStudentQuiz1(string studId, float updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Quiz1 = updValue;
            this.students[index] = temp; 
        }

        public void updateStudentQuiz2(string studId, float updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Quiz2 = updValue;
            this.students[index] = temp; 
        }

        public void updateStudentAssignment(string studId, float updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Assignment = updValue;
            this.students[index] = temp; 
        }

        public void updateStudentMidterm(string studId, float updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Midterm = updValue;
            this.students[index] = temp; 
        }

        public void updateStudentFinal(string studId, float updValue)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            int index = this.students.FindIndex(x => x.Id == studId);

            Student temp = this.students[index];
            temp.Final = updValue;
            this.students[index] = temp; 
        }

        public void deleteStudent(string studId)
        {
            Student temp = new Student();
            temp.Id = studId;
            this.students.Remove(temp);
        }

        public void showStudent(string studId)
        {
            if (this.students.Exists(x => x.Id == studId))
            {
                Console.WriteLine(this.students.Find(x => x.Id == studId));
            }
        }

        public void showAllStudents()
        {
            foreach(Student stud in students){
                Console.WriteLine(stud);
            }
        }

        public void showStudentAvg(string studId)
        {
            if (!this.students.Exists(x => x.Id == studId))
            {
                return;
            }

            float avg = this.calcAvg(this.students.Find(x => x.Id == studId));

            Console.WriteLine("Student {0} has an average score of {1}", studId, avg);
        }

        public void showMaxStudentScore()
        {
            Student stud = this.findMaxScore();

            Console.WriteLine(stud);

        }

        public void showMinStudentScore()
        {
            Student stud = this.findMinScore();

            Console.WriteLine(stud);
        }

        private float calcAvg(Student stud)
        {
            return stud.Total / 5;
        }

        private Student findMaxScore()
        {
            Student max = new Student();

            foreach (Student stud in this.students)
            {
                if (max.Id == null)
                {
                    max = stud;
                }
                if (stud.Total > max.Total)
                {
                    max = stud;
                }
            }

            return max;
        }

        private Student findMinScore()
        {
            Student min = new Student();
            
            foreach(Student stud in this.students)
            {
                if (min.Id == null)
                {
                    min = stud;
                }
                if (stud.Total < min.Total)
                {
                    min = stud;
                }
            }

            return min;
        }

        public void sortStudents()
        {
            this.students.Sort(compareByTotalDesc);
        }

        public bool findStudent(string studId)
        {
            return this.students.Exists(x => x.Id == studId);
        }

        private int compareByTotalDesc(Student stud1, Student stud2)
        {
            if (stud1.Total < stud2.Total)
            {
                return 1;
            }

            else if (stud1.Total == stud2.Total)
            {
                return 0;
            }

            else 
            {
                return -1;
            }
        }

        public bool hasStudents()
        {
            if (this.students.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
