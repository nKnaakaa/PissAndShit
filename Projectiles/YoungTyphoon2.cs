using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class YoungTyphoon : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Whirlpool");
        Main.projFrames[Projectile.type] = 3;
    }

    public override void SetDefaults() {
        Projectile.width = 30;
        Projectile.height = 30;
        Projectile.aiStyle = 71;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 360;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 2;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.hostile = false;
        Projectile.scale = 1;
    }

    public override void AI() { }
}