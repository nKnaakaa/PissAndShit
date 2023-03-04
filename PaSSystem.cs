using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using PissAndShit.NPCs;
using PissAndShit.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace PissAndShit;

public class PaSSystem : ModSystem
{
    public static bool downedGodSlime;
    public static bool downedGrandDad;
    public static bool downedYoungDuke;
    public static bool downedBoozeshrume;
    public static bool downedVendingMachine;
    public static bool downedHive;
    public static bool endlessModeSave;
    public static bool endlesserModeSave;
    public static int deathHandNPCType;
    public static int deathHandNPCIdentifier;
    private UserInterface _deathHandDamageUI;
    private UserInterface _deathHandPanelDraw;
    internal DeathHandDamagePanel deathHandDamageUI;

    internal DeathHandPanelDraw deathHandPanelDraw;

    public override void Load() {
        if (Main.dedServ) {
            return;
        }

        deathHandPanelDraw = new DeathHandPanelDraw();
        deathHandPanelDraw.Activate();
        _deathHandPanelDraw = new UserInterface();
        _deathHandPanelDraw.SetState(null); // change null to DeathHandPanelDraw to open the death hand's main UI on spawn, disabled for a reason
        deathHandDamageUI = new DeathHandDamagePanel();
        deathHandDamageUI.Activate();
        _deathHandDamageUI = new UserInterface();
        _deathHandDamageUI.SetState(null); // change null to DeathHandDamageUI to open the death hand damage button's UI on spawn, disabled for a reason
    }


    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) /* tModPorter Note: Removed. Use ModSystem.ModifyInterfaceLayers */ {
        int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseTextIndex != -1) {
            layers.Insert(
                mouseTextIndex,
                new LegacyGameInterfaceLayer(
                    "The Funny Community Made Content Mod: Now 200% Better!",
                    delegate {
                        _deathHandPanelDraw.Draw(Main.spriteBatch, new GameTime());
                        _deathHandDamageUI.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                )
            );
        }
    }

    public override void UpdateUI(GameTime gameTime) /* tModPorter Note: Removed. Use ModSystem.UpdateUI */ {
        _deathHandPanelDraw?.Update(gameTime);
        _deathHandDamageUI?.Update(gameTime);
    }

    public override void OnWorldLoad() /* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */ {
        downedGodSlime = false;
        downedGrandDad = false;
        downedYoungDuke = false;
        downedBoozeshrume = false;
        downedVendingMachine = false;
        downedHive = false;
        endlessModeSave = false;
        endlesserModeSave = false;
        deathHandNPCType = 0;
        deathHandNPCIdentifier = 0;
    }

    public override void SaveWorldData(TagCompound tag) /* tModPorter Suggestion: Edit tag parameter instead of returning new TagCompound */ {
        var Downed = new List<string>();
        var Modes = new List<string>();

        if (downedGodSlime) {
            Downed.Add("godSlime");
        }

        if (downedGrandDad) {
            Downed.Add("grandDad");
        }

        if (downedYoungDuke) {
            Downed.Add("youngDuke");
        }

        if (downedBoozeshrume) {
            Downed.Add("boozeshrume");
        }

        if (downedVendingMachine) {
            Downed.Add("vendingMachine");
        }

        if (downedHive) {
            Downed.Add("hive");
        }

        if (endlessModeSave) {
            Modes.Add("endlessModeSave");
        }

        if (endlesserModeSave) {
            Modes.Add("endlesserModeSave");
        }
    }

    public override void LoadWorldData(TagCompound tag) {
        var Downed = tag.GetList<string>("Downed");
        var Modes = tag.GetList<string>("Modes");

        downedGodSlime = Downed.Contains("godSlime");
        downedGrandDad = Downed.Contains("grandDad");
        downedYoungDuke = Downed.Contains("youngDuke");
        downedBoozeshrume = Downed.Contains("boozeshrume");
        downedVendingMachine = Downed.Contains("vendingMachine");
        downedHive = Downed.Contains("hive");
        endlessModeSave = Modes.Contains("endlessModeSave");
        endlesserModeSave = Modes.Contains("endlesserModeSave");
    }

    public override void NetSend(BinaryWriter writer) {
        var downedFlags0 = new BitsByte();
        var miscFlags0 = new BitsByte();

        downedFlags0[0] = downedGodSlime;
        downedFlags0[1] = downedGrandDad;
        downedFlags0[2] = downedYoungDuke;
        downedFlags0[3] = downedBoozeshrume;
        downedFlags0[4] = downedHive;
        downedFlags0[5] = downedVendingMachine;
        miscFlags0[0] = endlessModeSave;
        miscFlags0[1] = endlesserModeSave;

        writer.Write(downedFlags0);
        writer.Write(miscFlags0);
    }

    public override void NetReceive(BinaryReader reader) {
        BitsByte downedFlags0 = reader.ReadByte();
        BitsByte miscFlags0 = reader.ReadByte();

        downedGodSlime = downedFlags0[0];
        downedGrandDad = downedFlags0[1];
        downedYoungDuke = downedFlags0[2];
        downedBoozeshrume = downedFlags0[3];
        downedHive = downedFlags0[4];
        endlessModeSave = miscFlags0[0];
        endlesserModeSave = miscFlags0[0];
    }

    public override void PostUpdateWorld() {
        PaSGlobalNPC.hardDifficulty = endlessModeSave;
        PaSGlobalNPC.endlesserMode = endlesserModeSave;
    }
}