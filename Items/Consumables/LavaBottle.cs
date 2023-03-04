using PissAndShit.Items.Misc;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class LavaBottle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Bottled Lava");
        Tooltip.SetDefault("It burns the tongue");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.UseSound = SoundID.Item3;
        Item.width = 20;
        Item.buffType = BuffID.Burning;
        Item.buffTime = 1800;
        Item.height = 26;
        Item.width = 20;
        Item.rare = ItemRarityID.Green;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<ObsidianBottle>());
        recipe.Register();
    }
}