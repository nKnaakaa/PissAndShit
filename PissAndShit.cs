using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using PissAndShit.Items.Accessories;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Consumables;
using PissAndShit.Items.Misc;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace PissAndShit;

public class PissAndShit : Mod
{
    private Mod bossChecklist;
    private Mod FargosMutantMod;

    public override void PostSetupContent() {
        bool hasChecklist = ModLoader.TryGetMod("BossChecklist", out bossChecklist);
        if (hasChecklist) {
            bossChecklist.Call(
                "AddBoss",
                5.5f,
                NPCType<YoungDuke>(),
                this,
                "Young Duke",
                (Func<bool>)(() => PaSSystem.downedYoungDuke),
                ItemType<YoungWorm>(),
                new List<int> {
                },
                new List<int> {
                    ItemType<YoungBow>(),
                    ItemType<YoungGun>(),
                    ItemType<youngdukeyoyo>(),
                    ItemType<YoungRazorTyphoon>()
                },
                "Spawn by using [i:" + ItemType<YoungWorm>() + "] at the Ocean.",
                "Young Duke has outsped everyone!",
                "PissAndShit/NPCs/Bosses/YoungDuke_Still",
                "PissAndShit/NPCs/Bosses/YoungDuke_Head_Boss"
            );

            bossChecklist.Call(
                "AddBoss",
                6.5f,
                NPCType<boozeshrume>(),
                this,
                "boozeshrume.exe",
                (Func<bool>)(() => PaSSystem.downedBoozeshrume),
                ItemType<SuspiciousAle>(),
                new List<int> {
                },
                new List<int> {
                    ItemType<BoozeshrumeBag>(),
                    ItemType<ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix>(),
                    ItemType<BeerBook>(),
                    ItemType<BeerBow>()
                },
                "Spawn by using [i:" + ItemType<SuspiciousAle>() + "].",
                "boozeshrume.exe has completed successfully.",
                "PissAndShit/NPCs/Bosses/boozeshrume",
                "PissAndShit/NPCs/Bosses/boozeshrume_Head_Boss"
            );

            bossChecklist.Call(
                "AddBoss",
                16f,
                NPCType<GrandDad>(),
                this,
                "Grand Dad",
                (Func<bool>)(() => PaSSystem.downedGrandDad),
                ItemType<Mario7>(),
                new List<int> {
                },
                new List<int> {
                    ItemType<GrandDadBag>(),
                    ItemType<the7>(),
                    ItemType<DaedalusSevenbow>(),
                    ItemType<SevenShortsword>()
                },
                "Spawn by using [i:" + ItemType<Mario7>() + "].",
                "Grand Dad has turned everyone into flint and stones...",
                "PissAndShit/NPCs/Bosses/GrandDad_Still",
                "PissAndShit/NPCs/Bosses/GrandDad_Head_Boss"
            );

            bossChecklist.Call(
                "AddBoss",
                15f,
                NPCType<Hive>(),
                this,
                "Hive",
                (Func<bool>)(() => PaSSystem.downedHive),
                ItemType<HiveSummon>(),
                0,
                new List<int> {
                    ItemType<HiveBag>(),
                    ItemType<BeeBook>(),
                    ItemType<BeeBasher>(),
                    ItemType<BeeTime>()
                },
                "Spawn by using [i:" + ItemType<HiveSummon>() + "].",
                "The Hive's minions have stung everyone to death...",
                "PissAndShit/NPCs/Bosses/Hive",
                "PissAndShit/NPCs/Bosses/Hive_Head_Boss"
            );

            bossChecklist.Call(
                "AddBoss",
                15.5f,
                NPCType<GodSlime>(),
                this,
                "God Slime",
                (Func<bool>)(() => PaSSystem.downedGodSlime),
                ItemType<HeavenlyChalice>(),
                0,
                new List<int> {
                    ItemType<GodSlimeTreasureBag>(),
                    ItemType<GodlyCross>(),
                    ItemType<HolyShower>(),
                    ItemType<GodSlimesGel>(),
                    23
                },
                "Spawn by using [i:" + ItemType<HeavenlyChalice>() + "].",
                "God Slime has vibed everybody to death.",
                "PissAndShit/NPCs/Bosses/GodSlime_Still",
                "PissAndShit/NPCs/Bosses/GodSlime_Head_Boss"
            );
        }

        bool hasFargos = ModLoader.TryGetMod("Fargowiltas", out FargosMutantMod);
        if (hasFargos) {
            FargosMutantMod.Call("AddSummon", 5.5f, "PissAndShit", "YoungWorm", (Func<bool>)(() => PaSSystem.downedYoungDuke), 150000);
            FargosMutantMod.Call("AddSummon", 6.5f, "PissAndShit", "SuspiciousAle", (Func<bool>)(() => PaSSystem.downedBoozeshrume), 300000);
            FargosMutantMod.Call("AddSummon", 16f, "PissAndShit", "HeavenlyChalice", (Func<bool>)(() => PaSSystem.downedGodSlime), 12000000);
            FargosMutantMod.Call("AddSummon", 15f, "PissAndShit", "HiveSummon", (Func<bool>)(() => PaSSystem.downedHive), 1);
            FargosMutantMod.Call("AddSummon", 17f, "PissAndShit", "GrandDad", (Func<bool>)(() => PaSSystem.downedGrandDad), 42000000);
        }
    }

    public override void Unload() {
        bossChecklist = null;
        FargosMutantMod = null;
    }
}