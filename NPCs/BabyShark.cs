using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class BabyShark : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Sharkron");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults() {
        NPC.noGravity = true;
        NPC.width = 120;
        NPC.height = 24;
        NPC.aiStyle = 71;
        NPC.damage = 20;
        NPC.defense = 20;
        NPC.lifeMax = 20;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.knockBackResist = 0f;
        NPC.alpha = 255;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.75);
        NPC.damage = (int)(NPC.damage * 0.75);
    }

    public override void HitEffect(int hitDirection, double damage) {
        if (NPC.life > 0) {
            for (int num117 = 0; num117 < NPC.damage / (double)NPC.lifeMax * 100.0; num117++) {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f);
            }
        }
        else {
            for (int num118 = 0; num118 < 75; num118++) {
                int num119 = Dust.NewDust(NPC.Center - Vector2.One * 25f, 50, 50, 5, 2 * hitDirection, -2f);
                var dust2 = Main.dust[num119];
                var dust160 = dust2;
                dust160.velocity /= 2f;
            }

            Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/dukegore_").Type, 1f);
            Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, NPC.velocity * 0.8f, Mod.Find<ModGore>("Gores/dukegore_2").Type, 1f);
            Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, NPC.velocity * 0.9f, Mod.Find<ModGore>("Gores/dukegore_3").Type, 1f);
            Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, NPC.velocity, Mod.Find<ModGore>("Gores/dukegore_4").Type, 1f);
        }
    }

    public override void AI() {
        NPC.noTileCollide = true;
        int num39 = 90;
        if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead) {
            NPC.TargetClosest(false);
            NPC.direction = 1;
            NPC.netUpdate = true;
        }

        if (NPC.ai[0] == 0f) {
            NPC.ai[1]++;
            _ = NPC.type;
            NPC.noGravity = true;
            NPC.dontTakeDamage = true;
            NPC.velocity.Y = NPC.ai[3];
            if (NPC.type == NPCID.Sharkron2) {
                float num40 = (float)Math.PI / 30f;
                float num41 = NPC.ai[2];
                float num42 = (float)(Math.Cos(num40 * NPC.localAI[1]) - 0.5) * num41;
                NPC.position.X -= num42 * -NPC.direction;
                NPC.localAI[1]++;
                num42 = (float)(Math.Cos(num40 * NPC.localAI[1]) - 0.5) * num41;
                NPC.position.X += num42 * -NPC.direction;
                if (Math.Abs(Math.Cos(num40 * NPC.localAI[1]) - 0.5) > 0.25) {
                    NPC.spriteDirection = !(Math.Cos(num40 * NPC.localAI[1]) - 0.5 >= 0.0) ? 1 : -1;
                }

                NPC.rotation = NPC.velocity.Y * NPC.spriteDirection * 0.1f;
                if (NPC.rotation < -0.2) {
                    NPC.rotation = -0.2f;
                }

                if (NPC.rotation > 0.2) {
                    NPC.rotation = 0.2f;
                }

                NPC.alpha -= 6;
                if (NPC.alpha < 0) {
                    NPC.alpha = 0;
                }
            }

            if (NPC.ai[1] >= num39) {
                NPC.ai[0] = 1f;
                NPC.ai[1] = 0f;
                if (!Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                    NPC.ai[1] = 1f;
                }

                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.Center);
                NPC.TargetClosest();
                NPC.spriteDirection = NPC.direction;
                var vector28 = Main.player[NPC.target].Center - NPC.Center;
                vector28.Normalize();
                NPC.velocity = vector28 * 16f;
                NPC.rotation = NPC.velocity.ToRotation();
                if (NPC.direction == -1) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.netUpdate = true;
            }
        }
        else {
            if (NPC.ai[0] != 1f) {
                return;
            }

            NPC.noGravity = true;
            if (!Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                if (NPC.ai[1] < 1f) {
                    NPC.ai[1] = 1f;
                }
            }
            else {
                NPC.alpha -= 15;
                if (NPC.alpha < 150) {
                    NPC.alpha = 150;
                }
            }

            if (NPC.ai[1] >= 1f) {
                NPC.alpha -= 60;
                if (NPC.alpha < 0) {
                    NPC.alpha = 0;
                }

                NPC.dontTakeDamage = false;
                NPC.ai[1]++;
                if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                    if (NPC.DeathSound != null) {
                        SoundEngine.PlaySound(NPC.DeathSound, NPC.position);
                    }

                    NPC.life = 0;
                    NPC.HitEffect();
                    NPC.active = false;
                    return;
                }
            }

            if (NPC.ai[1] >= 60f) {
                NPC.noGravity = false;
            }

            NPC.rotation = NPC.velocity.ToRotation();
            if (NPC.direction == -1) {
                NPC.rotation += (float)Math.PI;
            }
        }
    }
}