using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class TalkComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        [ForeignKey("FK_TalkID")]
        public int TalkId { get; set; }
        [Required]
        [Column(TypeName ="text")]
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("TalkCommentUserId")]
        public string userId { get; set; }

        public Talk Talk { get; set; }


    }
}
