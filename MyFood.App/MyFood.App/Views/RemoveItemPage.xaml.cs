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

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
