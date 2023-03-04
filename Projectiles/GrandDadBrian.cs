using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class GrandDadBrian : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("GrandDadBrian");
    }

    public override void SetDefaults() {
        Projectile.width = 64;
        Projectile.height = 92;
        Projectile.aiStyle = 107;
        Projectile.hostile = true;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 180;
        Projectile.tileCollide = false;
    }

    //public override void AI() => projectile.CloneDefaults(ProjectileID.DesertDjinnCurse);
}