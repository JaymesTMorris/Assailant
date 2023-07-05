namespace Shared
{
    public interface ICharacter
    {
        EquipmentSet EquipedItems { get; set; }
        int Experience { get; set; }
        int Level { get; set; }
        string Name { get; set; }
        int Rank { get; set; }
        int Score { get; set; }
        SkillLoadout Skills { get; set; }
        Attributes.Attributes Stats { get; set; }
    }
}