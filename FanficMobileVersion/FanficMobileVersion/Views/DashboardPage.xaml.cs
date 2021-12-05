using FanficMobileVersion.Models.Login;
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
    public partial class DashboardPage : ContentPage
    {
        LoginApiResponseModel Content { get; set; }
        bool edited = true; // флаг редактирования
        public DashboardPage(LoginApiResponseModel content)
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