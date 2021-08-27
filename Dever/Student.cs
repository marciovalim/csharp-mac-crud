using System;

namespace Dever
{
    public class Student
    {
        public int id;
        public string name;
        public string fatherName;
        public string motherName;
        public int brothersCount;
        public string birthdate;
        public string sex;

        public Student(int id, string name, string fatherName, string motherName, int brothersCount, string birthdate, string sex)
        {
            this.id = id;
            this.name = name;
            this.fatherName = fatherName;
            this.motherName = motherName;
            this.brothersCount = brothersCount;
            this.birthdate = birthdate;
            this.sex = sex;
        }
    }
}