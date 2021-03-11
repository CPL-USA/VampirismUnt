using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirismUnt.Serialization;

namespace VampirismUnt
{
    public class Configuration : IRocketPluginConfiguration
    {
        public List<VampirItem> VampirItems;

        public ushort EffectVampirId;

        public void LoadDefaults()
        {
            EffectVampirId = 124;
            VampirItems = new List<VampirItem>
            {
                new VampirItem(363, 10),
                new VampirItem(519, 100),
                new VampirItem(105, 100),
            };
        }
    }
}
