using System;
using Code.Core.Common;

namespace Code.Core
{
    public sealed class BattleInformation : IDisposable
    {
        public BattleInformation(int startResourcesCount)
        {
            ResourcesValue = new RecatValue<int>(startResourcesCount);
        }

        public RecatValue<int> ResourcesValue { get; }


        public void Dispose()
        {
            ResourcesValue.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
