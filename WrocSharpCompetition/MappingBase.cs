using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WrocSharpCompetition
{
    public abstract class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>
    where TEntity : ModelBase
    {
        protected MappingBase()
        {
            HasKey(e => e.Id);
        }
    }
}