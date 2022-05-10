using System;
using MyFood.App.Models;
using Xamarin.Forms;

namespace MyFood.App.ViewModels
{
    public class RemoveItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
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
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
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

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                EAN = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}