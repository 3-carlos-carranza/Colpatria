﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Common.Definition;

namespace Data.Common.Implementation
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private IQueryableUnitOfWork _unitOfWork;

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _unitOfWork = unitOfWork;
        }

        protected Repository()
        {
        }

        public object Mapper(object entity, object entity2)
        {
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var name = propertyInfo.Name;
                var value = propertyInfo.GetValue(entity, null);
                entity2.GetType().GetProperty(name).SetValue(entity2, value, null);
            }
            return entity2;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }

            set { _unitOfWork = (IQueryableUnitOfWork)value; }
        }

        public IEnumerable<T> GetForEdit(Expression<Func<T, bool>> filter, IEnumerable<T> entity)
        {
            var dt = _unitOfWork.CreateSet<T>().Where(filter).AsEnumerable();
            if (dt == null) return entity;
            var edit = dt as IList<T> ?? dt.ToList();
            return edit.Any() ? edit : entity;
        }

        public void Add(T item)
        {
            GetSet().Add(item); // add new item in this set
            _unitOfWork.Commit();
        }

        public T AddItem(T item)
        {
            if (item != null)
                GetSet().Add(item); // add new item in this set

            _unitOfWork.Commit();

            return item;
        }

        public bool All(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return GetSet().All(predicate);
            }

            return false;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return predicate != null && GetSet().Any(predicate);
        }

        public long Count(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? GetSet().Count(filter) : GetSet().Count();
        }

        public T Get(Expression<Func<T, bool>> specification)
        {
            if (specification == null) return null;
            IQueryable<T> set = GetSet();
            try
            {
                return set.FirstOrDefault(specification);
            }
            catch (Exception ex)
            {
                throw new Exception("Se ha producido un error en el metodo Get()", ex);
            }
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> set = GetSet();
            return set;
        }

        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            IQueryable<T> set = GetSet();
            return set.Where(filter);
        }

        public void Remove(T item)
        {
            // attach item if not exist
            _unitOfWork.Attach(item);

            // set as "removed"
            GetSet().Remove(item);
        }

        public void Edit(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.Attach(entity);
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _unitOfWork.SetModified(entity);

                _unitOfWork.Commit();
            }
        }

        public IQueryable<T> GetQueryable()
        {
            return GetSet();
        }

        protected IDbSet<T> GetSet()
        {
            return _unitOfWork.CreateSet<T>();
        }
    }
}