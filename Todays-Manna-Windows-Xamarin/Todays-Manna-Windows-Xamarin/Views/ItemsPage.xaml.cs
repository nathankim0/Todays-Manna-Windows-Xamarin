using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todays_Manna_Windows_Xamarin.Models;
using Todays_Manna_Windows_Xamarin.ViewModels;
using Todays_Manna_Windows_Xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todays_Manna_Windows_Xamarin.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}