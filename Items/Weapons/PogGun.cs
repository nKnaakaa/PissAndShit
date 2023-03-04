using PissAndShit.Projectiles;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class PogGun : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Pogket Launcher");
        Tooltip.SetDefault("'Prepare thine buttocks' - Ryan");
    }

    public override void SetDefaults() {
        Item.damage = 5;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 44;
        Item.height = 32;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.UseSound = new SoundStyle("PissAndShit/Sounds/Custom/Pog");
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.value = 23000;
        Item.rare = ItemRarityID.LightPurple;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<PogChamp>();
        Item.shootSpeed = 19f;
    }

    public override void AddRecipes() {
        var shitRecipes = CreateRecipe();
        shitRecipes.AddIngredient(ItemID.DirtBlock, 999);
        shitRecipes.AddIngredient(ItemID.StoneBlock, 999);
        shitRecipes.AddIngredient(ItemID.SandBlock, 999);
        shitRecipes.AddIngredient(ItemID.MudBlock, 999);
        shitRecipes.AddTile(TileID.Painting2X3);
        shitRecipes.Register();
    }
}