using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class HallowedBottle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Hallowed Bottle");
        Tooltip.SetDefault("King Arthur's bottle of choice");
    }

    public override void SetDefaults() {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.LightPurple;
        Item.width = 20;
        Item.height = 26;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.HallowedBar, 3);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}