using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items;

public class MoneyShirt : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Money Shirt");
        Tooltip.SetDefault("Mmm yes shiny on shirt");
    }

    public override void SetDefaults() {
        Item.rare = ItemRarityID.Pink;
        Item.width = 18;
        Item.height = 16;
        Item.maxStack = 1;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.AddIngredient(ItemType<MoneyBar>(), 10);
        recipe.Register();
    }
}