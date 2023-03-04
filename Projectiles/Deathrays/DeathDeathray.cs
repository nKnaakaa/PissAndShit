using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace PissAndShit.Projectiles.Deathrays;

public class DeathDeathray : BaseDeathray
{
    private const float maxTime = 900;
    private Vector2 spawnPos;

    public DeathDeathray() : base(120, "DeathDeathray") { }

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("deaths meme laser");
    }

    public override void AI() {
        Vector2? vector78 = null;

        if (Projectile.velocity.HasNaNs() || Projectile.velocity == Vector2.Zero) {
            Projectile.velocity = -Vector2.UnitY;
        }

        if (Projectile.localAI[0] == 0f) {
            SoundEngine.PlaySound(SoundID.Zombie104, Projectile.position);
            spawnPos = Projectile.Center;
        }

        //vibrate beam
        //projectile.Center = spawnPos + Main.rand.NextVector2Circular(5, 5);
        //didn't look nice in the deathray box
        float num801 = 1f;
        Projectile.localAI[0] += 1f;

        if (Projectile.localAI[0] >= maxTime) {
            Projectile.Kill();
            return;
        }

        Projectile.scale = (float)Math.Sin(Projectile.localAI[0] * 3.14159274f / maxTime) * num801 * 6f;

        if (Projectile.scale > num801) {
            Projectile.scale = num801;
        }

        float num805 = 3f;
        float num806 = Projectile.width;
        var samplingPoint = Projectile.Center;

        if (vector78.HasValue) {
            samplingPoint = vector78.Value;
        }

        float[] array3 = new float[(int)num805];

        for (int i = 0; i < array3.Length; i++) {
            array3[i] = 3000f;
        }

        float num807 = 0f;
        int num3;

        for (int num808 = 0; num808 < array3.Length; num808 = num3 + 1) {
            num807 += array3[num808];
            num3 = num808;
        }

        num807 /= num805;

        float amount = 0.5f;

        Projectile.localAI[1] = MathHelper.Lerp(Projectile.localAI[1], num807, amount);

        var vector79 = Projectile.Center + Projectile.velocity * (Projectile.localAI[1] - 14f);

        for (int num809 = 0; num809 < 2; num809 = num3 + 1) {
            float num810 = Projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1f : 1f) * 1.57079637f;
            float num811 = (float)Main.rand.NextDouble() * 2f + 2f;
            var vector80 = new Vector2((float)Math.Cos(num810) * num811, (float)Math.Sin(num810) * num811);
            int num812 = Dust.NewDust(vector79, 0, 0, 244, vector80.X, vector80.Y);

            Main.dust[num812].noGravity = true;
            Main.dust[num812].scale = 1.7f;

            num3 = num809;
        }

        if (Main.rand.NextBool(5)) {
            var value29 = Projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
            int num813 = Dust.NewDust(vector79 + value29 - Vector2.One * 4f, 8, 8, 244, 0f, 0f, 100, default(Color), 1.5f);
            var dust = Main.dust[num813];

            dust.velocity *= 0.5f;

            Main.dust[num813].velocity.Y = -Math.Abs(Main.dust[num813].velocity.Y);
        }

        Projectile.position -= Projectile.velocity;
        Projectile.rotation = Projectile.velocity.ToRotation() - 1.57079637f;
    }
}