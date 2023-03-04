using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs;

public class GasterBlaster : ModNPC
{
    private int frameNum;
    private int frameTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Duke's Trusty Blaster");
        Main.npcFrameCount[NPC.type] = 5;
        NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
    }

    public override void SetDefaults() {
        NPC.height = 60;
        NPC.width = 50;
        NPC.timeLeft = 300;
        NPC.lifeMax = 1;
        NPC.knockBackResist = 1f;
        NPC.HitSound = SoundID.NPCHit3;
        NPC.DeathSound = SoundID.NPCDeath3;
        NPC.noGravity = true;
        NPC.spriteDirection = 0;
        NPC.rotation = 0;
        NPC.dontTakeDamage = true;
    }

    public override void FindFrame(int frameHeight) {
        NPC.spriteDirection = NPC.direction;

        if (frameTimer == 2) {
            frameNum++;
            frameTimer = 0;
        }

        if (frameNum == 5) {
            frameNum = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }

    public override void AI() {
        NPC.ai[2]++;
        if (NPC.ai[2] >= 3) {
            NPC.ai[2] = 0f;
            NPC.netUpdate = true;
            frameTimer++;
        }

        var player = Main.player[NPC.target];
        var center = NPC.Center;
        var Velocity = NPC.velocity;
        if (++NPC.frameCounter >= 5) {
            NPC.frameCounter = 0;
            NPC.frameCounter = ++NPC.frameCounter % Main.npcFrameCount[NPC.type];
        }

        NPC.ai[1] += 1f;
        if (NPC.ai[1] >= 300f) {
            for (int i = 0; i < 20; i++) {
                int KillDust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 212, NPC.direction * 2, 0f, 100, default(Color), 1.4f);
                var DustExample = Main.dust[KillDust];
                DustExample.color = Color.LightPink;
                DustExample.color = Color.Lerp(DustExample.color, Color.White, 0.3f);
                DustExample.noGravity = true;
            }

            NPC.life = 0;
        }

        var vectoridk = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
        float playerX = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vectoridk.X;
        float playerY = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vectoridk.Y;
        if (playerX > 0f) {
            NPC.spriteDirection = player.direction;
            NPC.rotation = (float)Math.Atan2(playerX, -playerY) + 3.14f;
        }

        if (playerX < 0f) {
            NPC.spriteDirection = -player.direction;
            NPC.rotation = (float)Math.Atan2(playerX, -playerY) + -3.14f;
        }

        NPC.ai[0] += 1f;
        if (NPC.ai[0] >= 15f) {
            // Half a second has passed. Reset timer, etc.
            NPC.ai[0] = 0f;
            NPC.netUpdate = true;
            // Do something here, maybe change to a new state.
            //NPC.NewNPC((int)center.X, (int)center.Y, NPCType<NPCs.SoapBubble>());

            if (Main.netMode != NetmodeID.MultiplayerClient) {
                float velocityX = NPC.rotation;
                float velocityY = NPC.rotation;
                var vector3 = Vector2.Normalize(player.Center - center) * (NPC.width + 20) / 2f + center;
                //int bubble = Projectile.NewProjectile(center.X, center.Y, velocityX, -velocityY, ProjectileType<SlightlyLessSoapyBubble>(), 35, 3f, 0, 0f, 0f);
                int bubble = NPC.NewNPC(NPC.GetSource_FromAI(),(int)vector3.X, (int)vector3.Y + 45, NPCType<SoapBubble>());
            }
        }
    }
}