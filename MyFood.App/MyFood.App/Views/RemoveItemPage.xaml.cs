using MyFood.App.Models;
using MyFood.App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFood.App.Views
{
    public partial class RemoveItemPage : ContentPage
    {
        public Item Item { get; set; }
        public RemoveItemPage()
        {
            InitializeComponent();
            BindingContext = new RemoveItemViewModel(); 
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
                    EANEntry.Text = result.Text;
                });
            };
            // Navigate to our scanner page
            await Navigation.PushModalAsync(scanPage, true);
        }
    }
}
