using FanficMobileVersion.Models;
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
    public partial class InformationUser : ContentPage
    {
        User User { get; set; }
        bool edited = true; // флаг редактирования
        public InformationUser(User user)
        {
            InitializeComponent();
            User = user;

            if (user == null)
            {
                User = new User();
                edited = false;
            }
            this.BindingContext = User;
        }

    }
}