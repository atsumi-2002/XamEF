using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamEF.Views;


namespace XamEF.ViewModels
{
    public class MenuItemVM
    {
        #region Atributos
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Atributos

        #region Comandos
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Comandos

        #region Metodos
        private void SelectMenuItemExecute()
        {
            if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new AlbumPage());

            else
                Application.Current.MainPage.Navigation.PushAsync(new AlbumesPage());
        }
        #endregion Metodos

    }
}
