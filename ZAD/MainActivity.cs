using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.TextField;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZAD.Model;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace ZAD
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private TextInputLayout _textInputLayoutEmail;
        private TextInputLayout _textInputLayoutPassword;
        private EditText _edittextTextEmail;
        private EditText _editTextPassword;
        private TextView _textViewForgotPassword;
        private TextView _textViewSignIn;
        private Toolbar _toolbarLogin;
        private AppCompatButton _appCompatButtonLogin;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();

         

        }

        private void UIClickEvents()
        {
            _textViewForgotPassword.Click += _textViewForgotPassword_Click;
            _textViewSignIn.Click += _textViewSignIn_Click;
            _appCompatButtonLogin.Click += _appCompatButtonLogin_ClickAsync;

            
        }

        private void _appCompatButtonLogin_ClickAsync(object sender, EventArgs e)
        {
            _ = UpdatePostAsync();
          
        }

       
        private void _textViewSignIn_Click(object sender, EventArgs e)
        {
            Intent signup = new Intent(this, typeof(SignupActivity));
            StartActivity(signup);
        }

        private void _textViewForgotPassword_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Forgot Password", ToastLength.Short).Show();
        }

        private void UIReferences()
        {
            _textInputLayoutEmail = FindViewById<TextInputLayout>(Resource.Id.textInputLayoutEmail);
            _textInputLayoutPassword = FindViewById<TextInputLayout>(Resource.Id.textInputLayoutPassword);
            _edittextTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            _editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            _textViewForgotPassword = FindViewById<TextView>(Resource.Id.textViewForgotPassword);
            _textViewSignIn = FindViewById<TextView>(Resource.Id.textViewSignUp);
            _appCompatButtonLogin = FindViewById<AppCompatButton>(Resource.Id.buttonLogin);
            _toolbarLogin = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
        }

       

        private  async Task UpdatePostAsync()
        {

            PostLoginModel post = new PostLoginModel { email = _edittextTextEmail.Text, password = _editTextPassword.Text };

            
            HttpClient httpClient = new HttpClient();
            var jasonString = JsonConvert.SerializeObject(post);
            var content = new StringContent(jasonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://reqres.in/api/login", content);
            if (response.IsSuccessStatusCode)
            {
                Intent parkingInfo = new Intent(this, typeof(ParkingDetails));
                StartActivity(parkingInfo);

            }
            else
            {
                Toast.MakeText(this, "Enter Data Doesn't Match", ToastLength.Short).Show();
            }

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}