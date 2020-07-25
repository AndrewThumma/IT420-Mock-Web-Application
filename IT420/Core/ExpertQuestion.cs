using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class ExpertQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string question { get; set; }
        [ForeignKey("FK_ExpertQuestionTypeId")]
        public int typeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool answered { get; set; }
        [ForeignKey("FK_UserId")]
        public string userId { get; set; }

        public ExpertQuestionAnswer Answer { get; set; }
        public ExpertQuestionType Type { get; set; }
    }
}
