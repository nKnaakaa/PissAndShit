using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class TerraWater : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Terra water");
        Tooltip.SetDefault("1 of the 4 terra potion materials, this can't be good for you");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.UseSound = SoundID.Item3;
        Item.width = 24;
        Item.buffType = BuffID.Stoned;
        Item.buffTime = 1800;
        Item.height = 38;
        Item.width = 20;
        Item.rare = ItemRarityID.Lime;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<TrueNocturnalOoze>());
        recipe.AddIngredient(ItemType<TrueSparklyWater>());
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}