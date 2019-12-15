using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        [JsonProperty(PropertyName = "calledIn")]
        public bool CalledIn { get; set; }

        public string FormattedDateAndTime
        {
            get
            {
                var duration = EndTime - StartTime;
                return string.Format("{0}  |  {1} - {2}  |  {3}", StartTime.ToString("dd MMMM"), 
                    StartTime.TimeOfDay.ToString("hh\\:mm"), EndTime.TimeOfDay.ToString("hh\\:mm"),
                    duration.ToString("hh\\:mm"));
            }
        }
    }
}
