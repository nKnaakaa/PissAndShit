using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Misc;
using PissAndShit.Items.Weapons;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses;

[AutoloadBossHead]
public class boozeshrume : ModNPC
{
    public int AtttaackTimer;
    public int GameCrashCounter;
    public int PhaseValueOrSomethingIDK;
    public int SpeeeeedValue;
    public int SpeeeeenTimer;

    public bool SpeeeenBool;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("boozeshrume.exe");
    }

    public override void SetDefaults() {
        NPC.width = NPC.height = 120;
        NPC.damage = 69;
        NPC.knockBackResist = 1f;
        NPC.boss = true;
        NPC.lifeMax = 8500;
        NPC.defense = 30;
        NPC.noTileCollide = true;
        NPC.value = Item.buyPrice(0, 12, 80);
        NPC.aiStyle = -1;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.lavaImmune = true;
        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Staying_As_a_1.14");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }

    public override void AI() {
        if (NPC.life < NPC.lifeMax / 2) {
            PhaseValueOrSomethingIDK = 1;
        }

        NPC.TargetClosest();
        NPC.spriteDirection = NPC.direction;

        var player = Main.player[NPC.target];

        SpeeeeedValue = SpeeeenBool ? 5 : 7;

        var moveTo = player.Center - NPC.Center;
        moveTo.Normalize();
        moveTo = moveTo * SpeeeeedValue;

        NPC.velocity = moveTo;

        if (++SpeeeeenTimer % 180 == 0) {
            if (SpeeeenBool) {
                SpeeeenBool = true;
            }
            else {
                SpeeeenBool = false;
            }
        }

        if (SpeeeenBool) {
            NPC.rotation += NPC.velocity.X * 0.1f;
        }

        if (PhaseValueOrSomethingIDK == 0) {
            if (++AtttaackTimer >= 250) {
                for (int i = 0; i < Main.rand.Next(10, 20); i++) {
                    Projectile.NewProjectile(
                        NPC.GetSource_FromAI(),
                        NPC.Center.X - Main.rand.Next(-600, 600),
                        NPC.Center.Y - Main.screenHeight / 2 - 60,
                        moveTo.X * 1.5f,
                        moveTo.Y * 1.5f,
                        ModContent.ProjectileType<rum>(),
                        35,
                        2
                    );
                }

                AtttaackTimer = 0;
            }
        }
        else if (PhaseValueOrSomethingIDK == 1) {
            GameCrashCounter++;

            if (GameCrashCounter == 1) {
                CombatText.NewText(NPC.Hitbox, Color.DarkRed, "Kill me in 2 minute or you get booted", true);
            }

            if (GameCrashCounter == 3600) {
                CombatText.NewText(NPC.Hitbox, Color.DarkRed, "One minute kill me or terraria go back to menu", true);
            }

            if (GameCrashCounter == 7140) {
                CombatText.NewText(NPC.Hitbox, Color.DarkRed, "You are going to brazil", true);
            }

            if (GameCrashCounter == 7200) {
                CombatText.NewText(NPC.Hitbox, Color.DarkRed, "Whoops gotta save your stuff first", true);
            }

            if (GameCrashCounter == 7300) {
                CombatText.NewText(NPC.Hitbox, Color.DarkRed, "PASTA LA VISTA!!!!!", true);
            }

            if (GameCrashCounter >= 7320) {
                Main.SaveSettings();

                if (Main.netMode == NetmodeID.SinglePlayer) {
                    WorldFile.CacheSaveTime();
                }

                Main.invasionProgress = 0;
                Main.invasionProgressDisplayLeft = 0;
                Main.invasionProgressAlpha = 0f;
                Main.menuMode = 10;
                Main.gameMenu = true;
                CaptureInterface.ResetFocus();
                Main.ActivePlayerFileData.StopPlayTimer();

                Player.SavePlayer(Main.ActivePlayerFileData);

                if (Main.netMode == NetmodeID.SinglePlayer) {
                }
                else {
                    Main.netMode = NetmodeID.SinglePlayer;
                }

                Main.fastForwardTime = false;
                Main.menuMode = 0;
            }

            if (++AtttaackTimer >= 40) {
                Projectile.NewProjectile(NPC.GetSource_FromAI(),NPC.Center, moveTo * 4, ModContent.ProjectileType<beer>(), 50, 3);

                AtttaackTimer = 0;
            }
        }
    }

    public override void OnKill() {
        PaSSystem.downedBoozeshrume = true;
        Main.NewText("boozeshrume.exe has stopped working", Color.MediumPurple);
        int bossWeapon = Main.rand.Next(4);

        if (!Main.expertMode) {
            Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix>(), 3);
            switch (bossWeapon) //godslimepog case switching
            {
                case 0:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BeerBook>());
                    break;
                case 1:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<BeerBow>());
                    break;
            }
        }
        else {

        }
    }
}

/*boozeshrume.exe

Phase 1: Chases you, spins around, and throws rum all over the floor
Phase 2: Causes beer to rain from the sky, and then gives you 2 minute to fight him or else your game crash

Also replace the death message with "boozeshrume.exe has stopped working."

Drops Scrumpy Cider Redwine Tequilla Whiskey Vodka Rum snorts at book Arrack Spirit Pure Ethanol Drink Mix, which makes you super dronk
*/