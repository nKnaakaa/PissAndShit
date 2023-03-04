using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles;

public class YoungDukeSharknadoBolt : ModProjectile
{
    public static int maxAI = 2;

    public float[] localAI = new float[maxAI];

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Sharknado Bolt");
        Main.projFrames[Projectile.type] = 3;
        ProjectileID.Sets.MinionShot[Projectile.type] = true;
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults() {
        Projectile.width = 54;
        Projectile.height = 54;
        Projectile.hostile = true;
        Projectile.penetrate = -1;
        Projectile.aiStyle = 65;
        Projectile.alpha = 255;
        Projectile.timeLeft = 300;
    }

    public override void Kill(int timeLeft) {
        SoundEngine.PlaySound(SoundID.NPCDeath19, Projectile.Center);
        int num252 = 36;

        for (int num253 = 0; num253 < num252; num253++) {
            var spinningpoint2 = Vector2.Normalize(Projectile.velocity) * new Vector2(Projectile.width / 2f, Projectile.height) * 0.75f;
            spinningpoint2 = spinningpoint2.RotatedBy((num253 - (num252 / 2 - 1)) * ((float)Math.PI * 2f) / num252) + Projectile.Center;
            var vector6 = spinningpoint2 - Projectile.Center;
            int num254 = Dust.NewDust(spinningpoint2 + vector6, 0, 0, 172, vector6.X * 2f, vector6.Y * 2f, 100, default(Color), 1.4f);

            Main.dust[num254].noGravity = true;
            Main.dust[num254].noLight = true;
            Main.dust[num254].velocity = vector6;
        }

        if (Projectile.owner == Main.myPlayer) {
            if (Projectile.ai[1] < 1f) {
                int num255 = Main.expertMode ? 25 : 40;
                int num256 = Projectile.NewProjectile(
                    Projectile.GetSource_FromAI(),
                    Projectile.Center.X - Projectile.direction * 30,
                    Projectile.Center.Y - 4f,
                    -Projectile.direction * 0.01f,
                    0f,
                    ProjectileType<YoungDukeSharknado>(),
                    num255,
                    4f,
                    Projectile.owner,
                    16f,
                    15f
                );

                Main.projectile[num256].netUpdate = true;
            }
            else {
                int num258 = (int)(Projectile.Center.Y / 16f);
                int num259 = (int)(Projectile.Center.X / 16f);
                int num260 = 100;

                if (num259 < 10) {
                    num259 = 10;
                }

                if (num259 > Main.maxTilesX - 10) {
                    num259 = Main.maxTilesX - 10;
                }

                if (num258 < 10) {
                    num258 = 10;
                }

                if (num258 > Main.maxTilesY - num260 - 10) {
                    num258 = Main.maxTilesY - num260 - 10;
                }

                for (int num261 = num258; num261 < num258 + num260; num261++) {
                    var tile = Main.tile[num259, num261];
                    if (tile.HasTile && (Main.tileSolid[tile.TileType] || tile.LiquidAmount != 0)) {
                        num258 = num261;
                        break;
                    }
                }

                int num262 = Main.expertMode ? 50 : 80;
                int num263 = Projectile.NewProjectile(Projectile.GetSource_FromAI(),num259 * 16 + 8, num258 * 16 - 24, 0f, 0f, ProjectileID.Cthulunado, num262, 4f, Main.myPlayer, 16f, 24f);

                Main.projectile[num263].netUpdate = true;
            }
        }
    }

    public override void AI() {
        if (++Projectile.frameCounter >= 4) {
            Projectile.frameCounter = 0;
            Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
        }

        if (Projectile.ai[1] > 0f) {
            int num784 = (int)Projectile.ai[1] - 1;

            if (num784 < 255) {
                localAI[0]++;
                if (localAI[0] > 10f) {
                    int num786 = 6;
                    for (int num787 = 0; num787 < num786; num787++) {
                        var spinningpoint = Vector2.Normalize(Projectile.velocity) * new Vector2(Projectile.width / 2f, Projectile.height) * 0.75f;

                        spinningpoint = spinningpoint.RotatedBy((num787 - (num786 / 2 - 1)) * Math.PI / (float)num786) + Projectile.Center;

                        var value6 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                        int num788 = Dust.NewDust(spinningpoint + value6, 0, 0, 172, value6.X * 2f, value6.Y * 2f, 100, default(Color), 1.4f);

                        Main.dust[num788].noGravity = true;
                        Main.dust[num788].noLight = true;
                        var dust119 = Main.dust[num788];
                        var dust189 = dust119;

                        dust189.velocity /= 4f;
                        dust119 = Main.dust[num788];
                        dust189 = dust119;
                        dust189.velocity -= Projectile.velocity;
                    }

                    Projectile.alpha -= 5;

                    if (Projectile.alpha < 100) {
                        Projectile.alpha = 100;
                    }

                    Projectile.rotation += Projectile.velocity.X * 0.1f;
                    Projectile.frame = (int)(localAI[0] / 3f) % 3;
                }

                var value7 = Main.player[num784].Center - Projectile.Center;
                float num789 = 4f;

                num789 += localAI[0] / 20f;
                Projectile.velocity = Vector2.Normalize(value7) * num789;

                if (value7.Length() < 50f) {
                    Projectile.Kill();
                }
            }
        }
        else {
            float num790 = (float)Math.PI / 15f;
            float num791 = 4f;
            float num792 = (float)(Math.Cos(num790 * Projectile.ai[0]) - 0.5) * num791;

            Projectile.velocity.Y -= num792;
            Projectile.ai[0]++;

            num792 = (float)(Math.Cos(num790 * Projectile.ai[0]) - 0.5) * num791;

            Projectile.velocity.Y += num792;
            localAI[0]++;

            if (localAI[0] > 10f) {
                Projectile.alpha -= 5;

                if (Projectile.alpha < 100) {
                    Projectile.alpha = 100;
                }

                Projectile.rotation += Projectile.velocity.X * 0.1f;
                Projectile.frame = (int)(localAI[0] / 3f) % 3;
            }
        }

        if (Projectile.wet) {
            Projectile.position.Y -= 16f;
            Projectile.Kill();
        }

        if (Main.rand.NextBool(2)) {
            int num234 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 14);

            Main.dust[num234].velocity.X *= 0.4f;
        }
    }
}