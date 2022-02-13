using Newtonsoft.Json;
using System;

namespace MyMessager
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message();
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMessage = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMessage);
        }
    }
}
