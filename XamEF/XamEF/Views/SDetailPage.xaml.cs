using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamEF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SDetailPage : ContentPage
    {
        public SDetailPage(int StudentId)
        {
            InitializeComponent();
            BindingContext = new SDetailVM(StudentId);
        }
    }
}