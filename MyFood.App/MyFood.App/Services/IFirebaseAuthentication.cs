using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFood.App.Services
{
  public interface IFirebaseAuthentication
  {
    Task<string> LoginWithEmailAndPassword(string email, string password);
    Task ForgotPassword(string email);
    bool SignOut();
    Task<bool> IsSignIn();
    Task<string> CreateUser(string email, string password, string userPass);
  }
}
