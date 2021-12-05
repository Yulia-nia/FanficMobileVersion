using FanficMobileVersion.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : TabbedPage
    {
        //LoginApiResponseModel Content { get; set; }
        //bool edited = true; // флаг редактирования
        public Profile(LoginApiResponseModel content)
        {
            InitializeComponent();
            this.Children.Add(new FavoritePage(content) { Title = "Избранное" });
            this.Children.Add(new Information(content) { Title = "Home" });
            this.Children.Add(new WorkPage(content) { Title = "Работы" });
            
            //this.Children.Add(new WorkPage() { Title = "Избранное" });
        }


    }
}