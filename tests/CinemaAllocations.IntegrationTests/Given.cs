using System.Reflection;
using System.Runtime.InteropServices;
using CinemaAllocations.Adapters.DataPersistence;
using CinemaAllocations.IntegrationTests.StubMovieScreening;
using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.IntegrationTests;

internal static class Given
{
    internal static class The
    {
        internal static string FordTheaterId => "1";

        internal static MovieScreenings FordTheater =>
            RetrieveMovieScreeningsFromJson(FordTheaterId);

        internal static string DockStreetId => "3";

        internal static MovieScreenings DockStreet =>
            RetrieveMovieScreeningsFromJson(DockStreetId);

        internal static string MadisonTheatherId => "5";

        internal static MovieScreenings MadisonTheater =>
            RetrieveMovieScreeningsFromJson(MadisonTheatherId);

        internal static string O3AuditoriumId => "2";

        internal static MovieScreenings O3Auditorium =>
            RetrieveMovieScreeningsFromJson(O3AuditoriumId);

        private static MovieScreenings RetrieveMovieScreeningsFromJson(string showId)
        {
            var options = new DbContextOptionsBuilder<MovieScreeningsContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var cinemaContext = new MovieScreeningsContext(options);

            AddMovieScreeningIfDoesExists(showId, cinemaContext);

            return new MovieScreenings(cinemaContext);
        }

        private static void AddMovieScreeningIfDoesExists(string showId, MovieScreeningsContext cinemaContext)
        {
            var directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}\\StubMovieScreening\\Stubs\\MovieScreenings\\";

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

            if (directoryName != null && directoryName.StartsWith(@"file:\"))
            {
                directoryName = directoryName.Substring(6);
            }

            if (directoryName != null && directoryName.StartsWith(@"file:/"))
            {
                directoryName = directoryName.Substring(5);
            }

            return directoryName ?? string.Empty;
        }
    }
}