using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class Aquarian : ModNPC
{
    private int frameNum;
    private int frameTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Aquarian");
        NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        Main.npcFrameCount[NPC.type] = 4;
    }

    public override void SetDefaults() {
        NPC.width = 72;
        NPC.height = 56;
        NPC.damage = 22;
        NPC.defense = 9;
        NPC.lifeMax = 108;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath7;
        NPC.value = 31f;
        NPC.knockBackResist = 0.07f;
        NPC.aiStyle = 3;
        NPC.noGravity = false;
        NPC.noTileCollide = false;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if (spawnInfo.Player.ZoneRain) {
            return SpawnCondition.Overworld.Chance * 0.12f;
        }

        if (spawnInfo.Player.ZoneBeach) {
            return SpawnCondition.Overworld.Chance * 0.18f;
        }

        return 0.1f;
    }

    public override void AI() {
        frameTimer++;
    }

    public override void OnKill() {
        Item.NewItem(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemID.Coral, Main.rand.Next(3, 5));
    }

    public override void FindFrame(int frameHeight) {
        NPC.spriteDirection = NPC.direction;

        if (frameTimer == 3) {
            frameNum++;
            frameTimer = 0;
        }

        if (frameNum == 4) {
            frameNum = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }
}