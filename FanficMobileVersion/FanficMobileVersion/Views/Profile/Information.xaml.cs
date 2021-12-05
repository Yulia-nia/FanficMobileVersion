using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Services;
using FanficMobileVersion.ViewModel;
using System.Collections.ObjectModel;

namespace FanficMobileVersion.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Information : ContentPage
    {
        LoginApiResponseModel Content { get; set; }
        bool edited = true; // флаг редактирования
        public Information(LoginApiResponseModel content)
        {
            InitializeComponent();

            Content = content;

            if (content == null)
            {
                Content = new LoginApiResponseModel();
                edited = false;
            }
            this.BindingContext = Content;
        }


    }
}