using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_UI.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Desktop_UI.ViewModels
{
    public partial class AddStudentVM : ObservableObject // ObservableProperty/RelayCommand automatically create another partial class. So ,we use 'partial'.
    {
        [ObservableProperty]
        public int number;
        [ObservableProperty]
        public string? insertPhoto;
        [ObservableProperty]
        public string? firstname;
        [ObservableProperty]
        public string? lastname;
        [ObservableProperty]
        public string? dateofbirth;
        [ObservableProperty]
        public string? gpa;
        [ObservableProperty]
        public string? department;
        [ObservableProperty]
        public string title;
        [ObservableProperty]
        public BitmapImage ip;

        public Student addStudent { get; private set; }
        public AddStudentVM(Student x) 
        {
            addStudent = x;

            number = addStudent.Number;
            firstname = addStudent.FirstName;
            lastname = addStudent.LastName;
            dateofbirth = addStudent.DateOfBirth;
            gpa = addStudent.Gpa;
            department = addStudent.Department;
            insertPhoto = addStudent.Image;
        }

        public AddStudentVM() 
        {
            
        }

        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void SaveStudent()
        {

            if (Convert.ToDouble(gpa) < 0 || Convert.ToDouble(gpa) > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.");
                return;
            }
            if (addStudent == null)
            {

                addStudent = new Student()
                {
                    Number = number,
                    FirstName = firstname,
                    LastName = lastname,
                    DateOfBirth = dateofbirth,
                    Gpa = gpa,
                    Department = department,
                    Image = insertPhoto
                };


            }
            else
            {

                addStudent.Number = number;
                addStudent.FirstName = firstname;
                addStudent.LastName = lastname;
                addStudent.DateOfBirth = dateofbirth;
                addStudent.Gpa = gpa;
                addStudent.Department = department;
                addStudent.Image = insertPhoto;

            }

            if (addStudent.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();
            return;


        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog insertImg = new OpenFileDialog();
            insertImg.Filter = "Image files | *.bmp; *.png; *.jpg";
            insertImg.FilterIndex = 1;
            if (insertImg.ShowDialog() == true)
            {
                ip = new BitmapImage(new Uri(insertImg.FileName));

                MessageBox.Show("Photo successfully uploded!");
            }
        }





    }
}

