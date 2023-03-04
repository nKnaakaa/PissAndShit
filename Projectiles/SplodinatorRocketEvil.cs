using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class SplodinatorRocketEvil : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("deaths meme kaboom cylinder");
        Main.projFrames[Projectile.type] = 2;
    }

    public override void SetDefaults() {
        Projectile.CloneDefaults(ProjectileID.RocketIII);
        AIType = ProjectileID.RocketIII;
        Projectile.width = 26;
        Projectile.height = 10;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.timeLeft = 600;
        Projectile.tileCollide = false;
        Projectile.penetrate = 1;
    }

    public override bool PreKill(int timeLeft) {
        Projectile.type = ProjectileID.RocketIII;

        return true;
    }

    public override void AI() {
        int num13 = 6;

        if (Projectile.timeLeft <= 3) {
            Projectile.tileCollide = false;
            Projectile.ai[1] = 0f;
            Projectile.alpha = 255;
        }
        else {
            if (Math.Abs(Projectile.velocity.X) >= 8f || Math.Abs(Projectile.velocity.Y) >= 8f) {
                for (int n = 0; n < 2; n++) {
                    float num28 = 0f;
                    float num29 = 0f;

                    if (n == 1) {
                        num28 = Projectile.velocity.X * 0.5f;
                        num29 = Projectile.velocity.Y * 0.5f;
                    }

                    int num30 = Dust.NewDust(
                        new Vector2(Projectile.position.X + 3f + num28, Projectile.position.Y + 3f + num29) - Projectile.velocity * 0.5f,
                        Projectile.width - 8,
                        Projectile.height - 8,
                        num13,
                        0f,
                        0f,
                        100
                    );

                    Main.dust[num30].scale *= 2f + Main.rand.Next(10) * 0.1f;
                    Main.dust[num30].velocity *= 0.2f;
                    Main.dust[num30].noGravity = true;

                    if (Main.dust[num30].type == 152) {
                        Main.dust[num30].scale *= 0.5f;
                        Main.dust[num30].velocity += Projectile.velocity * 0.1f;
                    }
                    else if (Main.dust[num30].type == 35) {
                        Main.dust[num30].scale *= 0.5f;
                        Main.dust[num30].velocity += Projectile.velocity * 0.1f;
                    }
                    else if (Main.dust[num30].type == Dust.dustWater()) {
                        Main.dust[num30].scale *= 0.65f;
                        Main.dust[num30].velocity += Projectile.velocity * 0.1f;
                    }

                    num30 = Dust.NewDust(
                        new Vector2(Projectile.position.X + 3f + num28, Projectile.position.Y + 3f + num29) - Projectile.velocity * 0.5f,
                        Projectile.width - 8,
                        Projectile.height - 8,
                        31,
                        0f,
                        0f,
                        100,
                        default(Color),
                        0.5f
                    );
                    Main.dust[num30].fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                    Main.dust[num30].velocity *= 0.05f;
                }
            }

            if (Math.Abs(Projectile.velocity.X) < 15f && Math.Abs(Projectile.velocity.Y) < 15f) {
                Projectile.velocity *= 1.1f;
            }

            int num33 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100);

            Main.dust[num33].scale = 0.1f + Main.rand.Next(5) * 0.1f;
            Main.dust[num33].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
            Main.dust[num33].noGravity = true;
            Main.dust[num33].position = Projectile.Center + new Vector2(0f, -Projectile.height / 2).RotatedBy(Projectile.rotation) * 1.1f;

            int num34 = 6;

            var dust8 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, num34, 0f, 0f, 100);

            dust8.scale = 1f + Main.rand.Next(5) * 0.1f;
            dust8.noGravity = true;
            dust8.position = Projectile.Center + new Vector2(0f, -Projectile.height / 2 - 6).RotatedBy(Projectile.rotation) * 1.1f;
        }

        Projectile.ai[0] += 1f;

        if (Projectile.velocity != Vector2.Zero) {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }

        float num165 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
        float num166 = Projectile.localAI[0];

        if (num166 == 0f) {
            Projectile.localAI[0] = num165;
        }
    }

    public override bool OnTileCollide(Vector2 oldVelocity) {
        Projectile.penetrate--;

        if (Projectile.penetrate <= 0) {
            Projectile.Kill();
        }

        return false;
    }

    public override void Kill(int timeLeft) {
        Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
    }
}