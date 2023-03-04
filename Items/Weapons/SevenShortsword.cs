using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class SevenShortsword : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Seven Dagger");
        Tooltip.SetDefault("Not all shortswords are bad");
    }

    public override void SetDefaults() {
        Item.width = 40;
        Item.height = 40;

        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.damage = 600;
        Item.knockBack = 2.5f;
        Item.useTime = 1;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Thrust;

        Item.autoReuse = true;
        Item.rare = ItemRarityID.Red;
        Item.shoot = ModContent.ProjectileType<SevenDaggerProj>();
        Item.shootSpeed = 12f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        int spread = 30;
        float spreadMult = 0.1f;
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        for (int i = 0; i < 7; i++) {
            float vX = speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
            float vY = speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;
            Projectile.NewProjectile(source, position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
        }

        return false;
    }
}