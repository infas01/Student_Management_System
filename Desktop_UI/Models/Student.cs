using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_UI.Models
{
    public class Student
    {
        // First Name, Last Name, Image thumbnail, Date of Birth, and GPA value.

        //[Key] //Everyone details unique that's why we use key.
        public int Number { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gpa { get; set; }
        public string Department { get; set; }

        /*
        public string FullName 
        {
            get { return $"{FirstName} {LastName}"; }
        }
        */
        public string ImagePath
        {
            get { return $"C:/Users/Infas_NM/Desktop/Desktop_UI_Project/Desktop_UI/Desktop_UI/Images/{Image}"; }
        }

        public Student(int number, string image, string firstName, string lastName, string dateOfBirth, string gpa, string department)
        {
            Number = number;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gpa = gpa;
            Department = department;
        }

        public Student() 
        {

        }
    }
}
