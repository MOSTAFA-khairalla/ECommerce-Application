﻿namespace WebApplication12.Model.Interfaces
{
    public interface IUnitOfWork<T> where T :class 
    {
        IGenericRepository<T> Entity { get; }
        void Save();

     }
}
