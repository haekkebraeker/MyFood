using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing;

namespace MyFood.App.Views
{
    public partial class ScanPage 
    {
        public ScanPage()
        {
            InitializeComponent();
        }
        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", result.Text, "OK");
                await Navigation.PopAsync();
            });
        }
    }
}
