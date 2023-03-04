using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items;

public class BigChunk : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Big Chunk");
        Tooltip.SetDefault("large");
    }

    public override void SetDefaults() {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.LightPurple;
        Item.width = 26;
        Item.height = 28;
        Item.scale = 10;
    }
}