using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Security;
#if(CodeFirst)
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
#endif
using EFDemo.Module.Data;


namespace EFDemo.Module.DatabaseUpdate {
#if(CodeFirst)
    public class Updater : ModuleUpdater {  
        private void CreateDataToBeAnalysed() {
            Analysis taskAnalysis1 = ObjectSpace.FirstOrDefault<Analysis>(a => a.Name == "Completed tasks");
            if(taskAnalysis1 == null) {
                taskAnalysis1 = ObjectSpace.CreateObject<Analysis>();
                taskAnalysis1.Name = "Completed tasks";
                taskAnalysis1.ObjectTypeName = typeof(DemoTask).FullName;
                /*taskAnalysis1.Criteria = "[Status] = 'Completed'";*/
                taskAnalysis1.Criteria = "[Status] = ##Enum#DevExpress.Persistent.Base.General.TaskStatus,Completed#";
            }
            Analysis taskAnalysis2 = ObjectSpace.FirstOrDefault<Analysis>(a => a.Name == "Estimated and actual work comparison");
            if(taskAnalysis2 == null) {
                taskAnalysis2 = ObjectSpace.CreateObject<Analysis>();
                taskAnalysis2.Name = "Estimated and actual work comparison";
                taskAnalysis2.ObjectTypeName = typeof(DemoTask).FullName;
            }
        }
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            //Role defaultRole = CreateDefaultRole();

            Position developerPosition = ObjectSpace.FirstOrDefault<Position>(p => p.Title == "Developer");
            if(developerPosition == null) {
                developerPosition = ObjectSpace.CreateObject<Position>();
                developerPosition.Title = "Developer";
            }
            Position managerPosition = ObjectSpace.FirstOrDefault<Position>(p => p.Title == "Manager");
            if(managerPosition == null) {
                managerPosition = ObjectSpace.CreateObject<Position>();
                managerPosition.Title = "Manager";
            }

            Department devDepartment = ObjectSpace.FirstOrDefault<Department>(d => d.Title == "Development Department");
            if(devDepartment == null) {
                devDepartment = ObjectSpace.CreateObject<Department>();
                devDepartment.Title = "Development Department";
                devDepartment.Office = "205";
                devDepartment.Positions.Add(developerPosition);
                devDepartment.Positions.Add(managerPosition);
            }

            Department salesDepartment = ObjectSpace.FirstOrDefault<Department>(d => d.Title == "Sales Department");
            if(salesDepartment == null) {
                salesDepartment = ObjectSpace.CreateObject<Department>();
                salesDepartment.Title = "Sales Department";
                salesDepartment.Office = "125";
                salesDepartment.Positions.Add(managerPosition);
            }

