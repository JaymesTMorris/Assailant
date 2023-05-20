namespace Shared
{
    public class Character  
    {
        public Attributes BaseStats { get; set; }
        public Attributes CurrentStats { get; set; }
        public SkillLoadout Skills { get; set; }
        public EquipmentSet EquipedItems { get; set; }
        public int Score { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
    }
}