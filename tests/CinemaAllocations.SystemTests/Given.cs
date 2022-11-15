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

                RetrieveMovieScreeningFromJson(fordTheaterId);

                return fordTheaterId;
            }
        }

        private static void RetrieveMovieScreeningFromJson(string showId)
        {
            var options = new DbContextOptionsBuilder<CinemaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var cinemaContext = new CinemaContext(options);
            LoadMovieScreeningIfDoesExists(showId, cinemaContext);
        }

        private static void LoadMovieScreeningIfDoesExists(string showId, CinemaContext cinemaContext)
        {
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