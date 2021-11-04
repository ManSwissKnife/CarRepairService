using CarRepairService.Database;
using CarRepairService.Mappers.Interfaces;
using CarRepairService.Models;


namespace CarRepairService.Repositories
{
    public interface IRepository<T, Y> /*: IDisposable*/ where T : BaseModel where Y : BaseModel
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(Y item);
        Task<T> DeleteAsync(int id);
    }
    public class SQLRepository<T, Y> : IRepository<T, Y> where T : BaseModel where Y : BaseModel
    {
        private readonly CRSContext _db;
        private readonly IMapper<T, Y> _mapper;

        public SQLRepository(CRSContext  context, IMapper<T, Y> modelMapper)
        {
            _db = context;
            _mapper = modelMapper;
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await Task.Run(() => _db.Set<T>().ToList());
        }

        public async Task<T> GetAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsync(T model)
        {
            await _db.Set<T>().AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<T> UpdateAsync(Y model)
        {
            T toUpdate = await _db.Set<T>().FindAsync(model.Id);
            if (toUpdate != null)
            {
                _mapper.Map(toUpdate, model);
                await _db.SaveChangesAsync();
            }
            return toUpdate;
        }

        public async Task<T> DeleteAsync(int id)
        {
            T model = await _db.Set<T>().FindAsync(id);
            if (model != null)
            {
                _db.Set<T>().Remove(model);
                await _db.SaveChangesAsync();
            } 
            return model;
        }

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
