using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class ObsidianBottle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Obsidian Bottle");
        Tooltip.SetDefault("Resilient enough to hold lava");
    }

    public override void SetDefaults() {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Green;
        Item.width = 20;
        Item.height = 26;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Obsidian, 3);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}