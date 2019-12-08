using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using WorkAssistant.Helpers;

namespace WorkAssistant.Models
{
    public class WorkDay
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [JsonProperty(PropertyName = "startTime")]
        public DateTime StartTime { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [JsonProperty(PropertyName = "endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty(PropertyName = "sick")]
        public bool Sick { get; set; }

        [JsonProperty(PropertyName = "school")]
        public bool School { get; set; }

        [JsonProperty(PropertyName = "timeOff")]
        public bool TimeOff { get; set; }

        [JsonProperty(PropertyName = "onCall")]
        public bool OnCall { get; set; }
    }
}
