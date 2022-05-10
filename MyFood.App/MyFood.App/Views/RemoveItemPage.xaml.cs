using System;
using System.Collections.Generic;
using MyFood.App.ViewModels;
using Xamarin.Forms;

namespace MyFood.App.Views
{
    public partial class RemoveItemPage : ContentPage
    {
        public RemoveItemPage()
        {
            InitializeComponent();
            BindingContext = new RemoveItemViewModel(); 
        }
    }
}
