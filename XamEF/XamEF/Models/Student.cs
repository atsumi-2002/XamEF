using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamEF.Views;

namespace XamEF.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public int Average { get; set; }
        public bool IsStudy { get; set; }

    }
}
