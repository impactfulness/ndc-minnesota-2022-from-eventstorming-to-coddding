using Newtonsoft.Json;

namespace CinemaAllocations.SystemTests.StubMovieScreening;

public static class JsonFile
{
    public static T ReadFromJsonFile<T>(string filePath) where T : new()
    {
        TextReader reader = new StreamReader(filePath);
        try
        {
            var fileContents = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(fileContents);
        }
        finally
        {
            reader.Close();
        }
    }
}