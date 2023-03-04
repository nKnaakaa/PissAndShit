using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items;

public class MoneySleeves : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Money Pants");
        Tooltip.SetDefault("Mmm yes shiny on pant");
    }

    public override void SetDefaults() {
        Item.rare = ItemRarityID.Pink;
        Item.width = 30;
        Item.height = 20;
        Item.maxStack = 1;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.AddIngredient(ItemType<MoneyBar>(), 10);
        recipe.Register();
    }
}