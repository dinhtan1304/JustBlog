using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Test.Reponsitory
{
    [TestFixture]
    public class PostRepositoryTest : BaseTest
    {
        public PostRepositoryTest() : base()
        {

        }

        [OneTimeTearDown]
        public void Clean()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public void GetAll_ListPost_WhenCall_ReturnValue()
        {
            // Arrge

            //Act
            var result = _postRepository.GetAll();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void FindId_Post_WhenCall_ReturnObjetct()
        {
            // Arrge

            //Act
            var result = _postRepository.Find(3);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateNewPost_WhenCalled_ReturnObject()
        {
            //Arrange
            var itemToAdd = new Post
            {
                Title = "The pandemic has changed consumer behaviour forever - and online shopping looks set to stay",
                ShortDescripion = "In total, 75% of US consumers have tried a new shopping behaviour and over a third of them (36%) have tried a new product brand. In part, this trend has been driven by popular items being out of stock as supply chains became strained at the height of the pandemic. However, 73% of consumers who had tried a different brand said they would continue to seek out new brands in the future.",
                PostContent = "The consulting and accounting firm's June 2021 Global Consumer Insights Pulse Survey reports a strong shift to online shopping as people were first confined by lockdowns, and then many continued to work from home.",
                UrlSlug = "the-pandemic-has-changed-consumer-behaviour-forever-and-online-shopping-looks-set-to-stay",
                Published = false,
                PostedOn = DateTime.Now,
                Modified = DateTime.Now,
                CategoryId = 2,
            };

            //Act
            _postRepository.Create(itemToAdd);

            //Assert
            var result = _postRepository.Find(itemToAdd.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateCategory_WhenCalled_ReturnsObject()
        {
            // Arrange

            // Act
            var result = _postRepository.Find(1);
            result.Title = "abc";
            // Assert         
            _postRepository.Update(result);
            Assert.That(result.Title, Is.EqualTo(_postRepository.Find(1).Title));
        }

        [Test]
        public void DeleteCategory_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            var result = _postRepository.Find(1);
            // Assert         
            _postRepository.Delete(result);

            Assert.That(result.Id, Is.EqualTo(_postRepository.Find(1).Id));


        }

        [Test]
        public void DeleteCategoryById_WhenCalled_ReturnObject()
        {
            // Arrange

            // Act
            // Assert         
            _postRepository.Delete(1);
        }

        [Test]
        public void CountPostsForCategory_WhenCall_ReturnValue()
        {
            // Arrange
            string categoryName = "Game Sport";



            // Act
            var result = _postRepository.CountPostsForCategory(categoryName);



            // Assert
            Assert.That(result, Is.GreaterThanOrEqualTo(1));
        }
        [Test]
        public void GetPostByCategory_WhenCall_ReturnObject()
        {
            //Act 
            var result = _postRepository.GetPostsByCategory("Game Sport");
            //Assert
            Assert.NotNull(result);
            //Assert.IsNotNull(result);
        }
        [Test]
        public void CountPostsForTag_WhenCall_ReturnObject()
        {
            // Arrange

            // Act
            var result = _postRepository.CountPostsForTag("#Game Sport");

            // Assert
            Assert.That(result, Is.GreaterThanOrEqualTo(1));
        }



        [Test]
        public void FindPost_WhenCall_ReturnObject()
        {
            // Arrange

            // Act
            var result = _postRepository.FindPost(DateTime.Now.Year, DateTime.Now.Month, "the-pandemic-has-changed-consumer-behaviour-forever-and-online-shopping-looks-set-to-stay");



            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetLatestPost_WhenCall_ReturnObject()
        {
            // Arrange
            int size = 2;

            // Act
            var result = _postRepository.GetLatestPost(size).Count;

            // Assert
            Assert.That(result, Is.EqualTo(size));
        }



        [Test]
        public void GetPostsByMonth_WhenCall_ReturnObjetct()
        {
            DateTime monthYear = DateTime.Now;
            // Arrange

            // Act
            int result = _postRepository.GetPostsByMonth(monthYear).Count;



            // Assert
            Assert.That(result, Is.EqualTo(3));
        }




        [Test]
        public void GetPostsByTag_WhenValidTagName_ReturnPosts()
        {
            // Arrange
            string tagName = "#Sport Football";

            // Act
            var result = _postRepository.GetPostsByTag(tagName);

            // Assert
            Assert.That(result, Is.Not.Empty);
        }
        [Test]
        public void GetPublishedPosts_WhenCalled_ReturnObject()
        {
            // Act
            var result = _postRepository.GetPublisedPosts().Equals(true);
            // Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetUnpublishedPosts_WhenCalled_ReturnObject()
        {
            // Act
            var result = _postRepository.GetUnpublisedPosts().Equals(false);

            // Assert
            Assert.That(result, Is.EqualTo(false));
        }

    }
}
