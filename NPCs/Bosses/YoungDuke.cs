using System;
using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs.Bosses;

[AutoloadBossHead]
public class YoungDuke : ModNPC
{
    //private short Cthulu;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Duke");
        Main.npcFrameCount[NPC.type] = 8;
    }

    public override void SetDefaults() {
        NPC.width = 192;
        NPC.height = 130;
        NPC.aiStyle = 69;
        NPC.damage = 25;
        NPC.defense = 16;
        NPC.lifeMax = 6500;
        NPC.knockBackResist = 0f;
        NPC.noTileCollide = true;
        NPC.noGravity = true;
        NPC.npcSlots = 10f;
        NPC.HitSound = SoundID.NPCHit14;
        NPC.DeathSound = SoundID.NPCDeath20;
        NPC.value = 10000f;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.timeLeft = 22500;
        NPC.buffImmune[20] = true;
        NPC.buffImmune[24] = true;
        NPC.buffImmune[31] = true;
        NPC.buffImmune[44] = true;
        AnimationType = NPCID.DukeFishron;
        Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/YungDook_2");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }

    public override void BossLoot(ref string name, ref int potionType) {
        potionType = ItemID.HealingPotion;
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
        NPC.lifeMax = (int)(NPC.lifeMax * 0.6 * 1f);
        NPC.damage = (int)(NPC.damage * 0.7);
    }

    public override void OnKill() {
        PaSSystem.downedYoungDuke = true;
        int bossWeapon = Main.rand.Next(4);
        if (Main.expertMode) {

        }
        else {
            switch (bossWeapon) {
                case 0:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemType<YoungBow>());
                    break;

                case 1:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemType<youngdukeyoyo>());
                    break;

                case 2:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemType<YoungGun>());
                    break;

                case 3:
                    Item.NewItem(NPC.GetSource_FromAI(),(int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ItemType<YoungRazorTyphoon>());
                    break;
            }
        }
    }

    public override void HitEffect(int hitDirection, double damage) {
        if (NPC.life > 0) {
            for (int num123 = 0; num123 < NPC.damage / (double)NPC.lifeMax * 100.0; num123++) {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hitDirection, -1f);
            }
        }
        else {
            for (int num125 = 0; num125 < 150; num125++) {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2 * hitDirection, -2f);
            }

            Gore.NewGore(NPC.GetSource_FromAI(),NPC.Center - Vector2.UnitX * 20f * NPC.direction, NPC.velocity, Mod.Find<ModGore>("Gores/younggore_4").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_FromAI(),NPC.Center - Vector2.UnitY * 30f, NPC.velocity, Mod.Find<ModGore>("Gores/younggore_3").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_FromAI(),NPC.Center, NPC.velocity, Mod.Find<ModGore>("Gores/younggore_(1)").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_FromAI(),NPC.Center - Vector2.UnitY * 30f, NPC.velocity, Mod.Find<ModGore>("Gores/younggore_3").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_FromAI(),NPC.Center, NPC.velocity, Mod.Find<ModGore>("Gores/younggore_2").Type, NPC.scale);
        }
    }

    public void SimpleFlyMovement(Vector2 desiredVelocity, float moveSpeed) {
        if (NPC.velocity.X < desiredVelocity.X) {
            NPC.velocity.X += moveSpeed;
            if (NPC.velocity.X < 0f && desiredVelocity.X > 0f) {
                NPC.velocity.X += moveSpeed;
            }
        }
        else if (NPC.velocity.X > desiredVelocity.X) {
            NPC.velocity.X -= moveSpeed;
            if (NPC.velocity.X > 0f && desiredVelocity.X < 0f) {
                NPC.velocity.X -= moveSpeed;
            }
        }

        if (NPC.velocity.Y < desiredVelocity.Y) {
            NPC.velocity.Y += moveSpeed;
            if (NPC.velocity.Y < 0f && desiredVelocity.Y > 0f) {
                NPC.velocity.Y += moveSpeed;
            }
        }
        else if (NPC.velocity.Y > desiredVelocity.Y) {
            NPC.velocity.Y -= moveSpeed;
            if (NPC.velocity.Y > 0f && desiredVelocity.Y < 0f) {
                NPC.velocity.Y -= moveSpeed;
            }
        }
    }

    public override void AI() {
        for (int i = 0; i < Main.maxProjectiles; i++) {
            var proj = Main.projectile[i];
            if (proj.active && proj.type == 386) {
                proj.Kill();
            }
        }

        for (int i = 0; i < Main.maxProjectiles; i++) {
            var proj = Main.projectile[i];
            if (proj.active && proj.type == 385) {
                proj.Kill();
            }
        }

        for (int i = 0; i < Main.maxProjectiles; i++) {
            var proj = Main.projectile[i];
            if (proj.active && proj.type == 384) {
                proj.Kill();
            }
        }

        for (int i = 0; i < Main.maxNPCs; i++) {
            var npc = Main.npc[i];
            if (npc.active && npc.type == NPCID.DetonatingBubble) {
                npc.life = 0;
            }
        }

        bool expertMode = Main.expertMode;
        float num = expertMode ? 0.6f * Main.GameModeInfo.EnemyDamageMultiplier : 1f;
        bool flag = NPC.life <= NPC.lifeMax * 0.5;
        bool flag2 = expertMode && NPC.life <= NPC.lifeMax * 0.15;
        bool flag3 = NPC.ai[0] > 4f;
        bool flag4 = NPC.ai[0] > 9f;
        bool flag5 = NPC.ai[3] < 10f;
        if (flag4) {
            NPC.damage = (int)(NPC.defDamage * 1.1f * num);
            NPC.defense = 0;
        }
        else if (flag3) {
            NPC.damage = (int)(NPC.defDamage * 1.2f * num);
            NPC.defense = (int)(NPC.defDefense * 0.8f);
        }
        else {
            NPC.damage = NPC.defDamage;
            NPC.defense = NPC.defDefense;
        }

        int num12 = expertMode ? 40 : 60;
        float num23 = expertMode ? 0.55f : 0.45f;
        float scaleFactor = expertMode ? 8.5f : 7.5f;
        if (flag4) {
            num23 = 0.7f;
            scaleFactor = 12f;
            num12 = 30;
        }
        else if (flag3 && flag5) {
            num23 = expertMode ? 0.6f : 0.5f;
            scaleFactor = expertMode ? 10f : 8f;
            num12 = expertMode ? 40 : 20;
        }
        else if (flag5 && !flag3 && !flag4) {
            num12 = 30;
        }

        int num31 = expertMode ? 28 : 30;
        float num32 = expertMode ? 17f : 16f;
        if (flag4) {
            num31 = 25;
            num32 = 27f;
        }
        else if (flag5 && flag3) {
            num31 = expertMode ? 27 : 30;
            if (expertMode) {
                num32 = 21f;
            }
        }

        int num33 = 80;
        int num34 = 4;
        float num35 = 0.3f;
        float scaleFactor2 = 5f;
        int num36 = 90;
        int num2 = 180;
        int num3 = 180;
        int num4 = 30;
        int num5 = 120;
        int num6 = 4;
        float scaleFactor3 = 6f;
        float scaleFactor4 = 20f;
        float num7 = (float)Math.PI * 2f / (num5 / 2);
        int num8 = 75;
        var center = NPC.Center;
        var player = Main.player[NPC.target];
        if (NPC.ai[0] >= 5f) {
            Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Young_Dook_Phase_2");
        }

        if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active) {
            NPC.TargetClosest();
            player = Main.player[NPC.target];
            NPC.netUpdate = true;
        }

        if (player.dead || Vector2.DistanceSquared(player.Center, center) > 5600f * 5600f) {
            NPC.velocity.Y -= 0.4f;
            if (NPC.timeLeft > 10) {
                NPC.timeLeft = 10;
            }

            if (NPC.ai[0] > 4f) {
                NPC.ai[0] = 5f;
            }
            else {
                NPC.ai[0] = 0f;
            }

            NPC.ai[2] = 0f;
        }

        if (player.position.Y < 800f || player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 6400f && player.position.X < Main.maxTilesX * 16 - 6400)) {
            num12 = 20;
            NPC.damage = NPC.defDamage * 2;
            NPC.defense = NPC.defDefense * 2;
            NPC.ai[3] = 0f;
            num32 += 6f;
        }

        if (NPC.localAI[0] == 0f) {
            NPC.localAI[0] = 1f;
            NPC.alpha = 255;
            NPC.rotation = 0f;
            if (Main.netMode != NetmodeID.MultiplayerClient) {
                NPC.ai[0] = -1f;
                NPC.netUpdate = true;
            }
        }

        float num9 = (float)Math.Atan2(player.Center.Y - center.Y, player.Center.X - center.X);
        if (NPC.spriteDirection == 1) {
            num9 += (float)Math.PI;
        }

        if (num9 < 0f) {
            num9 += (float)Math.PI * 2f;
        }

        if (num9 > (float)Math.PI * 2f) {
            num9 -= (float)Math.PI * 2f;
        }

        if (NPC.ai[0] == -1f) {
            num9 = 0f;
        }

        if (NPC.ai[0] == 3f) {
            num9 = 0f;
        }

        if (NPC.ai[0] == 4f) {
            num9 = 0f;
        }

        if (NPC.ai[0] == 8f) {
            num9 = 0f;
        }

        float num10 = 0.04f;
        if (NPC.ai[0] == 1f || NPC.ai[0] == 6f) {
            num10 = 0f;
        }

        if (NPC.ai[0] == 7f) {
            num10 = 0f;
        }

        if (NPC.ai[0] == 3f) {
            num10 = 0.01f;
        }

        if (NPC.ai[0] == 4f) {
            num10 = 0.01f;
        }

        if (NPC.ai[0] == 8f) {
            num10 = 0.01f;
        }

        if (NPC.rotation < num9) {
            if (num9 - NPC.rotation > Math.PI) {
                NPC.rotation -= num10;
            }
            else {
                NPC.rotation += num10;
            }
        }

        if (NPC.rotation > num9) {
            if (NPC.rotation - num9 > Math.PI) {
                NPC.rotation += num10;
            }
            else {
                NPC.rotation -= num10;
            }
        }

        if (NPC.rotation > num9 - num10 && NPC.rotation < num9 + num10) {
            NPC.rotation = num9;
        }

        if (NPC.rotation < 0f) {
            NPC.rotation += (float)Math.PI * 2f;
        }

        if (NPC.rotation > (float)Math.PI * 2f) {
            NPC.rotation -= (float)Math.PI * 2f;
        }

        if (NPC.rotation > num9 - num10 && NPC.rotation < num9 + num10) {
            NPC.rotation = num9;
        }

        if (NPC.ai[0] != -1f && NPC.ai[0] < 9f) {
            if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                NPC.alpha += 15;
            }
            else {
                NPC.alpha -= 15;
            }

            if (NPC.alpha < 0) {
                NPC.alpha = 0;
            }

            if (NPC.alpha > 150) {
                NPC.alpha = 150;
            }
        }

        if (NPC.ai[0] == -1f) {
            NPC.velocity *= 0.98f;
            int num11 = Math.Sign(player.Center.X - center.X);
            if (num11 != 0) {
                NPC.direction = num11;
                NPC.spriteDirection = -NPC.direction;
            }

            if (NPC.ai[2] > 20f) {
                NPC.velocity.Y = -2f;
                NPC.alpha -= 5;
                if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                    NPC.alpha += 15;
                }

                if (NPC.alpha < 0) {
                    NPC.alpha = 0;
                }

                if (NPC.alpha > 150) {
                    NPC.alpha = 150;
                }
            }

            if (NPC.ai[2] == num36 - 30) {
                int num13 = 36;
                for (int i = 0; i < num13; i++) {
                    var value6 = (Vector2.Normalize(NPC.velocity) * new Vector2(NPC.width / 2f, NPC.height) * 0.75f * 0.5f).RotatedBy((i - (num13 / 2 - 1)) * ((float)Math.PI * 2f) / num13) +
                        NPC.Center;
                    var value2 = value6 - NPC.Center;
                    int num14 = Dust.NewDust(value6 + value2, 0, 0, 172, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num14].noGravity = true;
                    Main.dust[num14].noLight = true;
                    Main.dust[num14].velocity = Vector2.Normalize(value2) * 3f;
                }

                SoundEngine.PlaySound(SoundID.Zombie20, center);
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num8) {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 0f && !player.dead) {
            if (NPC.ai[1] == 0f) {
                NPC.ai[1] = 300 * Math.Sign((center - player.Center).X);
            }

            var vector = Vector2.Normalize(player.Center + new Vector2(NPC.ai[1], -200f) - center - NPC.velocity) * scaleFactor;
            if (NPC.velocity.X < vector.X) {
                NPC.velocity.X += num23;
                if (NPC.velocity.X < 0f && vector.X > 0f) {
                    NPC.velocity.X += num23;
                }
            }
            else if (NPC.velocity.X > vector.X) {
                NPC.velocity.X -= num23;
                if (NPC.velocity.X > 0f && vector.X < 0f) {
                    NPC.velocity.X -= num23;
                }
            }

            if (NPC.velocity.Y < vector.Y) {
                NPC.velocity.Y += num23;
                if (NPC.velocity.Y < 0f && vector.Y > 0f) {
                    NPC.velocity.Y += num23;
                }
            }
            else if (NPC.velocity.Y > vector.Y) {
                NPC.velocity.Y -= num23;
                if (NPC.velocity.Y > 0f && vector.Y < 0f) {
                    NPC.velocity.Y -= num23;
                }
            }

            int num15 = Math.Sign(player.Center.X - center.X);
            if (num15 != 0) {
                if (NPC.ai[2] == 0f && num15 != NPC.direction) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.direction = num15;
                if (NPC.spriteDirection != -NPC.direction) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.spriteDirection = -NPC.direction;
            }

            NPC.ai[2] += 1f;
            if (!(NPC.ai[2] >= num12)) {
                return;
            }

            int num16 = 0;
            switch ((int)NPC.ai[3]) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    num16 = 1;
                    break;

                case 10:
                    NPC.ai[3] = 1f;
                    num16 = 2;
                    break;

                case 11:
                    NPC.ai[3] = 0f;
                    num16 = 3;
                    break;
            }

            if (flag) {
                num16 = 4;
            }

            switch (num16) {
                case 1:
                    NPC.ai[0] = 1f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.velocity = Vector2.Normalize(player.Center - center) * num32;
                    NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
                    if (num15 != 0) {
                        NPC.direction = num15;
                        if (NPC.spriteDirection == 1) {
                            NPC.rotation += (float)Math.PI;
                        }

                        NPC.spriteDirection = -NPC.direction;
                    }

                    break;

                case 2:
                    NPC.ai[0] = 2f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;

                case 3:
                    NPC.ai[0] = 3f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;

                case 4:
                    NPC.ai[0] = 4f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;
            }

            NPC.netUpdate = true;
        }
        else if (NPC.ai[0] == 1f) {
            int num17 = 7;
            for (int j = 0; j < num17; j++) {
                var value7 = (Vector2.Normalize(NPC.velocity) * new Vector2((NPC.width + 50) / 2f, NPC.height) * 0.75f).RotatedBy((j - (num17 / 2 - 1)) * Math.PI / (float)num17) + center;
                var value3 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                int num18 = Dust.NewDust(value7 + value3, 0, 0, 172, value3.X * 2f, value3.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num18].noGravity = true;
                Main.dust[num18].noLight = true;
                Main.dust[num18].velocity /= 4f;
                Main.dust[num18].velocity -= NPC.velocity;
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num31) {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] += 2f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 2f) {
            if (NPC.ai[1] == 0f) {
                NPC.ai[1] = 300 * Math.Sign((center - player.Center).X);
            }

            var vector2 = Vector2.Normalize(player.Center + new Vector2(NPC.ai[1], -200f) - center - NPC.velocity) * scaleFactor2;
            if (NPC.velocity.X < vector2.X) {
                NPC.velocity.X += num35;
                if (NPC.velocity.X < 0f && vector2.X > 0f) {
                    NPC.velocity.X += num35;
                }
            }
            else if (NPC.velocity.X > vector2.X) {
                NPC.velocity.X -= num35;
                if (NPC.velocity.X > 0f && vector2.X < 0f) {
                    NPC.velocity.X -= num35;
                }
            }

            if (NPC.velocity.Y < vector2.Y) {
                NPC.velocity.Y += num35;
                if (NPC.velocity.Y < 0f && vector2.Y > 0f) {
                    NPC.velocity.Y += num35;
                }
            }
            else if (NPC.velocity.Y > vector2.Y) {
                NPC.velocity.Y -= num35;
                if (NPC.velocity.Y > 0f && vector2.Y < 0f) {
                    NPC.velocity.Y -= num35;
                }
            }

            if (NPC.ai[2] == 0f) {
                SoundEngine.PlaySound(SoundID.Zombie20, center);
            }

            if (NPC.ai[2] % num34 == 0f) {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.Center);
                if (Main.netMode != NetmodeID.MultiplayerClient) {
                    var vector3 = Vector2.Normalize(player.Center - center) * (NPC.width + 20) / 2f + center;
                    NPC.NewNPC(NPC.GetSource_FromAI(),(int)vector3.X, (int)vector3.Y + 45, NPCType<SoapBubble>());
                }
            }

            int num19 = Math.Sign(player.Center.X - center.X);
            if (num19 != 0) {
                NPC.direction = num19;
                if (NPC.spriteDirection != -NPC.direction) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.spriteDirection = -NPC.direction;
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num33) {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 3f) {
            NPC.velocity *= 0.98f;
            NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
            if (NPC.ai[2] == num36 - 30) {
                SoundEngine.PlaySound(SoundID.Zombie9, center);
            }

            if (Main.netMode != NetmodeID.MultiplayerClient && NPC.ai[2] == num36 - 30) {
                var vector4 = NPC.rotation.ToRotationVector2() * (Vector2.UnitX * NPC.direction) * (NPC.width + 20) / 2f + center;
                Projectile.NewProjectile(NPC.GetSource_FromAI(),vector4.X, vector4.Y, NPC.direction * 2, 8f, ProjectileType<YoungDukeSharknadoBolt>(), 0, 0f, Main.myPlayer);
                Projectile.NewProjectile(NPC.GetSource_FromAI(),vector4.X, vector4.Y, -NPC.direction * 2, 8f, ProjectileType<YoungDukeSharknadoBolt>(), 0, 0f, Main.myPlayer);
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num36) {
                NPC.ai[0] = 0f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 4f) {
            NPC.velocity *= 0.98f;
            NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
            if (NPC.ai[2] == num2 - 60) {
                SoundEngine.PlaySound(SoundID.Zombie20, center);
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num2) {
                NPC.ai[0] = 5f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 5f && !player.dead) {
            if (NPC.ai[1] == 0f) {
                NPC.ai[1] = 300 * Math.Sign((center - player.Center).X);
            }

            var vector5 = Vector2.Normalize(player.Center + new Vector2(NPC.ai[1], -200f) - center - NPC.velocity) * scaleFactor;
            if (NPC.velocity.X < vector5.X) {
                NPC.velocity.X += num23;
                if (NPC.velocity.X < 0f && vector5.X > 0f) {
                    NPC.velocity.X += num23;
                }
            }
            else if (NPC.velocity.X > vector5.X) {
                NPC.velocity.X -= num23;
                if (NPC.velocity.X > 0f && vector5.X < 0f) {
                    NPC.velocity.X -= num23;
                }
            }

            if (NPC.velocity.Y < vector5.Y) {
                NPC.velocity.Y += num23;
                if (NPC.velocity.Y < 0f && vector5.Y > 0f) {
                    NPC.velocity.Y += num23;
                }
            }
            else if (NPC.velocity.Y > vector5.Y) {
                NPC.velocity.Y -= num23;
                if (NPC.velocity.Y > 0f && vector5.Y < 0f) {
                    NPC.velocity.Y -= num23;
                }
            }

            int num20 = Math.Sign(player.Center.X - center.X);
            if (num20 != 0) {
                if (NPC.ai[2] == 0f && num20 != NPC.direction) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.direction = num20;
                if (NPC.spriteDirection != -NPC.direction) {
                    NPC.rotation += (float)Math.PI;
                }

                NPC.spriteDirection = -NPC.direction;
            }

            NPC.ai[2] += 1f;
            if (!(NPC.ai[2] >= num12)) {
                return;
            }

            int num21 = 0;
            switch ((int)NPC.ai[3]) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    num21 = 1;
                    break;

                case 6:
                    NPC.ai[3] = 1f;
                    num21 = 2;
                    break;

                case 7:
                    NPC.ai[3] = 0f;
                    num21 = 3;
                    break;
            }

            if (flag2) {
                num21 = 4;
            }

            switch (num21) {
                case 1:
                    NPC.ai[0] = 6f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.velocity = Vector2.Normalize(player.Center - center) * num32;
                    NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
                    if (num20 != 0) {
                        NPC.direction = num20;
                        if (NPC.spriteDirection == 1) {
                            NPC.rotation += (float)Math.PI;
                        }

                        NPC.spriteDirection = -NPC.direction;
                    }

                    break;

                case 2:
                    NPC.velocity = Vector2.Normalize(player.Center - center) * scaleFactor4;
                    NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
                    if (num20 != 0) {
                        NPC.direction = num20;
                        if (NPC.spriteDirection == 1) {
                            NPC.rotation += (float)Math.PI;
                        }

                        NPC.spriteDirection = -NPC.direction;
                    }

                    NPC.ai[0] = 7f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;

                case 3:
                    NPC.ai[0] = 8f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;

                case 4:
                    NPC.ai[0] = 9f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    break;
            }

            NPC.netUpdate = true;
        }
        else if (NPC.ai[0] == 6f) {
            int num22 = 7;
            for (int k = 0; k < num22; k++) {
                var value8 = (Vector2.Normalize(NPC.velocity) * new Vector2((NPC.width + 50) / 2f, NPC.height) * 0.75f).RotatedBy((k - (num22 / 2 - 1)) * Math.PI / (float)num22) + center;
                var value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                int num24 = Dust.NewDust(value8 + value4, 0, 0, 172, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num24].noGravity = true;
                Main.dust[num24].noLight = true;
                Main.dust[num24].velocity /= 4f;
                Main.dust[num24].velocity -= NPC.velocity;
            }

            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num31) {
                NPC.ai[0] = 5f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.ai[3] += 2f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 7f) {
            if (NPC.ai[2] == 0f) {
                SoundEngine.PlaySound(SoundID.Zombie20, center);
            }

            if (NPC.ai[2] % num6 == 0f) {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.Center);
                if (Main.netMode != NetmodeID.MultiplayerClient) {
                    var vector6 = Vector2.Normalize(NPC.velocity) * (NPC.width + 20) / 2f + center;
                    int num25 = NPC.NewNPC(NPC.GetSource_FromAI(),(int)vector6.X, (int)vector6.Y + 45, NPCType<SoapBubble>());
                    Main.npc[num25].target = NPC.target;
                    Main.npc[num25].velocity = Vector2.Normalize(NPC.velocity).RotatedBy((float)Math.PI / 2f * NPC.direction) * scaleFactor3;
                    Main.npc[num25].netUpdate = true;
                }
            }

            NPC.velocity = NPC.velocity.RotatedBy((0f - num7) * NPC.direction);
            NPC.rotation -= num7 * NPC.direction;
            NPC.ai[2] += 1f;
            if (NPC.ai[2] >= num5) {
                NPC.ai[0] = 5f;
                NPC.ai[1] = 0f;
                NPC.ai[2] = 0f;
                NPC.netUpdate = true;
            }
        }
        else if (NPC.ai[0] == 8f) {
            NPC.velocity *= 0.98f;
            NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
            if (NPC.ai[2] == num36 - 30) {
                SoundEngine.PlaySound(SoundID.Zombie20, center);
            }

            if (Main.netMode != NetmodeID.MultiplayerClient && NPC.ai[2] == num36 - 30) {
                //float gasterdirection = -2f;
                /*if (player.position.Y > npc.position.Y)
                {
                    gasterdirection = 2f;
                }*/
                NPC.NewNPC(NPC.GetSource_FromAI(),(int)center.X, (int)center.Y, NPCType<GasterBlaster>());
                if (NPC.ai[2] >= num36) {
                    NPC.ai[0] = 5f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.netUpdate = true;
                }
            }
            else if (NPC.ai[0] == 9f) {
                if (NPC.ai[2] < num3 - 90) {
                    if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height)) {
                        NPC.alpha += 15;
                    }
                    else {
                        NPC.alpha -= 15;
                    }

                    if (NPC.alpha < 0) {
                        NPC.alpha = 0;
                    }

                    if (NPC.alpha > 150) {
                        NPC.alpha = 150;
                    }
                }

                NPC.velocity *= 0.98f;
                NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
                if (NPC.ai[2] == num3 - 60) {
                    SoundEngine.PlaySound(SoundID.Zombie20, center);
                }

                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num3) {
                    NPC.ai[0] = 10f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.netUpdate = true;
                }
            }
            else if (NPC.ai[0] == 10f && !player.dead) {
                NPC.dontTakeDamage = false;
                NPC.chaseable = false;
                if (NPC.alpha < 255) {
                    NPC.alpha += 25;
                    if (NPC.alpha > 255) {
                        NPC.alpha = 255;
                    }
                }

                if (NPC.ai[1] == 0f) {
                    NPC.ai[1] = 360 * Math.Sign((center - player.Center).X);
                }

                var desiredVelocity = Vector2.Normalize(player.Center + new Vector2(NPC.ai[1], -200f) - center - NPC.velocity) * scaleFactor;
                SimpleFlyMovement(desiredVelocity, num23);
                int num26 = Math.Sign(player.Center.X - center.X);
                if (num26 != 0) {
                    if (NPC.ai[2] == 0f && num26 != NPC.direction) {
                        NPC.rotation += (float)Math.PI;
                        for (int l = 0; l < NPC.oldPos.Length; l++) {
                            NPC.oldPos[l] = Vector2.Zero;
                        }
                    }

                    NPC.direction = num26;
                    if (NPC.spriteDirection != -NPC.direction) {
                        NPC.rotation += (float)Math.PI;
                    }

                    NPC.spriteDirection = -NPC.direction;
                }

                NPC.ai[2] += 1f;
                if (!(NPC.ai[2] >= num12)) {
                    return;
                }

                int num27 = 0;
                switch ((int)NPC.ai[3]) {
                    case 0:
                    case 2:
                    case 3:
                    case 5:
                    case 6:
                    case 7:
                        num27 = 1;
                        break;

                    case 1:
                    case 4:
                    case 8:
                        num27 = 2;
                        break;
                }

                switch (num27) {
                    case 1:
                        NPC.ai[0] = 11f;
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                        NPC.velocity = Vector2.Normalize(player.Center - center) * num32;
                        NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
                        if (num26 != 0) {
                            NPC.direction = num26;
                            if (NPC.spriteDirection == 1) {
                                NPC.rotation += (float)Math.PI;
                            }

                            NPC.spriteDirection = -NPC.direction;
                        }

                        break;

                    case 2:
                        NPC.ai[0] = 12f;
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                        break;

                    case 3:
                        NPC.ai[0] = 13f;
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                        break;
                }

                NPC.netUpdate = true;
            }
            else if (NPC.ai[0] == 11f) {
                NPC.dontTakeDamage = false;
                NPC.chaseable = true;
                NPC.alpha -= 25;
                if (NPC.alpha < 0) {
                    NPC.alpha = 0;
                }

                int num28 = 7;
                for (int m = 0; m < num28; m++) {
                    var value9 = (Vector2.Normalize(NPC.velocity) * new Vector2((NPC.width + 50) / 2f, NPC.height) * 0.75f).RotatedBy((m - (num28 / 2 - 1)) * Math.PI / (float)num28) + center;
                    var value5 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num29 = Dust.NewDust(value9 + value5, 0, 0, 172, value5.X * 2f, value5.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num29].noGravity = true;
                    Main.dust[num29].noLight = true;
                    Main.dust[num29].velocity /= 4f;
                    Main.dust[num29].velocity -= NPC.velocity;
                }

                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num31) {
                    NPC.ai[0] = 10f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] += 1f;
                    NPC.netUpdate = true;
                }
            }
            else if (NPC.ai[0] == 12f) {
                NPC.dontTakeDamage = true;
                NPC.chaseable = false;
                if (NPC.alpha < 255) {
                    NPC.alpha += 17;
                    if (NPC.alpha > 255) {
                        NPC.alpha = 255;
                    }
                }

                NPC.velocity *= 0.98f;
                NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
                if (NPC.ai[2] == num4 / 2) {
                    SoundEngine.PlaySound(SoundID.Zombie20, center);
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && NPC.ai[2] == num4 / 2) {
                    if (NPC.ai[1] == 0f) {
                        NPC.ai[1] = 300 * Math.Sign((center - player.Center).X);
                    }

                    var vector7 = player.Center + new Vector2(0f - NPC.ai[1], -200f);
                    var vector9 = NPC.Center = vector7;
                    center = vector9;
                    int num30 = Math.Sign(player.Center.X - center.X);
                    if (num30 != 0) {
                        if (NPC.ai[2] == 0f && num30 != NPC.direction) {
                            NPC.rotation += (float)Math.PI;
                            for (int n = 0; n < NPC.oldPos.Length; n++) {
                                NPC.oldPos[n] = Vector2.Zero;
                            }
                        }

                        NPC.direction = num30;
                        if (NPC.spriteDirection != -NPC.direction) {
                            NPC.rotation += (float)Math.PI;
                        }

                        NPC.spriteDirection = -NPC.direction;
                    }
                }

                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num4) {
                    NPC.ai[0] = 10f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] += 1f;
                    if (NPC.ai[3] >= 9f) {
                        NPC.ai[3] = 0f;
                    }

                    NPC.netUpdate = true;
                }
            }
            else if (NPC.ai[0] == 13f) {
                if (NPC.ai[2] == 0f) {
                    SoundEngine.PlaySound(SoundID.Zombie20, center);
                }

                NPC.velocity = NPC.velocity.RotatedBy((0f - num7) * NPC.direction);
                NPC.rotation -= num7 * NPC.direction;
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num5) {
                    NPC.ai[0] = 10f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] += 1f;
                    NPC.netUpdate = true;
                }
            }
        }
    }
}