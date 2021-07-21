using System;
using System.Data.Common;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Win;

using EFDemo.Module.Data;

namespace EFDemo.Win {
	public partial class EFDemoWinApplication : WinApplication {
        #region Default XAF configuration options (https://www.devexpress.com/kb=T501418)
        #endregion
		public EFDemoWinApplication() {
			InitializeComponent();
			DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderControllerBase.ScriptRecorderEnabled = true;
		}
		protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
			if(args.Connection != null) {
				args.ObjectSpaceProviders.Add(new EFObjectSpaceProvider(typeof(EFDemoDbContext), TypesInfo, null, (DbConnection)args.Connection));
			}
			else {
                args.ObjectSpaceProviders.Add(new EFObjectSpaceProvider(typeof(EFDemoDbContext), TypesInfo, null, args.ConnectionString));
			}
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider());
        }
		private void EFDemoWinApplication_DatabaseVersionMismatch(Object sender, DatabaseVersionMismatchEventArgs e) {
			e.Updater.Update();
			e.Handled = true;
		}
	}
}
