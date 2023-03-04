using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace PissAndShit.NPCs;

public class HermesSlime : ModNPC
{
    private int frameNum;
    private int frameTimer;
    private int jumpTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Hermes Boots Slime");
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults() {
        NPC.width = 32;
        NPC.height = 26;
        NPC.damage = 20;
        NPC.lifeMax = 200;
        NPC.defense = 15;
        NPC.knockBackResist = 0;
        NPC.value = 10000;
        NPC.aiStyle = -1;
        NPC.lavaImmune = false;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }

    public override void AI() {
        frameTimer++;
        jumpTimer++;
        NPC.TargetClosest();
        var player = Main.player[NPC.target];
        var targetPosition = Main.player[NPC.target].position;
        var position = new Vector2(NPC.position.X, NPC.position.Y + NPC.height);
        if (targetPosition.X < NPC.position.X) {
            NPC.spriteDirection = -1;
        }
        else if (targetPosition.X > NPC.position.X) {
            NPC.spriteDirection = 1;
        }

        if (targetPosition.X < NPC.position.X && NPC.velocity.X > -15) {
            NPC.velocity.X -= 0.22f;
        }

        if (targetPosition.X > NPC.position.X && NPC.velocity.X < 15) {
            NPC.velocity.X += 0.22f;
        }

        if (jumpTimer >= 60 && Main.rand.NextBool(3) && NPC.velocity.Y == 0) {
            NPC.velocity.Y -= 5f;
            jumpTimer = 0;
        }
        else if (jumpTimer >= 60) {
            jumpTimer = 0;
        }

        if (NPC.velocity.X > 5 || NPC.velocity.X < -5) {
            if (NPC.velocity.Y == 0) {
                Dust dust;
                dust = Main.dust[Dust.NewDust(position, 30, 0, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.447368f)];
            }
        }
    }

    public override void FindFrame(int frameHeight) {
        if (frameNum == 2) {
            frameNum = 0;
        }

        if (frameTimer == 6) {
            frameNum++;
            frameTimer = 0;
        }

        NPC.frame.Y = frameNum * frameHeight;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        return SpawnCondition.Underground.Chance * 0.05f;
    }

    public override void OnKill() {
        Item.NewItem(NPC.GetSource_FromAI(),new Vector2(NPC.Center.X, NPC.Center.Y), ItemID.HermesBoots);
    }
}