using System;
using System.Collections.Generic;

using AppKit;
using Foundation;

namespace Dever
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        private List<Student>  students = new List<Student>() {
            new Student(23, "marcio", "marcio pai", "alessandra", 0, "20/03/2004", "m"),
            new Student(89, "iago", "alexandre", "monica", 2, "15/03/2004", "m"),
        };

        partial void clearSearch(Foundation.NSObject sender)
        {
            nameResLabel.StringValue = "";
            fatherNameResLabel.StringValue = "";
            motherNameResLabel.StringValue = "";
            brotherCountResLabel.StringValue = "";
            birthdateResLabel.StringValue = "";
            sexResLabel.StringValue = "";
            searchTextField.StringValue = "";
        }

        partial void search(Foundation.NSObject sender)
        {
            var student = searchStudentById(searchTextField.StringValue);

            if (student != null)
            {
                nameResLabel.StringValue = student.name;
                fatherNameResLabel.StringValue = student.fatherName;
                motherNameResLabel.StringValue = student.motherName;
                brotherCountResLabel.StringValue = student.brothersCount.ToString();
                birthdateResLabel.StringValue = student.birthdate;
                sexResLabel.StringValue = student.sex;
            }
            else
            {
                clearSearch(sender);
            }
            
        }

        partial void saveButton(Foundation.NSObject sender)
        {
            if (nameResLabel.StringValue == ""||
                fatherNameResLabel.StringValue == "" ||
                motherNameResLabel.StringValue == "" ||
                brotherCountResLabel.StringValue == "" ||
                int.TryParse(brotherCountResLabel.StringValue, out int _) == false ||
                birthdateResLabel.StringValue == "" ||
                sexResLabel.StringValue == "")
            {
                return;
            }


            var isNewStudent = searchTextField.StringValue == "";
            int.TryParse(searchTextField.StringValue, out int id);
             

            var studentData = new Student(
                isNewStudent ?  9 : id,
                nameResLabel.StringValue,
                fatherNameResLabel.StringValue,
                motherNameResLabel.StringValue,
                int.Parse(brotherCountResLabel.StringValue),
                birthdateResLabel.StringValue,
                sexResLabel.StringValue
             );


            
            if (isNewStudent)
            {
                addStudent(studentData);
            }
            else
            {
                updateStudent(studentData);
            }


            clearSearch(null);
        }

        partial void deleteButton(Foundation.NSObject sender)
        {
            if (searchTextField.StringValue == "") return;

            var student = searchStudentById(searchTextField.StringValue);
            if (student == null) return;

            deleteStudent(student);
            clearSearch(null);
        }



        private Student searchStudentById(string id)
        {
            // TODO: implement db
            return students.Find(x => x.id.ToString() == id);
        }

        private void addStudent(Student student)
        {
            // TODO: implement db
            students.Add(student);

        }

        private void updateStudent(Student student)
        {
            // TODO: implement db
            var index = students.FindIndex(x => x.id == student.id);
            students[index] = student;

        }

        private void deleteStudent(Student student)
        {
            // TODO: implement db
            students.RemoveAll(x => x.id == student.id);
        }

    }
}
