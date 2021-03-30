using System;
using System.Collections.Generic;
using Todays_Manna_Windows_Xamarin.ViewModels;
using Todays_Manna_Windows_Xamarin.Views;
using Xamarin.Forms;

namespace Todays_Manna_Windows_Xamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
