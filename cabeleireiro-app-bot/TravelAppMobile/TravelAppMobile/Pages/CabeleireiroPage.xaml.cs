using Xamarin.Forms;

namespace CabeleireiroAppMobile.Pages
{
    public partial class CabeleireiroPage : ContentPage
    {
        public CabeleireiroPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            //var viewmodel = this.BindingContext as ViewModels.CabeleireiroViewModel;
           // await viewmodel._chatBotService.InitializeConversation();
        }
    }
}
