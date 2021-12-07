using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Repositories;
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
    public partial class CommentPage : ContentPage
    {
        LoginApiResponseModel _Login { get; set; }
        bool edited1 = true;
        bool edited = true;
        public Fanfic _Fanfic { get; set; }

        public CommentPage(LoginApiResponseModel login, Fanfic fanfic)
        {
            InitializeComponent();

            _Fanfic = fanfic;

            if (fanfic == null)
            {
                _Fanfic = new Fanfic();
                edited = false;
            }

            this.BindingContext = _Fanfic;


            _Login = login;

            if (login == null)
            {
                _Login = new LoginApiResponseModel();
                edited1 = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CommentMy.Text == null)
            {
                await DisplayAlert("Error", "Entry is null", "Ok");
            }
            else
            {
                CommentService cs = new CommentService();
                await cs.AddComment(_Login.user.id, _Fanfic.id, CommentMy.Text, _Login.accessToken);
            }
        }
    }
}