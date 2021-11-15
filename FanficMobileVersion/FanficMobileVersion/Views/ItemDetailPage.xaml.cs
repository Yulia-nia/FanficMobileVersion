using FanficMobileVersion.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FanficMobileVersion.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}