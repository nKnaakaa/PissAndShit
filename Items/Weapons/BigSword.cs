using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons;

public class BigSword : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Big Sword");
        Tooltip.SetDefault("L a r g e");
    }

    public override void SetDefaults() {
        Item.width = 150;
        Item.height = 150;
        Item.rare = ItemRarityID.Green;
        Item.damage = 10;
        Item.crit = 25;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.NPCHit41;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.scale = 5;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<BigChunk>(), 15);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}