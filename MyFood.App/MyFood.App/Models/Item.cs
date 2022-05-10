using System;

namespace MyFood.App.Models
{
  public class Item
  {
    public string Id { get; set; }
    public string Text { get; set; }
    public string EAN { get; set; }
        public int Anzahl { get; set; }
        public DateTime Ablaufdatum { get; set; }
    }
}