using System;


namespace TicsaManagmentSoftware.APIHelper.Model {
    public partial class Order : BasicElement {
        public DateTime OrderDate { get; set; }
        public int IdClient { get; set; }
    }
}
