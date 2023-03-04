using PissAndShit.Items.Misc;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class TrueNocturnalOoze : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("True Nocturnal Ooze");
        Tooltip.SetDefault("This is definitely not drinkable!");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.UseSound = SoundID.Item3;
        Item.width = 20;
        Item.buffType = BuffID.Obstructed;
        Item.buffTime = 600;
        Item.height = 36;
        Item.width = 28;
        Item.rare = ItemRarityID.Lime;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<NocturnalOoze>());
        recipe.AddIngredient(ModContent.ItemType<BrokenHeroBottle>());
        recipe.Register();
    }
}