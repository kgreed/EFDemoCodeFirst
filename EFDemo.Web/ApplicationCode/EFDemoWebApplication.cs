using System;
using System.Data.Common;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Security;

using EFDemo.Module.Data;

namespace EFDemo.Web {
	public class EFDemoWebApplication : WebApplication {
		private DevExpress.ExpressApp.SystemModule.SystemModule systemModule1;
		private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule webSystemModule1;
		private SecurityModule securityModule1;
		private SecurityStrategyComplex securityStrategyComplex1;
		private DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule fileAttachmentsWebModule1;
		private DevExpress.ExpressApp.Validation.ValidationModule validationModule1;
        private DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule validationAspNetModule1;
		private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule1;
		private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule1;
		private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule objectsModule1;
		private EFDemo.Module.Web.EFDemoWebModule efDemoWebModule1;
		private EFDemo.Module.EFDemoModule efDemoModule1;
		private AuthenticationStandard authenticationStandard1;
		private DevExpress.ExpressApp.Scheduler.SchedulerModuleBase schedulerModuleBase1;
		private DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule schedulerAspNetModule1;
		private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModuleV21;
		private DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2 reportsAspNetModuleV21;
		private DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule pivotChartAspNetModule1;
		private DevExpress.ExpressApp.PivotChart.PivotChartModuleBase pivotChartModuleBase1;
		private DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule scriptRecorderAspNetModule1;
		private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase1;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule;
        private DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule notificationsModuleWeb;
        private DevExpress.ExpressApp.Office.Web.OfficeAspNetModule officeAspNetModule;

		public EFDemoWebApplication() {
			InitializeComponent();
		}
		protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
			if (args.Connection != null) {
				args.ObjectSpaceProvider = new EFObjectSpaceProvider(typeof(EFDemoDbContext), TypesInfo, null, (DbConnection)args.Connection);
			}
			else {
				args.ObjectSpaceProvider = new EFObjectSpaceProvider(typeof(EFDemoDbContext), TypesInfo, null, args.ConnectionString);
			}
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider());
		}
		private void EFDemoWebApplication_DatabaseVersionMismatch(Object sender, DatabaseVersionMismatchEventArgs e) {
			e.Updater.Update();
			e.Handled = true;
		}
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EFDemoWebApplication));
			this.systemModule1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
			this.webSystemModule1 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
			this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
			this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.securityStrategyComplex1.SupportNavigationPermissionsForTypes = false;
			this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
			this.fileAttachmentsWebModule1 = new DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule();
			this.validationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.validationAspNetModule1 = new DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule();
			this.viewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
			this.conditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
			this.objectsModule1 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
			this.efDemoModule1 = new EFDemo.Module.EFDemoModule();
			this.efDemoWebModule1 = new EFDemo.Module.Web.EFDemoWebModule();
			this.schedulerAspNetModule1 = new DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule();
			this.reportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
			this.reportsAspNetModuleV21 = new DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2();
			this.schedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
			this.pivotChartAspNetModule1 = new DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule();
			this.pivotChartModuleBase1 = new DevExpress.ExpressApp.PivotChart.PivotChartModuleBase();
			this.scriptRecorderModuleBase1 = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
			this.scriptRecorderAspNetModule1 = new DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule();
            this.notificationsModule = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.notificationsModuleWeb = new DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule();
            this.officeAspNetModule = new DevExpress.ExpressApp.Office.Web.OfficeAspNetModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// securityComplex1
			// 
			this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
			this.securityStrategyComplex1.RoleType = typeof(DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyRole);
			this.securityStrategyComplex1.UserType = typeof(DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyUser);
			// 
			// authenticationStandard1
			// 
			this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
			this.authenticationStandard1.UserType = typeof(DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyUser);
			// 
			// reportsModuleV21
			// 
			this.reportsModuleV21.EnableInplaceReports = true;
			this.reportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
			this.reportsModuleV21.ShowAdditionalNavigation = false;
            this.reportsModuleV21.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            this.reportsAspNetModuleV21.ReportViewerType = DevExpress.ExpressApp.ReportsV2.Web.ReportViewerTypes.HTML5;
            // 
            // validationModule1
            // 
            this.validationModule1.AllowValidationDetailsAccess = true;
			// 
			// viewVariantsModule1
			// 
			this.viewVariantsModule1.ShowAdditionalNavigation = false;
			// 
			// pivotChartModuleBase1
			// 
			this.pivotChartModuleBase1.ShowAdditionalNavigation = false;
			// 
			// EFDemoWebApplication
			// 
			this.ApplicationName = "EFDemo";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
			this.Modules.Add(this.systemModule1);
			this.Modules.Add(this.webSystemModule1);
			this.Modules.Add(this.securityModule1);
			this.Modules.Add(this.fileAttachmentsWebModule1);
			this.Modules.Add(this.validationModule1);
            this.Modules.Add(this.validationAspNetModule1);
			this.Modules.Add(this.viewVariantsModule1);
			this.Modules.Add(this.conditionalAppearanceModule1);
			this.Modules.Add(this.objectsModule1);
			this.Modules.Add(this.efDemoModule1);
			this.Modules.Add(this.efDemoWebModule1);
			this.Modules.Add(this.schedulerModuleBase1);
			this.Modules.Add(this.schedulerAspNetModule1);
			this.Modules.Add(this.reportsModuleV21);
			this.Modules.Add(this.reportsAspNetModuleV21);
			this.Modules.Add(this.pivotChartModuleBase1);
			this.Modules.Add(this.pivotChartAspNetModule1);
			this.Modules.Add(this.scriptRecorderModuleBase1);
			this.Modules.Add(this.scriptRecorderAspNetModule1);
            this.Modules.Add(this.notificationsModule);
            this.Modules.Add(this.notificationsModuleWeb);
            this.Modules.Add(this.officeAspNetModule);
            this.Security = this.securityStrategyComplex1;
			this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.EFDemoWebApplication_DatabaseVersionMismatch);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
		}
	}
}
