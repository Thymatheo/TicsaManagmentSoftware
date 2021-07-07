﻿using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaAPI.BLL.DTO.Gamme {
    public class DtoGammeUpdate : BasicElement {
        public string? Label { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int? IdType { get; set; }
        public int? Stock { get; set; }
        public int? IdProducer { get; set; }
    }
}
