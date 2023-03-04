using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class youngdukeyoyoproj : ModProjectile
{
    public override void SetStaticDefaults() {
        ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8f;
        ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
        ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14f;
    }

    public override void SetDefaults() {
        Projectile.extraUpdates = 0;
        Projectile.width = 8;
        Projectile.height = 8;
        Projectile.aiStyle = 99;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.scale = 2f;
    }

    public override void AI() {
        if (Main.rand.NextBool(10)) {
            Projectile.NewProjectile(Projectile.GetSource_FromAI(),Projectile.position.X, Projectile.position.Y, 0, 0, ProjectileID.None, 50, Projectile.knockBack, Main.myPlayer);
        }
    }

    public override void OnHitNPC(NPC n, int damage, float knockback, bool crit) {
        if (Main.rand.NextBool(10)) {
            n.AddBuff(20, 180);
        }
    }
}