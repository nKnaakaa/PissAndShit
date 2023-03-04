using System;
using Microsoft.Xna.Framework;
using PissAndShit.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class SoapBubble : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Soap Bubble");
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.DetonatingBubble];
    }

    public override void SetDefaults() {
        NPC.width = 36;
        NPC.height = 36;
        NPC.damage = 100;
        NPC.aiStyle = NPCID.DetonatingBubble;
        NPC.defense = 0;
        NPC.lifeMax = 1;
        NPC.HitSound = SoundID.NPCHit3;
        NPC.DeathSound = SoundID.NPCDeath3;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.knockBackResist = 0f;
        NPC.alpha = 255;
        NPCID.Sets.NeedsExpertScaling[NPC.type] = true;
        NPCID.Sets.ProjectileNPC[NPC.type] = true;
    }

    public override void OnHitPlayer(Player target, int damage, bool crit) {
        target.AddBuff(ModContent.BuffType<Soaped>(), 300, false);
    }

    public override void HitEffect(int hitDirection, double damage) {
        SoundEngine.PlaySound(SoundID.NPCDeath3, NPC.position);
        if (NPC.life <= 0) {
            _ = NPC.Center;
            for (int num120 = 0; num120 < 60; num120++) {
                int num121 = 25;
                _ = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
                int num122 = Dust.NewDust(NPC.Center - Vector2.One * num121, num121 * 2, num121 * 2, 212);
                var dust154 = Main.dust[num122];
                var vector7 = Vector2.Normalize(dust154.position - NPC.Center);
                dust154.position = NPC.Center + vector7 * 25f * NPC.scale;
                if (num120 < 30) {
                    dust154.velocity = vector7 * dust154.velocity.Length();
                }
                else {
                    dust154.velocity = vector7 * Main.rand.Next(45, 91) / 10f;
                }

                dust154.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
                dust154.color = Color.Lerp(dust154.color, Color.White, 0.3f);
                dust154.noGravity = true;
                dust154.scale = 0.7f;
            }
        }
    }

    public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit) {
        damage = 0.0;
        NPC.ai[0] = 1f;
        NPC.ai[1] = 4f;
        NPC.dontTakeDamage = true;
        return false;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.damage = (int)(NPC.damage * 0.75);
    }

    public override void AI() {
        if (NPC.target == 255) {
            NPC.TargetClosest();
            NPC.ai[3] = Main.rand.Next(80, 121) / 100f;
            float scaleFactor = Main.rand.Next(165, 265) / 15f;
            NPC.velocity = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101))) * scaleFactor;
            NPC.netUpdate = true;
        }

        var vector27 = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center);
        NPC.velocity = (NPC.velocity * 40f + vector27 * 20f) / 41f;
        NPC.scale = NPC.ai[3];
        NPC.alpha -= 30;
        if (NPC.alpha < 50) {
            NPC.alpha = 50;
        }

        NPC.alpha = 50;
        NPC.velocity.X = (NPC.velocity.X * 50f + Main.windPhysicsStrength * 2f + Main.rand.Next(-10, 11) * 0.1f) / 51f;
        NPC.velocity.Y = (NPC.velocity.Y * 50f + -0.25f + Main.rand.Next(-10, 11) * 0.2f) / 51f;
        if (NPC.velocity.Y > 0f) {
            NPC.velocity.Y -= 0.04f;
        }

        if (NPC.ai[0] == 0f) {
            int num37 = 40;
            var rect = NPC.getRect();
            rect.X -= num37 + NPC.width / 2;
            rect.Y -= num37 + NPC.height / 2;
            rect.Width += num37 * 2;
            rect.Height += num37 * 2;
            for (int num38 = 0; num38 < 255; num38++) {
                var player2 = Main.player[num38];
                if (player2.active && !player2.dead && rect.Intersects(player2.getRect())) {
                    NPC.ai[0] = 1f;
                    NPC.ai[1] = 4f;
                    NPC.netUpdate = true;
                    break;
                }
            }
        }

        if (NPC.ai[0] == 0f) {
            NPC.ai[1]++;
            if (NPC.ai[1] >= 150f) {
                NPC.ai[0] = 1f;
                NPC.ai[1] = 4f;
            }
        }

        if (NPC.ai[0] == 1f) {
            NPC.ai[1]--;
            if (NPC.ai[1] <= 0f) {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.active = false;
                return;
            }
        }

        if (NPC.justHit || NPC.ai[0] == 1f) {
            NPC.dontTakeDamage = true;
            NPC.position = NPC.Center;
            NPC.width = NPC.height = 100;
            NPC.position = new Vector2(NPC.position.X - NPC.width / 2, NPC.position.Y - NPC.height / 2);
            if (NPC.timeLeft > 3) {
                NPC.timeLeft = 3;
            }
        }
    }
}