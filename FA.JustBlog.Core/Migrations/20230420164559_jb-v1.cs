using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class jbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescripion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FAJustBlogUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_FAJustBlogUserId",
                        column: x => x.FAJustBlogUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FAJustBlogUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_FAJustBlogUserId",
                        column: x => x.FAJustBlogUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f89f46b-0102-414b-8fed-4898d5a05357", "3c56d952-2194-4470-b931-4f681e6a9d35", "CONTRIBUTOR", "CONTRIBUTOR" },
                    { "257ca16f-43ae-4eaa-bdbd-ee6b15af39d0", "4cad3ab0-10b9-43d5-872a-80e7cf09f486", "Blog_Owner", "Blog_Owner" },
                    { "b5e8e51f-7cc2-4c37-beec-f918a7278d83", "efb2811a-b9e6-40c6-85a8-517df3d17c08", "OTHER", "OTHER" },
                    { "d602c8e8-8efe-40cc-bc1a-10631256e634", "23d1e9b1-9d90-4d59-9832-3ca659cd1060", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "65e642d0-d721-40db-8c29-33f8dcbd2561", 0, "7f5ba478-d6ea-4d34-a574-8a63745c436c", "tandv@gmail.com", true, "Tân", "CONTRIBUTOR", false, null, "TANDV@GMAIL.COM", "TANDV@GMAIL.COM", "AQAAAAEAACcQAAAAECzCPVYTgoVIZcS2VQmuW3hjbrkCk5pjgDilj5UcFvsNrCJXa+21IaGF0ih9gPjbLw==", "0987654321", true, "X7KL6KKFOLHPZ3UP6TXP6KHW5GDWKZLJ", false, "tandv@gmail.com" },
                    { "b02c55d8-8310-413a-a164-972a49ec3ae7", 0, "e77dc837-e22a-404f-95ad-75679ef72db7", "admin@gmail.com", true, "Đinh", "Tân", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEH2Dfkzp3xa5Gga2TrNHxfdAvFTc8eBwhUlKpECP5fMXDH5l7FaxidLEglGTQ9k92A==", "0987654321", true, "FORYX2L6CLYTMOU2MF5SQKUYSI7SSCX7", false, "admin@gmail.com" },
                    { "edf72b05-771d-4847-979f-a3a4eb59ad17", 0, "25decc9f-a481-452e-8c24-0a9acc7a59d5", "user@gmail.com", true, "User", "NoName", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEN4R4cqx0nVDzyikJRLz5qGs1qhPc9KaqBUS4Endsu4Wcbo2viIRoAGYjPWXosV+hg==", "0987654321", true, "QCOP5KYUYLQ36Y2TZS3P466U6KVMLRHJ", false, "user@gmail.com" },
                    { "f2cc633b-1e66-430d-b85a-0961deb7f434", 0, "5d2f1036-876d-438e-92e0-2fe6934b4397", "tandv3@gmail.com", true, "Tân", "Other", false, null, "TANDV3@GMAIL.COM", "TANDV3@GMAIL.COM", "AQAAAAEAACcQAAAAEKaB6Qa1K6c33Hw6K/v31r1J9w+9z1+CdvwyYAM3AgwoPRpuBXdCTpYPhn3+sX1COQ==", "0987654321", true, "JY6CHAWGK2Y2RLNRYD72Y3TG5BPHDU35", false, "tandv3@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "A Game is a structured form of play, usually undertaken for entertainment or fun, and sometimes used as an educational tool. Many games are also considered to be work (such as professional players of spectator sports or games) or art (such as jigsaw puzzles or games involving an artistic layout such as Mahjong, solitaire, or some video games).", "Game Sport", "game-sport" },
                    { 2, "Sports, physical contests pursued for the goals and challenges they entail. Sports are part of every culture past and present, but each culture has its own definition of sports. The most useful definitions are those that clarify the relationship of sports to play, games, and contests.", "Sport Football", "sport-football" },
                    { 3, "Shopping is the act of selecting and buying goods from retail stores or online platforms. It includes a wide range of products such as clothing, groceries, electronics, home decorations, etc. In-store shopping involves physically examining and comparing products with the help of sales associates, while online shopping offers convenience, allowing customers to browse websites, compare prices, and make purchases easily. Shopping experiences vary based on store type, product quality, discounts/promotions, and customer service. Overall, shopping can be enjoyable, meeting both practical needs and personal preferences.", "Shopping Socal", "shopping-socal" },
                    { 4, "Social media are interactive technologies that facilitate the creation and sharing of information, ideas, interests, and other forms of expression through virtual communities and networks. While challenges to the definition of social media arise due to the variety of stand-alone and built-in social media services currently available.", "Socal", "social-media" },
                    { 5, "The world economy or global economy is the economy of all humans of the world, referring to the global economic system, which includes all economic activities which are conducted both within and between nations, including production, consumption, economic management, work in general, exchange of financial values and trade of goods and services.", "Economic", "world-economy" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 5, "Game", "#Game Sport", "game-sport" },
                    { 2, 3, "Sport", "#Sport Football", "sport-football" },
                    { 3, 2, "Shopping Socal", "#Shopping Socal", "shopping-socal" },
                    { 4, 2, "Socal", "#Socal", "socal" },
                    { 5, 2, "Economic", "#Economic", "economic" },
                    { 6, 2, "Food", "#Food", "food" },
                    { 7, 2, "Genshin Impact", "#Genshin Impact", "genshin-impact" },
                    { 8, 2, "Donal Trump", "#Trump", "donal-trump" },
                    { 9, 2, "Education", "#Education", "education" },
                    { 10, 2, "Labor", "#labor", "labor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1f89f46b-0102-414b-8fed-4898d5a05357", "65e642d0-d721-40db-8c29-33f8dcbd2561" },
                    { "257ca16f-43ae-4eaa-bdbd-ee6b15af39d0", "b02c55d8-8310-413a-a164-972a49ec3ae7" },
                    { "b5e8e51f-7cc2-4c37-beec-f918a7278d83", "edf72b05-771d-4847-979f-a3a4eb59ad17" },
                    { "d602c8e8-8efe-40cc-bc1a-10631256e634", "f2cc633b-1e66-430d-b85a-0961deb7f434" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "FAJustBlogUserId", "Modified", "PostContent", "PostedOn", "Published", "Rate", "RateCount", "ShortDescripion", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8715), "Genshin Impact is an action role-playing video game developed by miHoYo. It features an open world environment and a gacha game monetization system, with players collecting characters and weapons by spending in-game currency or real money. The game takes place in the fantasy world of Teyvat, where players explore various regions and complete quests while battling enemies and bosses. Genshin Impact received positive critical reception for its gameplay, graphics, and music.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8702), true, 2m, 5000, "How  to the build Hutao and Ayaka.", "Some thing about Genshin", 2000, "some-thing-about-genshin", 10000 },
                    { 2, 2, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8809), "The countdown to Euro 2024 is ticking. The qualifiers begin on 23 March with Kazakhstan against Slovenia. These will be the first international matches after the World Cup, which was attractive in sporting terms but controversial in Europe. Qatar benefits from football for its political goals. We should do the same.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8808), false, 2m, 5000, "Europe needs to reflect on how fortunate it is to host a tournament in a democracy and create a spirit of optimism.", "Euro 2024 will put football back in the spotlight and boost a continent’s self-belief Philipp Lahm", 2000, "euro-2024-will-put-football-back-in-the-spotlight-and-boost-a-continents-self-belief-philipp-lahm", 9000 },
                    { 3, 3, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8856), "In total, 75% of US consumers have tried a new shopping behaviour and over a third of them (36%) have tried a new product brand. In part, this trend has been driven by popular items being out of stock as supply chains became strained at the height of the pandemic. However, 73% of consumers who had tried a different brand said they would continue to seek out new brands in the future.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8855), true, 2m, 5000, "The consulting and accounting firm's June 2021 Global Consumer Insights Pulse Survey reports a strong shift to online shopping as people were first confined by lockdowns, and then many continued to work from home.", "The pandemic has changed consumer behaviour forever - and online shopping looks set to stay", 2000, "the-pandemic-has-changed-consumer-behaviour-forever---and-online-shopping-looks-set-to-stay", 7000 },
                    { 4, 5, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8921), "WASHINGTON — The secret contract was finalized on Nov. 8, 2021, a deal between a company that has acted as a front for the United States government and the American affiliate of a notorious Israeli hacking firm.\r\n\r\nUnder the arrangement, the Israeli firm, NSO Group, gave the U.S. government access to one of its most powerful weapons — a geolocation tool that can covertly track mobile phones around the world without the phone user’s knowledge or consent.\r\n\r\nIf the veiled nature of the deal was unusual — it was signed for the front company by a businessman using a fake name — the timing was extraordinary.\r\n\r\nOnly five days earlier, the Biden administration had announced it was taking action against NSO, whose hacking tools for years had been abused by governments around the world to spy on political dissidents, human rights activists and journalists. The White House placed NSO on a Commerce Department blacklist, declaring the company a national security threat and sending the message that American companies should stop doing business with it.\r\n\r\nThe secret contract — which The New York Times is disclosing for the first time — violates the Biden administration’s public policy, and still appears to be active. The contract, reviewed by The Times, stated that the “United States government” would be the ultimate user of the tool, although it is unclear which government agency authorized the deal and might be using the spyware. It specifically allowed the government to test, evaluate, and even deploy the spyware against targets of its choice in Mexico.\r\n\r\nAsked about the contract, White House officials said it was news to them.\r\n\r\n“We are not aware of this contract, and any use of this product would be highly concerning,” said a senior administration official, responding on the basis of anonymity to address a national security issue.Spokesmen for the White House and Office of the Director of National Intelligence declined to make any further comment, leaving unresolved questions: What intelligence or law enforcement officials knew about the contract when it was signed? Did any government agency direct the deployment of the technology? Could the administration be dealing with a rogue government contractor evading Mr. Biden’s own policy? And why did the contract specify Mexico?", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8920), true, 2m, 5000, "The Biden administration has been trying to choke off use of hacking tools made by the Israeli firm NSO. It turns out that not every part of the government has gotten the message.", "A Front Company and a Fake Identity: How the U.S. Came to Use Spyware It Was Trying to Kill.", 2000, "a-front-company-and-a-fake-identity-how-the-us-came-to-use-spyware-it-was-trying-to-kill", 6000 },
                    { 5, 5, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8951), "WASHINGTON — Since long before he entered the White House, former President Donald J. Trump has been an any-publicity-is-good-publicity kind of guy. In fact, he once told advisers, “There’s no bad press unless you’re a pedophile.” Hush money for a porn star? Evidently not an exception to that rule.\r\n\r\nAnd so, while no one wants to be indicted, Mr. Trump in one sense finds himself exactly where he loves to be — in the center ring of the circus, with all the spotlights on him. He has spent the days since a grand jury called him a potential criminal milking the moment for all it’s worth, savoring the attention as no one else in modern American politics would.\r\n\r\nHe has blitzed out one fund-raising email after another with the kind of headlines other politicians would dread, like “BREAKING: PRESIDENT TRUMP INDICTED” and “RUMORED DETAILS OF MY ARREST” and “Yes I’ve been indicted, BUT” — the “but” being but you can still give him money. And when it turned out that they did give him money, a total of $4 million by his campaign’s count in the 24 hours following his indictment, he trumpeted that as loudly as he could too.\r\n\r\nRather than hide from the indignity of turning himself into authorities this week, Mr. Trump obligingly sent out a schedule as if for a campaign tour, letting everyone know he would fly on Monday from Florida to New York, then on Tuesday surrender for mug shots, fingerprinting and arraignment. In case that were not enough to draw the eye, he plans to then fly back to Florida to make a prime-time evening statement at Mar-a-Lago, surrounded by the cameras and microphones he covets.Never mind that any defense attorney worth the law degree would prefer he keep quiet; no one who knows Mr. Trump could reasonably expect that. He has already trashed the prosecutor (“degenerate psychopath”) and the judge in the case (“HATES ME”) and absent a court-issued gag order surely will continue to. His public comments could ultimately be used against him in a court of law, but to him that hardly seems like a reason to stay silent.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(8951), true, 2m, 5000, "The former president’s appetite for attention has been fundamental to his identity for decades. Where others may focus on the hazards of a criminal case, he raises money, promotes his campaign and works to reduce the case to a cliffhanging spectacle", "Trump Flourishes in the Glare of His Indictment", 2000, "trump-flourishes-in-the-glare-of-his-indictment", 5000 },
                    { 6, 2, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9006), "Louisiana State Coach Kim Mulkey had been trying to temper expectations all season.\r\n\r\nShe had added nine new players. Who knew how they would jell? In her second year coaching at L.S.U., nobody should expect a national championship, she argued.\r\n\r\nBut there was Mulkey in Sunday’s national championship game, clad in a sequin pantsuit that looked like something between a disco ball and an exploded glitter bomb, leading the third-seeded Tigers to their first women’s basketball championship with a convincing victory, 102-85, over Iowa and its superstar sharpshooter, Caitlin Clark. The Tigers’ 102 points were the most in a Division I women’s title game. Iowa’s 85 was the most in a loss.\r\n\r\nThe Tigers, behind the towering, smack-talking forward Angel Reese and a surprise shooting spark from Jasmine Carson, brought Clark and college basketball’s most exciting show to a screeching stop, ending one of the most electrifying individual runs in recent tournament history.\r\n\r\nClark, the consensus national player of the year, had caught the attention of the country with her N.B.A.-range shooting, her crisp passing and her visible emoting in celebration, frustration and competitive passion.\r\n\r\nThe Tigers celebrated at midcourt while freshman guard Flau’jae Johnson, who also raps, had one of her songs playing throughout the arena in Dallas. Johnson held the trophy and rapped her lyrics while waving her arms.\r\n\r\n“Year 2, and hoisting this trophy is crazy,” Mulkey told the crowd. The N.C.A.A. championship is Mulkey’s fourth as a head coach, moving her to third on the career list. Mulkey also won a title as a player with Louisiana Tech in 1982 and one as an assistant coach at the school. Mulkey said she “lost” it with about 90 seconds remaining Sunday, bursting into tears.\r\n\r\n“That’s really not like me until that final buzzer goes off, but I knew we were going to hold on to win this game,” Mulkey said through tears.\r\n\r\nReese was named the most outstanding player for the Final Four, finishing with 15 points, 10 rebounds, 5 assists and 3 steals. Carson scored a team-high 22 points, including 21 in the first half on 7-of-7 shooting.\r\n\r\n“I had so many goals coming into L.S.U.,” said Reese, who transferred from Maryland ahead of this season. “But I didn’t think I was going to win a national championship in my first year at L.S.U.”\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nAs the game wound down, Reese used one of Clark’s taunts of choice against her, waving a hand in front of her own face, the same move popularized by the professional wrestler John Cena. Reese also tapped her right ring finger while smiling at Clark, pointing out the spot for some fresh championship jewelry.\r\n\r\nReese, who has been criticized all season for her celebrations and taunting, said her showboating had added meaning.\r\n\r\n“I don’t fit the narrative,” Reese said. “I don’t fit the box that you all want me to be in. I’m too hood. I’m too ghetto. You all told me that all year. But when other people do it, you all say nothing. So this is for the girls that look like me that’s going to speak up on what they believe in — that’s unapologetically you.”\r\n\r\nAlexis Morris, the Tigers point guard, seemed to refer after the game to the massive attention Clark had been getting throughout the tournament.\r\n\r\n“Caitlin, you had an amazing game, you a great player,” Morris said. “But, you got to put some respect on L.S.U.”\r\n\r\nImage\r\n", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9005), true, 2m, 5000, "Angel Reese starred and talked trash as her Tigers held Caitlin Clark and Iowa at bay in a 102-85 victory.", "Louisiana State Wins N.C.A.A. Women’s Title With Rout of Clark and Iowa", 2000, "louisiana-state-wins-ncaa-womens-title-with-rout-of-clark-and-iowa", 4000 },
                    { 7, 1, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9029), "Rotating a colorful shape before slotting it into the perfect position is such a satisfying experience that Tetris has joined chess in the pantheon of universally recognizable games.\r\n\r\nLess familiar is the true story of how a prototype created in 1984 by a software engineer for the Soviet Union’s Academy of Sciences ended up reaching millions of players across the world. The movie “Tetris,” which stars Taron Egerton and was released on Apple TV+ on Friday, explores those humble beginnings.\r\n\r\nThe addictively simple puzzle game features seven uniquely shaped pieces, each composed of four square blocks. Players move, rotate and position the pieces to form solid lines, which are then cleared away, allowing for potentially endless play. The game’s name — derived from the words “tetra” (Greek for “four”) and “tennis” (the sport enjoyed by the game’s creator, Alexey Pajitnov) — has even pervaded culture as a verb, like when you “Tetris” your luggage into the overhead bin on a plane.\r\n\r\nIn an interview with The New York Times, Pajitnov described Tetris as “the game which appeals to everyone” and said he hoped that its future included e-sports and the integration of artificial intelligence. He is also working on making “a very good” two-player version of the game but said “we are not there yet.”\r\n\r\nBefore Tetris was able to cement itself as a household name with releases on consoles like the Nintendo Game Boy, Henk Rogers, the character played by Egerton, had to journey to the Soviet Union and fend off competitors to secure the game’s rights. As the film shows, that was an arduous task that paid off immensely. Here are more details about the game’s creation and why it has resonated with so many for so long: The Nintendo Game Boy\r\nIn the nearly four decades since Pajitnov created Tetris using the Pascal programming language on the Electronika 60, a Soviet-made computer, more than 215 officially recognized versions of Tetris have been released.\r\n\r\nPerhaps the most notable variant is the one that was packaged with each copy of the Nintendo Game Boy when the hand-held gaming console was released in 1989. But that incredibly successful pairing — the Game Boy and the Game Boy Color have combined for about 120 million unit sales — almost didn’t happen.\r\n\r\nThe president of Nintendo of America, Minoru Arakawa, initially wanted to bundle Super Mario Land with the Game Boy, following the company’s success packaging Super Mario Bros. with the Nintendo Entertainment System. Rogers, however, was able to convince Arakawa that Tetris should be included instead, in part because it would appeal to a broader group of demographics.\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nPajitnov described the partnership as “two creatures created for each other: Game Boy for Tetris and Tetris for the Game Boy.”\r\n\r\nImageIn a scene from “Tetris,” colorful shapes collect at the bottom of a computer screen. \r\n“Tetris” shows an early example of the video game featuring seven unique shapes.Credit...Apple\r\n\r\nThe Tetris Effect\r\nAs anybody who has spent hours playing Tetris knows, it is an incredibly addictive game. Many people who play for extended periods of time have reported seeing Tetris pieces outside of the game, such as in their mind when they close their eyes, or in their dreams. It’s a phenomenon known as the Tetris Effect.\r\n\r\nYou may have experienced the Tetris Effect yourself if you’ve ever seen tetrominoes, officially known as Tetriminos, when you’re trying to bag your groceries.\r\n\r\nIn professional studies, the psychologist Richard Haier found that regularly playing Tetris resulted in an increased thickness of the cerebral cortex. Haier’s studies also demonstrated how Tetris can affect the plasticity of cortical gray matter, potentially enhancing a person’s memory capacity and promoting motor and cognitive development.\r\n\r\nA study in 2017 by researchers at Oxford University and the Karolinska Institutet showed that Tetris had the potential to provide relief for people with post-traumatic stress disorder, if they played the game after an incident while recalling a stressful memory.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9028), false, 2m, 5000, "Tetris exploded in popularity after a race in the 1980s to secure global rights for the Soviet-made video game, a tale retold in a new movie. It is still captivating minds decades later.", "Why Tetris Consumed Your Brain", 2000, "why-tetris-consumed-your-brain", 3000 },
                    { 8, 3, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9074), "Even for a city accustomed to celebrity appearances, the two-day visit during which Donald J. Trump is expected be arraigned in Manhattan is likely to be a striking spectacle: There will be protests and celebrations, an all-hands-on-deck police presence and a crush of media attention on the moment in which the first American president is charged with a crime.\r\n\r\nMr. Trump is expected to arrive in New York on Monday from his estate in Florida and head to his erstwhile home in Trump Tower, where he began his pursuit of the presidency in 2015 by descending a golden escalator. The exact timing of the former president’s arrival was unclear, though he was expected to stay the night there before heading to a courthouse in Lower Manhattan on Tuesday.\r\n\r\nLaw enforcement officials and outside experts have not warned of major threats from Trump’s supporters or opponents this week. But New York City officials and police were already girding for protests near the courthouse and outside Trump Tower on Fifth Avenue, where barricades lined the streets for several blocks surrounding the building on Sunday, amid camera crews and curiosity seekers.\r\n\r\nAt the same time, Mr. Trump’s legal team was speaking out against the indictment, which came as a result of a grand jury vote in Manhattan on Thursday. In an interview on Sunday on “This Week with George Stephanopoulos” on ABC, Joe Tacopina, a lawyer for Mr. Trump, called the looming charges “a political persecution” and “a complete abuse of power” that the former president was ready to fight.\r\n\r\n“He’s a tough guy,” Mr. Tacopina said, adding that he was looking forward “to moving this thing along as quickly as possible to exonerate him. Mr. Trump, 76, is expected to surrender at the office of the Manhattan district attorney, Alvin L. Bragg, early Tuesday afternoon, before being arraigned in the hulking Manhattan Criminal Courts Building. The arraignment will take place in a 15th-floor courtroom, and Justice Juan M. Merchan, a state Supreme Court judge, will hear the case.\r\n\r\nThe exact charges have not yet been unsealed, though they are linked to a payment made during the 2016 election to buy the silence of a porn star, Stormy Daniels, who says she had a brief sexual relationship with Mr. Trump in 2006. Mr. Trump denies the affair. Prosecutors are expected to accuse Mr. Trump of falsifying business records to hide the nature of the reimbursements to his former fixer, who had paid the hush money to Ms. Daniels.”", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9073), true, 2m, 5000, "Donald J. Trump is expected to fly in on Monday night, then he is expected to spend the night in Trump Tower. The police will monitor every movement.", "As Trump Arraignment Looms, New York City Braces for a Day of Tumult", 2000, "as-trump-arraignment-looms-new-york-city-braces-for-a-day-of-tumult", 2000 },
                    { 9, 4, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9110), "Like many in the house, Mr. Springsteen too was at home on Saturday, just across the river from his bed in his native New Jersey after two months of barnstorming the country on his first U.S. tour with the E Street Band since 2016. With all respect to those cities where he has recently performed, beginning in Tampa and heading west, for New Yorkers, a Springsteen tour only really begins when it arrives at that legendary address on Seventh Avenue in Midtown. He would return more than 40 times in the decades that followed, putting him shoulder-to-shoulder with most every musical act except Billy Joel, who still performs at the Garden frequently enough to have his mail forwarded there.\r\n\r\nEditors’ Picks\r\n\r\nSheet-Pan Recipes for When You’re Down\r\n\r\nWhy Tetris Consumed Your Brain\r\n\r\nImagine T. Rex. Now Imagine It With Lips.\r\nIn 2001, after a global E Street Band tour, Mr. Springsteen released a concert album, “Live in New York City,” recorded at the Garden and a reminder of the city’s place in his creative thinking. That album contained the first recorded version of “American Skin (41 Shots),” about the 1999 fatal police shooting of Amadou Diallo in the Bronx as he reached for his wallet. The song divided fans and infuriated members of the Police Department, who reportedly refused to provide Mr. Springsteen with an escort out of the city after he played it at a later show.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9109), true, 2m, 5000, "There was tension in the city as New Yorkers waited for Donald J. Trump to appear, but in the meantime, Bruce kept playing at the Garden.", "Anxious Times Descend on New York. Enter Springsteen.", 2000, "anxious-times-descend-on-new-york-enter-springsteen", 1000 },
                    { 10, 4, "b02c55d8-8310-413a-a164-972a49ec3ae7", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9142), "I keep a running list of topics I want to cover in this newsletter, and I had a couple in mind for this week. Breakfasts that get me out of bed in the morning! Vibrant recipes for the spring produce creeping into farmers’ markets!\r\n\r\nBut the truth is I’ve been sad — mozzarella-sticks-for-lunch, cereal-for-dinner sad. You might recognize it, you might even be experiencing it right now. One can only eat that way for so long, though. Either your depleted supply of frozen foods or the siren song of fiber will snap you out of the funk. Still, you will need meals that require the absolute minimum of you.\r\n\r\nA sheet-pan recipe is the obvious place to start because it is so accessible. You’d be pressed to find a home kitchen without a sheet pan. They’re a key tool in so many easy, under-40-minute recipes that call for little more than piling a few ingredients together and shoving them into the oven.\r\n\r\nWith just five ingredients* and one sheet pan, you can prepare Ali Slagle’s roasted sweet potatoes and spinach with feta, an unexpected yet delightful amalgam of wholesome ingredients. Pickled jalapeño brine is used as a sort of spiced vinegar for the vegetables, which is the kind of genius pantry hack you appreciate when you’re down.\r\n\r\nWith just five ingredients and two sheet pans (OK, and a small cup), you can make Hetty McKinnon’s vegan tofu and brussels sprouts with hoisin-tahini sauce. Using two sheet pans ensures that the tofu and brussels sprouts cook evenly, but if you’re cooking for only one or two people, halve the recipe and use one sheet pan. It’s a filling recipe, and you’ll likely still have leftovers.\r\n\r\nWith just eight ingredients and two sheet pans, you can throw together Susan Spungen’s springy gnocchi with asparagus, leeks and peas. It’s a forgiving recipe: Use mini pierogi or big butter beans instead of gnocchi, or swap in green beans, broccolini or scallions for any of the vegetables. Whatever you have will be good enough.\r\n\r\nNot only can you cook an entire meal using a sheet pan, but you can eat off it, too. Light a taper candle in the center of the table, maybe break out a cloth napkin to lift your spirits, but the effort can stop there. You’re in the comfort of your home, after all, and life is hard enough.\r\n\r\n*I’m not counting salt and pepper or olive oil when totaling up ingredients, and you shouldn’t either.", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9141), true, 2m, 5000, "Sometimes you need meals that require minimum effort.", "Sheet-Pan Recipes for When You’re Down", 2000, "sheet-pan-recipes-for-when-youre-down", 500 }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "FAJustBlogUserId", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Good..", "Hey so good post", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9368), "tandv3@gmail.com", "b02c55d8-8310-413a-a164-972a49ec3ae7", "TanDinh", 1 },
                    { 2, "Good..", "Hey so good post", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9371), "anhth403@gmail.com", "b02c55d8-8310-413a-a164-972a49ec3ae7", "AnhTran", 2 },
                    { 3, "Good..", "Hey so good post", new DateTime(2023, 4, 20, 23, 45, 58, 781, DateTimeKind.Local).AddTicks(9373), "tuantv27@gmail.com", "b02c55d8-8310-413a-a164-972a49ec3ae7", "TuanTran", 3 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 7 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 10 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 6, 1 },
                    { 6, 6 },
                    { 6, 8 },
                    { 7, 3 },
                    { 7, 9 },
                    { 7, 10 },
                    { 8, 4 },
                    { 8, 6 },
                    { 8, 8 },
                    { 9, 5 },
                    { 9, 7 },
                    { 9, 9 },
                    { 10, 2 },
                    { 10, 5 },
                    { 10, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FAJustBlogUserId",
                table: "Comment",
                column: "FAJustBlogUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_FAJustBlogUserId",
                table: "Post",
                column: "FAJustBlogUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
