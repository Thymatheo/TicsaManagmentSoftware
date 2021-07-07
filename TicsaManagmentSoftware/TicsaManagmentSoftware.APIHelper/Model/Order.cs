using System;
using System.Collections.Generic;
using TicsaManagmentSoftware.APIHelper.Model;


namespace TicsaManagmentSoftware.APIHelper.Model {
    public partial class Order : BasicElement {
        public DateTime OrderDate { get; set; }
        public int IdClient { get; set; }
    }
}
