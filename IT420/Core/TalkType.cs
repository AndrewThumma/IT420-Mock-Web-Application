using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Core
{
    public class TalkType
    {
        //Only site content administrators can add additional Talk Types

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }        
        [Required]
        public String Type { get; set; }
    }
}
