using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class Pigler : ModNPC
{
    public override void SetStaticDefaults() {
        Main.npcFrameCount[NPC.type] = 8;
        DisplayName.SetDefault("Pigler");
    }

    public override void SetDefaults() {
        NPC.width = 64;
        NPC.height = 64;
        NPC.damage = 18;
        NPC.defense = 12;
        NPC.lifeMax = 150;
        NPC.HitSound = SoundID.NPCHit5;
        NPC.DeathSound = SoundID.NPCDeath5;
        NPC.value = 31f;
        NPC.knockBackResist = 0.2f;
        NPC.aiStyle = 26;
        NPC.noGravity = false;
        NPC.noTileCollide = false;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if (spawnInfo.Player.ZoneJungle) {
            return SpawnCondition.Overworld.Chance * 0.12f;
        }

        return 0f;
    }

    public override void FindFrame(int frameHeight) {
        NPC.spriteDirection = NPC.direction;
    }

    public override void OnKill() { }
}