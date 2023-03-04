using PissAndShit.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class BigMan : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Big Man");
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
    }

    public override void SetDefaults() {
        NPC.width = 380;
        NPC.height = 460;
        NPC.damage = 75;
        NPC.defense = 25;
        NPC.lifeMax = 500;
        NPC.HitSound = SoundID.NPCHit41;
        NPC.DeathSound = SoundID.NPCDeath14;
        AIType = NPCID.Zombie;
        NPC.aiStyle = 3;
        AnimationType = NPCID.Zombie;
        NPC.knockBackResist = 1;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
    }

    public override void OnKill() {
        Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BigChunk>(), 3);
    }
}