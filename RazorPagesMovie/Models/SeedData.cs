#define Rating

#if Rating

#region snippet_1 

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using System;

using System.Linq;



namespace RazorPagesMovie.Models

{

    public static class SeedData

    {

        public static void Initialize(IServiceProvider serviceProvider)

        {

            using (var context = new RazorPagesMovieContext(

                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))

            {

                // Look for any movies.

                if (context.ReportList.Any())

                {

                    return;   // DB has been seeded

                }



                #region snippet1

                context.ReportList.AddRange(

                    new ShowReport
                    {

                        Title = "When Harry Met Sally",

                        ReleaseDate = DateTime.Parse("1989-2-12"),

                        Type = "Romantic Comedy",

                        Price = 7.99M,

                        Rating = "R"

                    },

                #endregion



                    new ShowReport

                    {

                        Title = "Ghostbusters ",

                        ReleaseDate = DateTime.Parse("1984-3-13"),

                        Type = "Comedy",

                        Price = 8.99M,

                        Rating = "G"

                    },



                    new ShowReport

                    {

                        Title = "Ghostbusters 2",

                        ReleaseDate = DateTime.Parse("1986-2-23"),

                        Type = "Comedy",

                        Price = 9.99M,

                        Rating = "G"

                    },



                    new ShowReport

                    {

                        Title = "Rio Bravo",

                        ReleaseDate = DateTime.Parse("1959-4-15"),

                        Type = "Western",

                        Price = 3.99M,

                        Rating = "NA"

                    }

                );

                context.SaveChanges();

            }

        }

    }

}

#endregion

#endif