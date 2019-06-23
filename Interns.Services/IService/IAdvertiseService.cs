using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IAdvertiseService
    {
        IQueryable<Advertise> GetAdvertises();
        Advertise GetAdvertise(int id);
        void InsertAdvertise(Advertise advertise);
        void DeleteAdvertise(Advertise advertise);
        void UpdateAdvertise(Advertise advertise);
    }
}