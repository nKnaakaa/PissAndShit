using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class EndlesserModeItem : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Endlesser Mode");
        Tooltip.SetDefault("Use only if you are a true gamer\nMakes bosses even more difficult\nCan only be used while endless mode is active");
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
        return PaSSystem.endlessModeSave;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        if (!PaSSystem.endlesserModeSave) {
            PaSGlobalNPC.endlesserMode = PaSSystem.endlesserModeSave = true;
            Main.NewText("Turn back before its too late", 48, 0, 2);
        }
        else {
            PaSGlobalNPC.endlesserMode = PaSSystem.endlesserModeSave = false;
            Main.NewText("You may have strayed from the path, but you are back on it again", 212, 38, 45);
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}