using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using MyFood.App.Services;

[assembly: Dependency(typeof(MyFood.iOS.Services.FirebaseAuthentication))]
namespace MyFood.App.iOS.Services
{
  class FirebaseAuthentication : IFirebaseAuthentication
  {
    public async Task<bool> IsSignIn()
    {
      var user = Auth.DefaultInstance.CurrentUser;
      if (Auth.DefaultInstance.CurrentUser != null)
      {
        Songr.Songr.ApiKey = await user.GetIdTokenAsync();
        await Songr.Controller.UserController.GetUser(user.Uid, true);
        return true;
      }
      return false;
    }
    public async Task<string> CreateUser(string email, string pass, string adminPass)
    {
      try
      {
        await Auth.DefaultInstance.SignInWithPasswordAsync(Songr.Models.User.ThisUser.EMail, adminPass);
        await Auth.DefaultInstance.CreateUserAsync(email, pass);
        var user = Auth.DefaultInstance.CurrentUser;
        string uid = user.Uid;
        await Auth.DefaultInstance.SignInWithPasswordAsync(Songr.Models.User.ThisUser.EMail, adminPass);
        Songr.Songr.ApiKey = await user.GetIdTokenAsync();
        return uid;
      }
      catch (NSErrorException ex)
      {
        switch (ex.Code)
        {
          case 17007:
            return "FirebaseAuthUserCollisionException";
          case 17009:
            return "FirebaseAuthInvalidCredentialsException";
          default:
            return null;
        }
      }
    }
    public async Task<string> LoginWithEmailAndPassword(string email, string password)
    {
      AuthDataResult user;
      try
      {
        user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
        Songr.Songr.ApiKey = await user.User.GetIdTokenAsync();
        await Songr.Controller.UserController.GetUser(user.User.Uid, true);
      }
      catch (ArgumentNullException)
      {
        return "NoContext";
      }
      catch (Exception ex)
      {
        return "BadCredentials";
      }
      return user.User.Uid.ToString();
    }
    public async Task ForgotPassword(string email)
    {
      await Auth.DefaultInstance.SendPasswordResetAsync(email);
    }
    public bool SignOut()
    {
      try
      {
        _ = Auth.DefaultInstance.SignOut(out NSError error);
        return error == null;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}