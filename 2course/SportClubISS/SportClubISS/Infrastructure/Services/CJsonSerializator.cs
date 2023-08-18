using System.IO;
using Newtonsoft.Json;

namespace SportClubISS.Infrastructure.Services;

public class CJsonSerializator
{
    public static CJsonSerializator Instance { get; } = new CJsonSerializator();

    public void Serialize<T>(T model, string path)
    {
        var jsonContent = JsonConvert.SerializeObject(model);

        File.WriteAllText(path, jsonContent);
    }

    public T Deserialize<T>(string path)
    {
        var jsonContent = File.ReadAllText(path);

        if (jsonContent == null || jsonContent == "")
            throw new System.NullReferenceException();

        return JsonConvert.DeserializeObject<T>(jsonContent);
    }
}