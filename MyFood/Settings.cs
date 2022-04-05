using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MyFood
{
  public class Settings
  {
    public Settings()
    {
      HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
    }
    public static string ApiKey { get; set; }
    public static bool IsOnDevelopment { get; set; }
    public static Uri PublicApiUri = new Uri(""); //hier mit Slash, bei HttpClient ohne /
    public static Uri DevApiUrl = new Uri("");
    public HttpClient HttpClient = new HttpClient();
  }
}
