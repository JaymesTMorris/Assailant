namespace Shared
{
    public class Character  
    {
        public Attributes Stats { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Equipment> Equipment { get; set; }
        public int Score { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
    }
}