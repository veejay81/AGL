using AglTest.Data;
using System.Collections.Generic;
using AglTest.Data;

namespace AglTest.Business
{
    /// <summary>
    /// Filter Service Contract
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Filter pets
        /// </summary>
        /// <param name="petOwners">Owner list</param>
        /// <param name="gender">Gender</param>
        /// <param name="petType">Pet Type</param>
        /// <returns>Filtered Pets</returns>
        IList<Pet> FilterPets(IList<Owner> petOwners, string gender, string petType);
    }
}
