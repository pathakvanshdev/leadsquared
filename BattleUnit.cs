namespace leadsquared
{
    public class BattleUnit
    {
        public int id { get; set; }
        public string name { get; set; }
        public int hitPoints { get; set; }
        public int attack { get; set; }

        public bool isSame(BattleUnit battleUnit)
        {
            return (battleUnit.id == this.id);
        }
    }
}