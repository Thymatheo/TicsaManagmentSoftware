﻿using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaAPI.BLL.DTO.OrderContent {
    public class DtoOrderContentAdd : BasicElement {
        public int IdOrder { get; set; }
        public int IdGamme { get; set; }
        public int Quantity { get; set; }
    }
}
