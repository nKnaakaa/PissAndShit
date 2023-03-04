using PissAndShit.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Placeables;

public class GrandBrickItem : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Grand Brick");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults() {
        Item.width = 12;
        Item.height = 12;
        Item.maxStack = 999;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.createTile = TileType<GrandBrick>();
        // Set other item.X values here
    }

    public override void AddRecipes() {
        // Recipes here. See Basic Recipe Guide
    }
}