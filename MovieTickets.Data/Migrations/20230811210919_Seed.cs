using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTickets.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Ryan Rodney Reynolds OBC is a Canadian and American actor, film producer, and businessman. He began his career starring in the Canadian teen soap opera Hillside, and had minor roles before landing the lead role on the sitcom Two Guys and a Girl between 1998 and 2001.", "https://pics.filmaffinity.com/ryan_reynolds-279844037918521-nm_large.jpg", "Ryan Reynolds" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Jacob Benjamin Gyllenhaal is an American actor. Born into the Gyllenhaal family, he is the son of director Stephen Gyllenhaal and screenwriter Naomi Foner, and his older sister is actress Maggie Gyllenhaal.", "https://pics.filmaffinity.com/jake_gyllenhaal-173579980188358-nm_large.jpg", "Jake Gyllenhaal" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Rebecca Louisa Ferguson Sundström is a Swedish actress. She began her acting career with the Swedish soap opera Nya tider and went on to star in the slasher film Drowning Ghost.", "https://pics.filmaffinity.com/rebecca_ferguson-273006559554882-nm_200.jpg", "Rebecca Ferguson" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Christian Charles Philip Bale is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards.", "https://pics.filmaffinity.com/christian_bale-146362426279095-nm_large.jpg", "Christian Bale" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Aaron Edward Eckhart is an American actor. Born in Cupertino, California, Eckhart moved to the United Kingdom at an early age. He began his acting career by performing in school plays, before moving to Australia for his high school senior year.", "https://pics.filmaffinity.com/aaron_eckhart-072135910642502-nm_large.jpg", "Aaron Eckhart" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "LogoUrl", "Name" },
                values: new object[] { "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, you can pick you perfect parking spot in the underground car park outside.", "https://www1.lovethatdesign.com/wp-content/uploads/2019/03/Love-that-Design-NOVO-13-1024x623.jpg", "Cinema Sofia" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, you can pick you perfect parking spot in the underground car park outside.", "https://whatson.ae/wp-content/uploads/2019/02/innerNovo-high-res-07.jpg" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, you can pick you perfect parking spot in the underground car park outside.", "https://www1.lovethatdesign.com/wp-content/uploads/2019/03/Love-that-Design-NOVO-04.jpg" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, you can pick you perfect parking spot in the underground car park outside.", "https://img.freepik.com/free-vector/movie-home-curtains-cinema-seats_1419-1853.jpg?w=2000" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "We've got 5 screens of film magic, all screening stunning RealD 3D and perfectly located on the Top floor of the Sofia Mill Superstore.For those who love life behind the wheel, you can pick you perfect parking spot in the underground car park outside.", "https://img.freepik.com/free-vector/movie-home-curtains-cinema-seats_1419-1853.jpg?w=2000" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate" },
                values: new object[] { "As astronauts discover the first evidence of extra-terrestrial life on Mars, they begin realising that the life form is extremely intelligent and hostile.", new DateTime(2023, 8, 22, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8098), "https://pics.filmaffinity.com/Life-707248688-large.jpg", new DateTime(2023, 8, 2, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "Batman/Bruce Wayne (Christian Bale) raises the stakes in his war on crime. With the help of Lieutenant Jim Gordon (Gary Oldman) and District Attorney Harvey Dent (Aaron Eckhart), Batman sets out to dismantle the remaining criminal organizations that plague the city streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as The Joker (Heath Ledger).", new DateTime(2023, 8, 15, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8107), "https://pics.filmaffinity.com/The_Dark_Knight-102763119-large.jpg", new DateTime(2023, 8, 12, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8105), "The Dark Knight" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "Michael Jennings (Ben Affleck) is a high-paid engineer who works on hush-hush computer inventions and technology for shady companies. Later, his memory is wiped clean, so he has no recollection of his work. His so-called friend Rethrick (Aaron Eckhardt) offers him enough money to retire by working on a project at Rethrick's company, Allcom. When Jennings emerges three years later, sans memory, he tries to collect his paycheck. At the bank, he's handed a manila envelope filled with cryptic items he doesn't recognize, and told he voluntarily forfeited his entire paycheck. He also has a stunning girlfriend named Dr. Rachel Porter (Uma Thurman) who is likewise ensnared in the conspiracy. Jennings must somehow piece together the clues he left for himself, and find out why everyone is out to kill him... Adapted from a mind-bending sci-fi thriller novel by Philip K. Dick.", new DateTime(2023, 8, 19, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8114), "https://pics.filmaffinity.com/Paycheck-957568097-large.jpg", new DateTime(2023, 8, 12, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8112), "Paycheck" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "A young CIA agent is tasked with looking after a fugitive in a safe house. But when the safe house is attacked, he finds himself on the run with his charge.", new DateTime(2023, 8, 7, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8120), "https://pics.filmaffinity.com/Safe_House-299293074-large.jpg", new DateTime(2023, 8, 2, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8118), "Safe House" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "When Guy, a bank teller, learns that he is a non-player character in a bloodthirsty, open-world video game, he goes on to become the hero of the story and takes the responsibility of saving the world.", new DateTime(2023, 8, 10, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8125), "https://pics.filmaffinity.com/Free_Guy-297648487-large.jpg", new DateTime(2023, 8, 2, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8123), "Free Guy" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "Father Gabriele Amorth, chief exorcist for the Vatican, battles Satan and innocent-possessing demons. A detailed portrait of a priest who performed more than 100,000 exorcisms in his lifetime.", new DateTime(2023, 9, 1, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8132), "https://pics.filmaffinity.com/The_Pope_s_Exorcist-660382735-large.jpg", new DateTime(2023, 8, 15, 0, 9, 18, 868, DateTimeKind.Local).AddTicks(8130), "The Pope's Exorcist" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Jorge Daniel Espinosa is a Swedish-Chilean film director, screenwriter and film producer from Trångsund, Stockholm. He graduated from the National Film School of Denmark in 2001. He notably directed the Sony's Marvel Universe film Morbius starring Jared Leto and other films including Life, Easy Money, The Boxer, Babylon Disease, Outside Love and Child 44.", "https://pics.filmaffinity.com/daniel_espinosa-161586443111622-nm_large.jpg", "Daniel Espinosa" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Best known for his cerebral, often nonlinear, storytelling, acclaimed writer-director Christopher Nolan was born on July 30, 1970, in London, England. Over the course of 15 years of filmmaking, Nolan has gone from low-budget independent films to working on some of the biggest blockbusters ever made.", "https://pics.filmaffinity.com/christopher_nolan-055100338198118-nm_large.jpg", "Christopher Nolan" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Born in southern China, John Woo grew up in Hong Kong, where he began his film career as an assistant director in 1969, working for Shaw Brothers Studios. He directed his first feature in 1973 and has been a prolific director ever since, working in a wide variety of genres before A Better Tomorrow (1986) established his reputation as a master stylist specializing in ultra-violent gangster films and thrillers, with hugely elaborate action scenes shot with breathtaking panache. After gaining a cult reputation in the US with The Killer (1989), Woo was offered a Hollywood contract. He now works in the US.", "https://pics.filmaffinity.com/john_woo-168005725142890-nm_large.jpg", "John Woo" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Shawn Levy was born on July 23, 1968 in Montreal, Quebec, Canada. He is a producer and director, known for Stranger Things (2016), Real Steel (2011), and the Night at the Museum franchise. He is the founder and principal of 21 Laps Entertainment. He is married to Serena Levy and they have four daughters.", "https://pics.filmaffinity.com/shawn_levy-200697726875313-nm_large.jpg", "Shawn Levy" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Julius Avery is an Australian screenwriter and film director.", "https://pics.filmaffinity.com/julius_avery-142054011329446-nm_large.jpg", "Julius Avery" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Actor", "http://dotnethow.net/images/actors/actor-1.jpeg", "Actor 1" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Actor", "http://dotnethow.net/images/actors/actor-2.jpeg", "Actor 2" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Actor", "http://dotnethow.net/images/actors/actor-3.jpeg", "Actor 3" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Actor", "http://dotnethow.net/images/actors/actor-4.jpeg", "Actor 4" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Actor", "http://dotnethow.net/images/actors/actor-5.jpeg", "Actor 5" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "LogoUrl", "Name" },
                values: new object[] { "This is my first Cinema in Sofia", "http://dotnethow.net/images/cinemas/cinema-1.jpeg", "Cinema Sofiq" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "This is my first Cinema in Plovdiv", "http://dotnethow.net/images/cinemas/cinema-2.jpeg" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "This is my first Cinema in Varna", "http://dotnethow.net/images/cinemas/cinema-3.jpeg" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "This is my first Cinema in Burgas", "http://dotnethow.net/images/cinemas/cinema-4.jpeg" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "LogoUrl" },
                values: new object[] { "This is my first Cinema in Smolyan", "http://dotnethow.net/images/cinemas/cinema-5.jpeg" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate" },
                values: new object[] { "This is the Life movie description", new DateTime(2023, 8, 14, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2026), "http://dotnethow.net/images/movies/movie-3.jpeg", new DateTime(2023, 7, 25, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(1985) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "This is the Shawshank Redemption movie description", new DateTime(2023, 8, 7, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2035), "http://dotnethow.net/images/movies/movie-1.jpeg", new DateTime(2023, 8, 4, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2033), "The Shawshank Redemption" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "This is the Ghost movie description", new DateTime(2023, 8, 11, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2041), "http://dotnethow.net/images/movies/movie-4.jpeg", new DateTime(2023, 8, 4, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2039), "Ghost" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "This is the Race movie description", new DateTime(2023, 7, 30, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2046), "http://dotnethow.net/images/movies/movie-6.jpeg", new DateTime(2023, 7, 25, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2044), "Race" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "This is the Scoob movie description", new DateTime(2023, 8, 2, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2051), "http://dotnethow.net/images/movies/movie-7.jpeg", new DateTime(2023, 7, 25, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2049), "Scoob" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "EndDate", "ImageUrl", "StartDate", "Title" },
                values: new object[] { "This is the Cold Soles movie description", new DateTime(2023, 8, 24, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2058), "http://dotnethow.net/images/movies/movie-8.jpeg", new DateTime(2023, 8, 7, 23, 13, 56, 604, DateTimeKind.Local).AddTicks(2056), "Cold Soles" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the first Producer", "http://dotnethow.net/images/producers/producer-1.jpeg", "Producer 1" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the Second Producer", "http://dotnethow.net/images/producers/producer-2.jpeg", "Producer 2" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the thurd Producer", "http://dotnethow.net/images/producers/producer-3.jpeg", "Producer 3" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the forth Producer", "http://dotnethow.net/images/producers/producer-4.jpeg", "Producer 4" });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "This is the description of the fifth Producer", "http://dotnethow.net/images/producers/producer-5.jpeg", "Producer 5" });
        }
    }
}
