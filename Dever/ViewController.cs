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


        partial void clearSearch(NSObject sender)
        {
            nameResLabel.StringValue = "";
            fatherNameResLabel.StringValue = "";
            motherNameResLabel.StringValue = "";
            brotherCountResLabel.StringValue = "";
            birthdateResLabel.StringValue = "";
            sexResLabel.StringValue = "";
            searchTextField.StringValue = "";
        }

        partial void search(NSObject sender)
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

        partial void saveButton(NSObject sender)
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
             

            var studentData = new Student
            {
                id = isNewStudent ? -1 : id,
                name = nameResLabel.StringValue,
                fatherName = fatherNameResLabel.StringValue,
                motherName = motherNameResLabel.StringValue,
                brothersCount = int.Parse(brotherCountResLabel.StringValue),
                birthdate = birthdateResLabel.StringValue,
                sex = sexResLabel.StringValue
            };


            
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

        partial void DeleteButton(Foundation.NSObject sender)
        {
            if (searchTextField.StringValue == "") return;

            

            deleteStudent(searchTextField.StringValue);
            clearSearch(null);
        }



        private Student searchStudentById(string id)
        {
            return Database.SelectById(id);
        }

        private void addStudent(Student student)
        {
            Database.Insert(student);
        }

        private void updateStudent(Student student)
        {
            Database.Update(student);
        }

        private void deleteStudent(string id)
        {
            Database.DeleteById(id.ToString());
        }

    }
}
