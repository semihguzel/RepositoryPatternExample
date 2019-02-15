using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(x => x.CategoryID);
            Property(x => x.CategoryName).HasMaxLength(50);
            Property(x => x.Description).HasMaxLength(350);
        }
    }
}
