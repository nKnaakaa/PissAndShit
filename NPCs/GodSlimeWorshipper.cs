using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class GodSlimeWorshipper : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("God Slime's Servant");
        Main.npcFrameCount[NPC.type] = 5;
    }

    public override void SetDefaults() {
        NPC.width = 158;
        NPC.height = 115;

        NPC.lifeMax = 50000;
        NPC.damage = 200;
        NPC.defense = 100;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.aiStyle = 1;
        AIType = NPCID.GreenSlime;
        NPC.knockBackResist = 0;
        AnimationType = NPCID.RainbowSlime;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 1.3f);
    }
}