using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles;

public class DeathItselfDaggerBomb : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("deaths meme stabber kaboomer");
        Main.projFrames[Projectile.type] = 5;
    }

    public override void SetDefaults() {
        Projectile.damage = 400;
        Projectile.hostile = true;
        Projectile.knockBack = 2;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 1;
        Projectile.width = 38;
        Projectile.height = 24;
        Projectile.scale *= 1.3f;
        Projectile.timeLeft = 30;
        Projectile.tileCollide = false;
    }

    public override void AI() {
        if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
            Projectile.tileCollide = false;
            Projectile.ai[1] = 0f;
            Projectile.alpha = 255;
            Resize(128, 128);
            Projectile.damage = 800;
            Projectile.knockBack = 8f;
        }
        else {
            Projectile.damage = 0;

            int num33 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100);

            Main.dust[num33].scale = 0.1f + Main.rand.Next(5) * 0.1f;
            Main.dust[num33].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
            Main.dust[num33].noGravity = true;
            Main.dust[num33].position = Projectile.Center + new Vector2(0f, -Projectile.height / 2).RotatedBy(Projectile.rotation) * 1.1f;

            int num34 = 6;
            var dust8 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, num34, 0f, 0f, 100);

            dust8.scale = 1f + Main.rand.Next(5) * 0.1f;
            dust8.noGravity = true;
            dust8.position = Projectile.Center + new Vector2(0f, -Projectile.height / 2 - 6).RotatedBy(Projectile.rotation) * 1.1f;
        }

        Projectile.ai[0] += 1f;

        if (Projectile.velocity != Vector2.Zero) {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }
    }

    private void Resize(int newWidth, int newHeight) {
        Projectile.position = Projectile.Center;
        Projectile.width = newWidth;
        Projectile.height = newHeight;
        Projectile.Center = Projectile.position;
    }

    public override void Kill(int timeLeft) {
        Projectile.NewProjectile(
            Projectile.GetSource_Death(),
            new Vector2(Projectile.position.X, Projectile.position.Y),
            new Vector2(0, 25),
            ModContent.ProjectileType<DeathItselfDagger>(),
            400,
            0f,
            Main.myPlayer,
            0f,
            Projectile.owner
        );

        Projectile.NewProjectile(
            Projectile.GetSource_Death(),
            new Vector2(Projectile.position.X - 50, Projectile.position.Y),
            new Vector2(0, 25),
            ModContent.ProjectileType<DeathItselfDagger>(),
            400,
            0f,
            Main.myPlayer,
            0f,
            Projectile.owner
        );

        Projectile.NewProjectile(
            Projectile.GetSource_Death(),
            new Vector2(Projectile.position.X + 50, Projectile.position.Y),
            new Vector2(0, 25),
            ModContent.ProjectileType<DeathItselfDagger>(),
            400,
            0f,
            Main.myPlayer,
            0f,
            Projectile.owner
        );

        Projectile.NewProjectile(
            Projectile.GetSource_Death(),
            new Vector2(Projectile.position.X - 100, Projectile.position.Y),
            new Vector2(0, 25),
            ModContent.ProjectileType<DeathItselfDagger>(),
            400,
            0f,
            Main.myPlayer,
            0f,
            Projectile.owner
        );

        Projectile.NewProjectile(
            Projectile.GetSource_Death(),
            new Vector2(Projectile.position.X + 100, Projectile.position.Y),
            new Vector2(0, 25),
            ModContent.ProjectileType<DeathItselfDagger>(),
            400,
            0f,
            Main.myPlayer,
            0f,
            Projectile.owner
        );
    }
}