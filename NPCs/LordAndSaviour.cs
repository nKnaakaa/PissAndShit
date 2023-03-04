using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class LordAndSaviour : ModNPC
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("A Lord and Savior");
        NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
    }

    public override void SetDefaults() {
        NPC.aiStyle = 44;
        NPC.damage = 99999;
        NPC.lifeMax = 99999;
        NPC.width = 128;
        NPC.height = 128;
        NPC.lavaImmune = true;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.dontTakeDamage = true;
    }

    public override bool CheckActive() {
        return false;
    }

    public override void AI() {
        NPC.TargetClosest();
    }
}

//[redacted] in piss and shit, what war crimes will he commit