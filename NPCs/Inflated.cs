using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class Inflated : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Fat Gamer Pig");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults() {
        NPC.width = 64;
        NPC.height = 64;
        NPC.aiStyle = 26;
        NPC.damage = 7;
        NPC.defense = 2;
        NPC.lifeMax = 25;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 25f;
    }

    public override void AI() {
        NPC.rotation += NPC.velocity.X * 0.1f;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        // we would like this npc to spawn in the overworld.
        return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
    }
}