using Acr.UserDialogs;
using Android.Animation;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Views.Animations;
using AndroidX.Lifecycle;
using LoginMenuTest.Model;
using System;
using static Java.Util.Jar.Attributes;
using Android.Content;
using System.Reflection.Metadata.Ecma335;
using Google.Android.Material.Tabs;

namespace LoginMenuTest
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            List<UserModel> userModels = new List<UserModel>();
            userModels = CreateTempUsers();

            EditText username = (EditText)FindViewById(Resource.Id.username);
            EditText password = (EditText)FindViewById(Resource.Id.password);

            Button button = FindViewById<Button>(Resource.Id.loginbtn1);

            ObjectAnimator animatorLoginBtnCorrect = ObjectAnimator.OfFloat(button, nameof(button.ScaleX), 0.5f);
            animatorLoginBtnCorrect.SetDuration(800);

            ObjectAnimator animatorLoginBtnDenied = ObjectAnimator.OfFloat(button, nameof(button.TranslationX), -6f, 0f, 6f, 0f);
            animatorLoginBtnDenied.SetDuration(100);

            button.Click += (o, e) =>
            {
                bool isLoginSuccess = false;
                UserDialogs.Init(this);
                //animator.Start();

                foreach (var user in userModels)
                {
                    if (username.Text.Equals(user.Name) && password.Text.Equals(user.Password))
                    {
                        isLoginSuccess = true;
                        animatorLoginBtnCorrect.Start();
                        button.Text = "\u2713";

                        LoginConfirmed(animatorLoginBtnCorrect, animatorLoginBtnDenied, user);

                        break;
                    }
                }

                if (!isLoginSuccess)
                {
                    animatorLoginBtnDenied.Start();
                    LoginDenied(button);
                }

                /*if (username.Text.Equals("admin") && password.Text.Equals("admin"))
                {
                    animatorLoginBtnCorrect.Start();
                    button.Text = "\u2713";

                    LoginConfirmed();
                }
                else
                {
                    animatorLoginBtnDenied.Start();
                    LoginDenied(button);
                }*/
            };
        }

        private async void LoginConfirmed(ObjectAnimator anim1, ObjectAnimator anim2, UserModel user)
        {
            UserDialogs.Instance.ShowLoading("Logging in", MaskType.Gradient);
            await Task.Delay(1500);
            UserDialogs.Instance.ShowLoading("Completed", MaskType.Gradient);
            await Task.Delay(500);
            UserDialogs.Instance.ShowLoading("Loading application", MaskType.Gradient);
            await Task.Delay(1000);

            Intent intent = new Intent(this, typeof(HomeActivity));
            intent.PutExtra("user_logged_in", user.Name);
            StartActivity(intent);

            EditText username = (EditText)FindViewById(Resource.Id.username);
            EditText password = (EditText)FindViewById(Resource.Id.password);

            Button button = FindViewById<Button>(Resource.Id.loginbtn1);

            username.Text = string.Empty;
            password.Text = string.Empty;
            button.Text = "LOGIN";
            anim1.Reverse();
            anim2.Reverse();

            UserDialogs.Instance.HideLoading();

            /*UserDialogs.Instance.Loading("Loading Please Wait...", () =>
            {
                UserDialogs.Instance.HideLoading();
                SetContentView(Resource.Layout.home);

            }, "Cancel", true, MaskType.Gradient);*/
        }

        private async void LoginDenied(Button button)
        {
            button.Text = "\u2715";

            Toast.MakeText(Application, "The password and/or username you entered is wrong", ToastLength.Long).Show();

            await Task.Delay(200);

            button.Text = "LOGIN";

            // EXAMPLE OF ALERT DIALOG
            /*
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Title = "Wrong Credentials",
                Message = "The password and/or username you entered is wrong"
            });
            */
        }

        private List<UserModel> CreateTempUsers()
        {
            UserModel user1 = new UserModel("Daniel", "1234", 25);
            UserModel user2 = new UserModel("Kelvin", "4321", 31);

            UserModel adminUser = new UserModel("admin", "admin", 0);

            List<UserModel> userModels = new List<UserModel>();

            userModels.Add(user1);
            userModels.Add(user2);
            userModels.Add(adminUser);

            return userModels;
        }
    }
}