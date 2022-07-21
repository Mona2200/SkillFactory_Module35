﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Repos
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
