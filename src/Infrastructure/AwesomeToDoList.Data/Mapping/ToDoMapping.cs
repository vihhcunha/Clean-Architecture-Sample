using AwesomeTodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDoList.Data.Mapping
{
    public class ToDoMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(x => x.IdToDo);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Created)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.Done)
                .IsRequired();

            builder.Property(x => x.DateDone)
                .HasColumnType("datetime2");

            builder.Property(x => x.Prevision)
                .HasColumnType("datetime2");
        }
    }
}
