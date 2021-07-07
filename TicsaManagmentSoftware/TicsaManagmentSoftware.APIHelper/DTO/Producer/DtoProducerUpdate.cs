﻿using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaAPI.BLL.DTO.Producer {
    public class DtoProducerUpdate : BasicElement {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? CompagnieName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? PostalCode { get; set; }
    }
}
