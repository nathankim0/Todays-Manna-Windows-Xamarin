using System.ComponentModel;
using Todays_Manna_Windows_Xamarin.ViewModels;
using Xamarin.Forms;

namespace Todays_Manna_Windows_Xamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}