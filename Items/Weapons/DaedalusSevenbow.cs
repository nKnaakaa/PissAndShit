using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class DaedalusSevenbow : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Not a Daedelus Stormbow nockoff.");
    }

    public override void SetDefaults() {
        Item.Size = new Vector2(16, 27);
        Item.damage = 900;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 17;
        Item.useAnimation = 17;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 2.3f;
        Item.value = Item.sellPrice(gold: 15);
        Item.rare = ItemRarityID.Red;
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.useAmmo = AmmoID.Arrow;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 11f;
        Item.noMelee = true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        int numberProjectiles = 20 + Main.rand.Next(5);
        for (int index = 0; index < numberProjectiles; ++index) {
            var vector2_1 = new Vector2(
                (float)(player.position.X + player.width * 0.5 + Main.rand.Next(201) * -player.direction + (Main.mouseX + (double)Main.screenPosition.X - player.position.X)),
                (float)(player.position.Y + player.height * 0.5 - 600.0)
            );
            vector2_1.X = (float)((vector2_1.X + (double)player.Center.X) / 2.0) + Main.rand.Next(-200, 201);
            vector2_1.Y -= 100 * index;
            float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
            float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
            if (num13 < 0.0) {
                num13 *= -1f;
            }

            if (num13 < 20.0) {
                num13 = 20f;
            }
            float speedX = velocity.X;
            float speedY = velocity.Y;
            float knockBack = knockback;
            float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
            float num15 = Item.shootSpeed / num14;
            float num16 = num12 * num15;
            float num17 = num13 * num15;
            float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.02f;
            float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
            Projectile.NewProjectile(source, vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, Main.rand.Next(5));
        }

        return false;
    }

    public override bool CanConsumeAmmo(Item ammo, Player player) {
        return !Main.rand.NextBool(3);
    }
}