            Employee employeeMary = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Mary" && e.LastName == "Tellitson");
            if(employeeMary == null) {
                employeeMary = ObjectSpace.CreateObject<Employee>();
                employeeMary.FirstName = "Mary";
                employeeMary.LastName = "Tellitson";
                employeeMary.Email = "mary_tellitson@md.com";
                employeeMary.Birthday = new DateTime(1980, 11, 27);
                employeeMary.Department = devDepartment;
                employeeMary.Position = managerPosition;
            }
            Employee employeeJohn = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "John" && e.LastName == "Nilsen");
            if(employeeJohn == null) {
                employeeJohn = ObjectSpace.CreateObject<Employee>();
                employeeJohn.FirstName = "John";
                employeeJohn.LastName = "Nilsen";
                employeeJohn.Email = "john_nilsen@md.com";
                employeeJohn.Birthday = new DateTime(1981, 10, 3);
                employeeJohn.Department = devDepartment;
                employeeJohn.Position = developerPosition;
            }
            Employee employeeAndrew = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Andrew" && e.LastName == "Fuller");
            if(employeeAndrew == null) {
                employeeAndrew = ObjectSpace.CreateObject<Employee>();
                employeeAndrew.FirstName = "Andrew";
                employeeAndrew.LastName = "Fuller";
                employeeAndrew.Email = "andrewfuller@example.com";
                employeeAndrew.Birthday = new DateTime(1952, 3, 19);
                employeeAndrew.Department = salesDepartment;
                employeeAndrew.Position = managerPosition;
            }
            Employee employeeRobert = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Robert" && e.LastName == "King");
            if(employeeRobert == null) {
                employeeRobert = ObjectSpace.CreateObject<Employee>();
                employeeRobert.FirstName = "Robert";
                employeeRobert.LastName = "King";
                employeeRobert.Email = "robertking@example.com";
                employeeRobert.Birthday = new DateTime(1975, 4, 25);
                employeeRobert.Department = salesDepartment;
                employeeRobert.Position = managerPosition;
            }
            if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Review reports") == null) {
                DemoTask task = ObjectSpace.CreateObject<DemoTask>();
                task.Subject = "Review reports";
                task.AssignedTo = employeeJohn;
                task.StartDate = DateTime.Parse("May 03, 2008");
                task.DueDate = DateTime.Parse("September 06, 2008");
                task.Status = DevExpress.Persistent.Base.General.TaskStatus.InProgress;
                task.Priority = Priority.High;
                task.EstimatedWork = 60;
                task.Description = "Analyse the reports and assign new tasks to employees.";
            }
            if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Fix breakfast") == null) {
                DemoTask task = ObjectSpace.CreateObject<DemoTask>();
                task.Subject = "Fix breakfast";
                task.AssignedTo = employeeMary;
                task.StartDate = DateTime.Parse("May 03, 2008");
                task.DueDate = DateTime.Parse("May 04, 2008");
                task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
                task.Priority = Priority.Low;
                task.EstimatedWork = 1;
                task.ActualWork = 3;
                task.Description = "The Development Department - by 9 a.m.\r\nThe R&QA Department - by 10 a.m.";
            }
            if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Task1") == null) {
                DemoTask task = ObjectSpace.CreateObject<DemoTask>();
                task.Subject = "Task1";
                task.AssignedTo = employeeJohn;
                task.StartDate = DateTime.Parse("June 03, 2008");
                task.DueDate = DateTime.Parse("June 06, 2008");
                task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
                task.Priority = Priority.High;
                task.EstimatedWork = 10;
                task.ActualWork = 15;
                task.Description = "A task designed specially to demonstrate the PivotChart module. Switch to the Reports navigation group to view the generated analysis.";
            }
            if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Task2") == null) {
                DemoTask task = ObjectSpace.CreateObject<DemoTask>();
                task.Subject = "Task2";
                task.AssignedTo = employeeJohn;
                task.StartDate = DateTime.Parse("July 03, 2008");
                task.DueDate = DateTime.Parse("July 06, 2008");
                task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
                task.Priority = Priority.Low;
                task.EstimatedWork = 8;
                task.ActualWork = 16;
                task.Description = "A task designed specially to demonstrate the PivotChart module. Switch to the Reports navigation group to view the generated analysis.";
            }

            CreateDataToBeAnalysed();

            // Create Users for the Complex Security Strategy
            // If a user named 'Sam' doesn't exist in the database, create this user
            PermissionPolicyUser user1 = ObjectSpace.FirstOrDefault<PermissionPolicyUser>(ppu => ppu.UserName == "Sam");
            if(user1 == null) {
                user1 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user1.UserName = "Sam";
                // Set a password if the standard authentication type is used
                user1.SetPassword("");
            }
            // If a user named 'John' doesn't exist in the database, create this user
            PermissionPolicyUser user2 = ObjectSpace.FirstOrDefault<PermissionPolicyUser>(ppu => ppu.UserName == "John");
            if(user2 == null) {
                user2 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user2.UserName = "John";
                // Set a password if the standard authentication type is used
                user2.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(ppr => ppr.Name == "Administrators");
            if(adminRole == null) {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
                // Add the Administrators role to the user1
                user1.Roles.Add(adminRole);
            }
            adminRole.IsAdministrative = true;

            // If a role with the Users name doesn't exist in the database, create this role
            PermissionPolicyRole userRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(ppr => ppr.Name == "Users");
            if(userRole == null) {
                userRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                userRole.Name = "Users";
                userRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
                userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/PermissionPolicyRole_ListView", SecurityPermissionState.Deny);
                userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/PermissionPolicyUser_ListView", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyRole>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyUser>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
                userRole.AddObjectPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.ReadOnlyAccess, cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", null, SecurityPermissionState.Allow);
                userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword", null, SecurityPermissionState.Allow);
                userRole.AddTypePermission<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Allow);
                userRole.AddTypePermission<PermissionPolicyTypePermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyMemberPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyObjectPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyNavigationPermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyActionPermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            }
           
            // Add the Users role to the user2
            if(!user2.Roles.Contains(userRole)) {
                user2.Roles.Add(userRole);
            }

            ObjectSpace.CommitChanges();
        }
    }
