using PissAndShit.Items.Misc;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class TrueSparklyWater : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("True Sparkly Water");
        Tooltip.SetDefault("Sweet and sour");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.UseSound = SoundID.Item3;
        Item.width = 20;
        Item.buffType = BuffID.VortexDebuff;
        Item.buffTime = 600;
        Item.height = 36;
        Item.width = 28;
        Item.rare = ItemRarityID.Lime;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<SparklyWater>());
        recipe.AddIngredient(ItemType<BrokenHeroBottle>());
        recipe.Register();
    }
}