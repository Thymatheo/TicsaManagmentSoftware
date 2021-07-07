using System;
using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaAPI.BLL.DTO.Order {
    public class DtoOrderAdd : BasicElement {
        public DateTime OrderDate { get; set; }
        public int IdClient { get; set; }
    }
}
