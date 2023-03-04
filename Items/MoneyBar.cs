using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items;

public class MoneyBar : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Money Bar");
        Tooltip.SetDefault("Cost big money");
    }

    public override void SetDefaults() {
        Item.rare = ItemRarityID.Pink;
        Item.width = 30;
        Item.height = 24;
        Item.maxStack = 1;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.Register();
    }
}