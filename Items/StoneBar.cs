using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items;

public class StoneBar : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Stone bar");
        Tooltip.SetDefault("bar");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 24;
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.StoneBlock, 20);
        recipe.Register();
    }
}