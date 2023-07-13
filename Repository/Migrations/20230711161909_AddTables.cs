using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "BlogAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavGame = table.Column<bool>(type: "bit", nullable: false),
                    ForPlaySation = table.Column<bool>(type: "bit", nullable: false),
                    ForXbox = table.Column<bool>(type: "bit", nullable: false),
                    ForPC = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
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
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavBlog = table.Column<bool>(type: "bit", nullable: false),
                    BlogAuthorId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogAuthors_BlogAuthorId",
                        column: x => x.BlogAuthorId,
                        principalTable: "BlogAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameComments_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameImages_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartGames_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogImages_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "ModifiedAt", "SoftDelete", "Title" },
                values: new object[] { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(790), "At GameLib, we are passionate about video games and committed to bringing you the ultimate gaming experience. Our website is a haven for all gaming enthusiasts, offering a wide selection of the latest and greatest video games across multiple platforms.Discover a vast library of games covering various genres, from action-packed adventures to immersive role-playing worlds. Whether you're a casual gamer or a hardcore enthusiast, GameLib has something for everyone. Dive into captivating storylines, engage in intense multiplayer battles, or challenge yourself with mind-bending puzzles – the possibilities are endless.We pride ourselves on curating a diverse collection of games from renowned publishers and independent developers alike. Our team meticulously selects each title to ensure that only the highest quality and most exciting games make it to your fingertips.", "Ninja Cyberpunk.jpg", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(820), false, "Welcome to GameLib!" });

            migrationBuilder.InsertData(
                table: "Advantages",
                columns: new[] { "Id", "CreatedAt", "Description", "Icon", "ModifiedAt", "SoftDelete", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(950), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo.", "<i class=\"fa-solid fa-users\"></i>", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(950), false, "The Best Community" },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(950), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo.", "<i class=\"fa-solid fa-box\"></i>", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(950), false, "Payment Types" },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(950), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo.", "<i class=\"fa-solid fa-gift\"></i>", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(960), false, "Rewards" }
                });

            migrationBuilder.InsertData(
                table: "BlogAuthors",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), "Aaron Jason Espinoza", false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), "Ethan Reid", false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), "Lily Grant", false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(970), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(980), "Jane Stevenson", false }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "CreatedAt", "Logo", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1090), "Insomniac Games.webp", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1090), "Insomniac Games", false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1090), "343 Industries.png", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1090), "343 Industries", false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Guerrilla Games.png", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Guerrilla Games", false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Santa Monica Studio.png", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Santa Monica Studio", false },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "DICE.png", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "DICE", false },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Turn 10 Studios.png", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1100), "Turn 10 Studios", false }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedAt", "Description", "Developer", "FavGame", "ForPC", "ForPlaySation", "ForXbox", "ModifiedAt", "Name", "Price", "Publisher", "ReleaseDate", "SoftDelete", "Trailer" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1110), "From Santa Monica Studio and creative director Cory Barlog comes a new beginning for one of gaming’s most recognizable icons. Living as a man outside the shadow of the gods, Kratos must adapt to unfamiliar lands, unexpected threats, and a second chance at being a father. Together with his son Atreus, the pair will venture into the brutal Norse wilds and fight to fulfill a deeply personal quest.", "Santa Monica Studio", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1110), "God of War", 19.99m, "Sony Interactive Entertainment", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "K0u_kAWLJOA" },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "Lead your team to victory in both large all-out warfare and close-quarters combat on maps from the world of 2042 and classic Battlefield titles. Find your playstyle in class-based gameplay and take on several experiences comprising elevated versions of Conquest and Breakthrough. Explore Battlefield Portal, a platform where players can discover, create, and share unexpected battles from Battlefield's past and present.", "DICE", false, true, true, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "Battlefield 2042", 59.99m, "EA", new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "WomAGoEh-Ss" },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "In an experience delivered by award winning developer Naughty Dog, UNCHARTED: Legacy of Thieves Collection includes the two critically acclaimed, single player adventures: UNCHARTED 4: A Thief’s End and UNCHARTED: The Lost Legacy. Discover lost history with the charismatic yet complex thieves, Nathan Drake and Chloe Frazer, as they travel the world with a sense of wonder, pursuing extraordinary adventures and lost lore – remastered in stunning detail for the PS5™ console with improved visuals and frame rate.", "Naughty Dog", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "Uncharted: Legacy of Thieves Collection", 49.99m, "Sony Interactive Entertainment", new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "F3Wl-OiZCO4" },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "This isn’t the Spider-Man you’ve met or ever seen before. This is an experienced Peter Parker who’s more masterful at fighting big crime in New York City. At the same time, he’s struggling to balance his chaotic personal life and career while the fate of Marvel’s New York rest upon his shoulders.", "Insomniac Games", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1130), "Marvel's Spider-Man: Remastered", 49.99m, "Sony Interactive Entertainment", new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "utuTNW0Msoc" },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "In a ravaged civilization, where infected and hardened survivors run rampant, Joel, a weary protagonist, is hired to smuggle 14-year-old Ellie out of a military quarantine zone. However, what starts as a small job soon transforms into a brutal cross-country journey.", "Naughty Dog", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "The Last of Us Part 1", 69.99m, "Sony Interactive Entertainment", new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "R2Ebc_OFeug" },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "In the latest adventure in the Marvel’s Spider-Man universe, teenager Miles Morales is adjusting to his new home while following in the footsteps of his mentor, Peter Parker, as a new Spider-Man. But when a fierce power struggle threatens to destroy his new home, the aspiring hero realizes that with great power, there must also come great responsibility. To save all of Marvel’s New York, Miles must take up the mantle of Spider-Man and own it.", "Insomniac Games", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "Marvel's Spider-Man: Miles Morales", 49.99m, "Sony Interactive Entertainment", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "NTunTURbyUU" },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "When all hope is lost and humanity’s fate hangs in the balance, the Master Chief is ready to confront the most ruthless foe he’s ever faced. Step inside the armor of humanity’s greatest hero to experience an epic adventure and explore the massive scale of the Halo ring.", "343 Industries", false, true, false, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1140), "Halo Infinite", 59.99m, "Xbox Game Studios", new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "PyMlV5_HRWk" },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1150), "Forza Motorsport 7 is where Racers, Drifters, Drag Racers, Tuners, and Creators come together in a community devoted to everything automotive. Drive the cars of your dreams, with more than 700 amazing vehicles to choose from including the largest collection of Ferraris, Porsches, and Lamborghinis ever. Challenge yourself across 30 famous destinations and 200 Tracks, where race conditions change every time you return to the Track.", "Turn 10 Studios", false, true, false, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1150), "Forza Motorsport 7", 29.99m, "Microsoft Studios", new DateTime(2017, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "9aAr5blVy0g" },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1150), "From light planes to wide body jets to gliders and helicopters, fly highly detailed and accurate aircraft in the Microsoft Flight Simulator 40th Anniversary Edition. The world is at your fingertips.", "Asobo Studio", false, true, false, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1150), "Microsoft Flight Simulator", 59.99m, "Xbox Game Studios", new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "_QY7qXUZqoo" },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1150), "Don’t miss the game that IGN awarded Best Xbox One Game of 2014, the game that Polygon rated 9 out of 10, and the game that Eurogamer calls “a breath of fresh air.” In Sunset Overdrive, the year is 2027 and Sunset City is under siege. A contaminated energy drink has transformed most of the population into toxic mutants. For many it's the end of the world, but for you it’s a dream come true. Your old boss? Dead. Your boring job? Gone. Transform the open-world into your tactical playground by grinding, vaulting and wall-running across the city while using a devastating, unconventional arsenal. With hyper-agility, unique weapons, and customizable special abilities, Sunset Overdrive rewrites the rules of traditional shooters and delivers an explosive, irreverent, stylish, and totally unique adventure exclusively to Xbox One.", "Insomniac Games", false, true, false, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1160), "Sunset Overdrive", 29.99m, "Microsoft Studios", new DateTime(2014, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "heYWIUIFwbw" },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1160), "The little spirit Ori is no stranger to peril, but when a fateful flight puts the owlet Ku in harm’s way, it will take more than bravery to bring a family back together, heal a broken land, and discover Ori’s true destiny. From the creators of the acclaimed action-platformer Ori and the Blind Forest comes an adventure through a beautiful world filled with friends and foes that come to life in stunning, hand-painted artwork. Set to a fully orchestrated original score, Ori and the Will of the Wisps continues the Moon Studios tradition of tightly crafted platforming action and deeply emotional storytelling.", "Moon Studios", false, true, false, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1160), "Ori and the Will of the Wisps", 29.99m, "Xbox Game Studios", new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "2reK8k8nwBc" },
                    { 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1160), "Ratchet and Clank are back! Help them stop a robotic emperor intent on conquering cross-dimensional worlds, with their own universe next in the firing line. Witness the evolution of the dream team as they’re joined by Rivet – a Lombax resistance fighter from another dimension.", "Insomniac Games", false, true, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1160), "Ratchet and Clank: Rift Apart", 69.99m, "Sony Interactive Entertainment", new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "55PRv_e00wc" },
                    { 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "It’s In Our Blood! Discover a reborn Mortal Kombat Universe created by the Fire God Liu Kang. Mortal Kombat 1 ushers in a new era of the iconic franchise with a new fighting system, game modes, and fatalities!", "NetherRealm Studios", false, true, true, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "Mortal Kombat 1", 69.99m, "Warner Bros. Interactive", new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "jnVTPkCWzcI" },
                    { 14, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "Spider-Men Peter Parker and Miles Morales face the ultimate test of strength inside and outside the mask as they fight to save the city, each other and the ones they love, from the monstrous Venom and the dangerous new symbiote threat. Explore an expansive Marvel’s New York with faster web-swinging and the all-new Web Wings, quickly switching between Peter and Miles to experience different stories, epic new abilities and high-tech gear.", "Insomniac Games", false, false, true, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "Marvel's Spider-Man 2", 69.99m, "Sony Interactive Entertainment", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "qIQ3xNqkVC4" },
                    { 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "Play as Marcus Holloway, a brilliant young hacker living in the birthplace of the tech revolution, the San Francisco Bay Area. Team up with Dedsec, a notorious group of hackers, and expose the hidden dangers of ctOS 2.0, which, in the hands of corrupt corporations, is being wrongfully used to monitor and manipulate citizens on a massive scale.", "Ubisoft", true, true, true, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1170), "Watch Dogs 2", 49.99m, "Ubisoft Entertainment", new DateTime(2016, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "2GIVVsTKTLg" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1620), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1620), "Adventure", false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1620), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), "Action", false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), "Shooter", false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), "RPG", false },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), "Strategy", false },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1630), "Survival", false },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), "Sports", false },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), "Fighting", false },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), "Horror", false },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), "Simulation", false },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1640), "Platformer", false }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1600), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1600), "PlayStation 4", false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), "PlayStation 5", false }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), "Xbox One", false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), "Xbox Series X | S", false },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1610), "PC", false }
                });

            migrationBuilder.InsertData(
                table: "SectionHeaders",
                columns: new[] { "Id", "CreatedAt", "Key", "ModifiedAt", "SoftDelete", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1560), "HomeGames", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1560), false, "Games" },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1560), "HomeRecentBlogs", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1560), false, "Recent Publications" },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), "HomeSubscribe", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), false, "Subscribe to Our Newsletter" },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), "HomeDevelopersBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), false, "Developers BG.jpeg" },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), "HomeAdventages", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), false, "Why Users Trust Us" },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), "GameDetailsAbout", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), false, "About the Game" },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1570), "GameDetailsVisuals", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), false, "Visuals" },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), "BlogLatestBlogs", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), false, "Latest Posts" },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), "Social", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), false, "Follow Us" },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), "ContactBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), false, "Contact BG.jpeg" },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), "RegisterBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1580), false, "Register BG.jpg" },
                    { 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1590), "LoginBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1590), false, "Login BG.jpg" },
                    { 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1590), "ForgotPasswordBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1590), false, "Forgot Password BG.webp" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "Key", "ModifiedAt", "SoftDelete", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1540), "Icon", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1540), false, "icon.png" },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), "Logo", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), false, "logo.svg" },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), "FooterBG", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), false, "Footer BG.jpg" },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), "Copyright", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1550), false, "© 2023 GameLib" }
                });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "Color", "CreatedAt", "Icon", "Link", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, "#6441a5", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1750), "<i class=\"fa-brands fa-twitch\"></i>", "https://www.twitch.tv", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1750), "Twitch", false },
                    { 2, "red", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1750), "<i class=\"fa-brands fa-youtube\"></i>", "https://www.youtube.com", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1750), "YouTube", false },
                    { 3, "#7289da", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1750), "<i class=\"fa-brands fa-discord\"></i>", "https://discord.com", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "Discord", false },
                    { 4, "#00acee", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "<i class=\"fa-brands fa-twitter\"></i>", "https://twitter.com", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "Twitter", false },
                    { 5, "#3b5998", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "<i class=\"fa-brands fa-facebook-f\"></i>", "https://www.facebook.com", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "FaceBook", false },
                    { 6, "#bc2a8d", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "<i class=\"fa-brands fa-instagram\"></i>", "https://www.instagram.com", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1760), "Instagram", false }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogAuthorId", "CreatedAt", "Description", "FavBlog", "Game", "ModifiedAt", "ShortDescription", "SoftDelete", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(990), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!", false, "Marvel's Spider-Man 2", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(990), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.", false, "Marvel's Spider-Man 2 Gameplay Revealed" },
                    { 2, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(990), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!", false, "Phantom Blade Zero", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(990), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.", false, "Phantom Blade Zero: A New Beginning in A Long Journey" },
                    { 3, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!", false, "Assassin's Creed Mirage", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.", false, "First Assassin’s Creed Mirage Gameplay Revealed, Launches October 12" },
                    { 4, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!", true, "Ultros", new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.", false, "Revealing Ultros, A Psychedelic Sci-Fi Side-Scroller Coming to PS5 and PS4 in 2024" }
                });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "Id", "CreatedAt", "GameId", "GenreId", "ModifiedAt", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), 1, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), 1, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), 2, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), 2, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1660), false },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), 3, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), false },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), 3, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), false },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), 3, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), false },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), 4, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), false },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1670), 4, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), false },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), 5, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), false },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), 5, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), false },
                    { 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), 6, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), false },
                    { 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), 6, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), false },
                    { 14, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1680), 7, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), false },
                    { 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), 7, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), false },
                    { 16, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), 8, 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), false },
                    { 17, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), 9, 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), false },
                    { 18, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), 10, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1690), false },
                    { 19, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), 10, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), false },
                    { 20, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), 10, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), false },
                    { 21, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), 11, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), false },
                    { 22, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), 11, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), false },
                    { 23, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1700), 11, 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), false },
                    { 24, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), 11, 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), false },
                    { 25, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), 12, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), false },
                    { 26, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), 12, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), false },
                    { 27, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), 12, 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1710), false },
                    { 28, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), 13, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), false },
                    { 29, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), 13, 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), false },
                    { 30, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), 14, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), false },
                    { 31, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), 14, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1720), false },
                    { 32, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), 15, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), false },
                    { 33, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), 15, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), false },
                    { 34, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), 15, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1730), false }
                });

            migrationBuilder.InsertData(
                table: "GameImages",
                columns: new[] { "Id", "CreatedAt", "GameId", "IsMain", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1290), 1, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1290), "God of War.jpeg", false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), 1, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), "God of War Screenshot 1.jpeg", false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), 1, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), "God of War Screenshot 2.jpeg", false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), 1, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1300), "God of War Screenshot 3.jpeg", false }
                });

            migrationBuilder.InsertData(
                table: "GameImages",
                columns: new[] { "Id", "CreatedAt", "GameId", "IsMain", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), 1, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), "God of War Screenshot 4.jpeg", false },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), 1, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), "God of War Screenshot 5.jpeg", false },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), 2, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), "Battlefield 2042.jpg", false },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), 2, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), "Battlefield 2042 Screenshot 1.jpeg", false },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1310), 2, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), "Battlefield 2042 Screenshot 2.jpeg", false },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), 2, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), "Battlefield 2042 Screenshot 3.jpeg", false },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), 2, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), "Battlefield 2042 Screenshot 4.jpeg", false },
                    { 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), 2, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), "Battlefield 2042 Screenshot 5.jpeg", false },
                    { 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), 3, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1320), "Uncharted Legacy of Thieves Collection.jpg", false },
                    { 14, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), 3, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), "Uncharted Legacy of Thieves Collection Screenshot 1.jpeg", false },
                    { 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), 3, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), "Uncharted Legacy of Thieves Collection Screenshot 2.jpeg", false },
                    { 16, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), 3, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), "Uncharted Legacy of Thieves Collection Screenshot 3.jpeg", false },
                    { 17, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), 3, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), "Uncharted Legacy of Thieves Collection Screenshot 4.jpeg", false },
                    { 18, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), 3, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1330), "Uncharted Legacy of Thieves Collection Screenshot 5.jpeg", false },
                    { 19, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), 4, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), "Marvel's Spider-Man Remastered.jpg", false },
                    { 20, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), 4, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), "Marvel's Spider-Man Remastered Screenshot 1.jpeg", false },
                    { 21, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), 4, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), "Marvel's Spider-Man Remastered Screenshot 2.jpeg", false },
                    { 22, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), 4, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), "Marvel's Spider-Man Remastered Screenshot 3.jpeg", false },
                    { 23, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1340), 4, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), "Marvel's Spider-Man Remastered Screenshot 4.jpeg", false },
                    { 24, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), 4, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), "Marvel's Spider-Man Remastered Screenshot 5.jpeg", false },
                    { 25, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), 5, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), "The Last of Us Part 1.jpg", false },
                    { 26, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), 5, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), "The Last of Us Part 1 Screenshot 1.jpeg", false },
                    { 27, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), 5, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1350), "The Last of Us Part 1 Screenshot 2.jpeg", false },
                    { 28, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), 5, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), "The Last of Us Part 1 Screenshot 3.jpeg", false },
                    { 29, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), 5, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), "The Last of Us Part 1 Screenshot 4.jpeg", false },
                    { 30, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), 5, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), "The Last of Us Part 1 Screenshot 5.jpeg", false },
                    { 31, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), 6, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), "Marvel's Spider-Man Miles Morales.jpeg", false },
                    { 32, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1360), 6, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), "Marvel's Spider-Man Miles Morales Screenshot 1.jpeg", false },
                    { 33, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), 6, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), "Marvel's Spider-Man Miles Morales Screenshot 2.jpeg", false },
                    { 34, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), 6, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), "Marvel's Spider-Man Miles Morales Screenshot 3.jpeg", false },
                    { 35, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), 6, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), "Marvel's Spider-Man Miles Morales Screenshot 4.jpeg", false },
                    { 36, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), 6, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1370), "Marvel's Spider-Man Miles Morales Screenshot 5.jpeg", false },
                    { 37, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), 7, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), "Halo Infinite.png", false },
                    { 38, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), 7, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), "Halo Infinite Screenshot 1.jpeg", false },
                    { 39, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), 7, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), "Halo Infinite Screenshot 2.jpeg", false },
                    { 40, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), 7, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), "Halo Infinite Screenshot 3.png", false },
                    { 41, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1380), 7, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), "Halo Infinite Screenshot 4.png", false },
                    { 42, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), 7, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), "Halo Infinite Screenshot 5.jpeg", false },
                    { 43, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), 8, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), "Forza Motorsport 7.jpg", false },
                    { 44, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), 8, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), "Forza Motorsport 7 Screenshot 1.jpeg", false },
                    { 45, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), 8, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1390), "Forza Motorsport 7 Screenshot 2.jpeg", false },
                    { 46, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), 8, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), "Forza Motorsport 7 Screenshot 3.jpeg", false }
                });

            migrationBuilder.InsertData(
                table: "GameImages",
                columns: new[] { "Id", "CreatedAt", "GameId", "IsMain", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 47, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), 8, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), "Forza Motorsport 7 Screenshot 4.jpeg", false },
                    { 48, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), 8, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), "Forza Motorsport 7 Screenshot 5.jpeg", false },
                    { 49, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), 9, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), "Microsoft Flight Simulator.jpg", false },
                    { 50, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), 9, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1400), "Microsoft Flight Simulator Screenshot 1.jpeg", false },
                    { 51, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), 9, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), "Microsoft Flight Simulator Screenshot 2.jpeg", false },
                    { 52, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), 9, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), "Microsoft Flight Simulator Screenshot 3.jpeg", false },
                    { 53, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), 9, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1410), "Microsoft Flight Simulator Screenshot 4.jpeg", false },
                    { 54, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), 9, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), "Microsoft Flight Simulator Screenshot 5.jpeg", false },
                    { 55, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), 10, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), "Sunset Overdrive.jpg", false },
                    { 56, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), 10, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), "Sunset Overdrive Screenshot 1.jpeg", false },
                    { 57, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), 10, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1430), "Sunset Overdrive Screenshot 2.jpeg", false },
                    { 58, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1440), 10, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1440), "Sunset Overdrive Screenshot 3.jpeg", false },
                    { 59, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1440), 10, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), "Sunset Overdrive Screenshot 4.jpeg", false },
                    { 60, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), 10, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), "Sunset Overdrive Screenshot 5.jpeg", false },
                    { 61, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), 11, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), "Ori and the Will of the Wisps.jpg", false },
                    { 62, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), 11, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), "Ori and the Will of the Wisps Screenshot 1.png", false },
                    { 63, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), 11, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1450), "Ori and the Will of the Wisps Screenshot 2.png", false },
                    { 64, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), 11, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), "Ori and the Will of the Wisps Screenshot 3.jpeg", false },
                    { 65, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), 11, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), "Ori and the Will of the Wisps Screenshot 4.jpeg", false },
                    { 66, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), 11, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), "Ori and the Will of the Wisps Screenshot 5.jpeg", false },
                    { 67, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), 12, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), "Ratchet and Clank Rift Apart.jpg", false },
                    { 68, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), 12, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1460), "Ratchet and Clank Rift Apart Screenshot 1.jpeg", false },
                    { 69, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), 12, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), "Ratchet and Clank Rift Apart Screenshot 2.jpeg", false },
                    { 70, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), 12, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), "Ratchet and Clank Rift Apart Screenshot 3.jpeg", false },
                    { 71, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), 12, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), "Ratchet and Clank Rift Apart Screenshot 4.jpeg", false },
                    { 72, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), 12, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), "Ratchet and Clank Rift Apart Screenshot 5.webp", false },
                    { 73, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), 13, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1470), "Mortal Kombat 1.png", false },
                    { 74, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), 13, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), "Mortal Kombat 1 Screenshot 1.jpeg", false },
                    { 75, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), 13, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), "Mortal Kombat 1 Screenshot 2.jpeg", false },
                    { 76, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), 13, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), "Mortal Kombat 1 Screenshot 3.jpeg", false },
                    { 77, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), 13, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1480), "Mortal Kombat 1 Screenshot 4.jpeg", false },
                    { 78, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), 13, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), "Mortal Kombat 1 Screenshot 5.jpeg", false },
                    { 79, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), 14, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), "Marvel's Spider-Man 2.jpeg", false },
                    { 80, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), 14, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), "Marvel's Spider-Man 2 Screenshot 1.jpg", false },
                    { 81, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), 14, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), "Marvel's Spider-Man 2 Screenshot 2.jpg", false },
                    { 82, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1490), 14, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), "Marvel's Spider-Man 2 Screenshot 3.jpg", false },
                    { 83, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), 14, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), "Marvel's Spider-Man 2 Screenshot 4.jpg", false },
                    { 84, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), 14, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), "Marvel's Spider-Man 2 Screenshot 5.jpg", false },
                    { 85, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), 15, true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), "Watch Dogs 2.png", false },
                    { 86, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), 15, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1500), "Watch Dogs 2 Screenshot 1.webp", false },
                    { 87, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), 15, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), "Watch Dogs 2 Screenshot 2.jpeg", false },
                    { 88, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), 15, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), "Watch Dogs 2 Screenshot 3.jpeg", false }
                });

            migrationBuilder.InsertData(
                table: "GameImages",
                columns: new[] { "Id", "CreatedAt", "GameId", "IsMain", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 89, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), 15, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), "Watch Dogs 2 Screenshot 4.jpeg", false },
                    { 90, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), 15, false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1510), "Watch Dogs 2 Screenshot 5.jpeg", false }
                });

            migrationBuilder.InsertData(
                table: "GamePlatforms",
                columns: new[] { "Id", "CreatedAt", "GameId", "ModifiedAt", "PlatformId", "SoftDelete" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1190), 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1190), 1, false },
                    { 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 5, false },
                    { 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 1, false },
                    { 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 2, false },
                    { 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 3, false },
                    { 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1200), 4, false },
                    { 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 5, false },
                    { 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 2, false },
                    { 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 5, false },
                    { 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1210), 2, false },
                    { 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1220), 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1220), 5, false },
                    { 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1220), 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1220), 2, false },
                    { 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 5, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 5, false },
                    { 14, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 1, false },
                    { 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 2, false },
                    { 16, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 6, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 5, false },
                    { 17, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1230), 3, false },
                    { 18, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 4, false },
                    { 19, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 7, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 5, false },
                    { 20, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 3, false },
                    { 21, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 8, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 5, false },
                    { 22, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1240), 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 4, false },
                    { 23, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 9, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 5, false },
                    { 24, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 3, false },
                    { 25, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 10, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 5, false },
                    { 26, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1250), 3, false },
                    { 27, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 4, false },
                    { 28, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 11, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 5, false },
                    { 29, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 2, false },
                    { 30, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 12, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 5, false },
                    { 31, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1260), 2, false },
                    { 32, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 4, false },
                    { 33, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 13, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 5, false },
                    { 34, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 14, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 2, false },
                    { 35, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 1, false },
                    { 36, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1270), 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1280), 3, false },
                    { 37, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1280), 15, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1280), 5, false }
                });

            migrationBuilder.InsertData(
                table: "BlogImages",
                columns: new[] { "Id", "BlogId", "CreatedAt", "IsMain", "ModifiedAt", "Name", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1010), true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1010), "Marvel's Spider-Man 2.jpg", false },
                    { 2, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), "Marvel's Spider-Man 2 Screenshot 1.jpg", false },
                    { 3, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), "Marvel's Spider-Man 2 Screenshot 2.jpg", false },
                    { 4, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1020), "Marvel's Spider-Man 2 Screenshot 3.jpg", false },
                    { 5, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1030), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1030), "Marvel's Spider-Man 2 Screenshot 4.jpg", false },
                    { 6, 1, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1030), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1030), "Marvel's Spider-Man 2 Screenshot 5.jpg", false },
                    { 7, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), "Phantom Blade Zero.jpg", false },
                    { 8, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), "Phantom Blade Zero Screenshot 1.jpeg", false },
                    { 9, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), "Phantom Blade Zero Screenshot 2.jpeg", false },
                    { 10, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), "Phantom Blade Zero Screenshot 3.jpeg", false },
                    { 11, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1040), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), "Phantom Blade Zero Screenshot 4.webp", false },
                    { 12, 2, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), "Phantom Blade Zero Screenshot 5.jpg", false },
                    { 13, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), "Assassin's Creed Mirage.jpg", false },
                    { 14, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), "Assassin's Creed Mirage Screenshot 1.jpeg", false },
                    { 15, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1050), "Assassin's Creed Mirage Screenshot 2.jpeg", false },
                    { 16, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), "Assassin's Creed Mirage Screenshot 3.jpeg", false },
                    { 17, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), "Assassin's Creed Mirage Screenshot 4.jpeg", false },
                    { 18, 3, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), "Assassin's Creed Mirage Screenshot 5.jpeg", false },
                    { 19, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), true, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), "Ultros.png", false },
                    { 20, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1060), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), "Ultros Screenshot 1.jpeg", false },
                    { 21, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), "Ultros Screenshot 2.jpeg", false },
                    { 22, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), "Ultros Screenshot 3.jpeg", false },
                    { 23, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), "Ultros Screenshot 4.jpeg", false },
                    { 24, 4, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), false, new DateTime(2023, 7, 11, 20, 19, 9, 33, DateTimeKind.Local).AddTicks(1070), "Ultros Screenshot 5.jpeg", false }
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
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_UserId",
                table: "BlogComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogImages",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogAuthorId",
                table: "Blogs",
                column: "BlogAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CartGames_CartId",
                table: "CartGames",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartGames_GameId",
                table: "CartGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameComments_GameId",
                table: "GameComments",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameComments_UserId",
                table: "GameComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GameId",
                table: "GameGenres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreId",
                table: "GameGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_GameId",
                table: "GameImages",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_GameId",
                table: "GamePlatforms",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_PlatformId",
                table: "GamePlatforms",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Advantages");

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
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "BlogImages");

            migrationBuilder.DropTable(
                name: "CartGames");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "GameComments");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GameImages");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "SectionHeaders");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "BlogAuthors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
