using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class GDdemon : ModNPC
{
    private int frameNum = 0;

    private int frameTimer = 0;
    //int timer = 0;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("GDdemon");
        NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults() {
        NPC.width = 128;
        NPC.height = 117;
        NPC.damage = 30;
        NPC.defense = 10;
        NPC.lifeMax = 2000;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCHit2;
        NPC.value = 60f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 26;
        NPC.lavaImmune = true;
    }

    public override void AI() {
        NPC.rotation += NPC.velocity.X * 0.1f;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        // we would like this npc to spawn in the overworld.
        return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
    }
}