using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {

        School school = new School();
        public SchoolWindow()
        {
            InitializeComponent();
            lbCampuses.ItemsSource = school.Campuses;
            lbCourses.ItemsSource = school.Courses;
            lbMajors.ItemsSource = school.Majors;
            lbStudents.ItemsSource = school.Students;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                Student newStudent = new Student();
                MainWindow studentWindow = new MainWindow(newStudent);
                studentWindow.ShowDialog();
                if (studentWindow.DialogResult == true)
                {
                    MessageBox.Show("Student " + newStudent.StudentNumber + " Added!");
                    school.Students.Add(newStudent);
                    lbStudents.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Dialog Cancelled!");
                }



            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                using (StreamWriter file = new StreamWriter(saveFile.OpenFile()))
                {
                    foreach (var student in school.Students)
                    {
                        file.WriteLine(student.ToString());
                    }
                }
            }

        }
    }
}