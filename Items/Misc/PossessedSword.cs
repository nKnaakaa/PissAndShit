using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class PossessedSword : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Sometimes there's only one way out");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 52;
        Item.maxStack = 1;
        Item.useStyle = ItemUseStyleID.Shoot;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was bad"), 10000, 1);
        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
        recipe.AddIngredient(ItemID.Vertebrae, 5);
        recipe.AddIngredient(ItemID.GoldCoin, 5);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();

        var recipe1 = CreateRecipe();
        recipe1.AddRecipeGroup(RecipeGroupID.IronBar, 10);
        recipe1.AddIngredient(ItemID.RottenChunk, 5);
        recipe1.AddIngredient(ItemID.GoldCoin, 5);
        recipe1.AddTile(TileID.DemonAltar);
        recipe1.Register();
    }
}