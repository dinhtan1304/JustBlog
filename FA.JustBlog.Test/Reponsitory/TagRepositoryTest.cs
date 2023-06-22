using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Test.Reponsitory
{
    [TestFixture]
    public class TagRepositoryTest : BaseTest
    {
        public TagRepositoryTest() : base()
        {

        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetAll_ListTag_WhenCall_ReturnValue()
        {
            // Arrge

            //Act
            var result = _tagRepository.GetAll();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void FindId_Tag_WhenCall_ReturnObjetct()
        {
            // Arrge

            //Act
            var result = _tagRepository.Find(2);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateNewTag_WhenCalled_ReturnObject()
        {
            //Arrange
            var itemToAdd = new Tag
            {
                Name = "test tag",
                UrlSlug = "test-tag",
                Description = "test tag name",
                Count = 1,
            };

            //Act
            _tagRepository.Create(itemToAdd);

            //Assert
            var result = _tagRepository.Find(itemToAdd.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateCTag_WhenCalled_ReturnsObject()
        {
            // Arrange

            // Act
            var result = _tagRepository.Find(1);
            // Assert         
            _tagRepository.Update(result);
        }

        [Test]
        public void DeleteTag_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            var result = _tagRepository.Find(3);
            // Assert         
            _tagRepository.Delete(result);
        }


        [Test]
        public void DeleteTagById_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            // Assert         
            _tagRepository.Delete(3);
        }

        [Test]
        public void GetTagByUrlSlug_WhenCall_ReturnObject()
        {
            // Arrange
            string url = "#game-sport";
            // Act
            var result = _tagRepository.GetTagByUrlSlug(url);
            // Assert 
            Assert.IsNotNull(result);
        }
    }
}
