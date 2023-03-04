using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses;

[AutoloadBossHead]
public class Hive : ModNPC
{
    private int beeTimer;
    private int beeType;

    public override void SetDefaults() {
        NPC.width = 425;
        NPC.height = 375;

        NPC.boss = true;
        NPC.aiStyle = -1;
        AIType = 94;

        NPC.npcSlots = 1;

        NPC.lifeMax = 10000;
        NPC.defense = 10000;
        NPC.knockBackResist = 0f;

        NPC.value = Item.buyPrice(5);

        NPC.lavaImmune = true;
        NPC.noTileCollide = true;
        NPC.noGravity = true;

        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/CHUNGUS");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 1.3f);
    }

    public override void AI() {
        beeTimer++;
        if (beeTimer >= 5) {
            beeTimer = 0;
            beeType = Main.rand.Next(100);
            if (!Main.expertMode) {
                if (beeType == 0) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, NPC.whoAmI);
                }
                else if (beeType >= 1 && beeType <= 5) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, NPC.whoAmI);
                }
                else if (beeType >= 6 && beeType <= 15) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, NPC.whoAmI);
                }
                else if (beeType >= 16) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.Bee, NPC.whoAmI);
                }
            }

            if (Main.expertMode) {
                if (beeType == 0) {
                    Main.NewText("Bee Hell Mode Activated");
                    for (int i = 0; i < 5; i++) {
                        NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, NPC.whoAmI);
                    }

                    for (int k = 0; k < 9; k++) {
                        NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, NPC.whoAmI);
                    }

                    for (int l = 0; l < 19; l++) {
                        NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, NPC.whoAmI);
                    }
                }
                else if (beeType >= 1 && beeType <= 5) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, NPC.whoAmI);
                }
                else if (beeType >= 6 && beeType <= 15) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, NPC.whoAmI);
                }
                else if (beeType >= 16) {
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-200, 200), (int)NPC.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, NPC.whoAmI);
                }
            }
        }
    }

    public override void OnKill() {
        PaSSystem.downedHive = true;
        int bossWeapon = Main.rand.Next(3);
        if (Main.expertMode) {

        }

        if (!Main.expertMode) {
            if (bossWeapon == 0) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BeeBasher>());
            }

            if (bossWeapon == 1) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BeeBook>());
            }

            if (bossWeapon == 2) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BeeTime>());
            }
        }
    }
}