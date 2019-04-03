using Switch.CrossCutting.Shared.Enums;

namespace Switch.Domain.Entities
{
    public class RelationshipStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public bool NotSpecified { get { return Id == (int)ERelationshipStatus.NotSpecified; } }
        public bool Single { get { return Id == (int)ERelationshipStatus.Single; } }
        public bool RelationShip { get { return Id == (int)ERelationshipStatus.RelationShip; } }
        public bool Maried { get { return Id == (int)ERelationshipStatus.Maried; } }

    }
}
