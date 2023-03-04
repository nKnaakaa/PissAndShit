using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses;

[AutoloadBossHead]
public class GodSlime : ModNPC
{
    private int frameNum;
    private int frameTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("God Slime");
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults() {
        NPC.width = 390;
        NPC.height = 220;

        NPC.boss = true;
        NPC.aiStyle = 1;
        AIType = 1;

        NPC.npcSlots = 5;

        NPC.lifeMax = 10000000;
        NPC.damage = 400;
        NPC.defense = 175;
        NPC.knockBackResist = 0f;

        NPC.value = Item.buyPrice(15);

        NPC.lavaImmune = false;
        NPC.noTileCollide = false;
        NPC.noGravity = false;

        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/heavenly_bullshit");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 1.3f);
    }

    public override void OnKill() {
        PaSSystem.downedGodSlime = true;
        int bossWeapon = Main.rand.Next(4);
        if (Main.expertMode) {
            for (int i = 0; i < 49; i++) {
                NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-1000, 1000), (int)NPC.Center.Y + Main.rand.Next(-1000, 1000), ModContent.NPCType<GodSlimeWorshipper>(), NPC.whoAmI);
            }
        }
        else {
            Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Gel, 999);
            if (bossWeapon == 0) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<GodlyCross>());
            }

            for (int i = 0; i < 61; i++) {
                NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-1000, 1000), (int)NPC.Center.Y + Main.rand.Next(-1000, 1000), ModContent.NPCType<GodSlimeWorshipper>(), NPC.whoAmI);
            }
        }
    }

    public override void BossLoot(ref string name, ref int potionType) {
        potionType = ItemID.GreaterHealingPotion;
    }

    public override void AI() {
        frameTimer++;
    }

    public override void FindFrame(int frameHeight) {
        if (frameTimer == 6) {
            frameNum++;
            frameTimer = 0;
        }

        if (frameNum == 4) {
            frameNum = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }

    public override void HitEffect(int hitDirection, double damage) {
        if (Main.expertMode) {
            if (Main.rand.NextBool(5)) {
                NPC.NewNPC(NPC.GetSource_FromAI(),(int)NPC.Center.X + Main.rand.Next(-100, 100), (int)NPC.Center.Y + Main.rand.Next(-100, 100), ModContent.NPCType<GodSlimeWorshipper>(), NPC.whoAmI);
            }
        }
    }
}