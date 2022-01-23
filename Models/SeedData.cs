using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                    new MembershipType()
                    {
                        Id = 1,
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        Name = "Pay as You Go",
                        DiscountRate = 0,
                            
                    },
                    new MembershipType()
                    {
                        Id = 2,
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        Name = "Monthly",
                        DiscountRate = 10,
                            
                    },
                    new MembershipType()
                    {
                        Id = 3,
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        Name = "Quaterly",
                        DiscountRate = 15,
                            
                    },
                    new MembershipType()
                    {
                        Id = 4,
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        Name = "Yearly",
                        DiscountRate = 20,
                            
                    });
                context.SaveChanges();
                
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            Name = "The Red Badge of Courage",
                            AuthorName = "Stephen Crane",
                            GenreId = 1,
                            DateAdded = new DateTime(2021, 11, 11),
                            ReleaseDate = new DateTime(2021, 08, 22),
                            NumberInStock = 12,
                            NumberAvailable = 6
                        },
                        new Book()
                        {
                            Name = "On Earth We're Briefly Gorgeous",
                            AuthorName = "Ocean Vuong",
                            GenreId = 3,
                            DateAdded = new DateTime(2021, 11, 11),
                            ReleaseDate = new DateTime(2021, 08, 22),
                            NumberInStock = 14,
                            NumberAvailable = 2
                        },
                        new Book()
                        {
                            Name = "Look Homeward, Angel",
                            AuthorName = "Thomas Wolfe",
                            GenreId = 4,
                            DateAdded = new DateTime(2021, 11, 11),
                            ReleaseDate = new DateTime(2021, 08, 22),
                            NumberInStock = 19,
                            NumberAvailable = 7
                        },
                        new Book()
                        {
                            Name = "American War",
                            AuthorName = "Omar El Akkad",
                            GenreId = 2,
                            DateAdded = new DateTime(2021, 11, 11),
                            ReleaseDate = new DateTime(2021, 08, 22),
                            NumberInStock = 23,
                            NumberAvailable = 16
                        }
                       
                    );
                    context.SaveChanges();
                }
                
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer()
                        {
                            Name = "Ed Donata",
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 1,
                            Birthdate = new DateTime(1998, 05, 25)
                        },
                        new Customer()
                        {
                            Name = "Gordy Deeann",
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 2,
                            Birthdate = new DateTime(1999, 10, 19)
                        },
                        new Customer()
                        {
                            Name = "Koby Sheridan",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 3,
                            Birthdate = new DateTime(2000, 11, 08)
                        }
                        
                    );
                    context.SaveChanges();
                }

                if (!context.Rentals.Any())
                {
                    var customers = context.Customers.ToList();
                    var books = context.Books.ToList();
                    context.Rentals.AddRange(
                        new Rental()
                        {
                            Customer = customers[0],
                            Book = books[0],
                            DateRented = new DateTime(2021, 12, 21)
                        },
                        new Rental()
                        {
                            Customer = customers[1],
                            Book = books[1],
                            DateRented = new DateTime(2021, 11, 06),
                            DateReturned = new DateTime(2022, 01, 20)
                        }
                    );
                    context.SaveChanges();
                }
                
            }
        }
    }
}