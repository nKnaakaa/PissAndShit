using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class DetonatingBubbleProj : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Detonating Bubble");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults() {
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.aiStyle = 1;
        Projectile.friendly = false;
        Projectile.ignoreWater = true;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 500;
        Projectile.tileCollide = true;
        Projectile.hostile = true;
        Projectile.scale = 1;
        AIType = ProjectileID.Bullet;
    }

    public override void AI() {
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
    }

    public override void OnHitPlayer(Player target, int damage, bool crit) {
        target.AddBuff(BuffID.Wet, Main.rand.Next(180, 481), false);
    }
}