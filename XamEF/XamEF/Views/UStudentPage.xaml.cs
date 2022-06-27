using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEF.ViewModels;

namespace XamEF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UStudentPage : ContentPage
    {
        public UStudentPage(int id)
        {
            InitializeComponent();
            BindingContext = new UStudentVM(id);
        }
    }
}