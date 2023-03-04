using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class CoochieSnatcher : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Coochie Snatcher");
    }

    public override void SetDefaults() {
        NPC.width = 64;
        NPC.height = 64;
        NPC.damage = 28;
        NPC.defense = 12;
        NPC.lifeMax = 400;
        NPC.HitSound = SoundID.NPCHit5;
        NPC.DeathSound = SoundID.NPCDeath5;
        NPC.value = 31f;
        NPC.knockBackResist = 0.2f;
        NPC.aiStyle = 69;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
    }

    public override void OnKill() { }
}