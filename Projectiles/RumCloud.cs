using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class RumCloud : ModProjectile
{
    public override string Texture => "Terraria/Projectile_" + ProjectileID.ToxicCloud;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Rum Cloud");
    }

    public override void SetDefaults() {
        Projectile.damage = 50;
        Projectile.knockBack = 2;
        Projectile.aiStyle = -1;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.scale *= 1.2f;
        Projectile.tileCollide = false;
        Projectile.alpha = 2;
        Projectile.hostile = true;
        Projectile.width = Projectile.height = 18;
    }

    public override void AI() {
        Projectile.velocity.Y = -0.8f;
        Projectile.alpha += 8;

        if (Projectile.alpha >= 246) {
            Projectile.Kill();
        }
    }
}