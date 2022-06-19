using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;
using XamEF.Droid.Implements;
using XamEF.interfaces;

[assembly: Dependency(typeof(ConfigDB))]
namespace XamEF.Droid.Implements
{
    public class ConfigDB: IConfigDB
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }

    }
}