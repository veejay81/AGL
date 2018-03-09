using System;
using System.Collections.Generic;
using AglTest.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AglTest.Business.Test
{
    /// <summary>
    /// Test the filter business logic
    /// </summary>
    [TestClass]
    public class FilterServiceTest
    {
        IFilterService filterService = null;
        IList<Owner> owners;

        [TestInitialize()]
        public void Initialize()
        {
            filterService = new FilterService();

            owners = new List<Owner>()
            {
                new Owner()
                {
                    Name= "Patric",
                    Age = 20,
                    Gender = "Male",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name = "Ginger",
                            Type = "Cat"
                        },
                        new Pet()
                        {
                            Name = "Lyana",
                            Type = "Cat"
                        }
                    }
                },
                new Owner()
                {
                    Name= "Gina",
                    Age = 20,
                    Gender = "Female",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name = "Oli",
                            Type = "Cat"
                        },
                        new Pet()
                        {
                            Name = "Diablo",
                            Type = "Dog"
                        }
                    }
                },
                new Owner()
                {
                    Name= "Bryce",
                    Age = 20,
                    Gender = "Male",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name = "Tyson",
                            Type = "Dog"
                        }
                    }
                },
                new Owner()
                {
                    Name= "Ben",
                    Age = 20,
                    Gender = "Male",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name = "Bruce",
                            Type = "Dog"
                        },
                        new Pet()
                        {
                            Name = "Tom",
                            Type = "Cat"
                        }
                    }
                }
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullOwners()
        {
            var result = filterService.FilterPets(null, "Male", "cat");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyGender()
        {
            var result = filterService.FilterPets(owners, string.Empty, "Cat");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyPetType()
        {
            var result = filterService.FilterPets(owners, "Male", string.Empty);
        }

        [TestMethod]
        public void TestListOrderCats()
        {
            var result = filterService.FilterPets(owners, "Male", "Cat");
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Name, "Ginger");
            Assert.AreEqual(result[1].Name, "Lyana");
            Assert.AreEqual(result[2].Name, "Tom");
        }

        [TestMethod]
        public void TestListOrderDogs()
        {
            var result = filterService.FilterPets(owners, "Male", "Dog");
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "Bruce");
            Assert.AreEqual(result[1].Name, "Tyson");
        }
    }
}
