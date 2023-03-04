using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class DeathItselfDagger : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("deaths meme stabber");
    }

    public override void SetDefaults() {
        Projectile.damage = 400;
        Projectile.hostile = true;
        Projectile.knockBack = 2;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.aiStyle = 2;
        Projectile.penetrate = 1;
        Projectile.width = 22;
        Projectile.height = 52;
        Projectile.tileCollide = false;
    }

    public override void AI() {
        Projectile.velocity = Projectile.velocity / 1.0f;
    }
}