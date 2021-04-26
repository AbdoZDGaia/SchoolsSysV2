using SchoolsSys.BL.Models;
using SchoolsSys.BL.Repository;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace SchoolsSys.BL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolsSysDBContext _dbContext;
        DbContextTransaction dbContextTransaction = null;
        private bool disposed = false;

        public UnitOfWork(SchoolsSysDBContext dbContext, bool lazyLoadingEnabled = false)
        {
            _dbContext = dbContext;
            _dbContext.Database.CommandTimeout = 60;
            _dbContext.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

        #region Repos
        IRepositoryBase<Student> _studentsRepo;
        public IRepositoryBase<Student> StudentsRepo
        {
            get
            {
                if (_studentsRepo == null)
                    _studentsRepo = new RepositoryBase<Student>(_dbContext);
                return _studentsRepo;
            }
        }

        IRepositoryBase<Attachment> _attachmentsRepo;
        public IRepositoryBase<Attachment> AttachmentsRepo
        {
            get
            {
                if (_attachmentsRepo == null)
                    _attachmentsRepo = new RepositoryBase<Attachment>(_dbContext);
                return _attachmentsRepo;
            }
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                if (_dbContext.ChangeTracker.HasChanges())
                {
                    return await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
            }
            return -1;
        }

        public void BeginTransaction()
        {
            dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (dbContextTransaction != null)
                {
                    dbContextTransaction.Commit();
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                if (dbContextTransaction != null)
                    RollBack();
            }
        }

        public void RollBack()
        {
            dbContextTransaction.Rollback();
        }

        public DbRawSqlQuery<T> QueryFromDB<T>(string queryText)
        {
            var result = _dbContext.Database.SqlQuery<T>(queryText);
            return result;
        }

        public DbRawSqlQuery<T> QueryFromDB<T>(string queryText, params object[] parameters)
        {
            var result = _dbContext.Database.SqlQuery<T>(queryText, parameters);
            return result;
        }

        
    }
}
