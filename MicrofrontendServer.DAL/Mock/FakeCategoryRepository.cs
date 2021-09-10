using System;
using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        #region Private Fields

        private readonly IEnumerable<Category> categories;

        #endregion

        #region Public Constructors

        public FakeCategoryRepository()
        {
            categories = new List<Category> {
                new Category { Id = 1, Name = "Pizza" },
                new Category { Id = 2, Name = "Burger" },
                new Category { Id = 3, Name = "Vegetarian" },
                new Category { Id = 4, Name = "Italian" },
                new Category { Id = 5, Name = "Asian" },
                new Category { Id = 6, Name = "American" },
                new Category { Id = 7, Name = "Turkish" },
                new Category { Id = 8, Name = "International" },
                new Category { Id = 9, Name = "Thai"},
                new Category { Id = 10, Name = "Maxican"},
                new Category { Id = 11, Name = "Greek" },
                new Category { Id = 12, Name = "Fusion Kitchen"},
                new Category { Id = 13, Name = "Vietnamese"},
                new Category { Id = 14, Name = "Chinese"}
            };
        }

        #endregion

        #region Public Methods

        public IEnumerable<Category> Get()
        {
            return categories;
        }

        #endregion
    }
}