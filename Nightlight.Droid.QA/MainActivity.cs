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

namespace Nightlight.Droid.QA
{
    [Activity(Label = "Nightlight.Droid.QA", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private RecyclerView mRecyclerView;

        public static int TITLE_TEXT_VIEW_ID = 1;
        public static int WARNING_TEXT_VIEW_ID = 2;
        public static int TEXT_FIELD_EDIT_TEXT_ID = 3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            StringClassForTestingValues testClass = new StringClassForTestingValues();

            RunForm(mRecyclerView, testClass);
        }


        // BEGIN CLASSES
        public class NightLightCell : LinearLayout
        {
            public TextView Title { get; private set; }
            public TextView Warning { get; private set; }
            public EditText TextField { get; private set; }

            private void Initialize()
            {
                Title = new TextView(Application.Context) { Id = TITLE_TEXT_VIEW_ID };
                Warning = new TextView(Application.Context) { Id = WARNING_TEXT_VIEW_ID };
                TextField = new EditText(Application.Context) { Id = TEXT_FIELD_EDIT_TEXT_ID };


                Warning.Text = String.Empty;
                Warning.SetTextColor(Color.Red);
                Warning.SetLines(1);

                TextField.SetMaxLines(1);
                //TextField.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
                TextField.InputType = Android.Text.InputTypes.TextVariationPersonName;

                var cellLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

                this.Orientation = Orientation.Vertical;
                this.LayoutParameters = cellLayoutParams;

                this.AddView(Title);
                this.AddView(Warning);
                this.AddView(TextField);
            }

            public NightLightCell(Context context) : base(context)
            {
                Initialize();
            }

            public NightLightCell(Context context, IAttributeSet attrs) : base(context, attrs)
            {
                Initialize();
            }

            public NightLightCell(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
            {
                Initialize();
            }

            public NightLightCell(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
            {
                Initialize();
            }

            protected NightLightCell(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
                Initialize();
            }
        }

        public class NightlightAdapter : RecyclerView.Adapter
        {
            private NightlightFormController<StringClassForTestingValues> _formController;

            public NightlightAdapter(NightlightFormController<StringClassForTestingValues> formController)
            {
                _formController = formController;
            }
            public override int ItemCount => _formController.Nodes.Count();

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                NightlightViewHolder nightlightViewHolder = holder as NightlightViewHolder;

                // TODO: NONO
                var node = _formController.Nodes.ToList()[position] as NightlightStringNode;

                node.Value = "THIS IS A TEST";
                Log.Debug("MESSAGE:", node.GetErrorMessage());

                nightlightViewHolder.Title.Text = node.Title;
                nightlightViewHolder.TextField.Text = node.Value;
                nightlightViewHolder.IsValid = () => { node.Value = nightlightViewHolder.TextField.Text; return node.IsValid(); };
                nightlightViewHolder.GetErrorMessage = () => node.GetErrorMessage();
            }

            private NightLightCell CreateCell()
            {
                return new NightLightCell(Application.Context);
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                Context context = Application.Context;

                NightLightCell cell = CreateCell();

                NightlightViewHolder nightlightViewHolder = new NightlightViewHolder(cell);

                return nightlightViewHolder;
            }
        }

        public class NightlightViewHolder : RecyclerView.ViewHolder
        {
            public LinearLayout LinearLayout { get; private set; }

            private NightLightCell cell;

            public TextView Title { get; private set; }
            public TextView Warning { get; private set; }
            public EditText TextField { get; private set; }

            public Func<bool> IsValid { get; set; }
            public Func<string> GetErrorMessage { get; set; }

            public NightlightViewHolder(View itemView) : base(itemView)
            {
                cell = itemView as NightLightCell;

                Title = cell.Title;
                TextField = cell.TextField;
                Warning = cell.Warning;

                TextField.TextChanged += TextField_TextChanged;
            }

            private void TextField_TextChanged(object sender, TextChangedEventArgs e)
            {
                
                if (this.IsValid != null && !this.IsValid())
                {
                    if (this.GetErrorMessage != null)
                    {
                        Warning.Text = this.GetErrorMessage();
                        Log.Debug("AfterTextChanged: ", GetErrorMessage());
                    }
                }
                else
                {
                    Warning.Text = String.Empty;
                }
            }
        }

        protected void RunForm(RecyclerView recyclerView, StringClassForTestingValues testClass)
        {
            NightlightFormController<StringClassForTestingValues> formController 
                = new NightlightFormController<StringClassForTestingValues>(testClass);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            NightlightAdapter nightlightAdapter = new NightlightAdapter(formController);
            recyclerView.SetAdapter(nightlightAdapter);
        }
    }
}

