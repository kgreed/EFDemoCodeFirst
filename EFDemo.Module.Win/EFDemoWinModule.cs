using System;
using System.Collections.Generic;
using System.ComponentModel;

using Demo.Module.Win;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using EFDemo.Module.Controllers;
using EFDemo.Module.Win.Controllers;

namespace EFDemo.Module.Win {
	[ToolboxItemFilter("Xaf.Platform.Win")]
	public sealed partial class EFDemoWinModule : ModuleBase {
		protected override IEnumerable<Type> GetRegularTypes() {
			return null;
		}
		protected override IEnumerable<Type> GetDeclaredControllerTypes() {
			return new Type[] {
				typeof(DemoAboutInfoController),
				typeof(WinDateEditCalendarController),
				typeof(WinTooltipController)
			};
		}
		public EFDemoWinModule() {
			InitializeComponent();
			DevExpress.ExpressApp.Scheduler.Win.SchedulerListEditor.DailyPrintStyleCalendarHeaderVisible = false;
            DevExpress.ExpressApp.ReportsV2.Win.WinReportServiceController.UseNewWizard = true;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
    }
}
