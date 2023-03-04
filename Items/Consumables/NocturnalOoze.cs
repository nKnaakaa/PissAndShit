using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class NocturnalOoze : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Nocturnal Ooze");
        Tooltip.SetDefault("Dark and foul smelling");
    }

    public override void SetDefaults() {
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.EatFood;

        Item.UseSound = SoundID.Item3;
        Item.width = 20;
        Item.buffType = BuffID.Blackout;
        Item.buffTime = 300;
        Item.height = 26;
        Item.width = 20;
        Item.rare = ItemRarityID.Pink;
        Item.maxStack = 30;
        Item.consumable = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.BottledWater);
        recipe.AddIngredient(ItemID.BottledHoney);
        recipe.AddIngredient(ItemType<LavaBottle>());
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}