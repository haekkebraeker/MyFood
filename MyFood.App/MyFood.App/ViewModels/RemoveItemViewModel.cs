using System;
using System.IO;
using MyFood.App.JSON;
using MyFood.App.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyFood.App.ViewModels
{
    public class RemoveItemViewModel : BaseViewModel
    {
        private string text;
        private string eAN;
        private int anzahl;
        private DateTime ablaufdatum;

        public RemoveItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public int Anzahl
        {
            get => anzahl;
            set => SetProperty(ref anzahl, value);
        }

        public string EAN
        {
            get => eAN;
            set => SetProperty(ref eAN, value);
        }
        public DateTime Ablaufdatum
        {
            get => ablaufdatum;
            set => SetProperty(ref ablaufdatum, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                EAN = eAN,
                Ablaufdatum = Ablaufdatum,
                Anzahl = anzahl
            };

            await DataStore.AddItemAsync(newItem);


            string ProductJsonpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Product.json");
            if (!File.Exists(ProductJsonpath))
            {
                File.Create(ProductJsonpath);
            }
            string json = File.ReadAllText(ProductJsonpath);
            var Json = JsonConvert.DeserializeObject<ProductListJSON>(json);
            //Remove here


            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}