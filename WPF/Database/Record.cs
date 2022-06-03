using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF.Database
{
    [Table("TableRecordes")]
    public partial class Record
    {
        public string NameUser { get; set; } = null!;
        public int? Round { get; set; }
    }
}
