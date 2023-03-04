using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class rum : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("rum");
    }

    public override void SetDefaults() {
        Projectile.damage = 35;
        Projectile.hostile = true;
        Projectile.knockBack = 2;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.aiStyle = -1;
        Projectile.penetrate = 1;
        Projectile.width = Projectile.height = 14;
    }

    public override void AI() {
        Projectile.velocity.Y += 0.4f;
        Projectile.rotation = Projectile.velocity.ToRotation();
    }

    public override void Kill(int timeLeft) {
        Dust.NewDust(Projectile.Center, 10, 10, DustID.ToxicBubble, 14, 14);
        Projectile.NewProjectile(            Projectile.GetSource_Death(),Projectile.position, -Projectile.velocity * 0.1f, ModContent.ProjectileType<RumCloud>(), 40, 3);
    }
}