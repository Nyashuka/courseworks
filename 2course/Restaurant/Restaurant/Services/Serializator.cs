using Newtonsoft.Json;
using System.IO;

namespace Restaurant
{
    public class Serializator<T>
    {
        private readonly string _path;

        public Serializator(string path)
        {
            _path = path;   
        }

        public void Serialize(T model)
        {
            var jsonContent = JsonConvert.SerializeObject(model);

            File.WriteAllText(_path, jsonContent);
        }

        public T? Deserialize()
        {
            var jsonContent = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
