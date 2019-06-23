using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface ITestService
    {
        IQueryable<Test> GetTests();
        Test GetTest(int id);
        void InsertTest(Test test);
        void DeleteTest(Test test);
        void UpdateTest(Test test);
    }
}
