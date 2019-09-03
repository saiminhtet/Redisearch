namespace Redisearch.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Redis : DbContext
    {
        public Redis()
            : base("name=Redis")
        {
        }

        public virtual DbSet<MarkIndex_Luke> MarkIndex_Luke { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarkIndex_Luke>()
                .Property(e => e.WordsInMark)
                .IsUnicode(false);

            modelBuilder.Entity<MarkIndex_Luke>()
                .Property(e => e.Translation)
                .IsUnicode(false);

            modelBuilder.Entity<MarkIndex_Luke>()
                .Property(e => e.Transliteration)
                .IsUnicode(false);
        }
    }
}
