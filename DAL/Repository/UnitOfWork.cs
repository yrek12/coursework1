﻿using DAL.Models;
using System;

namespace DAL.Repository
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Context _context;

        public IGenericRepository<Role> Roles { get; set; }

        public IGenericRepository<User> Users { get; set; }

        public IGenericRepository<Resume> Resumes { get; set; }

        public IGenericRepository<Vacansy> Vacansies { get; set; }

        private bool _isDisposed;

        public UnitOfWork(Context context, IGenericRepository<Role> roles, IGenericRepository<User> users, IGenericRepository<Resume> resumes, IGenericRepository<Vacansy> vacansies)
        {
            _context = context;
            Roles = roles;
            Users = users;
            Resumes = resumes;
            Vacansies = vacansies;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                _context.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
