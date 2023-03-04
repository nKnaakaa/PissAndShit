using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BulletRainOfSans : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Bullet Hell");
        Tooltip.SetDefault("80% chance to not consume ammo.");
    }

    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 16;
        Item.damage = 325;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 2;
        Item.value = Item.sellPrice(5);
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item40;
        Item.autoReuse = true;
        Item.useAmmo = AmmoID.Bullet;
        Item.shoot = ProjectileID.Bullet;
        Item.shootSpeed = 10f;
        Item.noMelee = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.VortexBeater);
        recipe.AddIngredient(ItemID.SDMG);
        recipe.AddIngredient(ItemID.ChainGun);
        recipe.AddIngredient(ItemID.FragmentVortex, 25);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        int spread = 100;
        float spreadMult = 0.1f;
        for (int i = 0; i < 3; i++) {
            float speedX = velocity.X;
            float speedY = velocity.Y;
            float knockBack = knockback;
            
            float vX = speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
            float vY = speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;
            Projectile.NewProjectile(source, position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
        }

        return false;
    }

    public override bool CanConsumeAmmo(Item ammo, Player player) {
        int rand = Main.rand.Next(1, 6);
        if (rand >= 1 && rand <= 4) {
            return false;
        }

        return true;
    }
}