using System;
using System.Diagnostics.Metrics;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
	public class AppDbContext: IdentityDbContext<AppUser>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogAuthor> BlogAuthors { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SectionHeader> SectionHeaders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GameComment> GameComments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartGame> CartGames { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<About>().HasQueryFilter(a => !a.SoftDelete);
            modelBuilder.Entity<Advantage>().HasQueryFilter(a => !a.SoftDelete);
            modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.SoftDelete);
            modelBuilder.Entity<BlogComment>().HasQueryFilter(bc => !bc.SoftDelete);
            modelBuilder.Entity<BlogAuthor>().HasQueryFilter(ba => !ba.SoftDelete);
            modelBuilder.Entity<BlogImage>().HasQueryFilter(bi => !bi.SoftDelete);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => !c.SoftDelete);
            modelBuilder.Entity<Developer>().HasQueryFilter(d => !d.SoftDelete);
            modelBuilder.Entity<Game>().HasQueryFilter(g => !g.SoftDelete);
            modelBuilder.Entity<GameImage>().HasQueryFilter(gi => !gi.SoftDelete);
            modelBuilder.Entity<Setting>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<SectionHeader>().HasQueryFilter(sh => !sh.SoftDelete);
            modelBuilder.Entity<Social>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Subscribe>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Platform>().HasQueryFilter(p => !p.SoftDelete);
            modelBuilder.Entity<GamePlatform>().HasQueryFilter(gp => !gp.SoftDelete);
            modelBuilder.Entity<Genre>().HasQueryFilter(g => !g.SoftDelete);
            modelBuilder.Entity<GameGenre>().HasQueryFilter(gg => !gg.SoftDelete);
            modelBuilder.Entity<GameComment>().HasQueryFilter(gc => !gc.SoftDelete);
            modelBuilder.Entity<Cart>().HasQueryFilter(c => !c.SoftDelete);
            modelBuilder.Entity<CartGame>().HasQueryFilter(cg => !cg.SoftDelete);



            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    Image = "Ninja Cyberpunk.jpg",
                    Title = "Welcome to GameLib!",
                    Description = "At GameLib, we are passionate about video games and committed to bringing you the ultimate gaming experience. Our website is a haven for all gaming enthusiasts, offering a wide selection of the latest and greatest video games across multiple platforms.Discover a vast library of games covering various genres, from action-packed adventures to immersive role-playing worlds. Whether you're a casual gamer or a hardcore enthusiast, GameLib has something for everyone. Dive into captivating storylines, engage in intense multiplayer battles, or challenge yourself with mind-bending puzzles – the possibilities are endless.We pride ourselves on curating a diverse collection of games from renowned publishers and independent developers alike. Our team meticulously selects each title to ensure that only the highest quality and most exciting games make it to your fingertips."
                }
            );

            modelBuilder.Entity<Advantage>().HasData(
                new Advantage
                {
                    Id = 1,
                    Icon = "<i class=\"fa-solid fa-users\"></i>",
                    Title = "The Best Community",
                    Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo."
                },

                new Advantage
                {
                    Id = 2,
                    Icon = "<i class=\"fa-solid fa-box\"></i>",
                    Title = "Payment Types",
                    Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo."
                },

                new Advantage
                {
                    Id = 3,
                    Icon = "<i class=\"fa-solid fa-gift\"></i>",
                    Title = "Rewards",
                    Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Possimus, nemo."
                }
            );

            modelBuilder.Entity<BlogAuthor>().HasData(
                new BlogAuthor
                {
                    Id = 1,
                    Name = "Aaron Jason Espinoza"
                },

                new BlogAuthor
                {
                    Id = 2,
                    Name = "Ethan Reid"
                },

                new BlogAuthor
                {
                    Id = 3,
                    Name = "Lily Grant"
                },

                new BlogAuthor
                {
                    Id = 4,
                    Name = "Jane Stevenson"
                }
            );

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Marvel's Spider-Man 2 Gameplay Revealed",
                    Game = "Marvel's Spider-Man 2",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!",
                    BlogAuthorId = 1
                },

                new Blog
                {
                    Id = 2,
                    Title = "Phantom Blade Zero: A New Beginning in A Long Journey",
                    Game = "Phantom Blade Zero",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!",
                    BlogAuthorId = 2
                },

                new Blog
                {
                    Id = 3,
                    Title = "First Assassin’s Creed Mirage Gameplay Revealed, Launches October 12",
                    Game = "Assassin's Creed Mirage",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!",
                    BlogAuthorId = 3
                },

                new Blog
                {
                    Id = 4,
                    Title = "Revealing Ultros, A Psychedelic Sci-Fi Side-Scroller Coming to PS5 and PS4 in 2024",
                    Game = "Ultros",
                    ShortDescription = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias.",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor voluptate laboriosam quidem labore ipsa? Magni fugit optio voluptatem doloremque esse! Vel exercitationem facilis hic culpa officia iste ipsum eligendi dolore numquam molestias. Eligendi, quisquam iusto dolor necessitatibus ab sapiente delectus libero nesciunt eum? Dolor consequuntur architecto nemo quaerat minima ea!",
                    BlogAuthorId = 4,
                    FavBlog = true
                }
            );

            modelBuilder.Entity<BlogImage>().HasData(
                new BlogImage
                {
                    Id = 1,
                    Name = "Marvel's Spider-Man 2.jpg",
                    IsMain = true,
                    BlogId = 1
                },

                new BlogImage
                {
                    Id = 2,
                    Name = "Marvel's Spider-Man 2 Screenshot 1.jpg",
                    BlogId = 1
                },

                new BlogImage
                {
                    Id = 3,
                    Name = "Marvel's Spider-Man 2 Screenshot 2.jpg",
                    BlogId = 1
                },

                new BlogImage
                {
                    Id = 4,
                    Name = "Marvel's Spider-Man 2 Screenshot 3.jpg",
                    BlogId = 1
                },

                new BlogImage
                {
                    Id = 5,
                    Name = "Marvel's Spider-Man 2 Screenshot 4.jpg",
                    BlogId = 1
                },

                new BlogImage
                {
                    Id = 6,
                    Name = "Marvel's Spider-Man 2 Screenshot 5.jpg",
                    BlogId = 1
                },



                new BlogImage
                {
                    Id = 7,
                    Name = "Phantom Blade Zero.jpg",
                    IsMain = true,
                    BlogId = 2
                },

                new BlogImage
                {
                    Id = 8,
                    Name = "Phantom Blade Zero Screenshot 1.jpeg",
                    BlogId = 2
                },

                new BlogImage
                {
                    Id = 9,
                    Name = "Phantom Blade Zero Screenshot 2.jpeg",
                    BlogId = 2
                },

                new BlogImage
                {
                    Id = 10,
                    Name = "Phantom Blade Zero Screenshot 3.jpeg",
                    BlogId = 2
                },

                new BlogImage
                {
                    Id = 11,
                    Name = "Phantom Blade Zero Screenshot 4.webp",
                    BlogId = 2
                },

                new BlogImage
                {
                    Id = 12,
                    Name = "Phantom Blade Zero Screenshot 5.jpg",
                    BlogId = 2
                },



                new BlogImage
                {
                    Id = 13,
                    Name = "Assassin's Creed Mirage.jpg",
                    IsMain = true,
                    BlogId = 3
                },

                new BlogImage
                {
                    Id = 14,
                    Name = "Assassin's Creed Mirage Screenshot 1.jpeg",
                    BlogId = 3
                },

                new BlogImage
                {
                    Id = 15,
                    Name = "Assassin's Creed Mirage Screenshot 2.jpeg",
                    BlogId = 3
                },

                new BlogImage
                {
                    Id = 16,
                    Name = "Assassin's Creed Mirage Screenshot 3.jpeg",
                    BlogId = 3
                },

                new BlogImage
                {
                    Id = 17,
                    Name = "Assassin's Creed Mirage Screenshot 4.jpeg",
                    BlogId = 3
                },

                new BlogImage
                {
                    Id = 18,
                    Name = "Assassin's Creed Mirage Screenshot 5.jpeg",
                    BlogId = 3
                },



                new BlogImage
                {
                    Id = 19,
                    Name = "Ultros.png",
                    IsMain = true,
                    BlogId = 4
                },

                new BlogImage
                {
                    Id = 20,
                    Name = "Ultros Screenshot 1.jpeg",
                    BlogId = 4
                },

                new BlogImage
                {
                    Id = 21,
                    Name = "Ultros Screenshot 2.jpeg",
                    BlogId = 4
                },

                new BlogImage
                {
                    Id = 22,
                    Name = "Ultros Screenshot 3.jpeg",
                    BlogId = 4
                },

                new BlogImage
                {
                    Id = 23,
                    Name = "Ultros Screenshot 4.jpeg",
                    BlogId = 4
                },

                new BlogImage
                {
                    Id = 24,
                    Name = "Ultros Screenshot 5.jpeg",
                    BlogId = 4
                }
            );

            modelBuilder.Entity<Developer>().HasData(
                new Developer
                {
                    Id = 1,
                    Name = "Insomniac Games",
                    Logo = "Insomniac Games.webp"
                },

                new Developer
                {
                    Id = 2,
                    Name = "343 Industries",
                    Logo = "343 Industries.png"
                },

                new Developer
                {
                    Id = 3,
                    Name = "Guerrilla Games",
                    Logo = "Guerrilla Games.png"
                },

                new Developer
                {
                    Id = 4,
                    Name = "Santa Monica Studio",
                    Logo = "Santa Monica Studio.png"
                },
                
                new Developer
                {
                    Id = 5,
                    Name = "DICE",
                    Logo = "DICE.png"
                },

                new Developer
                {
                    Id = 6,
                    Name = "Turn 10 Studios",
                    Logo = "Turn 10 Studios.png"
                }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "God of War",
                    Description = "From Santa Monica Studio and creative director Cory Barlog comes a new beginning for one of gaming’s most recognizable icons. Living as a man outside the shadow of the gods, Kratos must adapt to unfamiliar lands, unexpected threats, and a second chance at being a father. Together with his son Atreus, the pair will venture into the brutal Norse wilds and fight to fulfill a deeply personal quest.",
                    Price = 19.99M,
                    Developer = "Santa Monica Studio",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "K0u_kAWLJOA",
                    ReleaseDate = new DateTime(2018, 04, 20)
                },

                new Game
                {
                    Id = 2,
                    Name = "Battlefield 2042",
                    Description = "Lead your team to victory in both large all-out warfare and close-quarters combat on maps from the world of 2042 and classic Battlefield titles. Find your playstyle in class-based gameplay and take on several experiences comprising elevated versions of Conquest and Breakthrough. Explore Battlefield Portal, a platform where players can discover, create, and share unexpected battles from Battlefield's past and present.",
                    Price = 59.99M,
                    Developer = "DICE",
                    Publisher = "EA",
                    ForPlaySation = true,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "WomAGoEh-Ss",
                    ReleaseDate = new DateTime(2021, 11, 19)
                },

                new Game
                {
                    Id = 3,
                    Name = "Uncharted: Legacy of Thieves Collection",
                    Description = "In an experience delivered by award winning developer Naughty Dog, UNCHARTED: Legacy of Thieves Collection includes the two critically acclaimed, single player adventures: UNCHARTED 4: A Thief’s End and UNCHARTED: The Lost Legacy. Discover lost history with the charismatic yet complex thieves, Nathan Drake and Chloe Frazer, as they travel the world with a sense of wonder, pursuing extraordinary adventures and lost lore – remastered in stunning detail for the PS5™ console with improved visuals and frame rate.",
                    Price = 49.99M,
                    Developer = "Naughty Dog",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "F3Wl-OiZCO4",
                    ReleaseDate = new DateTime(2022, 01, 28)
                },

                new Game
                {
                    Id = 4,
                    Name = "Marvel's Spider-Man: Remastered",
                    Description = "This isn’t the Spider-Man you’ve met or ever seen before. This is an experienced Peter Parker who’s more masterful at fighting big crime in New York City. At the same time, he’s struggling to balance his chaotic personal life and career while the fate of Marvel’s New York rest upon his shoulders.",
                    Price = 49.99M,
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "utuTNW0Msoc",
                    ReleaseDate = new DateTime(2023, 05, 04)
                },

                new Game
                {
                    Id = 5,
                    Name = "The Last of Us Part 1",
                    Description = "In a ravaged civilization, where infected and hardened survivors run rampant, Joel, a weary protagonist, is hired to smuggle 14-year-old Ellie out of a military quarantine zone. However, what starts as a small job soon transforms into a brutal cross-country journey.",
                    Price = 69.99M,
                    Developer = "Naughty Dog",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "R2Ebc_OFeug",
                    ReleaseDate = new DateTime(2022, 09, 02)
                },

                new Game
                {
                    Id = 6,
                    Name = "Marvel's Spider-Man: Miles Morales",
                    Description = "In the latest adventure in the Marvel’s Spider-Man universe, teenager Miles Morales is adjusting to his new home while following in the footsteps of his mentor, Peter Parker, as a new Spider-Man. But when a fierce power struggle threatens to destroy his new home, the aspiring hero realizes that with great power, there must also come great responsibility. To save all of Marvel’s New York, Miles must take up the mantle of Spider-Man and own it.",
                    Price = 49.99M,
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "NTunTURbyUU",
                    ReleaseDate = new DateTime(2020, 11, 12)
                },

                new Game
                {
                    Id = 7,
                    Name = "Halo Infinite",
                    Description = "When all hope is lost and humanity’s fate hangs in the balance, the Master Chief is ready to confront the most ruthless foe he’s ever faced. Step inside the armor of humanity’s greatest hero to experience an epic adventure and explore the massive scale of the Halo ring.",
                    Price = 59.99M,
                    Developer = "343 Industries",
                    Publisher = "Xbox Game Studios",
                    ForPlaySation = false,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "PyMlV5_HRWk",
                    ReleaseDate = new DateTime(2021, 11, 15)
                },

                new Game
                {
                    Id = 8,
                    Name = "Forza Motorsport 7",
                    Description = "Forza Motorsport 7 is where Racers, Drifters, Drag Racers, Tuners, and Creators come together in a community devoted to everything automotive. Drive the cars of your dreams, with more than 700 amazing vehicles to choose from including the largest collection of Ferraris, Porsches, and Lamborghinis ever. Challenge yourself across 30 famous destinations and 200 Tracks, where race conditions change every time you return to the Track.",
                    Price = 29.99M,
                    Developer = "Turn 10 Studios",
                    Publisher = "Microsoft Studios",
                    ForPlaySation = false,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "9aAr5blVy0g",
                    ReleaseDate = new DateTime(2017, 10, 03)
                },

                new Game
                {
                    Id = 9,
                    Name = "Microsoft Flight Simulator",
                    Description = "From light planes to wide body jets to gliders and helicopters, fly highly detailed and accurate aircraft in the Microsoft Flight Simulator 40th Anniversary Edition. The world is at your fingertips.",
                    Price = 59.99M,
                    Developer = "Asobo Studio",
                    Publisher = "Xbox Game Studios",
                    ForPlaySation = false,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "_QY7qXUZqoo",
                    ReleaseDate = new DateTime(2022, 11, 11)
                },

                new Game
                {
                    Id = 10,
                    Name = "Sunset Overdrive",
                    Description = "Don’t miss the game that IGN awarded Best Xbox One Game of 2014, the game that Polygon rated 9 out of 10, and the game that Eurogamer calls “a breath of fresh air.” In Sunset Overdrive, the year is 2027 and Sunset City is under siege. A contaminated energy drink has transformed most of the population into toxic mutants. For many it's the end of the world, but for you it’s a dream come true. Your old boss? Dead. Your boring job? Gone. Transform the open-world into your tactical playground by grinding, vaulting and wall-running across the city while using a devastating, unconventional arsenal. With hyper-agility, unique weapons, and customizable special abilities, Sunset Overdrive rewrites the rules of traditional shooters and delivers an explosive, irreverent, stylish, and totally unique adventure exclusively to Xbox One.",
                    Price = 29.99M,
                    Developer = "Insomniac Games",
                    Publisher = "Microsoft Studios",
                    ForPlaySation = false,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "heYWIUIFwbw",
                    ReleaseDate = new DateTime(2014, 10, 28)
                },

                new Game
                {
                    Id = 11,
                    Name = "Ori and the Will of the Wisps",
                    Description = "The little spirit Ori is no stranger to peril, but when a fateful flight puts the owlet Ku in harm’s way, it will take more than bravery to bring a family back together, heal a broken land, and discover Ori’s true destiny. From the creators of the acclaimed action-platformer Ori and the Blind Forest comes an adventure through a beautiful world filled with friends and foes that come to life in stunning, hand-painted artwork. Set to a fully orchestrated original score, Ori and the Will of the Wisps continues the Moon Studios tradition of tightly crafted platforming action and deeply emotional storytelling.",
                    Price = 29.99M,
                    Developer = "Moon Studios",
                    Publisher = "Xbox Game Studios",
                    ForPlaySation = false,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "2reK8k8nwBc",
                    ReleaseDate = new DateTime(2020, 03, 11)
                },

                new Game
                {
                    Id = 12,
                    Name = "Ratchet and Clank: Rift Apart",
                    Description = "Ratchet and Clank are back! Help them stop a robotic emperor intent on conquering cross-dimensional worlds, with their own universe next in the firing line. Witness the evolution of the dream team as they’re joined by Rivet – a Lombax resistance fighter from another dimension.",
                    Price = 69.99M,
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = true,
                    Trailer = "55PRv_e00wc",
                    ReleaseDate = new DateTime(2021, 06, 11)
                },

                new Game
                {
                    Id = 13,
                    Name = "Mortal Kombat 1",
                    Description = "It’s In Our Blood! Discover a reborn Mortal Kombat Universe created by the Fire God Liu Kang. Mortal Kombat 1 ushers in a new era of the iconic franchise with a new fighting system, game modes, and fatalities!",
                    Price = 69.99M,
                    Developer = "NetherRealm Studios",
                    Publisher = "Warner Bros. Interactive",
                    ForPlaySation = true,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "jnVTPkCWzcI",
                    ReleaseDate = new DateTime(2023, 09, 19)
                },

                new Game
                {
                    Id = 14,
                    Name = "Marvel's Spider-Man 2",
                    Description = "Spider-Men Peter Parker and Miles Morales face the ultimate test of strength inside and outside the mask as they fight to save the city, each other and the ones they love, from the monstrous Venom and the dangerous new symbiote threat. Explore an expansive Marvel’s New York with faster web-swinging and the all-new Web Wings, quickly switching between Peter and Miles to experience different stories, epic new abilities and high-tech gear.",
                    Price = 69.99M,
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                    ForPlaySation = true,
                    ForXbox = false,
                    ForPC = false,
                    Trailer = "qIQ3xNqkVC4",
                    ReleaseDate = new DateTime(2023, 10, 20)
                },

                new Game
                {
                    Id = 15,
                    Name = "Watch Dogs 2",
                    Description = "Play as Marcus Holloway, a brilliant young hacker living in the birthplace of the tech revolution, the San Francisco Bay Area. Team up with Dedsec, a notorious group of hackers, and expose the hidden dangers of ctOS 2.0, which, in the hands of corrupt corporations, is being wrongfully used to monitor and manipulate citizens on a massive scale.",
                    Price = 49.99M,
                    Developer = "Ubisoft",
                    Publisher = "Ubisoft Entertainment",
                    ForPlaySation = true,
                    ForXbox = true,
                    ForPC = true,
                    Trailer = "2GIVVsTKTLg",
                    ReleaseDate = new DateTime(2016, 11, 15),
                    FavGame = true
                }
            );

            modelBuilder.Entity<GamePlatform>().HasData(
                new GamePlatform
                {
                    Id = 1,
                    GameId = 1,
                    PlatformId = 1
                },

                new GamePlatform
                {
                    Id = 2,
                    GameId = 1,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 3,
                    GameId = 2,
                    PlatformId = 1
                },

                new GamePlatform
                {
                    Id = 4,
                    GameId = 2,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 5,
                    GameId = 2,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 6,
                    GameId = 2,
                    PlatformId = 4
                },

                new GamePlatform
                {
                    Id = 7,
                    GameId = 2,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 8,
                    GameId = 3,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 9,
                    GameId = 3,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 10,
                    GameId = 4,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 11,
                    GameId = 4,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 12,
                    GameId = 5,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 13,
                    GameId = 5,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 14,
                    GameId = 6,
                    PlatformId = 1
                },

                new GamePlatform
                {
                    Id = 15,
                    GameId = 6,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 16,
                    GameId = 6,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 17,
                    GameId = 7,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 18,
                    GameId = 7,
                    PlatformId = 4
                },

                new GamePlatform
                {
                    Id = 19,
                    GameId = 7,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 20,
                    GameId = 8,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 21,
                    GameId = 8,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 22,
                    GameId = 9,
                    PlatformId = 4
                },

                new GamePlatform
                {
                    Id = 23,
                    GameId = 9,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 24,
                    GameId = 10,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 25,
                    GameId = 10,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 26,
                    GameId = 11,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 27,
                    GameId = 11,
                    PlatformId = 4
                },

                new GamePlatform
                {
                    Id = 28,
                    GameId = 11,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 29,
                    GameId = 12,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 30,
                    GameId = 12,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 31,
                    GameId = 13,
                    PlatformId = 2
                },

                new GamePlatform
                {
                    Id = 32,
                    GameId = 13,
                    PlatformId = 4
                },

                new GamePlatform
                {
                    Id = 33,
                    GameId = 13,
                    PlatformId = 5
                },



                new GamePlatform
                {
                    Id = 34,
                    GameId = 14,
                    PlatformId = 2
                },



                new GamePlatform
                {
                    Id = 35,
                    GameId = 15,
                    PlatformId = 1
                },

                new GamePlatform
                {
                    Id = 36,
                    GameId = 15,
                    PlatformId = 3
                },

                new GamePlatform
                {
                    Id = 37,
                    GameId = 15,
                    PlatformId = 5
                }
            );

            modelBuilder.Entity<GameImage>().HasData(
                new GameImage
                {
                    Id = 1,
                    Name = "God of War.jpeg",
                    IsMain = true,
                    GameId = 1
                },

                new GameImage
                {
                    Id = 2,
                    Name = "God of War Screenshot 1.jpeg",
                    GameId = 1
                },

                new GameImage
                {
                    Id = 3,
                    Name = "God of War Screenshot 2.jpeg",
                    GameId = 1
                },

                new GameImage
                {
                    Id = 4,
                    Name = "God of War Screenshot 3.jpeg",
                    GameId = 1
                },

                new GameImage
                {
                    Id = 5,
                    Name = "God of War Screenshot 4.jpeg",
                    GameId = 1
                },

                new GameImage
                {
                    Id = 6,
                    Name = "God of War Screenshot 5.jpeg",
                    GameId = 1
                },



                new GameImage
                {
                    Id = 7,
                    Name = "Battlefield 2042.jpg",
                    IsMain = true,
                    GameId = 2
                },

                new GameImage
                {
                    Id = 8,
                    Name = "Battlefield 2042 Screenshot 1.jpeg",
                    GameId = 2
                },

                new GameImage
                {
                    Id = 9,
                    Name = "Battlefield 2042 Screenshot 2.jpeg",
                    GameId = 2
                },

                new GameImage
                {
                    Id = 10,
                    Name = "Battlefield 2042 Screenshot 3.jpeg",
                    GameId = 2
                },

                new GameImage
                {
                    Id = 11,
                    Name = "Battlefield 2042 Screenshot 4.jpeg",
                    GameId = 2
                },

                new GameImage
                {
                    Id = 12,
                    Name = "Battlefield 2042 Screenshot 5.jpeg",
                    GameId = 2
                },



                new GameImage
                {
                    Id = 13,
                    Name = "Uncharted Legacy of Thieves Collection.jpg",
                    IsMain = true,
                    GameId = 3
                },

                new GameImage
                {
                    Id = 14,
                    Name = "Uncharted Legacy of Thieves Collection Screenshot 1.jpeg",
                    GameId = 3
                },

                new GameImage
                {
                    Id = 15,
                    Name = "Uncharted Legacy of Thieves Collection Screenshot 2.jpeg",
                    GameId = 3
                },

                new GameImage
                {
                    Id = 16,
                    Name = "Uncharted Legacy of Thieves Collection Screenshot 3.jpeg",
                    GameId = 3
                },

                new GameImage
                {
                    Id = 17,
                    Name = "Uncharted Legacy of Thieves Collection Screenshot 4.jpeg",
                    GameId = 3
                },

                new GameImage
                {
                    Id = 18,
                    Name = "Uncharted Legacy of Thieves Collection Screenshot 5.jpeg",
                    GameId = 3
                },



                new GameImage
                {
                    Id = 19,
                    Name = "Marvel's Spider-Man Remastered.jpg",
                    IsMain = true,
                    GameId = 4
                },

                new GameImage
                {
                    Id = 20,
                    Name = "Marvel's Spider-Man Remastered Screenshot 1.jpeg",
                    GameId = 4
                },

                new GameImage
                {
                    Id = 21,
                    Name = "Marvel's Spider-Man Remastered Screenshot 2.jpeg",
                    GameId = 4
                },

                new GameImage
                {
                    Id = 22,
                    Name = "Marvel's Spider-Man Remastered Screenshot 3.jpeg",
                    GameId = 4
                },

                new GameImage
                {
                    Id = 23,
                    Name = "Marvel's Spider-Man Remastered Screenshot 4.jpeg",
                    GameId = 4
                },

                new GameImage
                {
                    Id = 24,
                    Name = "Marvel's Spider-Man Remastered Screenshot 5.jpeg",
                    GameId = 4
                },



                new GameImage
                {
                    Id = 25,
                    Name = "The Last of Us Part 1.jpg",
                    IsMain = true,
                    GameId = 5
                },

                new GameImage
                {
                    Id = 26,
                    Name = "The Last of Us Part 1 Screenshot 1.jpeg",
                    GameId = 5
                },

                new GameImage
                {
                    Id = 27,
                    Name = "The Last of Us Part 1 Screenshot 2.jpeg",
                    GameId = 5
                },

                new GameImage
                {
                    Id = 28,
                    Name = "The Last of Us Part 1 Screenshot 3.jpeg",
                    GameId = 5
                },

                new GameImage
                {
                    Id = 29,
                    Name = "The Last of Us Part 1 Screenshot 4.jpeg",
                    GameId = 5
                },

                new GameImage
                {
                    Id = 30,
                    Name = "The Last of Us Part 1 Screenshot 5.jpeg",
                    GameId = 5
                },



                new GameImage
                {
                    Id = 31,
                    Name = "Marvel's Spider-Man Miles Morales.jpeg",
                    IsMain = true,
                    GameId = 6
                },

                new GameImage
                {
                    Id = 32,
                    Name = "Marvel's Spider-Man Miles Morales Screenshot 1.jpeg",
                    GameId = 6
                },

                new GameImage
                {
                    Id = 33,
                    Name = "Marvel's Spider-Man Miles Morales Screenshot 2.jpeg",
                    GameId = 6
                },

                new GameImage
                {
                    Id = 34,
                    Name = "Marvel's Spider-Man Miles Morales Screenshot 3.jpeg",
                    GameId = 6
                },

                new GameImage
                {
                    Id = 35,
                    Name = "Marvel's Spider-Man Miles Morales Screenshot 4.jpeg",
                    GameId = 6
                },

                new GameImage
                {
                    Id = 36,
                    Name = "Marvel's Spider-Man Miles Morales Screenshot 5.jpeg",
                    GameId = 6
                },



                new GameImage
                {
                    Id = 37,
                    Name = "Halo Infinite.png",
                    IsMain = true,
                    GameId = 7
                },

                new GameImage
                {
                    Id = 38,
                    Name = "Halo Infinite Screenshot 1.jpeg",
                    GameId = 7
                },

                new GameImage
                {
                    Id = 39,
                    Name = "Halo Infinite Screenshot 2.jpeg",
                    GameId = 7
                },

                new GameImage
                {
                    Id = 40,
                    Name = "Halo Infinite Screenshot 3.png",
                    GameId = 7
                },

                new GameImage
                {
                    Id = 41,
                    Name = "Halo Infinite Screenshot 4.png",
                    GameId = 7
                },

                new GameImage
                {
                    Id = 42,
                    Name = "Halo Infinite Screenshot 5.jpeg",
                    GameId = 7
                },



                new GameImage
                {
                    Id = 43,
                    Name = "Forza Motorsport 7.jpg",
                    IsMain = true,
                    GameId = 8
                },

                new GameImage
                {
                    Id = 44,
                    Name = "Forza Motorsport 7 Screenshot 1.jpeg",
                    GameId = 8
                },

                new GameImage
                {
                    Id = 45,
                    Name = "Forza Motorsport 7 Screenshot 2.jpeg",
                    GameId = 8
                },

                new GameImage
                {
                    Id = 46,
                    Name = "Forza Motorsport 7 Screenshot 3.jpeg",
                    GameId = 8
                },

                new GameImage
                {
                    Id = 47,
                    Name = "Forza Motorsport 7 Screenshot 4.jpeg",
                    GameId = 8
                },

                new GameImage
                {
                    Id = 48,
                    Name = "Forza Motorsport 7 Screenshot 5.jpeg",
                    GameId = 8
                },



                new GameImage
                {
                    Id = 49,
                    Name = "Microsoft Flight Simulator.jpg",
                    IsMain = true,
                    GameId = 9
                },

                new GameImage
                {
                    Id = 50,
                    Name = "Microsoft Flight Simulator Screenshot 1.jpeg",
                    GameId = 9
                },

                new GameImage
                {
                    Id = 51,
                    Name = "Microsoft Flight Simulator Screenshot 2.jpeg",
                    GameId = 9
                },

                new GameImage
                {
                    Id = 52,
                    Name = "Microsoft Flight Simulator Screenshot 3.jpeg",
                    GameId = 9
                },

                new GameImage
                {
                    Id = 53,
                    Name = "Microsoft Flight Simulator Screenshot 4.jpeg",
                    GameId = 9
                },

                new GameImage
                {
                    Id = 54,
                    Name = "Microsoft Flight Simulator Screenshot 5.jpeg",
                    GameId = 9
                },



                new GameImage
                {
                    Id = 55,
                    Name = "Sunset Overdrive.jpg",
                    IsMain = true,
                    GameId = 10
                },

                new GameImage
                {
                    Id = 56,
                    Name = "Sunset Overdrive Screenshot 1.jpeg",
                    GameId = 10
                },

                new GameImage
                {
                    Id = 57,
                    Name = "Sunset Overdrive Screenshot 2.jpeg",
                    GameId = 10
                },

                new GameImage
                {
                    Id = 58,
                    Name = "Sunset Overdrive Screenshot 3.jpeg",
                    GameId = 10
                },

                new GameImage
                {
                    Id = 59,
                    Name = "Sunset Overdrive Screenshot 4.jpeg",
                    GameId = 10
                },

                new GameImage
                {
                    Id = 60,
                    Name = "Sunset Overdrive Screenshot 5.jpeg",
                    GameId = 10
                },



                new GameImage
                {
                    Id = 61,
                    Name = "Ori and the Will of the Wisps.jpg",
                    IsMain = true,
                    GameId = 11
                },

                new GameImage
                {
                    Id = 62,
                    Name = "Ori and the Will of the Wisps Screenshot 1.png",
                    GameId = 11
                },

                new GameImage
                {
                    Id = 63,
                    Name = "Ori and the Will of the Wisps Screenshot 2.png",
                    GameId = 11
                },

                new GameImage
                {
                    Id = 64,
                    Name = "Ori and the Will of the Wisps Screenshot 3.jpeg",
                    GameId = 11
                },

                new GameImage
                {
                    Id = 65,
                    Name = "Ori and the Will of the Wisps Screenshot 4.jpeg",
                    GameId = 11
                },

                new GameImage
                {
                    Id = 66,
                    Name = "Ori and the Will of the Wisps Screenshot 5.jpeg",
                    GameId = 11
                },



                new GameImage
                {
                    Id = 67,
                    Name = "Ratchet and Clank Rift Apart.jpg",
                    IsMain = true,
                    GameId = 12
                },

                new GameImage
                {
                    Id = 68,
                    Name = "Ratchet and Clank Rift Apart Screenshot 1.jpeg",
                    GameId = 12
                },

                new GameImage
                {
                    Id = 69,
                    Name = "Ratchet and Clank Rift Apart Screenshot 2.jpeg",
                    GameId = 12
                },

                new GameImage
                {
                    Id = 70,
                    Name = "Ratchet and Clank Rift Apart Screenshot 3.jpeg",
                    GameId = 12
                },

                new GameImage
                {
                    Id = 71,
                    Name = "Ratchet and Clank Rift Apart Screenshot 4.jpeg",
                    GameId = 12
                },

                new GameImage
                {
                    Id = 72,
                    Name = "Ratchet and Clank Rift Apart Screenshot 5.webp",
                    GameId = 12
                },



                new GameImage
                {
                    Id = 73,
                    Name = "Mortal Kombat 1.png",
                    IsMain = true,
                    GameId = 13
                },

                new GameImage
                {
                    Id = 74,
                    Name = "Mortal Kombat 1 Screenshot 1.jpeg",
                    GameId = 13
                },

                new GameImage
                {
                    Id = 75,
                    Name = "Mortal Kombat 1 Screenshot 2.jpeg",
                    GameId = 13
                },

                new GameImage
                {
                    Id = 76,
                    Name = "Mortal Kombat 1 Screenshot 3.jpeg",
                    GameId = 13
                },

                new GameImage
                {
                    Id = 77,
                    Name = "Mortal Kombat 1 Screenshot 4.jpeg",
                    GameId = 13
                },

                new GameImage
                {
                    Id = 78,
                    Name = "Mortal Kombat 1 Screenshot 5.jpeg",
                    GameId = 13
                },



                new GameImage
                {
                    Id = 79,
                    Name = "Marvel's Spider-Man 2.jpeg",
                    IsMain = true,
                    GameId = 14
                },

                new GameImage
                {
                    Id = 80,
                    Name = "Marvel's Spider-Man 2 Screenshot 1.jpg",
                    GameId = 14
                },

                new GameImage
                {
                    Id = 81,
                    Name = "Marvel's Spider-Man 2 Screenshot 2.jpg",
                    GameId = 14
                },

                new GameImage
                {
                    Id = 82,
                    Name = "Marvel's Spider-Man 2 Screenshot 3.jpg",
                    GameId = 14
                },

                new GameImage
                {
                    Id = 83,
                    Name = "Marvel's Spider-Man 2 Screenshot 4.jpg",
                    GameId = 14
                },

                new GameImage
                {
                    Id = 84,
                    Name = "Marvel's Spider-Man 2 Screenshot 5.jpg",
                    GameId = 14
                },



                new GameImage
                {
                    Id = 85,
                    Name = "Watch Dogs 2.png",
                    IsMain = true,
                    GameId = 15
                },

                new GameImage
                {
                    Id = 86,
                    Name = "Watch Dogs 2 Screenshot 1.webp",
                    GameId = 15
                },

                new GameImage
                {
                    Id = 87,
                    Name = "Watch Dogs 2 Screenshot 2.jpeg",
                    GameId = 15
                },

                new GameImage
                {
                    Id = 88,
                    Name = "Watch Dogs 2 Screenshot 3.jpeg",
                    GameId = 15
                },

                new GameImage
                {
                    Id = 89,
                    Name = "Watch Dogs 2 Screenshot 4.jpeg",
                    GameId = 15
                },

                new GameImage
                {
                    Id = 90,
                    Name = "Watch Dogs 2 Screenshot 5.jpeg",
                    GameId = 15
                }
            );

            modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    Id = 1,
                    Key = "Icon",
                    Value = "icon.png"
                },

                new Setting
                {
                    Id = 2,
                    Key = "Logo",
                    Value = "logo.svg"
                },

                new Setting
                {
                    Id = 3,
                    Key = "FooterBG",
                    Value = "Footer BG.jpg"
                },

                new Setting
                {
                    Id = 4,
                    Key = "Copyright",
                    Value = "© 2023 GameLib"
                }
            );

            modelBuilder.Entity<SectionHeader>().HasData(
                new SectionHeader
                {
                    Id = 1,
                    Key = "HomeGames",
                    Value = "Games"
                },

                new SectionHeader
                {
                    Id = 2,
                    Key = "HomeRecentBlogs",
                    Value = "Recent Publications"
                },

                new SectionHeader
                {
                    Id = 3,
                    Key = "HomeSubscribe",
                    Value = "Subscribe to Our Newsletter"
                },

                new SectionHeader
                {
                    Id = 4,
                    Key = "HomeDevelopersBG",
                    Value = "Developers BG.jpeg"
                },

                new SectionHeader
                {
                    Id = 5,
                    Key = "HomeAdventages",
                    Value = "Why Users Trust Us"
                },

                new SectionHeader
                {
                    Id = 6,
                    Key = "GameDetailsAbout",
                    Value = "About the Game"
                },

                new SectionHeader
                {
                    Id = 7,
                    Key = "GameDetailsVisuals",
                    Value = "Visuals"
                },

                new SectionHeader
                {
                    Id = 8,
                    Key = "BlogLatestBlogs",
                    Value = "Latest Posts"
                },

                new SectionHeader
                {
                    Id = 9,
                    Key = "Social",
                    Value = "Follow Us"
                },

                new SectionHeader
                {
                    Id = 10,
                    Key = "ContactBG",
                    Value = "Contact BG.jpeg"
                },

                new SectionHeader
                {
                    Id = 11,
                    Key = "RegisterBG",
                    Value = "Register BG.jpg"
                },

                new SectionHeader
                {
                    Id = 12,
                    Key = "LoginBG",
                    Value = "Login BG.jpg"
                },

                new SectionHeader
                {
                    Id = 13,
                    Key = "ForgotPasswordBG",
                    Value = "Forgot Password BG.webp"
                }
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    Name = "PlayStation 4"
                },

                new Platform
                {
                    Id = 2,
                    Name = "PlayStation 5"
                },

                new Platform
                {
                    Id = 3,
                    Name = "Xbox One"
                },

                new Platform
                {
                    Id = 4,
                    Name = "Xbox Series X | S"
                },

                new Platform
                {
                    Id = 5,
                    Name = "PC"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Adventure"
                },

                new Genre
                {
                    Id = 2,
                    Name = "Action"
                },

                new Genre
                {
                    Id = 3,
                    Name = "Shooter"
                },

                new Genre
                {
                    Id = 4,
                    Name = "RPG"
                },

                new Genre
                {
                    Id = 5,
                    Name = "Strategy"
                },

                new Genre
                {
                    Id = 6,
                    Name = "Survival"
                },

                new Genre
                {
                    Id = 7,
                    Name = "Sports"
                },

                new Genre
                {
                    Id = 8,
                    Name = "Fighting"
                },

                new Genre
                {
                    Id = 9,
                    Name = "Horror"
                },

                new Genre
                {
                    Id = 10,
                    Name = "Simulation"
                },

                new Genre
                {
                    Id = 11,
                    Name = "Platformer"
                }
            );

            modelBuilder.Entity<GameGenre>().HasData(
                new GameGenre
                {
                    Id = 1,
                    GameId = 1,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 2,
                    GameId = 1,
                    GenreId = 2
                },



                new GameGenre
                {
                    Id = 3,
                    GameId = 2,
                    GenreId = 2
                },

                new GameGenre
                {
                    Id = 4,
                    GameId = 2,
                    GenreId = 3
                },



                new GameGenre
                {
                    Id = 5,
                    GameId = 3,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 6,
                    GameId = 3,
                    GenreId = 2
                },

                new GameGenre
                {
                    Id = 7,
                    GameId = 3,
                    GenreId = 3
                },



                new GameGenre
                {
                    Id = 8,
                    GameId = 4,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 9,
                    GameId = 4,
                    GenreId = 2
                },



                new GameGenre
                {
                    Id = 10,
                    GameId = 5,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 11,
                    GameId = 5,
                    GenreId = 2
                },



                new GameGenre
                {
                    Id = 12,
                    GameId = 6,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 13,
                    GameId = 6,
                    GenreId = 2
                },



                new GameGenre
                {
                    Id = 14,
                    GameId = 7,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 15,
                    GameId = 7,
                    GenreId = 3
                },



                new GameGenre
                {
                    Id = 16,
                    GameId = 8,
                    GenreId = 7
                },



                new GameGenre
                {
                    Id = 17,
                    GameId = 9,
                    GenreId = 10
                },



                new GameGenre
                {
                    Id = 18,
                    GameId = 10,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 19,
                    GameId = 10,
                    GenreId = 2
                },

                new GameGenre
                {
                    Id = 20,
                    GameId = 10,
                    GenreId = 3
                },



                new GameGenre
                {
                    Id = 21,
                    GameId = 11,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 22,
                    GameId = 11,
                    GenreId = 3
                },

                new GameGenre
                {
                    Id = 23,
                    GameId = 11,
                    GenreId = 8
                },

                new GameGenre
                {
                    Id = 24,
                    GameId = 11,
                    GenreId = 11
                },



                new GameGenre
                {
                    Id = 25,
                    GameId = 12,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 26,
                    GameId = 12,
                    GenreId = 3
                },

                new GameGenre
                {
                    Id = 27,
                    GameId = 12,
                    GenreId = 11
                },



                new GameGenre
                {
                    Id = 28,
                    GameId = 13,
                    GenreId = 2
                },

                new GameGenre
                {
                    Id = 29,
                    GameId = 13,
                    GenreId = 8
                },



                new GameGenre
                {
                    Id = 30,
                    GameId = 14,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 31,
                    GameId = 14,
                    GenreId = 2
                },



                new GameGenre
                {
                    Id = 32,
                    GameId = 15,
                    GenreId = 1
                },

                new GameGenre
                {
                    Id = 33,
                    GameId = 15,
                    GenreId = 2
                },

                new GameGenre
                {
                    Id = 34,
                    GameId = 15,
                    GenreId = 3
                }
            );

            modelBuilder.Entity<Social>().HasData(
                new Social
                {
                    Id = 1,
                    Icon = "<i class=\"fa-brands fa-twitch\"></i>",
                    Name = "Twitch",
                    Link = "https://www.twitch.tv",
                    Color = "#6441a5"
                },

                new Social
                {
                    Id = 2,
                    Icon = "<i class=\"fa-brands fa-youtube\"></i>",
                    Name = "YouTube",
                    Link = "https://www.youtube.com",
                    Color = "red"
                },

                new Social
                {
                    Id = 3,
                    Icon = "<i class=\"fa-brands fa-discord\"></i>",
                    Name = "Discord",
                    Link = "https://discord.com",
                    Color = "#7289da"
                },

                new Social
                {
                    Id = 4,
                    Icon = "<i class=\"fa-brands fa-twitter\"></i>",
                    Name = "Twitter",
                    Link = "https://twitter.com",
                    Color = "#00acee"
                },

                new Social
                {
                    Id = 5,
                    Icon = "<i class=\"fa-brands fa-facebook-f\"></i>",
                    Name = "FaceBook",
                    Link = "https://www.facebook.com",
                    Color = "#3b5998"
                },

                new Social
                {
                    Id = 6,
                    Icon = "<i class=\"fa-brands fa-instagram\"></i>",
                    Name = "Instagram",
                    Link = "https://www.instagram.com",
                    Color = "#bc2a8d"
                }
            );
        }
    }
}