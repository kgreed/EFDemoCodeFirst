namespace EFDemo.Win {
	partial class EFDemoWinApplication {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void DisposeCore() {
			if((components != null)) {
				components.Dispose();
			}
			base.DisposeCore();
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.systemModule1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
			this.winSystemModule1 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
			this.viewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
			this.validationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
			this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
			this.objectsModule1 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
			this.efDemoModule1 = new EFDemo.Module.EFDemoModule();
			this.efDemoWinModule1 = new EFDemo.Module.Win.EFDemoWinModule();
			this.validationWinModule1 = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
			this.fileAttachmentsWinModule1 = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
			this.conditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
			this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.securityStrategyComplex1.SupportNavigationPermissionsForTypes = false;
			this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
			this.pivotChartWindowsFormsModule1 = new DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule();
			this.pivotChartModuleBase1 = new DevExpress.ExpressApp.PivotChart.PivotChartModuleBase();
			this.schedulerWindowsFormsModule1 = new DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule();
			this.reportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
			this.reportsWindowsFormsModuleV21 = new DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2();
			this.schedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
			this.scriptRecorderModuleBase1 = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
			this.scriptRecorderWindowsFormsModule1 = new DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule();
            this.notificationsModule = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.notificationsModuleWin = new DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule();
            this.officeWindowsFormsModule = new DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// reportsModuleV21
			// 
			this.reportsModuleV21.EnableInplaceReports = true;
			this.reportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
            this.reportsModuleV21.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
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
			// EFDemoWinApplication
			// 
			this.ApplicationName = "EFDemo";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
			this.Modules.Add(this.systemModule1);
			this.Modules.Add(this.winSystemModule1);
			this.Modules.Add(this.viewVariantsModule1);
			this.Modules.Add(this.validationModule1);
			this.Modules.Add(this.securityModule1);
			this.Modules.Add(this.objectsModule1);
			this.Modules.Add(this.conditionalAppearanceModule1);
			this.Modules.Add(this.efDemoModule1);
			this.Modules.Add(this.efDemoWinModule1);
			this.Modules.Add(this.validationWinModule1);
			this.Modules.Add(this.fileAttachmentsWinModule1);
			this.Modules.Add(this.pivotChartModuleBase1);
			this.Modules.Add(this.pivotChartWindowsFormsModule1);
			this.Modules.Add(this.schedulerModuleBase1);
			this.Modules.Add(this.schedulerWindowsFormsModule1);
			this.Modules.Add(this.reportsModuleV21);
			this.Modules.Add(this.reportsWindowsFormsModuleV21);
			this.Modules.Add(this.scriptRecorderModuleBase1);
			this.Modules.Add(this.scriptRecorderWindowsFormsModule1);
            this.Modules.Add(this.notificationsModule);
            this.Modules.Add(this.notificationsModuleWin);
            this.Modules.Add(this.officeWindowsFormsModule);
			this.Security = this.securityStrategyComplex1;
			this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.EFDemoWinApplication_DatabaseVersionMismatch);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.ExpressApp.SystemModule.SystemModule systemModule1;
		private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule winSystemModule1;
		private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule1;
		private DevExpress.ExpressApp.Validation.ValidationModule validationModule1;
		private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
		private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule objectsModule1;
		private EFDemo.Module.EFDemoModule efDemoModule1;
		private EFDemo.Module.Win.EFDemoWinModule efDemoWinModule1;
		private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule validationWinModule1;
		private DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule fileAttachmentsWinModule1;
		private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule1;
		private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
		private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
		private DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule pivotChartWindowsFormsModule1;
		private DevExpress.ExpressApp.PivotChart.PivotChartModuleBase pivotChartModuleBase1;
		private DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule schedulerWindowsFormsModule1;
		private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModuleV21;
		private DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2 reportsWindowsFormsModuleV21;
		private DevExpress.ExpressApp.Scheduler.SchedulerModuleBase schedulerModuleBase1;
		private DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule scriptRecorderWindowsFormsModule1;
		private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase1;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule;
        private DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule notificationsModuleWin;
        private DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule officeWindowsFormsModule;

    }
}
