using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI.Models;
using Desktop_UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_UI.ViewModels
{
    public partial class MainWindowVM : ObservableObject // ObservableProperty/RelayCommand automatically create another partial class. So ,we use 'partial'.
    {

        //public List<Student> Students { get; set; }
        public ObservableCollection<Student> Students { get; set; } // Here we want to delete and add student after that the list should automatically update.
                                                                    // That's why we use ObservableCollection instead of using list.
        [ObservableProperty]
        public Student? selectedUser = null;
        //[ObservableProperty]
        //public Student selectedstudent;

        public MainWindowVM()
        {
            //Students = new List<Student>()
            Students = new ObservableCollection<Student>()
            {
                new Student (1, "1.png", "Infas", "Mohamed", "2001/01/01", "3.0" ,"COM"),
                new Student (2, "2.png", "Aafrith", "Mohamed", "1999/05/18", "2.8", "COM"),
                new Student (3, "3.png", "Janu", "Gopan", "2000/08/18","3.3", "COM"),
                new Student (4, "4.png", "Sathujan", "Rajes", "1998/10/19", "3.3", "CEE"),
                new Student (5, "5.png", "Kais ", "Ahamed", "1999/05/14", "3.0", "MME"),
                new Student (6, "6.png", "Althaf", "Ahamed", "2000/06/15", "3.5", "CEE"),
                new Student (7, "7.png", "Arshad", "Mohamed", "2000/08/14", "3.7", "COM"),
                new Student (8, "8.png", "Sajan", "Than", "2000/07/14", "3.0", "MENA"),
                new Student (9, "9.png", "Ihsan", "Ahamed", "2000/01/01", "2.8", "CEE"),
                new Student (10, "10.png", "Ibraheem", "Lafeer", "2000/02/18", "2.8", "CEE"),
                new Student (11, "11.png", "Minhaj", "Shaa", "1998/12/24", "2.9", "COM"),
                new Student (12, "12.png", "Aathil", "Ahamed", "2001/01/01", "3.0", "MENA"),
                new Student (13, "13.png", "Dhalan", "Ahamed", "2000/09/15", "3.7", "EE"),
                new Student (14, "14.png", "Sasi", "Tharan", "2000/10/21", "3.1", "MME"),
                new Student (15, "15.png", "Sahmi", "Ahamed", "2000/05/19", "3.4", "EE"),
            };
        }

        [RelayCommand]
        public void AddStudent()
        {
            var addSW = new AddStudentVM();
            addSW.title = "ADD STUDENT";
            AddStudentWindowView window = new AddStudentWindowView(addSW);
            window.ShowDialog();

            if (addSW.addStudent.FirstName != null)
            {
                Students.Add(addSW.addStudent);
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (selectedUser != null)
            {
                var addSW = new AddStudentVM(selectedUser);
                addSW.title = "EDIT STUDENT";
                var window = new AddStudentWindowView(addSW);

                window.ShowDialog();


                int index = Students.IndexOf(selectedUser);
                Students.RemoveAt(index);
                Students.Insert(index, addSW.addStudent);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        

        //[RelayCommand]
        //public void Update()
        //{
        //    var deletestudent = Selectedstudent as Student;
        //    var x = Getstudent.get.Find(x => x.Gpa == deletestudent.Gpa && x.FullName == deletestudent.FullName);
        //    x.Gpa = Gpa;
        //    Students.Clear();
        //    foreach (var i in Getstudent.get)
        //    {
        //        Students.Add(i);

        //    }


        //    // student.Clear();

        //}

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                Students.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }

    }
}
