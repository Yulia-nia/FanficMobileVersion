using FanficMobileVersion.ViewModels;
using FanficMobileVersion.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FanficMobileVersion
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CategoriesListViewPage), typeof(CategoriesListViewPage));
            Routing.RegisterRoute(nameof(CategoryDetailPage), typeof(CategoryDetailPage));
            Routing.RegisterRoute(nameof(FanficPage), typeof(FanficPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
