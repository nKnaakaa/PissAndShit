using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class Head : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Siren Head");
        Main.npcFrameCount[NPC.type] = 1;
    }

    public override void SetDefaults() {
        NPC.width = 188;
        NPC.height = 175;
        NPC.aiStyle = 38;
        NPC.damage = 30;
        NPC.defense = 5;
        NPC.lifeMax = 1500;
        NPC.HitSound = SoundID.NPCHit55;
        NPC.DeathSound = SoundID.NPCDeath59;
        NPC.value = 25f;
        NPC.knockBackResist = 0.5f;
        NPC.scale = 1f;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        return SpawnCondition.SolarEclipse.Chance * 0.05f;
    }
}