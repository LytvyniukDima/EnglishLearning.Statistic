using System;
using System.Collections.Generic;

namespace EnglishLearning.Statistic.Domain.Core.Kestrel
{
    public abstract class Entity<TId> : IEqualityComparer<Entity<TId>>
    {
        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        public TId Id { get; protected set; }
        
        // For simple entities, this may suffice
        // As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;
            if (entity != null)
            {
                return Equals(this, entity);
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public virtual bool Equals(Entity<TId> x, Entity<TId> y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            
            if (x == null || y == null)
            {
                return false;
            }
            
            if (x.Id.Equals(y.Id))
            {
                return true;
            }

            return false;
        }

        public virtual int GetHashCode(Entity<TId> obj)
        {
            return obj.GetHashCode();
        }
    }
}
