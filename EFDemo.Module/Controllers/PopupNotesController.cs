using System;
using System.Text.RegularExpressions;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
#if (CodeFirst)
using DevExpress.Persistent.BaseImpl.EF;
#endif
using EFDemo.Module.Data;

namespace EFDemo.Module.Controllers {
	public partial class PopupNotesController : ViewController {
        private void ShowNotesAction_Execute(Object sender, PopupWindowShowActionExecuteEventArgs args) {
            DemoTask task = (DemoTask)View.CurrentObject;
            View.ObjectSpace.SetModified(task);
            foreach(Note note in args.PopupWindow.View.SelectedObjects) {
                if(!String.IsNullOrEmpty(task.Description)) {
                    task.Description += Environment.NewLine;
                }
                task.Description += StripHTML(note.Text);
            }
            ViewItem item = ((DetailView)View).FindItem("Description");
            ((PropertyEditor)item).ReadValue();
            if(View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View) {
                View.ObjectSpace.CommitChanges();
            }
        }
        private void ShowNotesAction_CustomizePopupWindowParams(Object sender, CustomizePopupWindowParamsEventArgs args) {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Note));
            string noteListViewId = Application.FindLookupListViewId(typeof(Note));
            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(Note), noteListViewId);
            args.View = Application.CreateListView(noteListViewId, collectionSource, true);
        }
        public PopupNotesController()
			: base() {
			InitializeComponent();
			RegisterActions(components);
		}
        private string StripHTML(string HTMLText) {
            return Regex.Replace(HTMLText, "<[^>]+>", string.Empty).Replace("&nbsp;", "").Replace("&nbsp", "").Replace(System.Environment.NewLine, "").Replace("\t", "");
        }
    }
}
