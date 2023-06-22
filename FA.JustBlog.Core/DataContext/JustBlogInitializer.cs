﻿using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FA.JustBlog.Core.DataContext
{
    public static class JustBlogInitializer
    {
        /// <summary>
        /// ham tao urlslug
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Slugify(string str)
        {
            str = str.ToLower().Trim();
            str = Regex.Replace(str, @"[^a-z0-9 -]", "");
            str = Regex.Replace(str, @"\s+", "-");
            return str;
        }

        /// <summary>
        /// add data vao database
        /// </summary>
        /// <param name="builder"></param>
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1f89f46b-0102-414b-8fed-4898d5a05357",
                    Name = "CONTRIBUTOR",
                    NormalizedName = "CONTRIBUTOR",
                    ConcurrencyStamp = "3c56d952-2194-4470-b931-4f681e6a9d35"
                },
                new IdentityRole
                {
                    Id = "257ca16f-43ae-4eaa-bdbd-ee6b15af39d0",
                    Name = "Blog_Owner",
                    NormalizedName = "Blog_Owner",
                    ConcurrencyStamp = "4cad3ab0-10b9-43d5-872a-80e7cf09f486"
                },
                new IdentityRole
                {
                    Id = "b5e8e51f-7cc2-4c37-beec-f918a7278d83",
                    Name = "OTHER",
                    NormalizedName = "OTHER",
                    ConcurrencyStamp = "efb2811a-b9e6-40c6-85a8-517df3d17c08"
                },
                new IdentityRole
                {
                    Id = "d602c8e8-8efe-40cc-bc1a-10631256e634",
                    Name = "USER",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "23d1e9b1-9d90-4d59-9832-3ca659cd1060"
                });
            builder.Entity<FAJustBlogUser>().HasData(
                new FAJustBlogUser
                {
                    Id = "b02c55d8-8310-413a-a164-972a49ec3ae7",
                    Firstname = "Đinh",
                    LastName = "Tân",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEH2Dfkzp3xa5Gga2TrNHxfdAvFTc8eBwhUlKpECP5fMXDH5l7FaxidLEglGTQ9k92A==",
                    SecurityStamp = "FORYX2L6CLYTMOU2MF5SQKUYSI7SSCX7",
                    ConcurrencyStamp = "e77dc837-e22a-404f-95ad-75679ef72db7",
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new FAJustBlogUser
                {
                    Id = "edf72b05-771d-4847-979f-a3a4eb59ad17",
                    Firstname = "User",
                    LastName = "NoName",
                    UserName = "user@gmail.com",
                    NormalizedUserName = "USER@GMAIL.COM",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEN4R4cqx0nVDzyikJRLz5qGs1qhPc9KaqBUS4Endsu4Wcbo2viIRoAGYjPWXosV+hg==",
                    SecurityStamp = "QCOP5KYUYLQ36Y2TZS3P466U6KVMLRHJ",
                    ConcurrencyStamp = "25decc9f-a481-452e-8c24-0a9acc7a59d5",
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new FAJustBlogUser
                {
                    Id = "65e642d0-d721-40db-8c29-33f8dcbd2561",
                    Firstname = "Tân",
                    LastName = "CONTRIBUTOR",
                    UserName = "tandv@gmail.com",
                    NormalizedUserName = "TANDV@GMAIL.COM",
                    Email = "tandv@gmail.com",
                    NormalizedEmail = "TANDV@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAECzCPVYTgoVIZcS2VQmuW3hjbrkCk5pjgDilj5UcFvsNrCJXa+21IaGF0ih9gPjbLw==",
                    SecurityStamp = "X7KL6KKFOLHPZ3UP6TXP6KHW5GDWKZLJ",
                    ConcurrencyStamp = "7f5ba478-d6ea-4d34-a574-8a63745c436c",
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new FAJustBlogUser
                {
                    Id = "f2cc633b-1e66-430d-b85a-0961deb7f434",
                    Firstname = "Tân",
                    LastName = "Other",
                    UserName = "tandv3@gmail.com",
                    NormalizedUserName = "TANDV3@GMAIL.COM",
                    Email = "tandv3@gmail.com",
                    NormalizedEmail = "TANDV3@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEKaB6Qa1K6c33Hw6K/v31r1J9w+9z1+CdvwyYAM3AgwoPRpuBXdCTpYPhn3+sX1COQ==",
                    SecurityStamp = "JY6CHAWGK2Y2RLNRYD72Y3TG5BPHDU35",
                    ConcurrencyStamp = "5d2f1036-876d-438e-92e0-2fe6934b4397",
                    PhoneNumber = "0987654321",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "b02c55d8-8310-413a-a164-972a49ec3ae7",
                    RoleId = "257ca16f-43ae-4eaa-bdbd-ee6b15af39d0"
                },
                new IdentityUserRole<string>
                {
                    UserId = "65e642d0-d721-40db-8c29-33f8dcbd2561",
                    RoleId = "1f89f46b-0102-414b-8fed-4898d5a05357"
                },
                new IdentityUserRole<string>
                {
                    UserId = "f2cc633b-1e66-430d-b85a-0961deb7f434",
                    RoleId = "d602c8e8-8efe-40cc-bc1a-10631256e634"
                },
                new IdentityUserRole<string>
                {
                    UserId = "edf72b05-771d-4847-979f-a3a4eb59ad17",
                    RoleId = "b5e8e51f-7cc2-4c37-beec-f918a7278d83"
                }
                );

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Game Sport",
                    UrlSlug = Slugify("Game Sport"),
                    Description = "A Game is a structured form of play, usually undertaken for entertainment or fun, and sometimes used as an educational tool. Many games are also considered to be work (such as professional players of spectator sports or games) or art (such as jigsaw puzzles or games involving an artistic layout such as Mahjong, solitaire, or some video games)."
                },
                new Category
                {
                    Id = 2,
                    Name = "Sport Football",
                    UrlSlug = Slugify("Sport Football"),
                    Description = "Sports, physical contests pursued for the goals and challenges they entail. Sports are part of every culture past and present, but each culture has its own definition of sports. The most useful definitions are those that clarify the relationship of sports to play, games, and contests."
                },
                new Category
                {
                    Id = 3,
                    Name = "Shopping Socal",
                    UrlSlug = Slugify("Shopping Socal"),
                    Description = "Shopping is the act of selecting and buying goods from retail stores or online platforms. It includes a wide range of products such as clothing, groceries, electronics, home decorations, etc. In-store shopping involves physically examining and comparing products with the help of sales associates, while online shopping offers convenience, allowing customers to browse websites, compare prices, and make purchases easily. Shopping experiences vary based on store type, product quality, discounts/promotions, and customer service. Overall, shopping can be enjoyable, meeting both practical needs and personal preferences."
                },
                new Category
                {
                    Id = 4,
                    Name = "Socal",
                    UrlSlug = Slugify("Social Media"),
                    Description = "Social media are interactive technologies that facilitate the creation and sharing of information, ideas, interests, and other forms of expression through virtual communities and networks. While challenges to the definition of social media arise due to the variety of stand-alone and built-in social media services currently available."
                },
                new Category
                {
                    Id = 5,
                    Name = "Economic",
                    UrlSlug = Slugify("World economy"),
                    Description = "The world economy or global economy is the economy of all humans of the world, referring to the global economic system, which includes all economic activities which are conducted both within and between nations, including production, consumption, economic management, work in general, exchange of financial values and trade of goods and services."
                }
                );
            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Some thing about Genshin",
                    ShortDescripion = "How  to the build Hutao and Ayaka.",
                    PostContent = "Genshin Impact is an action role-playing video game developed by miHoYo. It features an open world environment and a gacha game monetization system, with players collecting characters and weapons by spending in-game currency or real money. The game takes place in the fantasy world of Teyvat, where players explore various regions and complete quests while battling enemies and bosses. Genshin Impact received positive critical reception for its gameplay, graphics, and music.",
                    UrlSlug = Slugify("Some thing about Genshin"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                    ViewCount = 10000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 2,
                    Title = "Euro 2024 will put football back in the spotlight and boost a continent’s self-belief Philipp Lahm",
                    ShortDescripion = "Europe needs to reflect on how fortunate it is to host a tournament in a democracy and create a spirit of optimism.",
                    PostContent = "The countdown to Euro 2024 is ticking. The qualifiers begin on 23 March with Kazakhstan against Slovenia. These will be the first international matches after the World Cup, which was attractive in sporting terms but controversial in Europe. Qatar benefits from football for its political goals. We should do the same.",
                    UrlSlug = Slugify("Euro 2024 will put football back in the spotlight and boost a continent’s self-belief Philipp Lahm"),
                    Published = false,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                    ViewCount = 9000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 3,
                    Title = "The pandemic has changed consumer behaviour forever - and online shopping looks set to stay",
                    ShortDescripion = "The consulting and accounting firm's June 2021 Global Consumer Insights Pulse Survey reports a strong shift to online shopping as people were first confined by lockdowns, and then many continued to work from home.",
                    PostContent = "In total, 75% of US consumers have tried a new shopping behaviour and over a third of them (36%) have tried a new product brand. In part, this trend has been driven by popular items being out of stock as supply chains became strained at the height of the pandemic. However, 73% of consumers who had tried a different brand said they would continue to seek out new brands in the future.",
                    UrlSlug = Slugify("The pandemic has changed consumer behaviour forever - and online shopping looks set to stay"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                    ViewCount = 7000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 4,
                    Title = "A Front Company and a Fake Identity: How the U.S. Came to Use Spyware It Was Trying to Kill.",
                    ShortDescripion = "The Biden administration has been trying to choke off use of hacking tools made by the Israeli firm NSO. It turns out that not every part of the government has gotten the message.",
                    PostContent = "WASHINGTON — The secret contract was finalized on Nov. 8, 2021, a deal between a company that has acted as a front for the United States government and the American affiliate of a notorious Israeli hacking firm.\r\n\r\nUnder the arrangement, the Israeli firm, NSO Group, gave the U.S. government access to one of its most powerful weapons — a geolocation tool that can covertly track mobile phones around the world without the phone user’s knowledge or consent.\r\n\r\nIf the veiled nature of the deal was unusual — it was signed for the front company by a businessman using a fake name — the timing was extraordinary.\r\n\r\nOnly five days earlier, the Biden administration had announced it was taking action against NSO, whose hacking tools for years had been abused by governments around the world to spy on political dissidents, human rights activists and journalists. The White House placed NSO on a Commerce Department blacklist, declaring the company a national security threat and sending the message that American companies should stop doing business with it.\r\n\r\nThe secret contract — which The New York Times is disclosing for the first time — violates the Biden administration’s public policy, and still appears to be active. The contract, reviewed by The Times, stated that the “United States government” would be the ultimate user of the tool, although it is unclear which government agency authorized the deal and might be using the spyware. It specifically allowed the government to test, evaluate, and even deploy the spyware against targets of its choice in Mexico.\r\n\r\nAsked about the contract, White House officials said it was news to them.\r\n\r\n“We are not aware of this contract, and any use of this product would be highly concerning,” said a senior administration official, responding on the basis of anonymity to address a national security issue." +
                    "Spokesmen for the White House and Office of the Director of National Intelligence declined to make any further comment, leaving unresolved questions: What intelligence or law enforcement officials knew about the contract when it was signed? Did any government agency direct the deployment of the technology? Could the administration be dealing with a rogue government contractor evading Mr. Biden’s own policy? And why did the contract specify Mexico?",
                    UrlSlug = Slugify("A Front Company and a Fake Identity: How the U.S. Came to Use Spyware It Was Trying to Kill."),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 5,
                    ViewCount = 6000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 5,
                    Title = "Trump Flourishes in the Glare of His Indictment",
                    ShortDescripion = "The former president’s appetite for attention has been fundamental to his identity for decades. Where others may focus on the hazards of a criminal case, he raises money, promotes his campaign and works to reduce the case to a cliffhanging spectacle",
                    PostContent = "WASHINGTON — Since long before he entered the White House, former President Donald J. Trump has been an any-publicity-is-good-publicity kind of guy. In fact, he once told advisers, “There’s no bad press unless you’re a pedophile.” Hush money for a porn star? Evidently not an exception to that rule.\r\n\r\nAnd so, while no one wants to be indicted, Mr. Trump in one sense finds himself exactly where he loves to be — in the center ring of the circus, with all the spotlights on him. He has spent the days since a grand jury called him a potential criminal milking the moment for all it’s worth, savoring the attention as no one else in modern American politics would.\r\n\r\nHe has blitzed out one fund-raising email after another with the kind of headlines other politicians would dread, like “BREAKING: PRESIDENT TRUMP INDICTED” and “RUMORED DETAILS OF MY ARREST” and “Yes I’ve been indicted, BUT” — the “but” being but you can still give him money. And when it turned out that they did give him money, a total of $4 million by his campaign’s count in the 24 hours following his indictment, he trumpeted that as loudly as he could too.\r\n\r\nRather than hide from the indignity of turning himself into authorities this week, Mr. Trump obligingly sent out a schedule as if for a campaign tour, letting everyone know he would fly on Monday from Florida to New York, then on Tuesday surrender for mug shots, fingerprinting and arraignment. In case that were not enough to draw the eye, he plans to then fly back to Florida to make a prime-time evening statement at Mar-a-Lago, surrounded by the cameras and microphones he covets.Never mind that any defense attorney worth the law degree would prefer he keep quiet; no one who knows Mr. Trump could reasonably expect that. He has already trashed the prosecutor (“degenerate psychopath”) and the judge in the case (“HATES ME”) and absent a court-issued gag order surely will continue to. His public comments could ultimately be used against him in a court of law, but to him that hardly seems like a reason to stay silent.",
                    UrlSlug = Slugify("Trump Flourishes in the Glare of His Indictment"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 5,
                    ViewCount = 5000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 6,
                    Title = "Louisiana State Wins N.C.A.A. Women’s Title With Rout of Clark and Iowa",
                    ShortDescripion = "Angel Reese starred and talked trash as her Tigers held Caitlin Clark and Iowa at bay in a 102-85 victory.",
                    PostContent = "Louisiana State Coach Kim Mulkey had been trying to temper expectations all season.\r\n\r\nShe had added nine new players. Who knew how they would jell? In her second year coaching at L.S.U., nobody should expect a national championship, she argued.\r\n\r\nBut there was Mulkey in Sunday’s national championship game, clad in a sequin pantsuit that looked like something between a disco ball and an exploded glitter bomb, leading the third-seeded Tigers to their first women’s basketball championship with a convincing victory, 102-85, over Iowa and its superstar sharpshooter, Caitlin Clark. The Tigers’ 102 points were the most in a Division I women’s title game. Iowa’s 85 was the most in a loss.\r\n\r\nThe Tigers, behind the towering, smack-talking forward Angel Reese and a surprise shooting spark from Jasmine Carson, brought Clark and college basketball’s most exciting show to a screeching stop, ending one of the most electrifying individual runs in recent tournament history.\r\n\r\nClark, the consensus national player of the year, had caught the attention of the country with her N.B.A.-range shooting, her crisp passing and her visible emoting in celebration, frustration and competitive passion.\r\n\r\nThe Tigers celebrated at midcourt while freshman guard Flau’jae Johnson, who also raps, had one of her songs playing throughout the arena in Dallas. Johnson held the trophy and rapped her lyrics while waving her arms.\r\n\r\n“Year 2, and hoisting this trophy is crazy,” Mulkey told the crowd. The N.C.A.A. championship is Mulkey’s fourth as a head coach, moving her to third on the career list. Mulkey also won a title as a player with Louisiana Tech in 1982 and one as an assistant coach at the school. Mulkey said she “lost” it with about 90 seconds remaining Sunday, bursting into tears.\r\n\r\n“That’s really not like me until that final buzzer goes off, but I knew we were going to hold on to win this game,” Mulkey said through tears.\r\n\r\nReese was named the most outstanding player for the Final Four, finishing with 15 points, 10 rebounds, 5 assists and 3 steals. Carson scored a team-high 22 points, including 21 in the first half on 7-of-7 shooting.\r\n\r\n“I had so many goals coming into L.S.U.,” said Reese, who transferred from Maryland ahead of this season. “But I didn’t think I was going to win a national championship in my first year at L.S.U.”\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nAs the game wound down, Reese used one of Clark’s taunts of choice against her, waving a hand in front of her own face, the same move popularized by the professional wrestler John Cena. Reese also tapped her right ring finger while smiling at Clark, pointing out the spot for some fresh championship jewelry.\r\n\r\nReese, who has been criticized all season for her celebrations and taunting, said her showboating had added meaning.\r\n\r\n“I don’t fit the narrative,” Reese said. “I don’t fit the box that you all want me to be in. I’m too hood. I’m too ghetto. You all told me that all year. But when other people do it, you all say nothing. So this is for the girls that look like me that’s going to speak up on what they believe in — that’s unapologetically you.”\r\n\r\nAlexis Morris, the Tigers point guard, seemed to refer after the game to the massive attention Clark had been getting throughout the tournament.\r\n\r\n“Caitlin, you had an amazing game, you a great player,” Morris said. “But, you got to put some respect on L.S.U.”\r\n\r\nImage\r\n",
                    UrlSlug = Slugify("Louisiana State Wins N.C.A.A. Women’s Title With Rout of Clark and Iowa"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                    ViewCount = 4000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 7,
                    Title = "Why Tetris Consumed Your Brain",
                    ShortDescripion = "Tetris exploded in popularity after a race in the 1980s to secure global rights for the Soviet-made video game, a tale retold in a new movie. It is still captivating minds decades later.",
                    PostContent = "Rotating a colorful shape before slotting it into the perfect position is such a satisfying experience that Tetris has joined chess in the pantheon of universally recognizable games.\r\n\r\nLess familiar is the true story of how a prototype created in 1984 by a software engineer for the Soviet Union’s Academy of Sciences ended up reaching millions of players across the world. The movie “Tetris,” which stars Taron Egerton and was released on Apple TV+ on Friday, explores those humble beginnings.\r\n\r\nThe addictively simple puzzle game features seven uniquely shaped pieces, each composed of four square blocks. Players move, rotate and position the pieces to form solid lines, which are then cleared away, allowing for potentially endless play. The game’s name — derived from the words “tetra” (Greek for “four”) and “tennis” (the sport enjoyed by the game’s creator, Alexey Pajitnov) — has even pervaded culture as a verb, like when you “Tetris” your luggage into the overhead bin on a plane.\r\n\r\nIn an interview with The New York Times, Pajitnov described Tetris as “the game which appeals to everyone” and said he hoped that its future included e-sports and the integration of artificial intelligence. He is also working on making “a very good” two-player version of the game but said “we are not there yet.”\r\n\r\nBefore Tetris was able to cement itself as a household name with releases on consoles like the Nintendo Game Boy, Henk Rogers, the character played by Egerton, had to journey to the Soviet Union and fend off competitors to secure the game’s rights. As the film shows, that was an arduous task that paid off immensely. Here are more details about the game’s creation and why it has resonated with so many for so long: The Nintendo Game Boy\r\nIn the nearly four decades since Pajitnov created Tetris using the Pascal programming language on the Electronika 60, a Soviet-made computer, more than 215 officially recognized versions of Tetris have been released.\r\n\r\nPerhaps the most notable variant is the one that was packaged with each copy of the Nintendo Game Boy when the hand-held gaming console was released in 1989. But that incredibly successful pairing — the Game Boy and the Game Boy Color have combined for about 120 million unit sales — almost didn’t happen.\r\n\r\nThe president of Nintendo of America, Minoru Arakawa, initially wanted to bundle Super Mario Land with the Game Boy, following the company’s success packaging Super Mario Bros. with the Nintendo Entertainment System. Rogers, however, was able to convince Arakawa that Tetris should be included instead, in part because it would appeal to a broader group of demographics.\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nPajitnov described the partnership as “two creatures created for each other: Game Boy for Tetris and Tetris for the Game Boy.”\r\n\r\nImageIn a scene from “Tetris,” colorful shapes collect at the bottom of a computer screen. \r\n“Tetris” shows an early example of the video game featuring seven unique shapes.Credit...Apple\r\n\r\nThe Tetris Effect\r\nAs anybody who has spent hours playing Tetris knows, it is an incredibly addictive game. Many people who play for extended periods of time have reported seeing Tetris pieces outside of the game, such as in their mind when they close their eyes, or in their dreams. It’s a phenomenon known as the Tetris Effect.\r\n\r\nYou may have experienced the Tetris Effect yourself if you’ve ever seen tetrominoes, officially known as Tetriminos, when you’re trying to bag your groceries.\r\n\r\nIn professional studies, the psychologist Richard Haier found that regularly playing Tetris resulted in an increased thickness of the cerebral cortex. Haier’s studies also demonstrated how Tetris can affect the plasticity of cortical gray matter, potentially enhancing a person’s memory capacity and promoting motor and cognitive development.\r\n\r\nA study in 2017 by researchers at Oxford University and the Karolinska Institutet showed that Tetris had the potential to provide relief for people with post-traumatic stress disorder, if they played the game after an incident while recalling a stressful memory.",
                    UrlSlug = Slugify("Why Tetris Consumed Your Brain"),
                    Published = false,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                    ViewCount = 3000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 8,
                    Title = "As Trump Arraignment Looms, New York City Braces for a Day of Tumult",
                    ShortDescripion = "Donald J. Trump is expected to fly in on Monday night, then he is expected to spend the night in Trump Tower. The police will monitor every movement.",
                    PostContent = "Even for a city accustomed to celebrity appearances, the two-day visit during which Donald J. Trump is expected be arraigned in Manhattan is likely to be a striking spectacle: There will be protests and celebrations, an all-hands-on-deck police presence and a crush of media attention on the moment in which the first American president is charged with a crime.\r\n\r\nMr. Trump is expected to arrive in New York on Monday from his estate in Florida and head to his erstwhile home in Trump Tower, where he began his pursuit of the presidency in 2015 by descending a golden escalator. The exact timing of the former president’s arrival was unclear, though he was expected to stay the night there before heading to a courthouse in Lower Manhattan on Tuesday.\r\n\r\nLaw enforcement officials and outside experts have not warned of major threats from Trump’s supporters or opponents this week. But New York City officials and police were already girding for protests near the courthouse and outside Trump Tower on Fifth Avenue, where barricades lined the streets for several blocks surrounding the building on Sunday, amid camera crews and curiosity seekers.\r\n\r\nAt the same time, Mr. Trump’s legal team was speaking out against the indictment, which came as a result of a grand jury vote in Manhattan on Thursday. In an interview on Sunday on “This Week with George Stephanopoulos” on ABC, Joe Tacopina, a lawyer for Mr. Trump, called the looming charges “a political persecution” and “a complete abuse of power” that the former president was ready to fight.\r\n\r\n“He’s a tough guy,” Mr. Tacopina said, adding that he was looking forward “to moving this thing along as quickly as possible to exonerate him. Mr. Trump, 76, is expected to surrender at the office of the Manhattan district attorney, Alvin L. Bragg, early Tuesday afternoon, before being arraigned in the hulking Manhattan Criminal Courts Building. The arraignment will take place in a 15th-floor courtroom, and Justice Juan M. Merchan, a state Supreme Court judge, will hear the case.\r\n\r\nThe exact charges have not yet been unsealed, though they are linked to a payment made during the 2016 election to buy the silence of a porn star, Stormy Daniels, who says she had a brief sexual relationship with Mr. Trump in 2006. Mr. Trump denies the affair. Prosecutors are expected to accuse Mr. Trump of falsifying business records to hide the nature of the reimbursements to his former fixer, who had paid the hush money to Ms. Daniels.”",
                    UrlSlug = Slugify("As Trump Arraignment Looms, New York City Braces for a Day of Tumult"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                    ViewCount = 2000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 9,
                    Title = "Anxious Times Descend on New York. Enter Springsteen.",
                    ShortDescripion = "There was tension in the city as New Yorkers waited for Donald J. Trump to appear, but in the meantime, Bruce kept playing at the Garden.",
                    PostContent = "Like many in the house, Mr. Springsteen too was at home on Saturday, just across the river from his bed in his native New Jersey after two months of barnstorming the country on his first U.S. tour with the E Street Band since 2016. With all respect to those cities where he has recently performed, beginning in Tampa and heading west, for New Yorkers, a Springsteen tour only really begins when it arrives at that legendary address on Seventh Avenue in Midtown. He would return more than 40 times in the decades that followed, putting him shoulder-to-shoulder with most every musical act except Billy Joel, who still performs at the Garden frequently enough to have his mail forwarded there.\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nIn 2001, after a global E Street Band tour, Mr. Springsteen released a concert album, “Live in New York City,” recorded at the Garden and a reminder of the city’s place in his creative thinking. That album contained the first recorded version of “American Skin (41 Shots),” about the 1999 fatal police shooting of Amadou Diallo in the Bronx as he reached for his wallet. The song divided fans and infuriated members of the Police Department, who reportedly refused to provide Mr. Springsteen with an escort out of the city after he played it at a later show.",
                    UrlSlug = Slugify("Anxious Times Descend on New York. Enter Springsteen."),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 4,
                    ViewCount = 1000,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Post
                {
                    Id = 10,
                    Title = "Sheet-Pan Recipes for When You’re Down",
                    ShortDescripion = "Sometimes you need meals that require minimum effort.",
                    PostContent = "I keep a running list of topics I want to cover in this newsletter, and I had a couple in mind for this week. Breakfasts that get me out of bed in the morning! Vibrant recipes for the spring produce creeping into farmers’ markets!\r\n\r\nBut the truth is I’ve been sad — mozzarella-sticks-for-lunch, cereal-for-dinner sad. You might recognize it, you might even be experiencing it right now. One can only eat that way for so long, though. Either your depleted supply of frozen foods or the siren song of fiber will snap you out of the funk. Still, you will need meals that require the absolute minimum of you.\r\n\r\nA sheet-pan recipe is the obvious place to start because it is so accessible. You’d be pressed to find a home kitchen without a sheet pan. They’re a key tool in so many easy, under-40-minute recipes that call for little more than piling a few ingredients together and shoving them into the oven.\r\n\r\nWith just five ingredients* and one sheet pan, you can prepare Ali Slagle’s roasted sweet potatoes and spinach with feta, an unexpected yet delightful amalgam of wholesome ingredients. Pickled jalapeño brine is used as a sort of spiced vinegar for the vegetables, which is the kind of genius pantry hack you appreciate when you’re down.\r\n\r\nWith just five ingredients and two sheet pans (OK, and a small cup), you can make Hetty McKinnon’s vegan tofu and brussels sprouts with hoisin-tahini sauce. Using two sheet pans ensures that the tofu and brussels sprouts cook evenly, but if you’re cooking for only one or two people, halve the recipe and use one sheet pan. It’s a filling recipe, and you’ll likely still have leftovers.\r\n\r\nWith just eight ingredients and two sheet pans, you can throw together Susan Spungen’s springy gnocchi with asparagus, leeks and peas. It’s a forgiving recipe: Use mini pierogi or big butter beans instead of gnocchi, or swap in green beans, broccolini or scallions for any of the vegetables. Whatever you have will be good enough.\r\n\r\nNot only can you cook an entire meal using a sheet pan, but you can eat off it, too. Light a taper candle in the center of the table, maybe break out a cloth napkin to lift your spirits, but the effort can stop there. You’re in the comfort of your home, after all, and life is hard enough.\r\n\r\n*I’m not counting salt and pepper or olive oil when totaling up ingredients, and you shouldn’t either.",
                    UrlSlug = Slugify("Sheet-Pan Recipes for When You’re Down"),
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 4,
                    ViewCount = 500,
                    RateCount = 5000,
                    TotalRate = 2000,
                    Rate = 5000 / 2000,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                }
                );
            builder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "#Game Sport",
                    UrlSlug = Slugify("#Game-Sport"),
                    Description = "Game",
                    Count = 5,
                },
                new Tag
                {
                    Id = 2,
                    Name = "#Sport Football",
                    UrlSlug = Slugify("#Sport-Football"),
                    Description = "Sport",
                    Count = 3,
                },
                new Tag
                {
                    Id = 3,
                    Name = "#Shopping Socal",
                    UrlSlug = Slugify("#Shopping-Socal"),
                    Description = "Shopping Socal",
                    Count = 2,
                },
                new Tag
                {
                    Id = 4,
                    Name = "#Socal",
                    UrlSlug = Slugify("#Socal"),
                    Description = "Socal",
                    Count = 2,
                },
                new Tag
                {
                    Id = 5,
                    Name = "#Economic",
                    UrlSlug = Slugify("#Economic"),
                    Description = "Economic",
                    Count = 2,
                },
                new Tag
                {
                    Id = 6,
                    Name = "#Food",
                    UrlSlug = Slugify("#Food"),
                    Description = "Food",
                    Count = 2,
                },
                new Tag
                {
                    Id = 7,
                    Name = "#Genshin Impact",
                    UrlSlug = Slugify("#Genshin Impact"),
                    Description = "Genshin Impact",
                    Count = 2,
                },
                new Tag
                {
                    Id = 8,
                    Name = "#Trump",
                    UrlSlug = Slugify("#Donal Trump"),
                    Description = "Donal Trump",
                    Count = 2,
                },
                new Tag
                {
                    Id = 9,
                    Name = "#Education",
                    UrlSlug = Slugify("#Education"),
                    Description = "Education",
                    Count = 2,
                },
                new Tag
                {
                    Id = 10,
                    Name = "#labor",
                    UrlSlug = Slugify("#Labor"),
                    Description = "Labor",
                    Count = 2,
                }
                );
            builder.Entity<PostTagMap>().HasData(
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
                    PostId = 1,
                    TagId = 7,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 2,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 4,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 3,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 4,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 4,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 10,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 6,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 7,
                },
                new PostTagMap
                {
                    PostId = 6,
                    TagId = 6,
                },
                new PostTagMap
                {
                    PostId = 6,
                    TagId = 8,
                },
                new PostTagMap
                {
                    PostId = 6,
                    TagId = 1,
                },
                new PostTagMap
                {
                    PostId = 7,
                    TagId = 3,
                },
                new PostTagMap
                {
                    PostId = 7,
                    TagId = 10,
                },
                new PostTagMap
                {
                    PostId = 7,
                    TagId = 9,
                },
                new PostTagMap
                {
                    PostId = 8,
                    TagId = 8,
                },
                new PostTagMap
                {
                    PostId = 8,
                    TagId = 4,
                },
                new PostTagMap
                {
                    PostId = 8,
                    TagId = 6,
                },
                new PostTagMap
                {
                    PostId = 9,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 9,
                    TagId = 7,
                },
                new PostTagMap
                {
                    PostId = 9,
                    TagId = 9,
                },
                new PostTagMap
                {
                    PostId = 10,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 10,
                    TagId = 7,
                },
                new PostTagMap
                {
                    PostId = 10,
                    TagId = 2,
                }
                );
            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Name = "TanDinh",
                    Email = "tandv3@gmail.com",
                    PostId = 1,
                    CommentHeader = "Good..",
                    CommentText = "Hey so good post",
                    CommentTime = DateTime.Now,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Comment
                {
                    Id = 2,
                    Name = "AnhTran",
                    Email = "anhth403@gmail.com",
                    PostId = 2,
                    CommentHeader = "Good..",
                    CommentText = "Hey so good post",
                    CommentTime = DateTime.Now,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                },
                new Comment
                {
                    Id = 3,
                    Name = "TuanTran",
                    Email = "tuantv27@gmail.com",
                    PostId = 3,
                    CommentHeader = "Good..",
                    CommentText = "Hey so good post",
                    CommentTime = DateTime.Now,
                    FAJustBlogUserId = "b02c55d8-8310-413a-a164-972a49ec3ae7"
                }
                );
        }
    }
}
