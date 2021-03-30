using System;
using System.Collections.Generic;
using System.ComponentModel;
using Todays_Manna_Windows_Xamarin.Models;
using Todays_Manna_Windows_Xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todays_Manna_Windows_Xamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}