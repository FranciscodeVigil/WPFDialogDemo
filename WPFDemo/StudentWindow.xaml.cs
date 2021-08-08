using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Student student;

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        public MainWindow() : this(new Student())
        {
        }

        public MainWindow(Student st)
        {
            InitializeComponent();
            this.student = st;
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            student.FirstName = txbFirstName.Text;
            student.LastName = txbLastName.Text;
            student.StudentNumber = txbStudentNum.Text;
            student.Major = txbMajor.Text;

            List<Assignment> scores = new List<Assignment>();
            foreach (Assignment score in lbScores.Items)
            {
                scores.Add(score);    
            }
            student.Scores = scores;

            txbResults.Text = student.ToString();

            this.DialogResult = true;
            this.Close();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Assignment assign = new Assignment();
            assign.Title = txbTitle.Text;
            assign.Score = int.Parse(txbScore.Text);
            lbScores.Items.Add(assign);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
