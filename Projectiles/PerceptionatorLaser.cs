using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class PerceptionatorLaser : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Corrupt Laser");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults() {
        Projectile.width = 2;
        Projectile.height = 42;
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 500;
        Projectile.tileCollide = false;
        Projectile.hostile = true;
        Projectile.scale = 1;
        Projectile.light = 3;
        Projectile.alpha = 150;
        AIType = ProjectileID.Bullet;
    }

    public override void AI() {
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
    }
}