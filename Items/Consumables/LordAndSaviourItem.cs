using PissAndShit.NPCs;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables;

public class LordAndSaviourItem : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("???");
        Tooltip.SetDefault("Summons our Lord and Saviour");
    }

    public override void SetDefaults() {
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.width = 32;
        Item.height = 32;
        Item.rare = -12;
        Item.consumable = true;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        NPC.SpawnOnPlayer(player.whoAmI, NPCType<LordAndSaviour>());
        SoundEngine.PlaySound(SoundID.Roar, player.position);
        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.Register();
    }
}