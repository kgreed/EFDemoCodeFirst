using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using DevExpress.Persistent.Base;

namespace EFDemo.Module.Data {
    [DefaultClassOptions]
    public class Payment : INotifyPropertyChanging, INotifyPropertyChanged {
		private void OnPropertyChanging(String propertyName) {
			if(PropertyChanging != null) {
				PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		private void OnPropertyChanged(String propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
        //[Browsable(false)]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
		public Int32 ID { get; protected set; }
		private Decimal hours;
		private Decimal rate;
		public Decimal Rate {
			get { return rate; }
			set {
				if(rate != value) {
					OnPropertyChanging(nameof(Rate));
					rate = value;
					OnPropertyChanged(nameof(Rate));
				}
			}
		}
		public Decimal Hours {
			get { return hours; }
			set {
				if(hours != value) {
					OnPropertyChanging(nameof(Hours));
					hours = value;
					OnPropertyChanged(nameof(Hours));
				}
			}
		}
		
		[NotMapped]
		public Decimal Amount {
            get { return Rate * Hours; }
        }

		// INotifyPropertyChanging
		public event PropertyChangingEventHandler PropertyChanging;

		// INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
