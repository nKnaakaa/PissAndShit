using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses;

[AutoloadBossHead]
public class GrandDad : ModNPC
{
    private bool canTeleport = true;
    private int projectileShoot;
    private int projectileTimer;
    private bool secondPhase;
    private int teleportTimer;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("GRAND DAD");
        Main.npcFrameCount[NPC.type] = 15;
    }

    public override void SetDefaults() {
        NPC.width = 122;
        NPC.height = 181;

        NPC.boss = true;
        NPC.aiStyle = -1;

        NPC.npcSlots = 5;

        NPC.lifeMax = 7777777;
        NPC.damage = 500;
        NPC.defense = 777;
        NPC.knockBackResist = 0f;

        NPC.value = Item.buyPrice(20);

        NPC.lavaImmune = true;
        NPC.noTileCollide = true;
        NPC.noGravity = true;

        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/GRANDDAD");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
        NPC.damage = (int)(NPC.damage * 1.3f);
    }

    public override void AI() {
        var player = Main.player[NPC.target];
        NPC.TargetClosest();
        NPC.direction = NPC.spriteDirection = NPC.Center.X < player.Center.X ? -1 : 1;
        var targetPosition = Main.player[NPC.target].position;
        var target = NPC.HasPlayerTarget ? player.Center : Main.npc[NPC.target].Center;
        NPC.netAlways = true;
        if (canTeleport) {
            teleportTimer++;
        }

        if (secondPhase) {
            projectileTimer++;
        }

        if (NPC.life <= NPC.lifeMax / 2) {
            secondPhase = true;
        }

        if (teleportTimer >= 30) {
            NPC.position.X = targetPosition.X + Main.rand.Next(-500, 500);
            NPC.position.Y = targetPosition.Y + Main.rand.Next(-500, 500);
            teleportTimer = 0;
        }

        if (projectileTimer >= 180) {
            var shootPos = NPC.Center;
            float accuracy = 5f * (NPC.life / NPC.lifeMax);
            var shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
            shootVel.Normalize();
            shootVel *= 14.5f;
            projectileShoot = Main.rand.Next(3);
            for (int i = 0; i < (Main.expertMode ? 2 : 1); i++) {
                if (projectileShoot == 0) {
                    Projectile.NewProjectile(
                        NPC.GetSource_FromAI(),
                        shootPos.X + -100 * NPC.direction + Main.rand.Next(-20, 20),
                        shootPos.Y - Main.rand.Next(-20, 20),
                        shootVel.X,
                        shootVel.Y,
                        ModContent.ProjectileType<SevenProj>(),
                        NPC.damage / 3,
                        5f
                    );
                }

                if (projectileShoot == 1) {
                    //needs wario apparition
                }

                if (projectileShoot == 2) {
                    Projectile.NewProjectile(NPC.GetSource_FromAI(),
                        shootPos.X + -100 * NPC.direction + Main.rand.Next(-20, 20),
                        shootPos.Y - Main.rand.Next(-20, 20),
                        shootVel.X,
                        shootVel.Y,
                        ModContent.ProjectileType<GrandDadBrian>(),
                        NPC.damage / 2,
                        5f
                    );
                }
            }

            projectileTimer = 0;
        }

        if (player.dead) {
            canTeleport = false;
            NPC.TargetClosest(false);
            NPC.direction = 1;
            NPC.velocity.Y = NPC.velocity.Y - 0.1f;
            if (NPC.timeLeft > 5) {
                NPC.timeLeft = 5;
            }
        }
    }

    public override void FindFrame(int frameHeight) {
        /*if (secondPhase)
        {
            if (++npc.frameCounter > 15)
            {
                npc.frameCounter = 6;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= 15 * frameHeight)
                {
                    npc.frame.Y = 6;
                }
            }
        }
        else {
            if (++npc.frameCounter > 5)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= 5 * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        } */
        NPC.frameCounter += 1.0;
        if (NPC.frameCounter < 5.0) {
            NPC.frame.Y = 0;
            if (secondPhase) {
                NPC.frame.Y += frameHeight * 5;
            }
        }
        else if (NPC.frameCounter < 10.0) {
            NPC.frame.Y = frameHeight;
            if (secondPhase) {
                NPC.frame.Y += frameHeight * 5;
            }
        }
        else if (NPC.frameCounter < 15.0) {
            NPC.frame.Y = frameHeight * 2;
            if (secondPhase) {
                NPC.frame.Y += frameHeight * 5;
            }
        }
        else if (NPC.frameCounter < 20.0) {
            NPC.frame.Y = frameHeight * 3;
            if (secondPhase) {
                NPC.frame.Y += frameHeight * 5;
            }
        }
        else if (NPC.frameCounter < 25.0) {
            NPC.frame.Y = frameHeight * 4;
            if (secondPhase) {
                NPC.frame.Y += frameHeight * 5;
            }
        }
        /*else if (npc.frameCounter < 42.0 && secondPhase)
        {
            npc.frame.Y = frameHeight * 9;
        }*/
        else if (NPC.frameCounter < 30.0 && secondPhase) {
            NPC.frame.Y = frameHeight * 10;
        }
        else if (NPC.frameCounter < 35.0 && secondPhase) {
            NPC.frame.Y = frameHeight * 11;
        }
        else if (NPC.frameCounter < 40.0 && secondPhase) {
            NPC.frame.Y = frameHeight * 12;
        }
        else if (NPC.frameCounter < 45.0 && secondPhase) {
            NPC.frame.Y = frameHeight * 13;
        }
        else if (NPC.frameCounter < 50.0 && secondPhase) {
            NPC.frame.Y = frameHeight * 14;
        }
        else {
            NPC.frameCounter = 0.0;
            NPC.frame.Y = 0;
        }
    }

    public override void OnKill() {
        PaSSystem.downedGrandDad = true;
        int bossWeapon = Main.rand.Next(4);
        if (Main.expertMode) {

        }
        else {
            if (bossWeapon == 0) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<SevenShortsword>());
            }

            if (bossWeapon == 0) {
                Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<DaedalusSevenbow>());
            }
        }
    }
}