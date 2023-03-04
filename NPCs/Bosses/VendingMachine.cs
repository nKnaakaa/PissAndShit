using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses;

public class VendingMachine : ModNPC
{
    private int spawnTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Vending Machine");
    }

    public override void SetDefaults() {
        NPC.boss = true;
        NPC.noGravity = false;
        NPC.noTileCollide = false;
        NPC.lavaImmune = true;
        NPC.width = 544;
        NPC.height = 813;
        NPC.damage = 40;
        NPC.defense = 10;
        NPC.lifeMax = 4000;
        NPC.knockBackResist = 0f;
        Music = MusicID.Boss2;
        SceneEffectPriority = SceneEffectPriority.BossMedium;
    }

    public override void HitEffect(int hitDirection, double damage) {
        for (int k = 0; k < 50; k++) {
            Dust.NewDust(NPC.position, 0, 0, DustID.t_SteampunkMetal, Main.rand.Next(-4, 4), -4);
        }
    }

    public override void SendExtraAI(BinaryWriter writer) {
        writer.Write(spawnTimer);
    }

    public override void ReceiveExtraAI(BinaryReader reader) {
        spawnTimer = reader.ReadInt32();
    }

    public override void AI() {
        // npc.ai[value] usages
        // 0 for States (Phases and Stuff)
        // 1 for Attacks
        // 2 for Attack Timers
        // 3 n/a

        if (NPC.ai[0] == 0f) {
            // Cooldown
            if (NPC.ai[1] == 0f) {
                // Falling faster than usual since gravity
                NPC.velocity.Y = 4f;
                NPC.dontTakeDamage = false;

                spawnTimer++;
                if (spawnTimer >= 10 * 60) // 10 seconds
                {
                    NPC.ai[1] = 1f;
                }
            }
            else if (NPC.ai[1] == 1f) {
                NPC.dontTakeDamage = true;
                int npcToSpawn = 0;
                float ySpawnOffset = NPC.position.Y += -20f * 16f;

                switch (Main.rand.Next(1, 5)) {
                    case 1:
                        npcToSpawn = NPCID.KingSlime;
                        break;

                    case 2:
                        npcToSpawn = NPCID.EyeofCthulhu;
                        break;

                    case 3:
                        npcToSpawn = NPCID.QueenBee;
                        break;

                    case 4:
                        npcToSpawn = NPCID.SkeletronHead;
                        break;
                }

                int bossSpawned = NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)ySpawnOffset, npcToSpawn);
                if (!Main.npc[bossSpawned].active) {
                    NPC.ai[1] = 0f;
                }
            }
        }
    }

    public override void BossLoot(ref string name, ref int potionType) {
        PaSSystem.downedVendingMachine = true;
        if (Main.netMode == NetmodeID.Server) {
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}