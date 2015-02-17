using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_records_class
{
    class Student
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

        public Student()
        {
            this.id = "";
            this.name = "";
            this.sex = "";
            this.quiz1 = 0;
            this.quiz2 = 0;
            this.assignment = 0;
            this.midterm = 0;
            this.final = 0;

            addTotal();
        }

        public Student(string id, string name, string sex, float quiz1, float quiz2, float assignment, float midterm, float final)
        {
            this.id = id;
            this.name = name;
            this.sex = sex;
            this.quiz1 = quiz1;
            this.quiz2 = quiz2;
            this.assignment = assignment;
            this.midterm = midterm;
            this.final = final;

            addTotal();
        }

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
    }
}
