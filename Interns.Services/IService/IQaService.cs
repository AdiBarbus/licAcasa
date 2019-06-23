using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IQaService
    {
        IQueryable<Qa> GetQas();

        Qa GetQa(int id);

        void InsertQa(Qa qa);

        void DeleteQa(Qa qa);

        void UpdateQa(Qa qa);
    }
}