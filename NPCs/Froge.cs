using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class Froge : ModNPC
{
    private int frameNum;

    private int frameTimer;
    //int timer = 0;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Froge");
        NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        Main.npcFrameCount[NPC.type] = 53;
    }

    public override void SetDefaults() {
        NPC.width = 112;
        NPC.height = 112;
        NPC.damage = 1;
        NPC.defense = 10;
        NPC.lifeMax = 2000;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCHit2;
        NPC.value = 60f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 5;
        NPC.lavaImmune = true;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
    }

    public override void AI() {
        frameTimer++;
    }

    public override void FindFrame(int frameHeight) {
        NPC.spriteDirection = NPC.direction;

        if (frameTimer == 2) {
            frameNum++;
            frameTimer = 0;
        }

        if (frameNum == 53) {
            frameNum = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }
}