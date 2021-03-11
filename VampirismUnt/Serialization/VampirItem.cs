using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VampirismUnt.Serialization
{
    [Serializable]
    public class VampirItem
    {
        [XmlAttribute("ItemId")] public ushort ItemId;

        [XmlAttribute("HealValue")] public byte heal;


        public VampirItem(ushort ItemId, byte heal)
        {
            this.ItemId = ItemId;
            this.heal = heal;
        }

        public VampirItem() { }

    }
}
