using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class EndlessModeItem : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Endless Mode");
        Tooltip.SetDefault("Changes all bosses\nCan only be used in expert mode\nHave fun!");
    }

    public override void SetDefaults() {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 1;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = false;
        Item.rare = ItemRarityID.Red;
    }

    public override bool CanUseItem(Player player) {
        return Main.expertMode && !PaSSystem.endlesserModeSave;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        if (!PaSSystem.endlessModeSave) {
            PaSGlobalNPC.hardDifficulty = PaSSystem.endlessModeSave = true;
            Main.NewText("GET READY FOR A CHALLENGE", 135, 16, 22);
        }
        else {
            PaSGlobalNPC.hardDifficulty = PaSSystem.endlessModeSave = false;
            Main.NewText("noob", 48, 248);
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}