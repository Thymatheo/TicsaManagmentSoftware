using System;
using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaManagmentSoftware.APIHelper.DTO.Order {
    public class DtoOrderUpdate : BasicElement {
        public DateTime? OrderDate { get; set; }
        public int? IdClient { get; set; }
    }
}
