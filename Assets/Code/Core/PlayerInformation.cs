using System.Collections.Generic;
using Code.Core.Common;
using Code.GameData;

namespace Code.Core
{
    public sealed class PlayerInformation
    {
        public PlayerInformation(UnitData[] unitDatas)
        {
            UnitData = unitDatas;
        }

        public IReadOnlyList<UnitData> UnitData { get; }//TODO rework to graf by show chance

        public ReactValue<int> Coin { get; } = new();

        public void LoadPlayerData()
        {
            //TODO unlock player unit and add in panel in canvas
            Coin.Value = 100;
        }

        public void SavePlayerData()
        {
            //TODO save player data 
        }
    }
}
