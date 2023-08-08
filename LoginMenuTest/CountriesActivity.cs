using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMenuTest
{
    [Activity(Label = "CountriesActivity")]
    public class CountriesActivity : ListActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                        

            // Instead of setting SetContentView, setting the ListAdapter property will automatically add a ListView to fill
            // the entire screen of the ListActivity. An ArrayAdapter takes in the context, which is this and the next parameter
            // defines the layout of the stackview item and then at last the list

            // It is possible to use list item designs provided by the platform instead of defining your own layout file for the ListAdapter.
            // For example, try using Android.Resource.Layout.SimpleListItem1 instead of Resource.Layout.list_item.

            // ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, countries);

            string[] countries = Resources.GetStringArray(Resource.Array.countries_array);

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, countries);

            // This makes sure that when a user starts typing, the list will automatically filter while typing
            ListView.TextFilterEnabled = true;

            ListView.SetItemChecked(1, true);


            // The ItemClick is used to subscribe handlers to clicks. When an item in the listview is clicked, the
            // handler is called and a toast message is displayed using the text from the clicked item
            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                CheckedTextView checkedTextView = ((CheckedTextView)args.View);
                checkedTextView.Checked = !checkedTextView.Checked;

                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            
        }
    }
}
