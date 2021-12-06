using FanficMobileVersion.Models.Login;
using FanficMobileVersion.Views.UserProfile;
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

            this.Children.Add(new Information(content) { Title = "Информация" });

            this.Children.Add(new FavoritePage(content) { Title = "Работы" });
            
            this.Children.Add(new WorkPage(content) { Title = "Понравившиеся" });
            this.Children.Add(new FavoritePageUser(content.user) { Title = "Избранное" });
            //this.Children.Add(new WorkPage() { Title = "Избранное" });
        }


    }
}