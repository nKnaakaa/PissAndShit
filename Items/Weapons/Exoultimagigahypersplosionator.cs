using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class Exoultimagigahypersplosionator : ModItem
{
    private int splodinatorFired;
    private int splodinatorOffset = -1;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Exoultimagigahypersplosionator");
        Tooltip.SetDefault("A weapon so ridiculously overpowered it could kill death himself\n'Better stock up on rockets'");
    }

    public override void SetDefaults() {
        Item.width = 66;
        Item.height = 78;
        Item.rare = ItemRarityID.Expert;
        Item.damage = 1250000;
        Item.crit = 1000;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.UseSound = SoundID.Item11;
        Item.noMelee = true;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Ranged;
        Item.scale = 1;
        Item.expert = true;
        Item.useAmmo = AmmoID.Rocket;
        Item.shoot = ModContent.ProjectileType<SplosionatorRocket>();
        Item.shootSpeed = 5f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        var muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 29f;
        if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
            position += muzzleOffset;
        }

        type = ModContent.ProjectileType<SplosionatorRocket>();

        if (splodinatorFired > 2) {
            splodinatorFired = 0;
        }

        if (splodinatorFired == 0) {
            splodinatorOffset = -4;
        }
        else if (splodinatorFired == 1) {
            splodinatorOffset = 0;
        }
        else if (splodinatorFired == 2) {
            splodinatorOffset = 4;
        }

        if (player.direction == 1) {
            // how to choose position:
            // on X: if looking right, -22 X
            // on Y: -4 Y

            Projectile.NewProjectile(source, position.X - 22, position.Y - 4 + splodinatorOffset, speedX, speedY, type, damage, knockBack, player.whoAmI); //front
            Projectile.NewProjectile(source, position.X - 3 - splodinatorOffset, position.Y - 28, speedX - 5, speedY - 5, type, damage, knockBack, player.whoAmI); //top
            Projectile.NewProjectile(source, position.X - 6, position.Y + 9, speedX - 1f, speedY - 5f, type, damage, knockBack, player.whoAmI); //top angled
            Projectile.NewProjectile(source, position.X + 6, position.Y - 9, speedX + 10f, speedY + 15f, type, damage, knockBack, player.whoAmI); //bottom angled
            Projectile.NewProjectile(source, position.X - 3, position.Y + 9, speedX - 5f, speedY + 5f, type, damage, knockBack, player.whoAmI); //bottom
        }
        else {
            Projectile.NewProjectile(source, position.X, position.Y - 4 - splodinatorOffset, speedX, speedY, type, damage, knockBack, player.whoAmI); //front
            Projectile.NewProjectile(source, position.X + 19 + splodinatorOffset, position.Y - 28, speedX + 5, speedY - 5, type, damage, knockBack, player.whoAmI); //top
            Projectile.NewProjectile(source, position.X - 2, position.Y + 9, speedX + 1f, speedY + 5f, type, damage, knockBack, player.whoAmI); //top angled
            Projectile.NewProjectile(source, position.X + 2, position.Y - 9, speedX - 10f, speedY - 15f, type, damage, knockBack, player.whoAmI); //bottom angled
            Projectile.NewProjectile(source, position.X + 19, position.Y + 13, speedX + 5f, speedY + 5f, type, damage, knockBack, player.whoAmI); //bottom
        }

        splodinatorFired++;

        return false; // return false because we don't want tmodloader to shoot projectile
    }

    public override Vector2? HoldoutOffset() {
        return new Vector2(-22, -4);
    }
}