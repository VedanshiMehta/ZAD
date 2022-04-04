using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.TextField;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZAD.Model;

namespace ZAD
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SignupActivity : AppCompatActivity
    {
        private TextInputLayout _textInputLayoutEmailSignUp;
        private TextInputLayout _textInputLayoutPasswordSignUp;
        private EditText _editTextEmailSignUp;
        private EditText _editTextPasswordSignUp;
        private AppCompatButton _appCompatButtonSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.signUpLayout);
            UIReferences();
            UIEventClicks();
        }

        private void UIEventClicks()
        {
            _appCompatButtonSignUp.Click += _appCompatButtonSignUp_Click;
        }

        private void _appCompatButtonSignUp_Click(object sender, EventArgs e)
        {
            UpdateSigin();
    
        }

        private async Task UpdateSigin()
        {
            PostLoginModel posts = new PostLoginModel {email= _editTextEmailSignUp.Text , password = _editTextPasswordSignUp.Text };

            HttpClient httpClientSignUp = new HttpClient();
            var jasonStringSignUp = JsonConvert.SerializeObject(posts);
            var content = new StringContent(jasonStringSignUp, Encoding.UTF8, "application/json");
            var responseSignUp = await httpClientSignUp.PostAsync("https://reqres.in/api/register", content);
            if (responseSignUp.IsSuccessStatusCode)
            {
                Toast.MakeText(this, "SignUp Successfull", ToastLength.Short).Show();
                Finish();

            }
            else
            {

                Toast.MakeText(this, "Enter Data Doesn't Match", ToastLength.Short).Show();
            }
        }

        private void UIReferences()
        {
            _textInputLayoutEmailSignUp = FindViewById<TextInputLayout>(Resource.Id.textInputLayoutEmailSignUp);
            _textInputLayoutPasswordSignUp = FindViewById<TextInputLayout>(Resource.Id.textInputLayoutPasswordSignUp);
            _editTextEmailSignUp = FindViewById<EditText>(Resource.Id.editTextEmailSignUp);
            _editTextPasswordSignUp = FindViewById<EditText>(Resource.Id.editTextPasswordSignUp);
            _appCompatButtonSignUp = FindViewById<AppCompatButton>(Resource.Id.buttonSignUp);
        }
    }
}