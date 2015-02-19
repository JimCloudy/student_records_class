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
            private float total;

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
                get { return this.total; }
            }

            public void addTotal()
            {
                this.total = this.quiz1 + this.quiz2 + this.assignment + this.midterm + this.final;
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
                data += String.Format("\n\tTOTAL SCORE: {0}", this.total);
                data += String.Format("\n");
                return data;
            }
        }

        private Student[] students = new Student[20];
        
        private int studentCount = 0;

        public int StudentCount{
            get { return this.studentCount; }
        }

        public bool addStudent(string id, string name, string sex, float quiz1, float quiz2, float assignment, float midterm, float final)
        {
            if (this.studentCount > 19)
            {
                return false;
            }

            Student newStud = new Student();

            newStud.Id = id;
            newStud.Name = name;
            newStud.Sex = sex;
            newStud.Quiz1 = quiz1;
            newStud.Quiz2 = quiz2;
            newStud.Assignment = assignment;
            newStud.Midterm = midterm;
            newStud.Final = final;
            newStud.addTotal();

            this.students[this.studentCount] = newStud;

            this.studentCount++;

            return true;
        }

        public void updateStudentName(string studId, string updValue)
        {
            int index = this.findIndex(studId);
            
            if (index == -1)
            {
                return;
            }

            this.students[index].Name = updValue;
        }

        public void updateStudentSex(string studId, string updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Sex = updValue;
        }

        public void updateStudentQuiz1(string studId, float updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Quiz1 = updValue;
            this.students[index].addTotal();
        }

        public void updateStudentQuiz2(string studId, float updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Quiz2 = updValue;
            this.students[index].addTotal();
        }

        public void updateStudentAssignment(string studId, float updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Assignment = updValue;
            this.students[index].addTotal();
        }

        public void updateStudentMidterm(string studId, float updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Midterm = updValue;
            this.students[index].addTotal();
        }

        public void updateStudentFinal(string studId, float updValue)
        {
            int index = this.findIndex(studId);

            if (index == -1)
            {
                return;
            }

            this.students[index].Final = updValue;
            this.students[index].addTotal();
        }

        public void deleteStudent(string studId)
        {
            int x = this.findIndex(studId);
            if (x == -1)
            {
                return;
            }

            if (x == this.studentCount - 1)
            {
                this.students[x] = new Student();

                this.studentCount--;

                return;
            }

            for (int y = x + 1; y < this.studentCount; y++)
            {
                this.students[y - 1] = this.students[y];
            }

            this.students[this.studentCount - 1] = new Student();

            this.studentCount--;

        }

        public void showStudent(string studId)
        {
            int x = this.findIndex(studId);
            if (x == -1)
            {
                return;
            }

            Console.WriteLine(this.students[x].ToString());
        }

        public void showAllStudents()
        {
            for (int x = 0; x < this.studentCount; x++)
            {
                this.showStudent(this.students[x].Id);
            }
        }

        public void showStudentAvg(string id)
        {
            int x = this.findIndex(id);

            if (x == -1)
            {
                return;
            }

            float avg = this.calcAvg(this.students[x]);

            Console.WriteLine("Student {0} has an average score of {1}", this.students[x].Id, avg);
        }

        public void showMaxStudentScore()
        {
            string id = this.findMaxScore();

            this.showStudent(id);

        }

        public void showMinStudentScore()
        {
            string id = this.findMinScore();

            this.showStudent(id);
        }

        private float calcAvg(Student stud)
        {
            return stud.Total / 5;
        }

        private string findMaxScore()
        {
            float max = -1;
            string maxId = "";
            for (int x = 0; x < this.studentCount; x++)
            {
                if (this.students[x].Total > max)
                {
                    max = this.students[x].Total;
                    maxId = this.students[x].Id;
                }
            }

            return maxId;
        }

        private string findMinScore()
        {
            float min = 999;
            string minId = "";
            for (int x = 0; x < this.studentCount; x++)
            {
                if (this.students[x].Total < min)
                {
                    min = this.students[x].Total;
                    minId = this.students[x].Id;
                }
            }

            return minId;
        }

        public void sortStudents()
        {
            Student temp = new Student();

            for (int x = 0; x < this.studentCount; x++)
            {
                for (int y = this.studentCount - 1; y > x; y--)
                {
                    if (this.students[y].Total > this.students[x].Total)
                    {
                        temp = this.students[x];
                        this.students[x] = this.students[y];
                        this.students[y] = temp;
                    }
                }
            }
        }

        public bool findStudent(string id)
        {
            int x = this.findIndex(id);

            if (x == -1)
            {
                return false;
            }

            return true;
        }

        private int findIndex(string id)
        {
            for (int x = 0; x < this.studentCount; x++)
            {
                if (this.students[x].Id == id)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
