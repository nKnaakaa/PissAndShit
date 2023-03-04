using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class SevenProj : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("7");
        Main.projFrames[Projectile.type] = 4;
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults() {
        Projectile.width = 51;
        Projectile.height = 51;
        Projectile.hostile = true;
        Projectile.aiStyle = 1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.timeLeft = 300;
        AIType = ProjectileID.Skull;
    }

    public override void AI() {
        if (++Projectile.frameCounter >= 4) {
            Projectile.frameCounter = 0;
            Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
        }
    }
}