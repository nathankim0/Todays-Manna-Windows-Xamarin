using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace TodaysMannaWindows
{
    public partial class MannaPage : ContentPage
    {
        private string shareRangeString = "";
        DateTime date;

        public MannaPage()
        {
            InitializeComponent();
            BindingContext = new MannaViewModel();

            mannaDatepicker.MinimumDate = new DateTime(DateTime.Now.Year, 1, 1);
            mannaDatepicker.MaximumDate = DateTime.Now;
            date = DateTime.Now;
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnShareLabelTapped;
            rangeButton.GestureRecognizers.Add(tapGesture);
        }
        

        private async void OnShareLabelTapped(object sender, EventArgs args)
        {
            new Animation {
            { 0, 0.5, new Animation (v => rangeButton.Opacity = v, 1, 0.6) },
            { 0.5, 1, new Animation (v => rangeButton.Opacity = v, 0.6, 1) }
            }.Commit(this, "ChildAnimations", 16, 500);

            var shareText = mannaRangeLabel.Text + "\n" + mcRangeLabel.Text;
            await Clipboard.SetTextAsync(shareText);

            await DisplayAlert("클립보드에 복사됨", shareText, "확인");
        }

        private async void OnShareButtonClicked(object sender, EventArgs e)
        {
            var shareText = "";
            try
            {
                shareText = today.Text + "\n\n" + verse.Text + "\n\n" + (BindingContext as MannaViewModel).AllString;
            }
            catch(Exception ex)
            {
                
            }
            await Clipboard.SetTextAsync(shareText);

            await DisplayAlert("클립보드에 복사됨", shareText, "확인");
        }

        private async void OnEnglishButtonClicked(object sender, EventArgs e)
        {
            var uri = new Uri(((MannaViewModel)BindingContext)._completeUrl);
            await Browser.OpenAsync(uri, BrowserLaunchMode.External);
           
        }
        private async void OnCollectionViewItemTapped(object sender, EventArgs e)
        {
            var selectedGrid = sender as Grid;

            var verseText = verse.Text;
            string tmpRangeString = "";

            try
            {
                tmpRangeString = verseText.Substring(0, verseText.IndexOf(":"));
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("OnCollectionViewItemTapped error! : " + error.Message);
            }

            string num = "";
            string manna = "";

            try
            {
                num = ((Label)selectedGrid.Children.ElementAt(0)).Text;
                manna = ((Label)selectedGrid.Children.ElementAt(1)).Text;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error.Message);
            }

            shareRangeString = $"({tmpRangeString}:{num}) {manna}\n";
            await Clipboard.SetTextAsync(shareRangeString);

            await DisplayAlert("클립보드에 복사됨", shareRangeString, "확인");
        }

        private void OnMannaDateButtonClicked(object sender, EventArgs e)
        {
            mannaDatepicker.Focus();
        }
        private void OnMannaTodayButtonClicked(object sender, EventArgs e)
        {
            date = DateTime.Now;
            mannaDatepicker.Date = date;
        }

        private void OnMannaYesButtonClicked(object sender, EventArgs e)
        {
            if (date.Year == 2021 && date.Month == 1 && date.Day == 2)
            {
                return;
            }
            date = date.AddDays(-1);
            mannaDatepicker.Date = date;
        }

        private void OnMannaTomButtonClicked(object sender, EventArgs e)
        {
            if(date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day == DateTime.Now.Day)
            {
                return;
            }
            date = date.AddDays(1);
            mannaDatepicker.Date = date;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            (BindingContext as MannaViewModel).GetManna(e.NewDate);
        }

        private void mannaDatepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            (BindingContext as MannaViewModel).GetManna(e.NewDate);
        }
    }
}