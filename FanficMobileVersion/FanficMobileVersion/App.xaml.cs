using FanficMobileVersion.Services;
using FanficMobileVersion.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanficMobileVersion
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //DependencyService.Register<CategoryService>();
            DependencyService.Register<ApiServices>();
            MainPage = new NavigationPage(new LoginPage());//new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
