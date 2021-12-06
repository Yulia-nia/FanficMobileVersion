using FanficMobileVersion.Models;
using FanficMobileVersion.Views.Profile;
using FanficMobileVersion.ViewModels;
using FanficMobileVersion.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FanficMobileVersion.Models.Login;
using Profile = FanficMobileVersion.Views.Profile.Profile;

namespace FanficMobileVersion
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        LoginApiResponseModel _Content { get; set; }
        bool edited = true; // флаг редактирования
        public AppShell(LoginApiResponseModel content)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CategoriesListViewPage), typeof(CategoriesListViewPage));
            Routing.RegisterRoute(nameof(CategoryDetailPage), typeof(CategoryDetailPage));
            Routing.RegisterRoute(nameof(FanficPage), typeof(FanficPage));
            Routing.RegisterRoute(nameof(ChapterPage), typeof(ChapterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(UserList), typeof(UserList));
            Routing.RegisterRoute(nameof(PopularPage), typeof(PopularPage));

            //Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));


            _Content = content;

            if (content == null)
            {
                _Content = new LoginApiResponseModel();
                edited = false;
            }
            this.BindingContext = _Content;


            ShellSection shell_section1 = new ShellSection
            {
                Title = "Мой Профиль",
            };
            shell_section1.Items.Add(new ShellContent() { Content = new Profile(content) });


            ShellSection shell_section2 = new ShellSection
            {
                Title = "Категории",
            };
            shell_section2.Items.Add(new ShellContent() { Content = new CategoriesListViewPage(content) });


            ShellSection shell_section3 = new ShellSection
            {
                Title = "Популярные",
            };
            shell_section3.Items.Add(new ShellContent() { Content = new PopularPage(content) });


            ShellSection shell_section4 = new ShellSection
            {
                Title = "Добавить фанфик -",
            };
            shell_section4.Items.Add(new ShellContent() { Content = new ItemsPage() });


            ShellSection shell_section5 = new ShellSection
            {
                Title = "Авторы",
            };
            shell_section5.Items.Add(new ShellContent() { Content = new UserList(content) });


            myshell.Items.Add(shell_section2);
            myshell.Items.Add(shell_section5);
            myshell.Items.Add(shell_section3);
            myshell.Items.Add(shell_section1);
            myshell.Items.Add(shell_section4);

        }
    

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //var v = _Content;
            //await Shell.Current.GoToAsync("//AboutPage", v);
        }
    }
}
