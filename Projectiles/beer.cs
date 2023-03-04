using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class beer : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("beer");
    }

    public override void SetDefaults() {
        Projectile.damage = 60;
        Projectile.hostile = true;
        Projectile.knockBack = 2;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.aiStyle = -1;
        Projectile.penetrate = 1;
        Projectile.width = Projectile.height = 15;
        Projectile.scale *= 1.3f;
    }

    public override void AI() {
        Projectile.velocity.Y += 0.1f;
        Projectile.rotation = Projectile.velocity.Y * 0.1f;
    }

    public override void Kill(int timeLeft) {
        Dust.NewDust(Projectile.Center, 15, 15, DustID.Tungsten, Main.rand.Next(-1, 1), -10);
    }
}