using FACL_Locker_Room_API.Models;
using Newtonsoft.Json;

namespace FACL_Locker_Room_API.Utils
{
    public static class Routines
    {
        public static object ReadFile(string fileName)
        {
          var readString =  File.ReadAllText(fileName);
          var JsonObject = JsonConvert.DeserializeObject<CreateAccountDto>(readString);
          return JsonObject;
        }

        public static void WriteFile(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(fileName, jsonString);    
        }


    }
}
