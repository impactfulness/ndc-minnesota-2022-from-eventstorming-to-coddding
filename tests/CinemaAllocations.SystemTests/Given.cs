using System.Reflection;
using System.Runtime.InteropServices;
using CinemaAllocations.Adapters.DataPersistence;
using CinemaAllocations.SystemTests.StubMovieScreening;
using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.SystemTests;

internal static class Given
{
    internal static class The
    {
        internal static string FordTheaterId
        {
            get
            {
                const string fordTheaterId = "1";

                LoadMovieScreeningFromJson(fordTheaterId);

                return fordTheaterId;
            }
        }

        internal static string DockStreetId
        {
            get
            {
                const string dockStreetId = "3";

                LoadMovieScreeningFromJson(dockStreetId);

                return dockStreetId;
            }
        }

        internal static string MadisonTheaterId
        {
            get
            {
                const string madisonTheaterId = "5";

                LoadMovieScreeningFromJson(madisonTheaterId);

                return madisonTheaterId;
            }
        }

        public static string O3AuditoriumId
        {
            get
            {
                const string o3AuditoriumId = "2";

                LoadMovieScreeningFromJson(o3AuditoriumId);

                return o3AuditoriumId;
            }
        }

        private static void LoadMovieScreeningFromJson(string showId)
        {
            var options = new DbContextOptionsBuilder<MovieScreeningsContext>()
                .UseInMemoryDatabase(databaseName: ApiWebApplicationFactory.DatabaseName)
                .Options;

            using var cinemaContext = new MovieScreeningsContext(options);
            AddMovieScreeningIfDoesExists(showId, cinemaContext);
        }

        private static void AddMovieScreeningIfDoesExists(string showId, MovieScreeningsContext cinemaContext)
        {
            if (cinemaContext.MovieScreenings.Any(x => x.Id.Equals(showId)))
                return;

            var directoryName =
                $"{GetExecutingAssemblyDirectoryFullPath()}\\StubMovieScreening\\Stubs\\MovieScreenings\\";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}/StubMovieScreening/Stubs/MovieScreenings/";
            }

            foreach (var fileFullName in Directory.EnumerateFiles($"{directoryName}"))
            {
                var fileName = Path.GetFileName(fileFullName);
                var eventId = Path.GetFileName(fileName.Split("-")[0]);

                if (eventId != showId) continue;

                var movieScreeningDto = JsonFile.ReadFromJsonFile<MovieScreeningDto>(fileFullName);

                cinemaContext.MovieScreenings.Add(movieScreeningDto.ToDataModel(eventId));
                cinemaContext.SaveChanges();

                break;
            }
        }

        private static string GetExecutingAssemblyDirectoryFullPath()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (directoryName.StartsWith(@"file:\"))
            {
                directoryName = directoryName.Substring(6);
            }

            if (directoryName.StartsWith(@"file:/"))
            {
                directoryName = directoryName.Substring(5);
            }

            return directoryName;
        }
    }
}