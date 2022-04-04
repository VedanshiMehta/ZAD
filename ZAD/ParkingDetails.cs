using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace ZAD
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ParkingDetails : AppCompatActivity
    {
        private TabLayout _tabLayoutParkingDetails;
        private ParkingInformationDetailsFragment _parkingInformationDetailsFragment;
   
        private MapFragment _mapFragment;
        private Toolbar _toolbarParkingDetails;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.parkingInformationLayout);
            UIReferences();
            UIClickEvent();
            ObjectCreation();
            SetTabDetails();
            SetSupportActionBar(_toolbarParkingDetails);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _toolbarParkingDetails.NavigationClick += _toolbarParkingDetails_NavigationClick;
           
          
        }

        private void _toolbarParkingDetails_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            Finish();
        }

        private void ObjectCreation()
        {
            
            _mapFragment = new MapFragment();
            _parkingInformationDetailsFragment = new ParkingInformationDetailsFragment();
            
        }

        private void UIReferences()
        {
            _tabLayoutParkingDetails = FindViewById<TabLayout>(Resource.Id.tabLayoutParkingInformation);
            _toolbarParkingDetails = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbarParkingDetails);

        }
        private void UIClickEvent()
        {
            _tabLayoutParkingDetails.TabSelected += _tabLayoutParkingDetails_TabSelected;
           

        }

    
        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }

        private void _tabLayoutParkingDetails_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            Fragment _selected = null;
            
            switch (e.Tab.Position)
            {

                case 0:
                    _selected = _mapFragment;
                   
                    break;

                case 1:

                    _selected = _parkingInformationDetailsFragment;
                    break;
            
            }

            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutParkingInformation, _selected).Commit();
        }

        
        private void SetTabDetails()
        {
            _tabLayoutParkingDetails.AddTab(_tabLayoutParkingDetails.NewTab().SetText(Resource.String.map));
            _tabLayoutParkingDetails.AddTab(_tabLayoutParkingDetails.NewTab().SetText(Resource.String.list));
        }
    }
}