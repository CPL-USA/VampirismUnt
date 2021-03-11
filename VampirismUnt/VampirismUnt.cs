using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VampirismUnt.Serialization;
using static Rocket.Unturned.Events.UnturnedPlayerEvents;

namespace VampirismUnt
{
    public class VampirismUnt : RocketPlugin<Configuration>
    {
        public static VampirismUnt Instance;


        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerDeath += PlayerDeath; 
        }



        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= PlayerDeath;
        }


        private void PlayerDeath(UnturnedPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, Steamworks.CSteamID murderer)
        {
            UnturnedPlayer killer = UnturnedPlayer.FromCSteamID(murderer);

            if (killer != null)
            {
                VampirItem result = null;
                foreach (VampirItem item in Configuration.Instance.VampirItems)
                {
                    if (item.ItemId == killer.Player.equipment.itemID)
                    {
                        result = item;
                        break;
                    }
                    
                }

                if (result!=null)
                {
                    killer.Heal(result.heal);
                    EffectManager.sendEffect(Configuration.Instance.EffectVampirId, 32, killer.Position);
                }
            }

        }





    }
}
