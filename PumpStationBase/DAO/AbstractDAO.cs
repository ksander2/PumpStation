using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace PumpStationBase.DAO
{
     public abstract class  AbstractDAO<T> where T: class, new()
    {
    
        protected PumpStationContext _context;

        public AbstractDAO(PumpStationContext context)
        {
            _context = context; 
        }
        
        public virtual IQueryable<T> getAll()
        {
            return _context.Set<T>();
        }
        
        public virtual void create(T item)
        {
            creatItem(item);
        }

        public virtual void UndoChange(T item)
        {
            _context.Entry(item).State = EntityState.Unchanged;
        }

        public virtual void update(T item)
        {
            updateItem(item);
        }

        public virtual void delete(T item)
        {
            deleteItem(item);
        }
         
        protected virtual T CreatNew()
        {
            return new T();
        }
         
        protected abstract void creatItem(T item);
        protected abstract void updateItem(T item);
        protected abstract void deleteItem(T item);


    }
}