#else
    public class Updater : ModuleUpdater {
		private void CreateDataToBeAnalysed() {
			Analysis taskAnalysis1 = ObjectSpace.FirstOrDefault<Analysis>(a => a.Name == "Completed tasks");
			if(taskAnalysis1 == null) {
				taskAnalysis1 = ObjectSpace.CreateObject<Analysis>();
				taskAnalysis1.Name = "Completed tasks";
				taskAnalysis1.ObjectTypeName = typeof(DemoTask).FullName;
				/*taskAnalysis1.Criteria = "[Status] = 'Completed'";*/
				taskAnalysis1.Criteria = "[Status_Int] = " + ((Int32)TaskStatus.Completed).ToString();
			}
			Analysis taskAnalysis2 = ObjectSpace.FirstOrDefault<Analysis>(a => a.Name == "Estimated and actual work comparison");
			if(taskAnalysis2 == null) {
				taskAnalysis2 = ObjectSpace.CreateObject<Analysis>();
				taskAnalysis2.Name = "Estimated and actual work comparison";
				taskAnalysis2.ObjectTypeName = typeof(DemoTask).FullName;
			}
		}
		public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
		public override void UpdateDatabaseAfterUpdateSchema() {
			base.UpdateDatabaseAfterUpdateSchema();            

			Position developerPosition = ObjectSpace.FirstOrDefault<Position>(p => p.Title == "Developer");
			if(developerPosition == null) {
				developerPosition = ObjectSpace.CreateObject<Position>();
				developerPosition.Title = "Developer";
			}
			Position managerPosition = ObjectSpace.FirstOrDefault<Position>(p => p.Title == "Manager");
			if(managerPosition == null) {
				managerPosition = ObjectSpace.CreateObject<Position>();
				managerPosition.Title = "Manager";
			}

			Department devDepartment = ObjectSpace.FirstOrDefault<Department>(d => d.Title == "Development Department");
			if(devDepartment == null) {
				devDepartment = ObjectSpace.CreateObject<Department>();
				devDepartment.Title = "Development Department";
				devDepartment.Office = "205";
				devDepartment.Positions.Add(developerPosition);
				devDepartment.Positions.Add(managerPosition);
			}

            Department salesDepartment = ObjectSpace.FirstOrDefault<Department>(d => d.Title == "Sales Department");
            if (salesDepartment == null) {
                salesDepartment = ObjectSpace.CreateObject<Department>();
                salesDepartment.Title = "Sales Department";
                salesDepartment.Office = "125";
                salesDepartment.Positions.Add(managerPosition);
            }

            Employee employeeMary = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Mary" && e.LastName == "Tellitson");
			if(employeeMary == null) {
				employeeMary = ObjectSpace.CreateObject<Employee>();
				employeeMary.FirstName = "Mary";
				employeeMary.LastName = "Tellitson";
				employeeMary.Email = "mary_tellitson@md.com";
				employeeMary.Birthday = new DateTime(1980, 11, 27);
				employeeMary.Department = devDepartment;
				employeeMary.Position = managerPosition;
			}
            Employee employeeJohn = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "John" && e.LastName == "Nilsen");
			if(employeeJohn == null) {
				employeeJohn = ObjectSpace.CreateObject<Employee>();
				employeeJohn.FirstName = "John";
				employeeJohn.LastName = "Nilsen";
				employeeJohn.Email = "john_nilsen@md.com";
				employeeJohn.Birthday = new DateTime(1981, 10, 3);
				employeeJohn.Department = devDepartment;
				employeeJohn.Position = developerPosition;
			}
            Employee employeeAndrew = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Andrew" && e.LastName == "Fuller");
            if (employeeAndrew == null) {
                employeeAndrew = ObjectSpace.CreateObject<Employee>();
                employeeAndrew.FirstName = "Andrew";
                employeeAndrew.LastName = "Fuller";
                employeeAndrew.Email = "andrewfuller@example.com";
                employeeAndrew.Birthday = new DateTime(1952, 3, 19);
                employeeAndrew.Department = salesDepartment;
                employeeAndrew.Position = managerPosition;
            }
            Employee employeeRobert = ObjectSpace.FirstOrDefault<Employee>(e => e.FirstName == "Robert" && e.LastName == "King");
            if (employeeRobert == null) {
                employeeRobert = ObjectSpace.CreateObject<Employee>();
                employeeRobert.FirstName = "Robert";
                employeeRobert.LastName = "King";
                employeeRobert.Email = "robertking@example.com";
                employeeRobert.Birthday = new DateTime(1975, 4, 25);
                employeeRobert.Department = salesDepartment;
                employeeRobert.Position = managerPosition;
            }
			if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Review reports") == null) {
				DemoTask task = ObjectSpace.CreateObject<DemoTask>();
				task.Subject = "Review reports";
				task.AssignedTo = employeeJohn;
				task.StartDate = DateTime.Parse("May 03, 2008");
				task.DueDate = DateTime.Parse("September 06, 2008");
				task.Status = DevExpress.Persistent.Base.General.TaskStatus.InProgress;
				task.Priority = Priority.High;
				task.EstimatedWork = 60;
				task.Description = "Analyse the reports and assign new tasks to employees.";
			}
            if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Fix breakfast") == null) {
				DemoTask task = ObjectSpace.CreateObject<DemoTask>();
				task.Subject = "Fix breakfast";
				task.AssignedTo = employeeMary;
				task.StartDate = DateTime.Parse("May 03, 2008");
				task.DueDate = DateTime.Parse("May 04, 2008");
				task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
				task.Priority = Priority.Low;
				task.EstimatedWork = 1;
				task.ActualWork = 3;
				task.Description = "The Development Department - by 9 a.m.\r\nThe R&QA Department - by 10 a.m.";
			}
			if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Task1") == null) {
				DemoTask task = ObjectSpace.CreateObject<DemoTask>();
				task.Subject = "Task1";
				task.AssignedTo = employeeJohn;
				task.StartDate = DateTime.Parse("June 03, 2008");
				task.DueDate = DateTime.Parse("June 06, 2008");
				task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
				task.Priority = Priority.High;
				task.EstimatedWork = 10;
				task.ActualWork = 15;
				task.Description = "A task designed specially to demonstrate the PivotChart module. Switch to the Reports navigation group to view the generated analysis.";
			}
			if(ObjectSpace.FirstOrDefault<DemoTask>(dt => dt.Subject == "Task2") == null) {
				DemoTask task = ObjectSpace.CreateObject<DemoTask>();
				task.Subject = "Task2";
				task.AssignedTo = employeeJohn;
				task.StartDate = DateTime.Parse("July 03, 2008");
				task.DueDate = DateTime.Parse("July 06, 2008");
				task.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed;
				task.Priority = Priority.Low;
				task.EstimatedWork = 8;
				task.ActualWork = 16;
				task.Description = "A task designed specially to demonstrate the PivotChart module. Switch to the Reports navigation group to view the generated analysis.";
			}

			CreateDataToBeAnalysed();

            // Create Users for the Complex Security Strategy
            // If a user named 'Sam' doesn't exist in the database, create this user
            PermissionPolicyUser user1 = ObjectSpace.FirstOrDefault<PermissionPolicyUser>(ppu => ppu.UserName == "Sam");
            if(user1 == null) {
                user1 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user1.UserName = "Sam";
                // Set a password if the standard authentication type is used
                user1.SetPassword("");
            }
            // If a user named 'John' doesn't exist in the database, create this user
            PermissionPolicyUser user2 = ObjectSpace.FirstOrDefault<PermissionPolicyUser>(ppu => ppu.UserName == "John");
            if(user2 == null) {
                user2 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user2.UserName = "John";
                // Set a password if the standard authentication type is used
                user2.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(ppr => ppr.Name == "Administrators");
            if(adminRole == null) {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
                // Add the Administrators role to the user1
                user1.Roles.Add(adminRole);
            }
            adminRole.IsAdministrative = true;

            // If a role with the Users name doesn't exist in the database, create this role
            PermissionPolicyRole userRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(ppr => ppr.Name == "Users");
            if(userRole == null) {
                userRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                userRole.Name = "Users";
                userRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
                userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/PermissionPolicyRole_ListView", SecurityPermissionState.Deny);
                userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/PermissionPolicyUser_ListView", SecurityPermissionState.Deny);            
                userRole.AddTypePermission<PermissionPolicyRole>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyUser>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
                userRole.AddObjectPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.ReadOnlyAccess, cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", null, SecurityPermissionState.Allow);
                userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword", null, SecurityPermissionState.Allow);
                userRole.AddTypePermission<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Allow);
                userRole.AddTypePermission<PermissionPolicyTypePermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyMemberPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
                userRole.AddTypePermission<PermissionPolicyObjectPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            }

            // Add the Users role to the user2
            if(!user2.Roles.Contains(userRole)) {
                user2.Roles.Add(userRole);
            }

            ObjectSpace.CommitChanges();
		}
	}
