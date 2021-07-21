using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace EFDemo.Module.Data {
    [DefaultClassOptions]
    [DefaultProperty(nameof(Position.Title))]
    public class Position /*: IComparable*/ {
		public Position() {
			Departments = new List<Department>();
			Employees = new List<Employee>();
		}
        //[Browsable(false)]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
		public Int32 ID { get; protected set; }
		[RuleRequiredField("RuleRequiredField for Position.Title", DefaultContexts.Save)]
		public String Title { get; set; }
		public virtual IList<Department> Departments { get; set; }
		public virtual IList<Employee> Employees { get; set; }

		// IComparable
		/*Int32 IComparable.CompareTo(Object obj) {
			Int32 result = 0;
			if(obj == null) {
				result = 1;
			}
			else if(Object.ReferenceEquals(this, obj)) {
				result = 0;				
			}
			else {
				result = Comparer.Default.Compare(ID, ((Position)obj).ID);
			}
			return result;
		}*/
	}
}
