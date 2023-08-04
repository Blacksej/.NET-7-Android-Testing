using Android.Content;
using Android.Views;
using LoginMenuTest.Model;
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

            Intent intent = this.Intent;
            String str = intent.GetStringExtra("user_logged_in");

            SetContentView(Resource.Layout.Main);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            Activity activity = this;

            AddTab("Back Tab", Resource.Drawable.ic_tab_white, new SampleTabFragment(activity));
            SampleTabFragment2 sampleTabFragment2 = new SampleTabFragment2(str);
            AddTab("Profile", Resource.Drawable.ic_tab_white, sampleTabFragment2);



        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        class SampleTabFragment : Fragment
        {
            public Activity HomeActivity { get; set; }
            public SampleTabFragment(Activity homeActivity)
            {
                  HomeActivity = homeActivity;
            }
            public override View OnCreateView(LayoutInflater inflater,
                ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(
                    Resource.Layout.home, container, false);

                Button backButton = view.FindViewById<Button>(Resource.Id.backButton);

                backButton.Click += (o, e) =>
                {
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                    //SetContentView(Resource.Layout.activity_main);

                    HomeActivity.Finish();
                };

                return view;
            }
        }

        class SampleTabFragment2 : Fragment
        {
            string ProfileName { get; set; }

            public SampleTabFragment2(string profileName)
            {
                ProfileName = profileName;
            }
            public override View OnCreateView(LayoutInflater inflater,
                ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(
                    Resource.Layout.profileTab, container, false);

                TextView profileName = view.FindViewById<TextView>(Resource.Id.profileName);

                if (profileName != null)
                    profileName.Text = ProfileName;
                else
                profileName.Text = "No user found";

                return view;
            }
        }
    }
}
