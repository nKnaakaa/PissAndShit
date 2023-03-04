using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons;

public class BiggerSword : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Bigger Sword");
        Tooltip.SetDefault("L a r g e r");
    }

    public override void SetDefaults() {
        Item.width = 150;
        Item.height = 150;
        Item.rare = ItemRarityID.LightPurple;
        Item.damage = 75;
        Item.crit = 50;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.NPCHit41;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.scale = 8;
        Item.knockBack = 100000000000000;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<BigSword>());
        recipe.AddIngredient(ItemID.BrokenHeroSword);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}