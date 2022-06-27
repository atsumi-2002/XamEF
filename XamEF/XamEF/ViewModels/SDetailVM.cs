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
    public class SDetailVM : BaseVM
    {
        private readonly DBAccess<Student> dataServiceStudent;

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set { SetValue(ref this.students, value); }
        }
        private int id;
        public int Id
        {
            get { return this.id; }
            set { SetValue(ref this.id, value); }
        }
        private String name;
        public String Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }
        private String entryDate;
        public String EntryDate
        {
            get { return this.entryDate; }
            set { SetValue(ref this.entryDate, value); }
        }
        private int average;
        public int Average
        {
            get { return this.average; }
            set { SetValue(ref this.average, value); }
        }
        private String isStudy;
        public String IsStudy
        {
            get { return this.isStudy; }
            set { SetValue(ref this.isStudy, value); }
        }
        public SDetailVM(int id)
        {
            this.dataServiceStudent = new DBAccess<Student>();
            var studentsDB = this.dataServiceStudent.GetById(id);
            this.Students = new ObservableCollection<Student>(studentsDB);
            this.id = this.Students[0].StudentId;
            this.name = this.Students[0].Name;
            this.EntryDate = this.Students[0].EntryDate.ToString("d");
            this.Average = this.Students[0].Average;
            if (this.Students[0].IsStudy)
            {
                this.IsStudy = "Esta estudiando";
            } 
            else
            {
                this.IsStudy = "No esta estudiando";
            }
        }
        public ICommand toUpdateStudent
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new UStudentPage(this.id));
                });
            }
        }
        public ICommand deleteStudent
        {
            get 
            { 
                return new Command(async () =>
                {
                    this.dataServiceStudent.DeleteStudent(this.id);
                    await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                            $"Estudiante: {this.Name} " +
                                                                            $"Eliminado correctamente en la base de datos",
                                                                            "Ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new StudentPage());
                }); 
            }
        }
    }
}
