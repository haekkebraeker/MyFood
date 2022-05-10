using MyFood.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFood.App.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string EAN;
        private int anzahl;
        private DateTime ablaufdatum;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(EAN);
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
            get => EAN;
            set => SetProperty(ref EAN, value);
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
                EAN = EAN,
                Ablaufdatum = Ablaufdatum,
                Anzahl = Anzahl
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
