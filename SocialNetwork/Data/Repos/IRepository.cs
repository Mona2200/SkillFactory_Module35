using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Repos
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
