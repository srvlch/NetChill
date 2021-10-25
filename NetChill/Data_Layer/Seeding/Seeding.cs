using NetChill.DAL;
using System;
using System.Data.Entity;

namespace Data_Layer.Seeding
{
    //Seeding
    public class Seeding: DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Users.Add(new User()
            {
                FullName="Admin",
                Email="admin@netchill.com",
                Password="Admin@123",
                IsAdmin=true,
                isRevoked=false,
            });

            context.Movies.Add(new Movie()
            {
                Name = "Black Panther",
                Category = "Sci Fi",
                YearOfRelease = 2019,
                AvailaibilityStarts = new DateTime(2020, 12, 30),
                Description = "Black Panther Description - Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero eligendi vel perferendis consequatur maxime sunt magni enim! Corrupti vero praesentium, officiis laudantium eaque repellendus recusandae voluptates fuga cum at? Minima eveniet, harum, soluta, voluptatibus in consequuntur odio nesciunt error atque dolorum rerum. Praesentium, voluptas molestiae beatae quasi quibusdam consequuntur impedit.",
                IsFeatured=true,
                ContentPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fmovies%2F1611654935240?alt=media&token=d975d6b0-c7c9-47b0-bae6-13fd99ea7ce2",
                Views = 98,
                PosterPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fimages%2F1611733660983?alt=media&token=daf12e91-9552-40e6-b57e-0f3d4b30cc51",

            });

            context.Movies.Add(new Movie()
            {
                Name = "Avenger's Endgame",
                Category = "Sci Fi",
                YearOfRelease = 2019,
                AvailaibilityStarts = new DateTime(2020, 12, 30),
                Description = "Avenger's Endgame Description - Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero eligendi vel perferendis consequatur maxime sunt magni enim! Corrupti vero praesentium, officiis laudantium eaque repellendus recusandae voluptates fuga cum at? Minima eveniet, harum, soluta, voluptatibus in consequuntur odio nesciunt error atque dolorum rerum. Praesentium, voluptas molestiae beatae quasi quibusdam consequuntur impedit.",
                IsFeatured = true,
                ContentPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fmovies%2F1611654935240?alt=media&token=d975d6b0-c7c9-47b0-bae6-13fd99ea7ce2",
                PosterPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fimages%2F1611734757914?alt=media&token=b1e03a2b-56b7-4726-944b-d656d9104cb0",
                Views = 198
            });
            context.Movies.Add(new Movie()
            {
                Name = "kaagaz",
                Category = "Drama",
                YearOfRelease = 2021,
                AvailaibilityStarts = new DateTime(2021,01, 01),
                Description = "kaagaz Description - Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero eligendi vel perferendis consequatur maxime sunt magni enim! Corrupti vero praesentium, officiis laudantium eaque repellendus recusandae voluptates fuga cum at? Minima eveniet, harum, soluta, voluptatibus in consequuntur odio nesciunt error atque dolorum rerum. Praesentium, voluptas molestiae beatae quasi quibusdam consequuntur impedit.",
                IsFeatured = false,
                ContentPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fmovies%2F1611654935240?alt=media&token=d975d6b0-c7c9-47b0-bae6-13fd99ea7ce2",
                PosterPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fimages%2F1611734890813?alt=media&token=54e412c1-6122-47ea-a81d-0f3c0680b08f",
                Views = 176
            });
            context.Movies.Add(new Movie()
            {
                Name = "The Nun",
                Category = "Horror",
                YearOfRelease = 2019,
                AvailaibilityStarts = new DateTime(2021, 02, 10),
                Description = "The Nun Description - Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero eligendi vel perferendis consequatur maxime sunt magni enim! Corrupti vero praesentium, officiis laudantium eaque repellendus recusandae voluptates fuga cum at? Minima eveniet, harum, soluta, voluptatibus in consequuntur odio nesciunt error atque dolorum rerum. Praesentium, voluptas molestiae beatae quasi quibusdam consequuntur impedit.",
                IsFeatured = true,
                ContentPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fmovies%2F1611654935240?alt=media&token=d975d6b0-c7c9-47b0-bae6-13fd99ea7ce2",
                PosterPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fimages%2F1611734932973?alt=media&token=c1ff3f86-a20f-4bac-8a9d-9c68d45752ba",
                Views = 0
            });
            context.Movies.Add(new Movie()
            {
                Name = "Jumangi-The Next Level",
                Category = "Comedy",
                YearOfRelease = 2019,
                AvailaibilityStarts = new DateTime(2020, 01, 01),
                Description = "Jumangi-The Next Level Description - Lorem ipsum dolor sit amet consectetur adipisicing elit. Vero eligendi vel perferendis consequatur maxime sunt magni enim! Corrupti vero praesentium, officiis laudantium eaque repellendus recusandae voluptates fuga cum at? Minima eveniet, harum, soluta, voluptatibus in consequuntur odio nesciunt error atque dolorum rerum. Praesentium, voluptas molestiae beatae quasi quibusdam consequuntur impedit.",
                IsFeatured = true,
                ContentPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fmovies%2F1611654935240?alt=media&token=d975d6b0-c7c9-47b0-bae6-13fd99ea7ce2",
                PosterPath = "https://firebasestorage.googleapis.com/v0/b/netchill-ee9ab.appspot.com/o/NetChill%2Fimages%2F1611734989943?alt=media&token=194a5e53-7e46-41c7-81bf-419285153df6",
                Views = 58
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
