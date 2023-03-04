using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Buffs;

public class Soaped : ModBuff
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Soaped");
        Description.SetDefault("You are covered in soap");
        Main.debuff[Type] = true;
        Main.pvpBuff[Type] = false;
        Main.buffNoSave[Type] = true;

        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<PaSPlayer>().soaped = true;
    }
}