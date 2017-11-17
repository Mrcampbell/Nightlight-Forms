using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

namespace Nightlight.Droid.Models
{
    // BEGIN CLASSES
    public class NightLightCell : LinearLayout
    {
        public TextView Title { get; private set; }
        public TextView Warning { get; private set; }
        public EditText TextField { get; private set; }

        private void Initialize()
        {
            Title = new TextView(Application.Context) { Id = Constants.TITLE_TEXT_VIEW_ID };
            Warning = new TextView(Application.Context) { Id = Constants.WARNING_TEXT_VIEW_ID };
            TextField = new EditText(Application.Context) { Id = Constants.TEXT_FIELD_EDIT_TEXT_ID };


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
}