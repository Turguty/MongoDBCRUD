using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Model
{
    public class Users
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
