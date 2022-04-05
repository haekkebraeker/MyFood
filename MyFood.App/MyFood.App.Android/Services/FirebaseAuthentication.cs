using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using MyFood.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFood.App.Droid.Services
{
  public class FirebaseAuthentication : IFirebaseAuthentication
  {
    public async Task<bool> IsSignIn()
    {
      var user = FirebaseAuth.Instance.CurrentUser;
      if (FirebaseAuth.Instance.CurrentUser != null)
      {
        await Songr.Controller.UserController.GetUser(user.Uid, true);
        Songr.Songr.ApiKey = user.GetIdToken(false).Result.ToString();
        return true;
      }
      return user != null;
    }
    public async Task<string> CreateUser(string email, string pass, string userPass)
    {
      try
      {
        await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(User.ThisUser.EMail, userPass);
        var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, pass);
        string uid = user.User.Uid;
        await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(User.ThisUser.EMail, userPass);
        user.User.GetIdToken(false).Result.ToString();
        return uid;
      }
      catch (FirebaseAuthUserCollisionException)
      {
        return "FirebaseAuthUserCollisionException";
      }
      catch (FirebaseAuthInvalidCredentialsException)
      {
        return "FirebaseAuthInvalidCredentialsException";
      }
      catch (Exception)
      {
        return null;
      }
    }
    public async Task<string> LoginWithEmailAndPassword(string email, string password)
    {
      try
      {
        var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
        var token = user.User.GetIdToken(false).Result.ToString();
        await Songr.Controller.UserController.GetUser(user.User.Uid, true);
        Songr.Songr.ApiKey = token;
        return token;
      }
      catch (FirebaseAuthInvalidUserException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
      catch (FirebaseAuthInvalidCredentialsException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
    }
    public async Task ForgotPassword(string email)
    {
      await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
    }
    public bool SignOut()
    {
      try
      {
        Firebase.Auth.FirebaseAuth.Instance.SignOut();
        Songr.Songr.ApiKey = null;
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}