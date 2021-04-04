using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace TodaysMannaWindowsXamarin.WPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            LoadApplication(new Todays_Manna_Windows_Xamarin.App());
        }
    }
}
