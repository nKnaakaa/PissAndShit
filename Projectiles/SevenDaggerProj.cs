﻿using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class SevenDaggerProj : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Shooting Seven");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults() {
        Projectile.width = 14;
        Projectile.height = 18;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 250;
        Projectile.tileCollide = false;
        Projectile.hostile = false;
        Projectile.scale = 1;
        AIType = ProjectileID.Bullet;
    }

    public override void AI() {
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
    }
}