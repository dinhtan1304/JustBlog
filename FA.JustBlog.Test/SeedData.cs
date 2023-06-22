using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Test
{
    public static class SeedData
    {
        /// <summary>
        /// add du lieu
        /// </summary>
        /// <param name="context"></param>
        public static void SeedDataTest(this JustBlogContext context)
        {
            context.Categories.AddRange(GetCategories());
            context.Posts.AddRange(GetPosts());
            context.Tags.AddRange(GetTags());
            context.PostTagMaps.AddRange(GetPostTagMap());
            context.SaveChanges();
        }
        /// <summary>
        /// nhap du lieu
        /// </summary>
        /// <returns></returns>
        private static ICollection<PostTagMap> GetPostTagMap()
        {
            return new List<PostTagMap>()
            {
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 1,
                },
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 2,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 2,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 3,
                }
            };
        }

        private static ICollection<Tag> GetTags()
        {
            return new List<Tag>()
            {
                new Tag
                {
                    Id = 1,
                    Name = "#Game Sport",
                    UrlSlug = "#game-sport",
                    Description = "Game",
                    Count = 5,
                },
                new Tag
                {
                    Id = 2,
                    Name = "#Sport Football",
                    UrlSlug = "#sport-football",
                    Description = "Sport",
                    Count = 3,
                },
                new Tag
                {
                    Id = 3,
                    Name = "#Shopping Socal",
                    UrlSlug = "#shopping-socal",
                    Description = "Shopping Online",
                    Count = 2,
                }
            };
        }

        private static ICollection<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Title = "Some thing about Genshin",
                    ShortDescripion = "Genshin Impact is an action role-playing video game developed by miHoYo. It features an open world environment and a gacha game monetization system, with players collecting characters and weapons by spending in-game currency or real money. The game takes place in the fantasy world of Teyvat, where players explore various regions and complete quests while battling enemies and bosses. Genshin Impact received positive critical reception for its gameplay, graphics, and music.",
                    PostContent = "How  to the build Hutao and Ayaka.",
                    UrlSlug = "some-thing-about-genshin",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1
                },
                new Post
                {
                    Id = 2,
                    Title = "Euro 2024 will put football back in the spotlight and boost a continent’s self-belief Philipp Lahm",
                    ShortDescripion = "The countdown to Euro 2024 is ticking. The qualifiers begin on 23 March with Kazakhstan against Slovenia. These will be the first international matches after the World Cup, which was attractive in sporting terms but controversial in Europe. Qatar benefits from football for its political goals. We should do the same.",
                    PostContent = "Europe needs to reflect on how fortunate it is to host a tournament in a democracy and create a spirit of optimism.",
                    UrlSlug ="euro-2024-will-put-football-back-in-the-spotlight-and-boost-a-continent’s-self-belief-philipp-lahm",
                    Published = false,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2
                },
                new Post
                {
                    Id = 3,
                    Title = "The pandemic has changed consumer behaviour forever - and online shopping looks set to stay",
                    ShortDescripion = "In total, 75% of US consumers have tried a new shopping behaviour and over a third of them (36%) have tried a new product brand. In part, this trend has been driven by popular items being out of stock as supply chains became strained at the height of the pandemic. However, 73% of consumers who had tried a different brand said they would continue to seek out new brands in the future.",
                    PostContent = "The consulting and accounting firm's June 2021 Global Consumer Insights Pulse Survey reports a strong shift to online shopping as people were first confined by lockdowns, and then many continued to work from home.",
                    UrlSlug = "the-pandemic-has-changed-consumer-behaviour-forever-and-online-shopping-looks-set-to-stay",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3
                }

            };
        }

        private static ICollection<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Game Sport",
                    UrlSlug = "game-sport",
                    Description = "A Game is a structured form of play, usually undertaken for entertainment or fun, and sometimes used as an educational tool. Many games are also considered to be work (such as professional players of spectator sports or games) or art (such as jigsaw puzzles or games involving an artistic layout such as Mahjong, solitaire, or some video games)."
                },
                new Category
                {
                    Id = 2,
                    Name = "Sport Football",
                    UrlSlug = "sport-football",
                    Description = "Sports, physical contests pursued for the goals and challenges they entail. Sports are part of every culture past and present, but each culture has its own definition of sports. The most useful definitions are those that clarify the relationship of sports to play, games, and contests."
                },
                new Category
                {
                    Id = 3,
                    Name = "Shopping Socal",
                    UrlSlug = "shopping-socal",
                    Description = "Shopping is the act of selecting and buying goods from retail stores or online platforms. It includes a wide range of products such as clothing, groceries, electronics, home decorations, etc. In-store shopping involves physically examining and comparing products with the help of sales associates, while online shopping offers convenience, allowing customers to browse websites, compare prices, and make purchases easily. Shopping experiences vary based on store type, product quality, discounts/promotions, and customer service. Overall, shopping can be enjoyable, meeting both practical needs and personal preferences."
                }
            };
        }
    }
}
