using MyFood.App.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFood.App.ViewModels
{
  [QueryProperty(nameof(ItemId), nameof(ItemId))]
  public class ItemDetailViewModel : BaseViewModel
  {
    private string itemId;
    private string text;
    private string ean;
        private DateTime ablaufdatum;
        public string Id { get; set; }

    public string Text
    {
      get => text;
      set => SetProperty(ref text, value);
    }

    public string EAN
    {
      get => ean;
      set => SetProperty(ref ean, value);
    }
    public DateTime Ablaufdatum
    {
      get => ablaufdatum;
      set => SetProperty(ref ablaufdatum, value);
    }

    public string ItemId
    {
      get
      {
        return itemId;
      }
      set
      {
        itemId = value;
        LoadItemId(value);
      }
    }

    public async void LoadItemId(string itemId)
    {
      try
      {
        var item = await DataStore.GetItemAsync(itemId);
        Id = item.Id;
        Text = item.Text;
                EAN = item.EAN;
                Ablaufdatum = item.Ablaufdatum;
            }
      catch (Exception)
      {
        Debug.WriteLine("Failed to Load Item");
      }
    }
  }
}
