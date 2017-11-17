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
using Nightlight.Models.Form;
using Nightlight.TestClasses;
using Nightlight.Models.Nodes;
using Nightlight.Droid.Models;

namespace Nightlight.Droid.Services
{
    public class NightlightRecyclerViewAdapter : RecyclerView.Adapter
    {
        private NightlightFormController<StringClassForTestingValues> _formController;
        private List<INightlightNode> _nodes;

        public NightlightRecyclerViewAdapter(NightlightFormController<StringClassForTestingValues> formController)
        {
            _formController = formController;
            _nodes = formController.Nodes.ToList();
        }
        public override int ItemCount => _formController.Nodes.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            NightlightRecyclerViewViewHolder nightlightViewHolder = holder as NightlightRecyclerViewViewHolder;

            var node = _nodes[position] as NightlightStringNode;

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

            NightlightRecyclerViewViewHolder nightlightViewHolder = new NightlightRecyclerViewViewHolder(cell);

            return nightlightViewHolder;
        }
    }
}