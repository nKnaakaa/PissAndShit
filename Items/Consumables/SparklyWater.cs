using PissAndShit.Items.Misc;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class SparklyWater : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Sparkly Water");
        Tooltip.SetDefault("Somehow tastes sugary");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.UseSound = SoundID.Item3;
        Item.width = 20;
        Item.buffType = BuffID.Confused;
        Item.buffTime = 600;
        Item.height = 26;
        Item.width = 20;
        Item.rare = ItemRarityID.Lime;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<HallowedBottle>());
        recipe.AddIngredient(ItemID.CrystalShard, 5);
        recipe.Register();
    }
}