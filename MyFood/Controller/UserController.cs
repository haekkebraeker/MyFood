using MyFood.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFood.Controller
{
  public static class UserController
  {
    public static Task<User> GetUser(string firebaseUid, bool setAsDefault)
    {
      return null;
      /*
       * string query = "";
            try
            {
                using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                new KeyValuePair<string, string>("fid", firebaseUid),
                }))
                {
                    query = content.ReadAsStringAsync().Result;
                    User user = new User().Serialize(BsonDocument.Parse(await new Settings().HttpClient.GetStringAsync("user/getuser?" + query)));
                    if (setAsDefault) { User.ThisUser = user; }
                    return user;
                }
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("500"))
                {
                    throw new HttpRequestException("Serverfehler!");
                }
                else if (ex.Message.Contains("404"))
                {
                    return null;
                }
                else if (ex.Message.Contains("401"))
                {
                    throw new HttpRequestException("Nutzer nicht berechtigt!");
                }
                else
                {
                    throw new Exception("unbekannter Fehler");
                }
            }*/
    }
  }
}
