using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items;

public class MoneyHatScrap : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Money Hat Scrap");
        Tooltip.SetDefault("Mmm yes shiny on piece of hat");
    }

    public override void SetDefaults() {
        Item.rare = ItemRarityID.Pink;
        Item.width = 18;
        Item.height = 13;
        Item.maxStack = 1;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.AddIngredient(ItemType<MoneyBar>(), 10);
        recipe.Register();
    }
}