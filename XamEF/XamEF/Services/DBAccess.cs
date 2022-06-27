using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using XamEF.DataContext;
using XamEF.Models;


namespace XamEF.Services
{
    public class DBAccess<T> where T : class
    {
        private readonly DBContext _context;
        private ObservableCollection<Student> students;

        public DBAccess() => _context = App.GetContext();

        public bool Create(T entity)
        {
            bool created;

            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }

            return created;
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<Student> GetById(int id)
        {
            return _context.Studiantes.Where(x => x.StudentId.Equals(id)).AsEnumerable<Student>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Update1(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Attach(entity);
            _context.SaveChanges();
        }
        public bool Update(Student entity)
        {
            bool updated;
            try
            {
                _context.Update(entity);
                //_context.Entry(entity).State = EntityState.Modified;
                //_context.Set<T>().Attach(entity);
                _context.SaveChanges();

                updated = true;
            }
            catch (Exception)
            {
                throw;
            }
            return updated;
        }

        public void Delete(T entity)
        {
            T existing = _context.Set<T>().Find(entity);

            if (existing != null)
            {
                _context.Set<T>().Remove(existing);
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var existing = _context.Studiantes.Where(x => x.StudentId.Equals(id)).AsEnumerable<Student>();
            var Students = new ObservableCollection<Student>(existing);

            if (Students[0] != null)
            {
                _context.Studiantes.Remove(Students[0]);
                _context.SaveChanges();
            }
        }

        public async void SaveList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Add(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void DeleteList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Remove(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
