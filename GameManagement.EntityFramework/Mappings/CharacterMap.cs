using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameManagement.EntityFramework.Mappings
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.Property(Character => Character.Nickname).HasMaxLength(20);
            builder.Property(Character => Character.Classes).HasMaxLength(20);

            builder.HasIndex(Character => Character.Nickname).IsUnique();
            builder.HasOne(c => c.Player).WithMany(p => p.Characters).HasForeignKey(c => c.PlayerId);
        }
    }
}
