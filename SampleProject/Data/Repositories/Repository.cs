using System.Linq;
using BusinessEntities;
using Common;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Session;

namespace Data.Repositories
{
    [AutoRegister]
    public class Repository<T> : IRepository<T> where T : IdObject
    {
        private readonly IDocumentSession _documentSession;

        public Repository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Save(T entity)
        {
            _documentSession.Store(entity);
        }

        public void Delete(T entity)
        {
            _documentSession.Delete(entity);
        }

        public T Get(string id)
        {
            return _documentSession.Load<T>(id);
        }

        protected void DeleteAll<TIndex>() where TIndex : AbstractIndexCreationTask<T>
        {
            var objects = _documentSession.Query<T>().ToList();
            while (objects.Any())
            {
                foreach (var obj in objects)
                {
                    _documentSession.Delete(obj);
                }

                _documentSession.SaveChanges();
                objects = _documentSession.Query<T>().ToList();
            }
        }
    }
}