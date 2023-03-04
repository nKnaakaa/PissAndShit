using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons;

public class StonePickaxe : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Stone destruction tool");
        Tooltip.SetDefault("Made of stone");
    }

    public override void SetDefaults() {
        Item.width = 28;
        Item.height = 28;
        Item.rare = ItemRarityID.Green;
        Item.damage = 10;
        Item.crit = 4;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.pick = 50;
        Item.axe = 75;
        Item.hammer = 75;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<StoneBar>(), 25);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}