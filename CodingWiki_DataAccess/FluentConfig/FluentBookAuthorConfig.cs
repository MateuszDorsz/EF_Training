using CodingWiki_Model.Models;
using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(u => new { u.AuthorId, u.BookId });
            modelBuilder.HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.BookId);
            modelBuilder.HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.AuthorId);
        }
    }
}
