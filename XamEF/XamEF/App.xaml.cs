using Xamarin.Forms;
using XamEF.DataContext;
using XamEF.interfaces;
//using XamEF.Views;


namespace XamEF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new Views.MainPage());
        }

        public static DBContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDB>().GetFullPath("efCore.db");
            return new DBContext(DbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
