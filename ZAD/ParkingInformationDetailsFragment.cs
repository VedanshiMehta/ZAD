using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = AndroidX.Fragment.App.Fragment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.RecyclerView.Widget;
using ZAD.Model;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Android.App;

namespace ZAD
{
    public class ParkingInformationDetailsFragment : Fragment
    {
        private RecyclerView _recyclerViewLocationList;
        private RecyclerView.LayoutManager _layoutManagerLocationList;
        private LocationListAdapter _locationListAdapter;
        private List<LocationDetails> _locationList;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.parkingInformationDetailsFragment, container, false);
            _recyclerViewLocationList = view.FindViewById<RecyclerView>(Resource.Id.recycelerViewParkingInformation);



            GetLocationData();

            _layoutManagerLocationList = new LinearLayoutManager(Activity);
            _recyclerViewLocationList.SetLayoutManager(_layoutManagerLocationList);

            

            return view;


        }

     
        


        private async void GetLocationData()
        {


            ProgressDialog progressDialog = new ProgressDialog(Activity);
            progressDialog.SetMessage("Loading!.........");
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressDialog.Show();

            _locationList = new List<LocationDetails>();

            HttpClient httpClientlocation = new HttpClient();
            var response = await httpClientlocation.GetAsync("https://run.mocky.io/v3/46fd784a-979a-493d-a4f9-5cd08749fc6e");


            if (response.IsSuccessStatusCode)
            {

                var jasonStringLocation = await response.Content.ReadAsStringAsync();



                var _locationDetails = JsonConvert.DeserializeObject<List<LocationDetails>>(jasonStringLocation);



                _locationList.AddRange(_locationDetails);


            }

            _locationListAdapter = new LocationListAdapter(_locationList);
            _recyclerViewLocationList.SetAdapter(_locationListAdapter);
        }

    }
}
