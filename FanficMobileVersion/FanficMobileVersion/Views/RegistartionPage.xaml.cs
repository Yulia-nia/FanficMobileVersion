using FanficMobileVersion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistartionPage : ContentPage
    {
        public RegistartionPage()
        {
            InitializeComponent();
        }

        
        public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (MyUserName.Text == null || MyUserPassword.Text == null || MyUserEmail.Text == null)
            {
                await DisplayAlert("Ошибка", "Заполните поля", "Ок");
            }
            else
            {
                var content = await ApiServices.ServiceClientInstance.RegistrationUserAsync(MyUserName.Text, MyUserPassword.Text, MyUserEmail.Text);

                if (!string.IsNullOrEmpty(content.accessToken))
                {
                    Application.Current.MainPage = new AppShell(content);
                    //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");  //Navigation.PushAsync(new AboutPage());

                }
                //else
                //{
                //    await DisplayAlert("Error", "Invalid Login, try again", "Ok");

                //}
            }

        }
    }
}