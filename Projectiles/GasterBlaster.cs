using Microsoft.Xna.Framework;
using PissAndShit.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles;

public class GasterBlaster : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Duke's Trusty Blaster");
        Main.projFrames[Projectile.type] = 5;
    }

    public override void SetDefaults() {
        Projectile.height = 60;
        Projectile.width = 50;
        Projectile.hostile = true;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 300;
        Projectile.tileCollide = true;
        Projectile.ignoreWater = true;
    }

    public override void Kill(int timeLeft) {
        for (int i = 0; i < 20; i++) {
            int KillDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 212, Projectile.direction * 2, 0f, 100, default(Color), 1.4f);
            var DustExample = Main.dust[KillDust];

            DustExample.color = Color.LightPink;
            DustExample.color = Color.Lerp(DustExample.color, Color.White, 0.3f);
            DustExample.noGravity = true;
        }
    }

    public override void AI() {
        var center = Projectile.Center;

        if (++Projectile.frameCounter >= 5) {
            Projectile.frameCounter = 0;
            Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
        }

        Projectile.ai[0] += 1f;

        if (Projectile.ai[0] >= 15f) {
            Projectile.ai[0] = 0f;
            Projectile.netUpdate = true;
            // Do something here, maybe change to a new state.
            NPC.NewNPC(Projectile.GetSource_FromAI(), (int)center.X, (int)center.Y, NPCType<SoapBubble>());
        }
    }
}