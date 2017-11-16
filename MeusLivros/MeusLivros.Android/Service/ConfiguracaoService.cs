using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Util;

using SQLite.Net;
using SQLite.Net.Interop;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using MeusLivros.Service;

[assembly: Dependency(typeof(MeusLivros.Droid.Service.ConfiguracaoService))]

namespace MeusLivros.Droid.Service
{
    class ConfiguracaoService : IConfiguracaoService
    {
        private string _diretorioDB;
        private ISQLitePlatform _plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return _diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return _plataforma;
            }
        }

    }
}