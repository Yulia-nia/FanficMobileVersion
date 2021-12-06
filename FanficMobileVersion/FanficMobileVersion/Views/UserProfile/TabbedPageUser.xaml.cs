using FanficMobileVersion.Models;
using FanficMobileVersion.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion.Views.UserProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageUser : TabbedPage
    {
        public TabbedPageUser(User user, LoginApiResponseModel content)
        {
            InitializeComponent();
            this.Children.Add(new InformationUser(user) { Title = "Home" });
            this.Children.Add(new WorkPageUser(user, content) { Title = "Работы" });
            this.Children.Add(new LikedPageUser(user, content) { Title = "Понравившиеся" });
            this.Children.Add(new FavoritePageUser(user, content) { Title = "Избранное" });
            // this.Children.Add(new WorkPageUser(user) { Title = "Работы" });
        }
    }
}