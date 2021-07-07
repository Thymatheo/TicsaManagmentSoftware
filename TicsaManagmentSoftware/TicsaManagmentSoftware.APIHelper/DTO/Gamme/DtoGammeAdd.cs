using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaManagmentSoftware.APIHelper.DTO.Gamme {
    public class DtoGammeAdd : BasicElement {
        public string Label { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int IdType { get; set; }
        public int Stock { get; set; }
        public int IdProducer { get; set; }
    }
}
