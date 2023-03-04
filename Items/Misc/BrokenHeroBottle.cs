using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class BrokenHeroBottle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Broken Hero Bottle");
        Tooltip.SetDefault("The bottle is broken, what more info do you need");
    }

    public override void SetDefaults() {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.LightPurple;
        Item.width = 20;
        Item.height = 26;
    }
}