using Android.App;
using Android.Widget;
using Android.OS;
using Nightlight;
using Nightlight.TestClasses;
using Nightlight.Models.Form;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Runtime;
using System;
using System.Linq;
using Nightlight.Models.Nodes;
using Android.Text;
using Nightlight.Droid.Services;

namespace Nightlight.Droid.QA
{
    [Activity(Label = "Nightlight.Droid.QA", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView mRecyclerView;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            StringClassForTestingValues testClass = new StringClassForTestingValues();

            RunForm(mRecyclerView, testClass);
        }



        

        

        protected void RunForm(RecyclerView recyclerView, StringClassForTestingValues testClass)
        {
            NightlightFormController<StringClassForTestingValues> formController 
                = new NightlightFormController<StringClassForTestingValues>(testClass);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            NightlightRecyclerViewAdapter nightlightAdapter = new NightlightRecyclerViewAdapter(formController);
            recyclerView.SetAdapter(nightlightAdapter);
        }
    }
}

