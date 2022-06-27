using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Input;
using Xamarin.Forms;
using XamEF.Models;
using XamEF.Services;
using XamEF.Views;

namespace XamEF.ViewModels
{
    public class NStudentVM : BaseVM
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
        private DateTime entryDate;
        public DateTime EntryDate
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
        private bool isStudy;
        public bool IsStudy
        {
            get { return this.isStudy; }
            set { SetValue(ref this.isStudy, value); }
        }
        public NStudentVM()
        {
            this.dataServiceStudent = new DBAccess<Student>();
            this.IsStudy = true;
            this.EntryDate = DateTime.Now;
        }
        public ICommand createStudent
        {
            get
            {
                return new Command(async () =>
                {
                    var newStudent = new Student()
                    {
                        Name = this.Name,
                        EntryDate = this.EntryDate,
                        Average = this.Average,
                        IsStudy = this.IsStudy
                    };

                    if (newStudent != null)
                    {
                        if (this.dataServiceStudent.Create(newStudent))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                             $"Estudiante: {this.Name} " +
                                                                             $"Registrado correctamente en la base de datos",
                                                                             "Ok");

                            await Application.Current.MainPage.Navigation.PushAsync(new StudentPage());
                        }

                        else
                            await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                            $"Error al registrar estudiante en la base de datos",
                                                                            "Ok");
                    }
                });
            }
        }
    }
}
