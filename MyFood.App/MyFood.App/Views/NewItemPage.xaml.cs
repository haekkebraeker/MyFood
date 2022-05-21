using MyFood.App.Models;
using MyFood.App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Client;

namespace MyFood.App.Views
{
  public partial class NewItemPage : ContentPage
  {
    public Item Item { get; set; }
        public string EAN { get; set; }

    public NewItemPage()
    {
      InitializeComponent();
            Item = new Item();
      BindingContext = new NewItemViewModel();
    }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var scanPage = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    EAN = result.Text;
                });
            };
            // Navigate to our scanner page
            await Navigation.PushModalAsync(scanPage, true);
        }
    }
}