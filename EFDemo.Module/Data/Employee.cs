using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp;

namespace EFDemo.Module.Data {
	[DefaultClassOptions]
	public class Employee : Person, IObjectSpaceLink {
        IObjectSpace objectSpace;
        private int titleOfCourtesyInt;
        public Employee() {
			Resumes = new List<Resume>();
			Employees = new List<Employee>();
			Tasks = new List<DemoTask>();
		}

		public String WebPageAddress { get; set; }
		public String NickName { get; set; }
		public String SpouseName { get; set; }
        [Browsable(false)]
        public Int32 TitleOfCourtesy_Int {
            get { return titleOfCourtesyInt; }
            protected set { SetPropertyValue(ref titleOfCourtesyInt, value); }
        }
        public Nullable<DateTime> Anniversary { get; set; }
		[FieldSize(4096)]
		public String Notes { get; set; }
        [NotMapped]
		[ImmediatePostData]
        public virtual Department DisplayDepartment {
            get { return Department; }
            set {
                Department = value;
                Position = null;
                if(Manager != null && Manager.Department != value) {
                    Manager = null;
                }
                objectSpace.SetModified(this);
            }
        }
        //[Browsable(false)]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
		public virtual Department Department { get; set; }
		public virtual Position Position { get; set; }
		public virtual IList<Resume> Resumes { get; set; }
		[DataSourceProperty("Department.Employees", DataSourcePropertyIsNullMode.SelectAll), DataSourceCriteria("Position.Title = 'Manager'")]
		public virtual Employee Manager { get; set; }
		public virtual IList<Employee> Employees { get; set; }
		public virtual IList<DemoTask> Tasks { get; set; }

		[NotMapped]
		public TitleOfCourtesy TitleOfCourtesy {
			get { return (TitleOfCourtesy)TitleOfCourtesy_Int; }
			set { TitleOfCourtesy_Int = (Int32)value; }
		}
        // IObjectSpaceLink
        IObjectSpace IObjectSpaceLink.ObjectSpace {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
	}
}

