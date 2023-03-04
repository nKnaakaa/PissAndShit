using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class ConfettiSlime : ModNPC
{
    private int frameNum;
    private int frameTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Confetti Slime");
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults() {
        NPC.height = 139;
        NPC.width = 224;
        NPC.damage = 50;
        NPC.lifeMax = 5000;
        NPC.defense = 10;
        NPC.knockBackResist = 0;
        NPC.value = 20000f;
        NPC.aiStyle = 1;
        AnimationType = NPCID.GreenSlime;
    }

    public override void AI() {
        Dust.NewDust(NPC.position, NPC.width, NPC.height, 139);
        Dust.NewDust(NPC.position, NPC.width, NPC.height, 140);
        Dust.NewDust(NPC.position, NPC.width, NPC.height, 141);
        Dust.NewDust(NPC.position, NPC.width, NPC.height, 142);
        frameTimer++;
    }

    public override void FindFrame(int frameHeight) {
        if (frameTimer == 6) {
            frameNum++;
            frameTimer = 0;
        }

        if (frameNum == 2) {
            frameNum = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if (BirthdayParty.PartyIsUp) {
            return SpawnCondition.OverworldDaySlime.Chance * 0.1f / 2;
        }

        return 0f;
    }
}