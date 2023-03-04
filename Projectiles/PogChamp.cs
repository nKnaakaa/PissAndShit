using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class PogChamp : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Pog Champer");
    }

    public override void SetDefaults() {
        Projectile.width = 64;
        Projectile.height = 92;
        Projectile.aiStyle = ProjectileID.Fireball;
        AIType = ProjectileID.Fireball;
        Projectile.hostile = false;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 240;
        Projectile.tileCollide = true;
        Projectile.penetrate = 3;
        Projectile.scale = .4f;
        DrawOriginOffsetY -= 30;
    }

    public override void AI() {
        Projectile.velocity.Y = Projectile.velocity.Y + 0.15f;
        Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Marble, Projectile.velocity.X, Projectile.velocity.Y, 0, Colors.CoinCopper, 5f);
        Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.BlueCrystalShard, Projectile.velocity.X, Projectile.velocity.Y, 0, Colors.CoinGold, 5f);
        Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.SolarFlare, Projectile.velocity.X, Projectile.velocity.Y, 0, Colors.CoinPlatinum, 5f);
    }
}