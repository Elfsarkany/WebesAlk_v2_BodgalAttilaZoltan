namespace WebesAlk_v2_BodgalAttilaZoltan.Models
{
    public class Character
    {
        public int Id {  get; set; }
        public int Strength {  get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Inteligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public CharacterClasses Class { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public Races Race { get; set; }
        public bool AverageHP { get; set; }
        public int Maxhp { get; set; }
        public int Currenthp { get; set; }
    }
}
