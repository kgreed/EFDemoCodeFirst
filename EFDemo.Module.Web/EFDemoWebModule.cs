using System;
using System.Collections.Generic;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using EFDemo.Module.Controllers;
using EFDemo.Module.Web.Controllers;

namespace EFDemo.Module.Web {
	[ToolboxItemFilter("Xaf.Platform.Web")]
	public sealed partial class EFDemoWebModule : ModuleBase {
		protected override IEnumerable<Type> GetRegularTypes() {
			return null;
		}
		protected override IEnumerable<Type> GetDeclaredControllerTypes() {
			return new Type[] {
				typeof(ChooseTemplateController),
				typeof(WebDateEditCalendarController),
				typeof(WebTooltipController)
			};
		}
		public EFDemoWebModule() {
			InitializeComponent();
		}
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
    }
}
