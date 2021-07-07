using System;
using TicsaManagmentSoftware.APIHelper.Model;

namespace TicsaManagmentSoftware.APIHelper.DTO.Commentary {
    public class DtoCommentary : BasicElement {
        public int IdClient { get; set; }
        public string CommentaryContent { get; set; }
        public DateTime CommentaryDate { get; set; }
    }
}
