using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Test.Reponsitory
{

    [TestFixture]
    public class CategoryRepositoryTest : BaseTest
    {
        public CategoryRepositoryTest() : base()
        {

        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetAll_ListCategory_WhenCall_ReturnValue()
        {
            // Arrge

            //Act
            var result = _categoryRepository.GetAll();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void FindId_Category_WhenCall_ReturnObjetct()
        {
            // Arrge

            //Act
            var result = _categoryRepository.Find(3);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateNewCategory_WhenCalled_ReturnObject()
        {
            //Arrange
            var itemToAdd = new Category
            {
                Name = "Test Item",
                UrlSlug = "Test-Item",
                Description = "A test item for unit testing",
            };

            //Act
            _categoryRepository.Create(itemToAdd);

            //Assert
            var result = _categoryRepository.Find(itemToAdd.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateCategory_WhenCalled_ReturnsObject()
        {
            // Arrange

            // Act
            var result = _categoryRepository.Find(1);
            // Assert         
            _categoryRepository.Update(result);
        }

        [Test]
        public void DeleteCategory_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            var result = _categoryRepository.Find(2);
            // Assert         
            _categoryRepository.Delete(result);
        }
        [Test]
        public void DeleteCategoryById_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            // Assert         
            _categoryRepository.Delete(1);
        }


    }


}
