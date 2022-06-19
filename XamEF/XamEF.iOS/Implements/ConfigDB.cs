using System;
using System.IO;
using Xamarin.Forms;
using XamEF.interfaces;
using XamEF.iOS.Implements;

[assembly: Dependency(typeof(ConfigDB))]
namespace XamEF.iOS.Implements
{
    public class ConfigDB: IConfigDB
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}