using SchoolsSys.BL.Models;
using SchoolsSys.BL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace SchoolsSys.BL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IRepositoryBase<Student> StudentsRepo { get; }
        IRepositoryBase<Attachment> AttachmentsRepo { get; }
        #endregion

        Task<int> SaveChanges();
        void BeginTransaction();
        void Commit();
        void RollBack();
        DbRawSqlQuery<T> QueryFromDB<T>(string queryText);
        DbRawSqlQuery<T> QueryFromDB<T>(string queryText, params object[] parameters);
    }
}
