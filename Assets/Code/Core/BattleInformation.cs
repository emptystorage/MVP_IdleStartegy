using System;
using Code.Core.Common;

namespace Code.Core
{
    public sealed class BattleInformation : IDisposable
    {
        public BattleInformation(int startResourcesCount)
        {
            ResourcesValue = new ReactValue<int>(startResourcesCount);
        }

        public ReactValue<int> ResourcesValue { get; }


        public void Dispose()
        {
            ResourcesValue.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}