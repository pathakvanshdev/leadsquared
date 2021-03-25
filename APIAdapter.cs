namespace leadsquared
{
    public class APIAdapter
    {

        private static APIService _apiService = new APIService();

        private class APIBattleUnit
        {
            public int id { get; set; }
            public string name { get; set; }
            public int hit_points { get; set; }
            public int attack { get; set; }

        }


        private BattleUnit convertAPIToBattleUnit(string APIResponse)
        {
            APIBattleUnit battleUnit;
            battleUnit = System.Text.Json.JsonSerializer.Deserialize<APIBattleUnit>(APIResponse);

            BattleUnit convertedBattleUnit = new BattleUnit();
            convertedBattleUnit.id = battleUnit.id;
            convertedBattleUnit.attack = (battleUnit.attack==0)?-1:battleUnit.attack;
            convertedBattleUnit.hitPoints = (battleUnit.hit_points==0)?-1:battleUnit.hit_points;
            convertedBattleUnit.name = battleUnit.name;
            return convertedBattleUnit;
        }

        public BattleUnit getBattleUnit(int id)
        {
            string APIResponse = _apiService.getBattleUnit(id);
            BattleUnit convertedBattleUnit;
            convertedBattleUnit = convertAPIToBattleUnit(APIResponse);
            return convertedBattleUnit;
        }
    }
}