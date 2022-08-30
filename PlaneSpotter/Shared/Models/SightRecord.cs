using PlaneSpotter.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.Shared.Models
{
    public class SightRecord
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string? Make { get; set; }

        [StringLength(128)]
        [Required]
        public string? Model { get; set; }

        [Required]
        [RegularExpression(@"^([\da-zA-Z]{1,2})-([\da-zA-Z]{1,5})$",
         ErrorMessage = "Registration value not valid EX: G-RNAC or XX-R74AC")]
        public string? Registration { get; set; }

        [StringLength(225)]
        [Required]
        public string? Location { get; set; }

        [PastDateValidate(ErrorMessage ="Cannot enter future Date Time")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }

    }
}
