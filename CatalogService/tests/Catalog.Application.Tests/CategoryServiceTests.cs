using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Catalog.Infrastructure;
using Moq;
using Xunit;

namespace Catalog.Application.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICatalogRepository<Category>> _mockedRepository;
        private readonly ICatalogService<Category> _service;

        public CategoryServiceTests()
        {
            _mockedRepository = new Mock<ICatalogRepository<Category>>();
            _mockedRepository.Setup(x => x.Add(It.IsAny<Category>())).Callback<Category>((category) => { });
            _service = new CategoryService(_mockedRepository.Object);
        }

        [Fact]
        public void AddTest_ShouldThrowException_WhenNameInvalid()
        {
            Category categoryWithReallyLongName = new()
            {
                Id = 201,
                Name = "qwertyqwertyqwertyqwertyqwertyqwertyqwertyqwertyqwerty",
                Image = "image:mycategory/randomCategoryUrl.com",
                ParentCategoryId = null
            };
            Assert.Throws<NameExceedsLengthLimitException>(() => _service.Add(categoryWithReallyLongName));
        }
    }
}
