using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using DevExpress.Persistent.Base;

namespace EFDemo.Module.Data {
    [DefaultClassOptions]
    [DefaultProperty(nameof(Department.Title))]
    public class Department {
		public Department() {
			Positions = new List<Position>();
			Employees = new List<Employee>();
		}
        //[Browsable(false)]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
		public Int32 ID { get; protected set; }
		public String Title { get; set; }
		public String Office { get; set; }
		public virtual IList<Position> Positions { get; set; }
		public virtual IList<Employee> Employees { get; set; }
	}
}
