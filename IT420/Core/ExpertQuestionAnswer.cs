using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class ExpertQuestionAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string answer { get; set; }
        [ForeignKey("FK_ExpertId")]
        public int expertId { get; set; }
        [ForeignKey("FK_QuestionId")]
        public int questionId { get; set; }

        public ExpertQuestion Question { get; set; }
        public Expert Expert { get; set; }
    }
}
