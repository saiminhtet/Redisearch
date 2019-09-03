namespace Redisearch.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MarkIndex_Luke
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(4000)]
        public string WordsInMark { get; set; }

        [StringLength(4000)]
        public string Translation { get; set; }

        [StringLength(4000)]
        public string Transliteration { get; set; }
    }
}
