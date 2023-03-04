using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class SpiderSlime : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Spider Slime");
    }

    public override void SetDefaults() {
        NPC.width = 158;
        NPC.height = 115;

        NPC.lifeMax = 55;
        NPC.damage = 20;
        NPC.defense = 5;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.aiStyle = 1;
        AIType = NPCID.GreenSlime;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        return SpawnCondition.SpiderCave.Chance * 0.1f;
    }
}