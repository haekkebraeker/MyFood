using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFood.App.Views
{
  public partial class AboutPage : ContentPage
  {
    public AboutPage()
    {
      InitializeComponent();
    }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NewItemPage());
        }
    }
}