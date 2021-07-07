using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaManagmentSoftware.APIHelper.DTO.OrderContent {
    public class DtoOrderContentUpdate : BasicElement {
        public int? IdOrder { get; set; }
        public int? IdGamme { get; set; }
        public int? Quantity { get; set; }
    }
}
