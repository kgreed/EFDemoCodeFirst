using System;

using DevExpress.XtraEditors;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using EFDemo.Module.Data;

namespace EFDemo.Module.Win.Controllers {
    public class WinDateEditCalendarController : ObjectViewController<DetailView, Employee> {
        protected override void OnActivated() {
            base.OnActivated();
            View.CustomizeViewItemControl(this, SetCalendarView, nameof(Employee.Birthday));
        }
        private void SetCalendarView(ViewItem viewItem) {
            DateEdit dateEdit = (DateEdit)viewItem.Control;
            dateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
        }
    }
}
