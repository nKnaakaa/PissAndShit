using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class DaedalusStormbowStormbowDaedalusStormbow : ModProjectile
{
    private int daedalusStormbowStormbowDaedalusStormbowUT = 30;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Daedalus Stormbow Stormbow Daedalus Stormbow");
    }

    public override void SetDefaults() {
        Projectile.damage = 400;
        Projectile.hostile = false;
        Projectile.friendly = true;
        Projectile.knockBack = 2;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.aiStyle = -1;
        Projectile.penetrate = 1;
        Projectile.width = 62;
        Projectile.height = 30;
        Projectile.tileCollide = true;
    }

    public override void AI() {
        var player = Main.player[Projectile.owner];
        daedalusStormbowStormbowDaedalusStormbowUT--;
        if (daedalusStormbowStormbowDaedalusStormbowUT <= 0) {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Projectile.velocity.Y > 16f) {
                Projectile.velocity.Y = 16f;
            }

            int numberProjectiles = 4 + Main.rand.Next(4);
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

                float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
                float num15 = 9f / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.02f;
                float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, 91, 43 + 13, 2f + 2.25f, Main.myPlayer, 0.0f, Main.rand.Next(5));
                daedalusStormbowStormbowDaedalusStormbowUT = 30;
            }
        }
    }
}