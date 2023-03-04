using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items;

public class MoneyShoe : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Money Shoe");
        Tooltip.SetDefault("Mmm yes shiny on shoe");
    }

    public override void SetDefaults() {
        Item.rare = ItemRarityID.Pink;
        Item.width = 12;
        Item.height = 12;
        Item.maxStack = 1;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.AddIngredient(ItemType<MoneyBar>(), 10);
        recipe.Register();
    }
}