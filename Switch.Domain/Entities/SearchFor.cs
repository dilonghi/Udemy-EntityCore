using Switch.Domain.Core.Entities;
using Switch.Domain.Enums;

namespace Switch.Domain.Entities
{
    public class SearchFor
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public bool NotSpecified { get { return Id == (int)ESearchFor.NotSpecified; } }
        public bool Date { get { return Id == (int)ESearchFor.Date; } }
        public bool Friendship { get { return Id == (int)ESearchFor.Friendship; } }
        public bool RelationShip { get { return Id == (int)ESearchFor.RelationShip; } }
    }
}
