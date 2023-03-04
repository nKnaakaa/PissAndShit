using System;
using Microsoft.Xna.Framework;
using PissAndShit.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles;

public class YoungDukeSharknado : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Duke's Sharknado");
        Main.projFrames[Projectile.type] = 6;
    }

    public override void SetDefaults() {
        Projectile.width = 150;
        Projectile.height = 42;
        Projectile.hostile = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.alpha = 255;
        Projectile.timeLeft = 540;
    }

    public override void Kill(int timeLeft) {
        for (int num282 = 0; num282 < 20; num282++) {
            int num283 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 212, Projectile.direction * 2, 0f, 100, default(Color), 1.4f);

            var dust218 = Main.dust[num283];

            dust218.color = Color.LightPink;
            dust218.color = Color.Lerp(dust218.color, Color.White, 0.3f);
            dust218.noGravity = true;
        }
    }

    public override void AI() {
        int num771 = 8;
        int num772 = 8;
        float num773 = 1.5f;
        int num775 = 150;
        int num776 = 42;

        if (Projectile.velocity.X != 0f) {
            Projectile.direction = Projectile.spriteDirection = -Math.Sign(Projectile.velocity.X);
        }

        Projectile.frameCounter++;

        if (Projectile.frameCounter > 2) {
            Projectile.frame++;
            Projectile.frameCounter = 0;
        }

        if (Projectile.frame >= 6) {
            Projectile.frame = 0;
        }

        if (Projectile.localAI[0] == 0f && Main.myPlayer == Projectile.owner) {
            Projectile.localAI[0] = 1f;
            Projectile.position.X += Projectile.width / 2;
            Projectile.position.Y += Projectile.height / 2;
            Projectile.scale = (num771 + num772 - Projectile.ai[1]) * num773 / (num772 + num771);
            Projectile.width = (int)(num775 * Projectile.scale);
            Projectile.height = (int)(num776 * Projectile.scale);
            Projectile.position.X -= Projectile.width / 2;
            Projectile.position.Y -= Projectile.height / 2;
            Projectile.netUpdate = true;
        }

        if (Projectile.ai[1] != -1f) {
            Projectile.scale = (num771 + num772 - Projectile.ai[1]) * num773 / (num772 + num771);
            Projectile.width = (int)(num775 * Projectile.scale);
            Projectile.height = (int)(num776 * Projectile.scale);
        }

        if (!Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height)) {
            Projectile.alpha -= 30;

            if (Projectile.alpha < 60) {
                Projectile.alpha = 60;
            }

            if (Projectile.type == 386 && Projectile.alpha < 100) {
                Projectile.alpha = 100;
            }
        }
        else {
            Projectile.alpha += 30;
            if (Projectile.alpha > 150) {
                Projectile.alpha = 150;
            }
        }

        if (Projectile.ai[0] > 0f) {
            Projectile.ai[0]--;
        }

        if (Projectile.ai[0] == 1f && Projectile.ai[1] > 0f && Projectile.owner == Main.myPlayer) {
            Projectile.netUpdate = true;

            var center = Projectile.Center;

            center.Y -= num776 * Projectile.scale / 2f;

            float num777 = (num771 + num772 - Projectile.ai[1] + 1f) * num773 / (num772 + num771);

            center.Y -= num776 * num777 / 2f;
            center.Y += 2f;

            Projectile.NewProjectile(
                Projectile.GetSource_FromAI(),
                center.X,
                center.Y,
                Projectile.velocity.X,
                Projectile.velocity.Y,
                Projectile.type,
                Projectile.damage,
                Projectile.knockBack,
                Projectile.owner,
                10f,
                Projectile.ai[1] - 1f
            );
            int num778 = 4;

            if (Projectile.type == 386) {
                num778 = 2;
            }

            if ((int)Projectile.ai[1] % num778 == 0 && Projectile.ai[1] != 0f) {
                int num780 = NPC.NewNPC(Projectile.GetSource_FromAI(), (int)center.X, (int)center.Y, NPCType<BabyShark>());

                Main.npc[num780].velocity = Projectile.velocity;
                Main.npc[num780].netUpdate = true;

                if (Projectile.type == 386) {
                    Main.npc[num780].ai[2] = Projectile.width;
                    Main.npc[num780].ai[3] = -1.5f;
                }
            }
        }

        if (Projectile.ai[0] <= 0f) {
            float num781 = (float)Math.PI / 30f;
            float num782 = Projectile.width / 5f;

            if (Projectile.type == 386) {
                num782 *= 2f;
            }

            float num783 = (float)(Math.Cos(num781 * (0f - Projectile.ai[0])) - 0.5) * num782;

            Projectile.position.X -= num783 * -Projectile.direction;
            Projectile.ai[0]--;
            num783 = (float)(Math.Cos(num781 * (0f - Projectile.ai[0])) - 0.5) * num782;
            Projectile.position.X += num783 * -Projectile.direction;
        }
    }
}