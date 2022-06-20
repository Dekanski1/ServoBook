using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ContactBook.Services
{
    internal class ContactJson
    {
        string Path = @"..\..\Storage\Contacts.json";
        public List<Contact> c = new List<Contact>();
        public void SerializeListToJsonFile(List<Contact> contacts)
        {
            List<Contact> listTojson = contacts;
            

            string json = JsonConvert.SerializeObject(listTojson);

            File.WriteAllText(Path, json);

        }
        public void DeserializeListToJsonFile()
        {

            string json = File.ReadAllText(Path);
           c = JsonConvert.DeserializeObject<List<Contact>>(json);
            
        }




    }
}
