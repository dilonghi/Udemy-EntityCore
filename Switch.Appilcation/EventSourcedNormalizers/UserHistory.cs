using System;
using System.Collections.Generic;
using System.Linq;
using Switch.Domain.Core.Events;
using Newtonsoft.Json;

namespace Switch.Appilcation.EventSourcedNormalizers
{
    public class UserHistory
    {
        public static IList<UserHistoryData> HistoryData { get; set; }

        public static IList<UserHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<UserHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<UserHistoryData>();
            var last = new UserHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new UserHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    FirstName = string.IsNullOrWhiteSpace(change.FirstName) || change.FirstName == last.FirstName
                        ? ""
                        : change.FirstName,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    Birthdate = string.IsNullOrWhiteSpace(change.Birthdate) || change.Birthdate == last.Birthdate
                        ? ""
                        : change.Birthdate.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new UserHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Birthdate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.FirstName = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Birthdate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.FirstName = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
