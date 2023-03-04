using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs;

public class CursedSoul : ModNPC
{
    private bool hit;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Cursed Soul");
    }

    public override void SetDefaults() {
        NPC.width = 34;
        NPC.height = 32;
        NPC.damage = 0;
        NPC.defense = 0;
        NPC.immortal = true;
        NPC.lifeMax = 1;
        NPC.HitSound = SoundID.NPCHit8;
        NPC.DeathSound = SoundID.NPCDeath8;
        NPC.value = 0f;
        NPC.knockBackResist = 0f;
        NPC.aiStyle = -1;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
    }

    public override void AI() {
        NPC.TargetClosest();
        var player = Main.player[NPC.target];
        NPC.direction = NPC.spriteDirection = NPC.Center.X < player.Center.X ? -1 : 1;
        var targetPosition = Main.player[NPC.target].position;
        if (targetPosition.X > NPC.position.X && NPC.velocity.X >= -6) {
            NPC.velocity.X -= 0.1f;
        }
        else if (targetPosition.X < NPC.position.X && NPC.velocity.X <= 6) {
            NPC.velocity.X += 0.1f;
        }

        if (NPC.velocity.X >= 3 || NPC.velocity.X <= -3) {
            Dust dust;
            var position = NPC.Center;
            dust = Main.dust[Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255))];
        }

        if (hit) {
            player.statLife += 25;
            Dust dust;
            Dust dust1;
            Dust dust2;
            Dust dust3;
            var position = new Vector2(NPC.Center.X - NPC.width / 2, NPC.Center.Y);
            dust = Main.dust[Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255))];
            dust1 = Main.dust[Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255))];
            dust2 = Main.dust[Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255))];
            dust3 = Main.dust[Dust.NewDust(position, 30, 30, 74, 0f, 0f, 0, new Color(255, 255, 255))];
            NPC.active = false;
        }
    }

    public override void HitEffect(int hitDirection, double damage) {
        hit = true;
    }
}