using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Head)]
public class ExitiumHead : ModItem
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();
        DisplayName.SetDefault("Exitium's Head");
        Tooltip.SetDefault("Great for impersonating Funni Mod devs!");
    }

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 18;
        Item.rare = ItemRarityID.Cyan;
        Item.vanity = true;
    }

    public override void UpdateVanity(Player player) {
        player.armorEffectDrawShadow = true;
        player.armorEffectDrawShadowSubtle = true;
        player.armorEffectDrawShadowLokis = true;
        player.armorEffectDrawShadowBasilisk = true;
        player.armorEffectDrawShadowEOCShield = true;
    }
}