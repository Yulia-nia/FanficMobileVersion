using FanficMobileVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.Services;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }

        public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (MyUserName.Text == null || MyUserPassword.Text == null)
            {
                await DisplayAlert("Error", "Login or password is null", "Ok");
            }
            else
            {
                var content = await ApiServices.ServiceClientInstance.AuthenticateUserAsync(MyUserName.Text, MyUserPassword.Text);

                if (!string.IsNullOrEmpty(content.accessToken))
                {
                    await Navigation.PushAsync(new DashboardPage(content));

                }
                else
                {
                    await DisplayAlert("Error", "Invalid Login, try again", "Ok");

                }
            }

        }


    }
}