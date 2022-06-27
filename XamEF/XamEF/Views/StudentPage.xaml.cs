using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEF.ViewModels;
using XamEF.Models;

namespace XamEF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            InitializeComponent();
            BindingContext = new StudentVM();
        }
        
        private async void studentSelected(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Student;
            await Navigation.PushAsync(new SDetailPage(details.StudentId));
        }
        
    }
}