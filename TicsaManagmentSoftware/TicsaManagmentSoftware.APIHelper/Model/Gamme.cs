﻿using System.Collections.Generic;
using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaManagmentSoftware.APIHelper.Model {
    public partial class Gamme : BasicElement {
        public string Label { get; set; }
        public string Description { get; set; }
        public string CostHisto { get; set; }
        public double Cost { get; set; }
        public int IdType { get; set; }
        public int Stock { get; set; }
        public string StockHisto { get; set; }
        public int IdProducer { get; set; }
    }
}
