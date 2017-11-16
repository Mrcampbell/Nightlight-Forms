using Android.App;
using Android.Widget;
using Android.OS;
using Nightlight;
using Nightlight.TestClasses;
using Nightlight.Models.Form;

namespace Nightlight.Droid.QA
{
    [Activity(Label = "Nightlight.Droid.QA", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private NightlightFormController<StringClassForTestingValues> formController;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }

        protected void RunForm()
        {
            StringClassForTestingValues testClass = new StringClassForTestingValues();

            formController = new NightlightFormController<StringClassForTestingValues>(testClass);
        }
    }
}

