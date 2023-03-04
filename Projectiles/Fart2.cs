using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class Fart2 : ModProjectile
{
    public override void SetDefaults() {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 136;
        Projectile.alpha = 85;
        Projectile.tileCollide = false;
    }

    public override void AI() {
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 5f) {
            Projectile.ai[0] = 0f;
            Projectile.netUpdate = true;
            Projectile.rotation += 0.05f * Projectile.direction;
            Projectile.velocity.X /= 1.61f;
            Projectile.velocity.Y /= 1.61f;
        }
    }

    public override void Kill(int timeLeft) {
        SoundEngine.PlaySound(SoundID.NPCHit1, Projectile.position);

        for (int i = 0; i < 6; i++) {
            Projectile.NewProjectile(            Projectile.GetSource_Death(),Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), ModContent.ProjectileType<Fart>(), 30, 5, 0, 18, 1);
        }
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        Projectile.ai[0] += 0.1f;
        Projectile.velocity *= 1.35f;
    }
}