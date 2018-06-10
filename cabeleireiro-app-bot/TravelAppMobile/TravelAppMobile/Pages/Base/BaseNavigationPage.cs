﻿using Xamarin.Forms;

namespace CabeleireiroAppMobile.Pages.Base
{
    public class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage(Page page) : base(page)
        {
            BarBackgroundColor = Color.FromHex("#16ACE9");
            BarTextColor = Color.White;
        }
    }
}
