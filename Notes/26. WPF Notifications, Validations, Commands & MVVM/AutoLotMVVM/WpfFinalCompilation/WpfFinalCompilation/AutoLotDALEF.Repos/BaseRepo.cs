using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoLotDALEF.Models.Base;
using AutoLotDALEF.Models;
using AutoLotDALEF.EF;

namespace AutoLotDALEF.Repos {
    public class BaseRepo <T> : IDisposable, IRepo <T> where T:EntityBase, new()   {
        private readonly DbSet<T> table;
        private readonly AutoLotEntities db;
        public BaseRepo() {
            db = new AutoLotEntities();
            table = db.Set<T>();
        }

        protected AutoLotEntities Context { get { return db; } }
        public void Dispose() {
            if (db != null) db.Dispose();
        }

        internal int SaveChanges() {
            try {
                return db.SaveChanges();
            } catch (DbUpdateConcurrencyException ex) {
                throw;
            } catch (DbUpdateException ex) {
                throw;
            } catch (CommitFailedException ex) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }

        public T GetOne(int? id) {
            return table.Find(id);
        }

        public virtual List<T> GetAll() {
            return table.ToList();
        }

        public List<T> ExecuteQuery(string sql) {
            return table.SqlQuery(sql).ToList();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) {
            return table.SqlQuery(sql, sqlParametersObjects).ToList();
        }

        public int Add(T entity) {
            table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IList<T> entities) {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Save(T entity) {
            db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete(T entity) {
            db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp) {
            db.Entry(new T() { Id = id, TimeStamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }
    }
}
