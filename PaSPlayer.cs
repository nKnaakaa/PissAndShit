using Microsoft.Xna.Framework;
using PissAndShit.Dusts;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit;

public class PaSPlayer : ModPlayer
{
    private static int oldAge;
    public bool ancientIdol;
    private int cancerCounter;
    public bool cursedMedallion;
    public bool exoskeletonBad;
    public bool exoskeletonGood;
    private bool jungleTalked;
    public bool kamra;
    public bool soaped;
    private bool spaceTalked;

    public override void ResetEffects() {
        kamra = false;
        soaped = false;
        ancientIdol = false;
        cursedMedallion = false;
        exoskeletonBad = false;
        exoskeletonGood = false;
    }

    public override void UpdateBadLifeRegen() {
        if (kamra) {
            Player.lifeRegenTime = 0;
            Player.lifeRegen = Player.lifeRegen > 0 ? -25 : Player.lifeRegen - 25;
        }
    }

    public override void PreUpdate() {
        oldAge++;
        if (oldAge >= 108000) {
            Player.KillMe(PlayerDeathReason.ByCustomReason($"{Player.name} got too old."), 10000, 1);
            oldAge = 0;
        }

        if (PaSSystem.endlessModeSave) {
            if (Player.ZoneSnow) {
                Player.AddBuff(BuffID.Chilled, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneDesert) {
                Player.AddBuff(BuffID.Slow, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneCorrupt) {
                Player.AddBuff(BuffID.Darkness, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneCrimson) {
                Player.AddBuff(BuffID.Ichor, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneJungle) {
                Player.AddBuff(BuffID.Bleeding, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneDungeon) {
                Player.AddBuff(BuffID.WaterCandle, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneBeach) {
                Player.AddBuff(BuffID.BrokenArmor, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneGlowshroom) {
                Player.AddBuff(BuffID.Confused, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneHallow) {
                Player.AddBuff(BuffID.ChaosState, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneUnderworldHeight) {
                Player.AddBuff(BuffID.Blackout, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneSkyHeight) {
                Player.AddBuff(BuffID.VortexDebuff, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneRockLayerHeight) {
                Player.AddBuff(BuffID.Rabies, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }

            if (Player.ZoneDirtLayerHeight) {
                Player.AddBuff(BuffID.Rabies, Main.expertMode && Main.GameModeInfo.DebuffTimeMultiplier > 1 ? 1 : 2, false);
            }
        }

        if (PaSSystem.endlesserModeSave) {
            if (Player.ZoneCorrupt || Player.ZoneCrimson) {
                cancerCounter++;
                switch (cancerCounter) {
                    case 4500:
                        Main.NewText($"{Player.name} is feeling queasy", 50, 237, 21);
                        break;
                    case 9000:
                        Main.NewText($"{Player.name}'s hair is falling out in chunks", 39, 194, 16);
                        break;
                    case 13500:
                        Main.NewText($"{Player.name} is seeing spots", 28, 143, 11);
                        break;
                    case 18000:
                        Player.KillMe(PlayerDeathReason.ByCustomReason($"{Player.name} got cancer"), 10000, 1);
                        cancerCounter = 0;
                        break;
                }

                if (!NPC.downedSlimeKing) {
                    Player.KillMe(PlayerDeathReason.ByCustomReason("Gelatinous goop covers this evil"), 10000, 1);
                    Player.ZoneCrimson = false;
                }
            }
            else {
                cancerCounter--;
                if (cancerCounter < 0) {
                    cancerCounter = 0;
                }
            }

            if (Player.ZoneJungle && (Player.ZoneDirtLayerHeight || Player.ZoneRockLayerHeight) && !NPC.downedBoss1) {
                Player.width = 0;
                Player.height = 0;
                Player.velocity.Y -= 10;
                if (!jungleTalked) {
                    Main.NewText("The eye of cthulhu guards its treasure buried in the jungle", 0, 255, 0);
                    jungleTalked = true;
                }
            }
            else {
                if (jungleTalked) {
                    jungleTalked = false;
                    Player.width = 32;
                    Player.height = 48;
                }
            }

            if (Player.ZoneUnderworldHeight && !NPC.downedBoss2) {
                if (WorldGen.crimson) {
                    Player.KillMe(PlayerDeathReason.ByCustomReason("Brain of Cthulhu watches you as you burn in hell"), 10000, 1);
                }
                else {
                    Player.KillMe(PlayerDeathReason.ByCustomReason("Eater of Worlds watches you as you burn in hell"), 10000, 1);
                }

                Player.ZoneUnderworldHeight = false;
            }

            if (Player.ZoneSkyHeight && !NPC.downedBoss3) {
                Player.velocity.Y += 10;
                if (!spaceTalked) {
                    Main.NewText("Skeletron throws you out of the sky", 0, 0);
                    spaceTalked = true;
                }
            }
            else {
                if (spaceTalked) {
                    spaceTalked = false;
                }
            }
        }
    }

    public override void PostUpdateBuffs() {
        if (PaSSystem.endlesserModeSave) {
            if (Player.HasBuff(BuffID.MoonLeech)) {
                Player.wingTimeMax = Player.rocketTimeMax = 0;
            }
        }
    }

    public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
        if (soaped) {
            if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
                int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, DustType<SoapBubble>(), Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100);

                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                drawInfo.DustCache.Add(dust);
            }

            r *= 0.1f;
            g *= 0.5f;
            b *= 0.7f;
        }
    }

    public override void PostUpdateRunSpeeds() {
        if (exoskeletonBad) {
            Player.maxRunSpeed *= 0.5f;
            Player.accRunSpeed *= 0.5f;
            Player.moveSpeed *= 0.5f;
        }

        if (exoskeletonGood) {
            Player.maxRunSpeed *= 0.5f;
            Player.accRunSpeed *= 0.5f;
            Player.moveSpeed *= 0.5f;
        }

        if (exoskeletonBad && exoskeletonGood) {
            Player.maxRunSpeed *= 0.01f;
            Player.accRunSpeed *= 0.01f;
            Player.moveSpeed *= 0.01f;
        }
    }

    public override void OnHitByNPC(NPC npc, int damage, bool crit) {
        if (ancientIdol) {
            var source = npc.GetSource_OnHit(Player);

            int projectile = Projectile.NewProjectile(source, Player.Center.X + 5, Player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X + 5, Player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X, Player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X, Player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;
        }
    }

    public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
        if (ancientIdol) {
            var source = proj.GetSource_OnHit(Player);

            int projectile = Projectile.NewProjectile(source, Player.Center.X + 5, Player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X + 5, Player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X, Player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X, Player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;

            projectile = Projectile.NewProjectile(source, Player.Center.X - 5, Player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, Player.whoAmI);

            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;
        }
    }
}