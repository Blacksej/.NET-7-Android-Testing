using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMenuTest
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);

            Button backButton = FindViewById<Button>(Resource.Id.backButton);

            backButton.Click += (o, e) =>
            {
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
                //SetContentView(Resource.Layout.activity_main);

                Finish();
            };
        }
    }
}
