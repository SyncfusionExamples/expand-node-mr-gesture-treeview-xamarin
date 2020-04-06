using System;
using System.Collections.Generic;
using System.Text;
using MR.Gestures;
using Syncfusion.TreeView.Engine;
using Syncfusion.XForms.TreeView;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class Behavior : Behavior<MR.Gestures.Grid>
    {
        #region Overrrides
        protected override void OnAttachedTo(MR.Gestures.Grid bindable)
        {
            bindable.Tapped += Bindable_Tapped;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(MR.Gestures.Grid bindable)
        {
            bindable.Tapped -= Bindable_Tapped;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Event

        private void Bindable_Tapped(object sender, TapEventArgs e)
        {
            var treeViewNode = ((sender as MR.Gestures.Grid).BindingContext) as TreeViewNode;
            var treeView = (sender as MR.Gestures.Grid).Parent as SfTreeView;
            treeView.ExpandNode(treeViewNode);
        }
        #endregion
    }
}
