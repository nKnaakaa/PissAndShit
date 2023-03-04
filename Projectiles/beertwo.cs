using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class beertwo : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Beer or Grog");
    }

    public override void SetDefaults() {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Magic;
        AIType = ProjectileID.WoodenArrowFriendly;
    }

    public override void Kill(int timeLeft) {
        SoundEngine.PlaySound(SoundID.Shatter);

        Gore.NewGore(            Projectile.GetSource_Death(),Projectile.Center, Projectile.velocity * 0.8f, Mod.Find<ModGore>("Gores/beertwo_gore").Type, 1f);
        Gore.NewGore(            Projectile.GetSource_Death(),Projectile.Center, Projectile.velocity * 0.9f, Mod.Find<ModGore>("Gores/beertwo_gore2").Type, 1f);
    }

    public override void AI() {
        Projectile.rotation += 0.2f * Projectile.direction;
    }
}