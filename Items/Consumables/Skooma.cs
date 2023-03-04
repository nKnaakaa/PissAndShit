using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class Skooma : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Skooma");
        Tooltip.SetDefault("use at own risk" + "\nApplies the Skooma buff for a short time.");
    }

    public override void SetDefaults() {
        Item.width = 58;
        Item.height = 79;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.useAnimation = 12;
        Item.useTime = 12;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = 30;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.buyPrice(silver: 15);
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        player.AddBuff(ModContent.BuffType<Buffs.Skooma>(), 1080);
        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Mushroom, 2);
        recipe.AddIngredient(ItemID.MudBlock, 5);
        recipe.AddIngredient(ItemID.CopperCoin, 8);
        recipe.AddIngredient(ItemID.Bottle);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}