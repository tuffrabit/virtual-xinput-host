using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TuFFrabitX360
{
    public class ControllerBindingsStorage
    {
        const string filename = "controller_bindings.json";

        public Dictionary<int, int> load()
        {
            Dictionary<int, int> returnValue;

            if (File.Exists(ControllerBindingsStorage.filename))
            {
                returnValue = (Dictionary<int, int>)JsonConvert.DeserializeObject(File.ReadAllText(ControllerBindingsStorage.filename), typeof(Dictionary<int, int>));
            } else
            {
                returnValue = new Dictionary<int, int>();
            }

            return returnValue;
        }

        public void save(Dictionary<int, int> values)
        {
            File.WriteAllText(ControllerBindingsStorage.filename, JsonConvert.SerializeObject(values));
        }
    }
}
