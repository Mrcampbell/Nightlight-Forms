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
using Android.Support.V7.Widget;
using Nightlight.Droid.Models;
using Android.Text;
using Android.Util;
using Nightlight.Models.Nodes;

namespace Nightlight.Droid.Services
{
    public class NightlightRecyclerViewViewHolder : RecyclerView.ViewHolder
    {
        public LinearLayout LinearLayout { get; private set; }

        private NightLightCell cell;
        public INightlightNode Node;

        public TextView Title { get; private set; }
        public TextView Warning { get; private set; }
        public EditText TextField { get; private set; }

        public Func<bool> IsValid { get; set; }
        public Func<string> GetErrorMessage { get; set; }


        public NightlightRecyclerViewViewHolder(View itemView) : base(itemView)
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
}