#endif
    public abstract class TaskAnalysis1LayoutUpdaterBase {
        protected IObjectSpace objectSpace;
        protected abstract IAnalysisControl CreateAnalysisControl();
        protected abstract IPivotGridSettingsStore CreatePivotGridSettingsStore(IAnalysisControl control);
        private static void SetFieldArea(IAnalysisControl control, string fieldName, DevExpress.XtraPivotGrid.PivotArea fieldArea) {
            if(control.Fields[fieldName] == null) {
                throw new ArgumentNullException("control.Fields['" + fieldName + "']");
            }
            control.Fields[fieldName].Area = fieldArea;
        }
        public TaskAnalysis1LayoutUpdaterBase(IObjectSpace objectSpace) {
            this.objectSpace = objectSpace;
        }
        public void Update(Analysis analysis) {
            if(analysis != null && !PivotGridSettingsHelper.HasPivotGridSettings(analysis)) {
                IAnalysisControl control = CreateAnalysisControl();
                control.DataSource = new AnalysisDataSource(analysis, objectSpace.GetObjects(typeof(DemoTask)));
                if(control.Fields.Count > 0) {
                    SetFieldArea(control, "Priority", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
                    SetFieldArea(control, "Subject", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                    SetFieldArea(control, "AssignedTo.DisplayName", DevExpress.XtraPivotGrid.PivotArea.RowArea);
                    PivotGridSettingsHelper.SavePivotGridSettings(CreatePivotGridSettingsStore(control), analysis);
                }
            }
        }
    }

    public abstract class TaskAnalysis2LayoutUpdaterBase {
        protected IObjectSpace objectSpace;
        protected abstract IAnalysisControl CreateAnalysisControl();
        protected abstract IPivotGridSettingsStore CreatePivotGridSettingsStore(IAnalysisControl control);
        public TaskAnalysis2LayoutUpdaterBase(IObjectSpace objectSpace) {
            this.objectSpace = objectSpace;
        }
        public void Update(Analysis analysis) {
            if(analysis != null && !PivotGridSettingsHelper.HasPivotGridSettings(analysis)) {
                IAnalysisControl control = CreateAnalysisControl();
                control.DataSource = new AnalysisDataSource(analysis, objectSpace.GetObjects(typeof(DemoTask)));
                if(control.Fields.Count > 0) {
                    control.Fields["Status"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
                    control.Fields["Priority"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
                    control.Fields["EstimatedWork"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                    control.Fields["ActualWork"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                    control.Fields["AssignedTo.DisplayName"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                }
                PivotGridSettingsHelper.SavePivotGridSettings(CreatePivotGridSettingsStore(control), analysis);
            }
        }
    }
}
