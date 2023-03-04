using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

internal class TestStaff : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Test Staff");
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;

        Item.damage = 0;
        Item.knockBack = 2.5f;
        Item.useTime = 60;
        Item.useAnimation = 60;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.noMelee = true;
        Item.autoReuse = true;
        Item.rare = ItemRarityID.Red;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        for (int i = 0; i < 50; i++) {
            var position = player.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 50 * i)) * 30;
            var dust = Dust.NewDustPerfect(position, DustID.PurpleCrystalShard);
            dust.noGravity = true;
            dust.velocity = Vector2.Normalize(dust.position - player.Center) * 4;
            dust.noLight = false;
            dust.fadeIn = 1f;
        }

        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        for (int i = 0; i < 25; i++) {
            float speedX = velocity.X;
            float speedY = velocity.Y;
            float knockBack = knockback;
            Projectile.NewProjectile(
                source,
                new Vector2(Main.screenPosition.X + Main.screenPosition.X / 2, Main.screenPosition.Y - 10),
                new Vector2(speedX, speedY),
                ProjectileID.Meteor1,
                damage,
                (int)knockBack,
                player.whoAmI
            );
        }

        return false;
    }
}