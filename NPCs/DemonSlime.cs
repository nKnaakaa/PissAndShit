using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class DemonSlime : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Demon Slime");
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults() {
        NPC.height = 18;
        NPC.width = 29;
        NPC.damage = 19;
        NPC.lifeMax = 125;
        NPC.defense = 17;
        NPC.knockBackResist = 0;
        NPC.value = 69f;
        NPC.aiStyle = 14;
        NPC.lavaImmune = true;
        NPC.buffImmune[24] = true;
        NPC.buffImmune[39] = true;
        AnimationType = NPCID.GreenSlime;
    }

    public override void AI() {
        NPC.TargetClosest();
        NPC.spriteDirection = NPC.direction;
        float num1514 = 7f;
        var vector25 = new Vector2(NPC.Center.X + NPC.direction * 20, NPC.Center.Y + 6f);
        float num1515 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector25.X;
        float num1516 = Main.player[NPC.target].position.Y - vector25.Y;
        float num1517 = (float)Math.Sqrt(num1515 * num1515 + num1516 * num1516);
        float num1518 = num1514 / num1517;
        num1515 *= num1518;
        num1516 *= num1518;
        bool flag61 = Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1);
        if (Main.dayTime) {
            int num1519 = 60;
            NPC.velocity.X = (NPC.velocity.X * (num1519 - 1) - num1515) / num1519;
            NPC.velocity.Y = (NPC.velocity.Y * (num1519 - 1) - num1516) / num1519;
            if (NPC.timeLeft > 10) {
                NPC.timeLeft = 10;
            }

            return;
        }

        if (num1517 > 600f || !flag61) {
            int num1520 = 60;
            NPC.velocity.X = (NPC.velocity.X * (num1520 - 1) + num1515) / num1520;
            NPC.velocity.Y = (NPC.velocity.Y * (num1520 - 1) + num1516) / num1520;
            return;
        }

        NPC.velocity *= 0.98f;
        if (Math.Abs(NPC.velocity.X) < 1f && Math.Abs(NPC.velocity.Y) < 1f && Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.localAI[0] += 1f;
            if (NPC.localAI[0] >= 15f) {
                NPC.localAI[0] = 0f;
                num1515 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector25.X;
                num1516 = Main.player[NPC.target].Center.Y - vector25.Y;
                num1515 += Main.rand.Next(-35, 36);
                num1516 += Main.rand.Next(-35, 36);
                num1515 *= 1f + Main.rand.Next(-20, 21) * 0.015f;
                num1516 *= 1f + Main.rand.Next(-20, 21) * 0.015f;
                num1517 = (float)Math.Sqrt(num1515 * num1515 + num1516 * num1516);
                num1514 = 10f;
                num1518 = num1514 / num1517;
                num1515 *= num1518;
                num1516 *= num1518;
                num1515 *= 1f + Main.rand.Next(-20, 21) * 0.0125f;
                num1516 *= 1f + Main.rand.Next(-20, 21) * 0.0125f;
                int num1522 = Projectile.NewProjectile(NPC.GetSource_FromAI(), vector25.X, vector25.Y, num1515, num1516, ProjectileID.DemonSickle, 32, 0f, Main.myPlayer);
            }
        }
    }
}