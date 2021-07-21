using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.DC;

namespace EFDemo.Module.Data {
    [DefaultClassOptions]
    [ImageName("BO_Resume")]
    public class Resume {
        public Resume() {
            Portfolio = new List<PortfolioFileData>();
        }
        //[Browsable(false)]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        public Int32 ID { get; protected set; }
        [Aggregated]
        public virtual IList<PortfolioFileData> Portfolio { get; set; }
        public virtual Employee Employee { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public virtual FileData File { get; set; }
    }
}
