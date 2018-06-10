using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabeleireiroAppMobile.Pages;
using CabeleireiroAppMobile.Pages.Base;
using Xamarin.Forms;

namespace CabeleireiroAppMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BaseNavigationPage(new CabeleireiroPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
