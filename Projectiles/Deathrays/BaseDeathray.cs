using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles.Deathrays;

public abstract class BaseDeathray : ModProjectile
{
    private readonly float maxTime;
    private readonly string texture;

    protected BaseDeathray(float maxTime, string texture) {
        this.maxTime = maxTime;
        this.texture = texture;
    }

    public override void SetDefaults() //MAKE SURE YOU CALL BASE.SETDEFAULTS IF OVERRIDING
    {
        Projectile.width = 48;
        Projectile.height = 48;
        Projectile.hostile = true;
        Projectile.alpha = 255;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.timeLeft = 600;

        CooldownSlot = 1; //not in warning line, test?

        Projectile.hide = true; //fixes weird issues on spawn with scaling
    }

    public override void PostAI() {
        Projectile.hide = false;
    }

    public override bool PreDraw(ref Color lightColor) {
        SpriteBatch spriteBatch = Main.spriteBatch;
        
        if (Projectile.velocity != Vector2.Zero) {
            var projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D deathrayTexture2 = ModContent.Request<Texture2D>("PissAndShit/Projectiles/Deathrays/" + texture + "2").Value;
            Texture2D deathrayTexture3 = ModContent.Request<Texture2D>("PissAndShit/Projectiles/Deathrays/" + texture + "3").Value;
            float num = Projectile.localAI[1];
            var color = new Color(255, 255, 255, 0) * 0.9f;
            var projectileTexture2 = projectileTexture;
            var projCenter = Projectile.Center - Main.screenPosition;
            Rectangle? sourceRectangle = null;

            spriteBatch.Draw(projectileTexture2, projCenter, sourceRectangle, color, Projectile.rotation, projectileTexture.Size() / 2f, Projectile.scale, SpriteEffects.None, 0f);

            num -= (projectileTexture.Height / 2 + deathrayTexture3.Height) * Projectile.scale;

            var projectileCenter = Projectile.Center;
            projectileCenter += Projectile.velocity * Projectile.scale * projectileTexture.Height / 2f;

            if (num > 0f) {
                float num2 = 0f;
                var rectangle = new Rectangle(0, 16 * (Projectile.timeLeft / 3 % 5), deathrayTexture2.Width, 16);

                while (num2 + 1f < num) {
                    if (num - num2 < rectangle.Height) {
                        rectangle.Height = (int)(num - num2);
                    }

                    spriteBatch.Draw(
                        deathrayTexture2,
                        projectileCenter - Main.screenPosition,
                        new Rectangle?(rectangle),
                        color,
                        Projectile.rotation,
                        new Vector2(rectangle.Width / 2, 0f),
                        Projectile.scale,
                        SpriteEffects.None,
                        0f
                    );

                    num2 += rectangle.Height * Projectile.scale;
                    projectileCenter += Projectile.velocity * rectangle.Height * Projectile.scale;
                    rectangle.Y += 16;

                    if (rectangle.Y + rectangle.Height > deathrayTexture2.Height) {
                        rectangle.Y = 0;
                    }
                }
            }

            projectileCenter -= Main.screenPosition;
            sourceRectangle = null;

            spriteBatch.Draw(deathrayTexture3, projectileCenter, sourceRectangle, color, Projectile.rotation, deathrayTexture3.Frame().Top(), Projectile.scale, SpriteEffects.None, 0f);
        }

        return false;
    }

    public override void CutTiles() {
        DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
        var unit = Projectile.velocity;
        Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * Projectile.localAI[1], Projectile.width * Projectile.scale, null);
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
        if (projHitbox.Intersects(targetHitbox)) {
            return true;
        }

        float num6 = 0f;
        if (Collision.CheckAABBvLineCollision(
                targetHitbox.TopLeft(),
                targetHitbox.Size(),
                Projectile.Center,
                Projectile.Center + Projectile.velocity * Projectile.localAI[1],
                22f * Projectile.scale,
                ref num6
            )) {
            return true;
        }

        return false;
    }
}