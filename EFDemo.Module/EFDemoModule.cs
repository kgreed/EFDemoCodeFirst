using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.SystemModule;

using EFDemo.Module.Data;
using EFDemo.Module.Reports;
using EFDemo.Module.Controllers;

namespace EFDemo.Module {
    public sealed partial class EFDemoModule : ModuleBase {
        private String GetContextId() {
            return Application.GetType().Name.Contains("WinApplication") ? "Win" : "Web";
        }
        private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, GetContextId());
            e.Handled = true;
        }
        private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, GetContextId());
            e.Handled = true;
        }

        protected override IEnumerable<Type> GetRegularTypes() {
            return new Type[] {
                typeof(EFDemoDbContext)
            };
        }
        protected override IEnumerable<Type> GetDeclaredExportedTypes() {
            return new Type[] {
                typeof(Employee),
                typeof(DemoTask),
                typeof(Department),
                typeof(Payment),
                typeof(PortfolioFileData),
                typeof(Position),
                typeof(Resume)
            };
        }
        protected override IEnumerable<Type> GetDeclaredControllerTypes() {
            return new Type[] {
                typeof(ClearEmployeeTasksController),
				typeof(EFDetailViewController),
                typeof(PopupNotesController),
                typeof(TaskActionsController)
            };
        }
        static EFDemoModule() {
            Database.SetInitializer<EFDemoDbContext>(new DropCreateDatabaseIfModelChanges<EFDemoDbContext>());
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(SqlFunctions);
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(DbFunctions);
            ResetViewSettingsController.DefaultAllowRecreateView = false;
        }
        public EFDemoModule() {
            InitializeComponent();
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            application.OptimizedControllersCreation = true;
            application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            PredefinedReportsUpdater predefinedReportsUpdater = new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);
            predefinedReportsUpdater.AddPredefinedReport<EmployeeListReport>("Employee List Report", typeof(Employee), true);
            return new ModuleUpdater[] { updater, predefinedReportsUpdater };
        }
        public override void Setup(ApplicationModulesManager moduleManager) {
            base.Setup(moduleManager);
            ReportsModuleV2 reportModule = moduleManager.Modules.FindModule<ReportsModuleV2>();
            reportModule.ReportDataType = typeof(ReportDataV2);
        }
    }
}
