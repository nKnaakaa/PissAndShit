using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class Fart : ModProjectile
{
    public override void SetDefaults() {
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 165;
        Projectile.alpha = 85;
        Projectile.tileCollide = false;
    }

    public override void AI() {
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 5f) {
            Projectile.ai[0] = 0f;
            Projectile.netUpdate = true;
            Projectile.rotation += 0.05f * Projectile.direction;
            Projectile.velocity.X /= 1.43f;
            Projectile.velocity.Y /= 1.43f;
        }
    }

    public override void Kill(int timeLeft) {
        SoundEngine.PlaySound(SoundID.NPCHit1, Projectile.position);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        Projectile.ai[0] += 0.1f;
        Projectile.velocity *= 1.25f;
    }
}