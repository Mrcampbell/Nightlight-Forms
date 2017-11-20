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
        private NightlightFormController<StringClassForTestingValues> formController;
        private StringClassForTestingValues testClass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            testClass = new StringClassForTestingValues();

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));

            RunForm(mRecyclerView, testClass);
        }

        protected void RunForm(RecyclerView recyclerView, StringClassForTestingValues testClass)
        {
            formController 
                = new NightlightFormController<StringClassForTestingValues>(ref testClass);

            NightlightRecyclerViewAdapter nightlightAdapter = new NightlightRecyclerViewAdapter(ref formController);

            recyclerView.SetAdapter(nightlightAdapter);
        }

        private void BindNewValues()
        {
            StringClassForTestingValues newTestClass = new StringClassForTestingValues();

            //foreach(var node in formController.Nodes)
            //{
                
            //}
        }

        protected override void OnPause()
        {
            base.OnPause();

            formController.UpdateObject(ref testClass);

            Log.Debug("OUTPUT : RequiredStringWithNoPreviousValue", testClass.RequiredStringWithNoPreviousValue);
            Log.Debug("OUTPUT : RequiredStringWithPreviousValue", testClass.RequiredStringWithPreviousValue);
            Log.Debug("OUTPUT : StringWithMinLengthThree", testClass.StringWithMinLengthThree);
            Log.Debug("OUTPUT : StringWithMaxLengthThree", testClass.StringWithMaxLengthThree);
            Log.Debug("OUTPUT : StringWithMinLengthThreeMaxLength5", testClass.StringWithMinLengthThreeMaxLength5);
        }
    }
}

