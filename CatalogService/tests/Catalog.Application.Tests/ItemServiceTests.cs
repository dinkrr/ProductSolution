using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Catalog.Infrastructure;
using Moq;
using Xunit;

namespace Catalog.Application.Tests.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<ICatalogRepository<Item>> _mockedRepository;
        private readonly ICatalogService<Item> _service;

        public ItemServiceTests()
        {
            _mockedRepository = new Mock<ICatalogRepository<Item>>();
            _mockedRepository.Setup(x => x.Add(It.IsAny<Item>())).Callback<Item>((item) => { });
            _service = new ItemService(_mockedRepository.Object);
        }

        [Fact]
        public void AddTest_ShouldThrowException_WhenNameInvalid()
        {
            Item itemWithReallyLongName = new()
            {
                Id = 101,
                Name = "qwertyqwertyqwertyqwertyqwertyqwertyqwertyqwertyqwerty",
                Description = "Random Description",
                Image = "image:myproduct/randomItemUrl.com",
                CategoryId = 201
            };
            Assert.Throws<NameExceedsLengthLimitException>(() => _service.Add(itemWithReallyLongName));
        }
    }
}