using System.Collections.Generic;
using System.Threading.Tasks;
using AglTest.Data;

namespace AglTest.DataSource
{
    /// <summary>
    /// Data Service Contract
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Fetch the pet owners
        /// </summary>
        /// <returns>Awaitable task for list of owners</returns>
        Task<IList<Owner>> FetchOwnersAsync();
    }
}
