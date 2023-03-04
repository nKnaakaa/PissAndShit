using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BottleSword : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Bottle Sword");
        Tooltip.SetDefault("AAAAAAAAAAAAAAAAAAAAAA");
    }

    public override void SetDefaults() {
        Item.damage = 44;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 120;
        Item.height = 120;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 8;
        Item.value = 9200;
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Bottle, 999);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}