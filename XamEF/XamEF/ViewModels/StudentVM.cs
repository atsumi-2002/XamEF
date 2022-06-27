using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamEF.Models;
using XamEF.Services;
using XamEF.Views;


namespace XamEF.ViewModels
{
    public class StudentVM : BaseVM
    {
        #region Services
        private readonly DBAccess<Student> dataServiceStudent;
        #endregion Services

        #region Attributes
        private ObservableCollection<Student> students;
        #endregion Attributes

        #region Properties
        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set { SetValue(ref this.students, value); }
        }
        #endregion Properties

        #region Constructor
        public StudentVM()
        {
            this.dataServiceStudent = new DBAccess<Student>();
            var studentsDB = this.dataServiceStudent.Get().ToList() as List<Student>;
            this.LoadStudents();
            /*
            if (studentsDB.Count != 3)
            {
                this.CreateStudent();
            }
            this.LoadStudents();
            */
        }
        #endregion Constructor

        #region Methods
        private void LoadStudents()
        {
            var studentsDB = this.dataServiceStudent.Get().ToList() as List<Student>;
            this.Students = new ObservableCollection<Student>(studentsDB);
        }
        private void CreateStudent()
        {
            var students = new List<Student>()
            {
                new Student { Name = "Ricardo Arjona", EntryDate = new DateTime(2222,3,2), Average = 16, IsStudy = true },
                new Student { Name = "Kalimba", EntryDate = new DateTime(2111,1,1), Average = 04, IsStudy = false },
                new Student { Name = "Luis Miguel", EntryDate = new DateTime(2111,1,1), Average = 1206, IsStudy = true }
            };
            this.dataServiceStudent.SaveList(students);
        }
        #endregion Methods

        public ICommand toCreateStudent
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new NStudentPage());
                });
            }
        }
    }
}
