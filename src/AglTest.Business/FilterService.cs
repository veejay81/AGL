using System;
using System.Collections.Generic;
using System.Linq;
using AglTest.Data;

namespace AglTest.Business
{
    /// <summary>
    /// Filter service implementation
    /// </summary>
    public class FilterService : IFilterService
    {
        /// <summary>
        /// Filter pets
        /// </summary>
        /// <param name="petOwners">Owner list</param>
        /// <param name="gender">Gender</param>
        /// <param name="petType">Pet Type</param>
        /// <returns>Filtered Pets</returns>
        public IList<Pet> FilterPets(IList<Owner> petOwners, string gender, string petType)
        {
            if(petOwners == null || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(petType))
            {
                throw new ArgumentException();
            }

            var filterResult = (from owner in petOwners
                                where owner.Pets != null
                               from pet in owner.Pets
                               where owner.Gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase)
                               && pet.Type.Equals(petType, System.StringComparison.InvariantCultureIgnoreCase)
                               orderby pet.Name ascending
                               select pet).ToList();

            return filterResult.ToList();
        }
    }
}
