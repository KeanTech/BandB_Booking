using NPOI.SS.Formula.Functions;
using System.Runtime.InteropServices;

namespace B_B_App.Services
{
    public interface IDataService
    {
        public IEnumerable<T> Create(T type);
        public IEnumerable<T> Get(T type);
        public IEnumerable<T> Update(T type);
        public IEnumerable<T> Delete(T type);
    }
}
