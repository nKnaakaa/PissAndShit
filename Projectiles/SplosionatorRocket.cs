using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class SplosionatorRocket : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Exoultimagigahypersplosionator Rocket");
        Main.projFrames[Projectile.type] = 2;
    }

    public override void SetDefaults() {
        Projectile.CloneDefaults(ProjectileID.RocketIII);
        AIType = ProjectileID.RocketIII;
        Projectile.width = 26;
        Projectile.height = 10;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.timeLeft = 600;
        Projectile.tileCollide = true;
        Projectile.penetrate = 1;
    }

    public override bool PreKill(int timeLeft) {
        Projectile.type = ProjectileID.RocketIII;

        return true;
    }

    public override void AI() {
        int num13 = 6;

        if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
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

        // end rocket code

        float num1652 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
        float num1662 = Projectile.localAI[0];

        if (num1662 == 0f) {
            Projectile.localAI[0] = num1652;
            num1662 = num1652;
        }

        /*if (projectile.alpha > 0) projectile.alpha -= 25;
        if (projectile.alpha < 0) projectile.alpha = 0;*/
        float num167 = Projectile.position.X;
        float num168 = Projectile.position.Y;
        float num169 = 300f;
        bool flag4 = false;
        int num170 = 0;

        if (Projectile.ai[1] == 0f) {
            for (int num171 = 0; num171 < 200; num171++) {
                if (!Main.npc[num171].CanBeChasedBy(Projectile) || (Projectile.ai[1] != 0f && Projectile.ai[1] != num171 + 1)) {
                    continue;
                }

                float num172 = Main.npc[num171].position.X + Main.npc[num171].width / 2f;
                float num173 = Main.npc[num171].position.Y + Main.npc[num171].height / 2f;
                float num174 = Math.Abs(Projectile.position.X + Projectile.width / 2f - num172) + Math.Abs(Projectile.position.Y + Projectile.height / 2f - num173);

                if (!(num174 < num169) ||
                    !Collision.CanHit(
                        new Vector2(Projectile.position.X + Projectile.width / 2f, Projectile.position.Y + Projectile.height / 2f),
                        1,
                        1,
                        Main.npc[num171].position,
                        Main.npc[num171].width,
                        Main.npc[num171].height
                    )) {
                    continue;
                }

                num169 = num174;
                num167 = num172;
                num168 = num173;
                flag4 = true;
                num170 = num171;
            }

            if (flag4) {
                Projectile.ai[1] = num170 + 1;
            }

            flag4 = false;
        }

        if (Projectile.ai[1] > 0f) {
            int num175 = (int)(Projectile.ai[1] - 1f);

            if (Main.npc[num175].active && Main.npc[num175].CanBeChasedBy(Projectile, true) && !Main.npc[num175].dontTakeDamage) {
                float num176 = Main.npc[num175].position.X + Main.npc[num175].width / 2;
                float num177 = Main.npc[num175].position.Y + Main.npc[num175].height / 2;
                float num178 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num176) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num177);

                if (num178 < 1000f) {
                    flag4 = true;
                    num167 = Main.npc[num175].position.X + Main.npc[num175].width / 2;
                    num168 = Main.npc[num175].position.Y + Main.npc[num175].height / 2;
                }
            }
            else {
                Projectile.ai[1] = 0f;
            }
        }

        if (!Projectile.friendly) {
            flag4 = false;
        }

        if (flag4) {
            float num179 = num1662;
            var vector19 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            float num180 = num167 - vector19.X;
            float num181 = num168 - vector19.Y;
            float num182 = (float)Math.Sqrt(num180 * num180 + num181 * num181);

            num182 = num179 / num182;
            num180 *= num182;
            num181 *= num182;

            int num183 = 8;

            Projectile.velocity.X = (Projectile.velocity.X * (num183 - 1) + num180) / num183;
            Projectile.velocity.Y = (Projectile.velocity.Y * (num183 - 1) + num181) / num183;
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