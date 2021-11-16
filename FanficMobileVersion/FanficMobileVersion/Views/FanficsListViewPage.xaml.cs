using FanficMobileVersion.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanficMobileVersion.ViewModel;
using fanfic_mobile.Views;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace fanfic_mobile.Views
{

public partial class FanficsListViewPage : ContentPage
{
   
 
    public FanficsListViewPage()
    {
            //InitializeComponent();
        }

    async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //Deselect Item
        ((ListView)sender).SelectedItem = null;
    }
}
}
