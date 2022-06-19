using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamEF.Models;
using XamEF.Services;

namespace XamEF.ViewModels
{
    public class MainVM: BaseVM
    {
        #region Atributos
        private ObservableCollection<MenuItemVM> menu;
        #endregion Atributos

        #region Propiedades
        public ObservableCollection<MenuItemVM> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Propiedades

        #region Constructor
        public MainVM()
        {
            this.LoadMenu();
            //this.SaveArtistasList();
        }
        #endregion Constructor

        #region Metodos
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemVM>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemVM { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuItemVM { Id = 2, Option = "Lista de Registros" });
        }
        #endregion metodos

        DBAccess<Artista> dataService = new DBAccess<Artista>();
        private void SaveArtistasList()
        {
            var artistas = new List<Artista>()
            {
                new Artista{ Nombre = "Arjona" },
                new Artista{ Nombre = "Luismi" },
                new Artista{ Nombre = "Kalimba" }
            };

            dataService.SaveList(artistas);
        }

    }
}
