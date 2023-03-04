using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Buffs;

public class Kamra : ModBuff
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Kamra");
        Description.SetDefault("You feel your sins crawling on your back");
        Main.debuff[Type] = true;
        Main.pvpBuff[Type] = true;
        Main.buffNoSave[Type] = true;

        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<PaSPlayer>().kamra = true;
    }
}