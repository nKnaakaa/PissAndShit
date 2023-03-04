using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class HeavenlyChalice : ModItem
{
    public override void SetDefaults() {
        Item.width = 14;
        Item.height = 20;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Red;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(ModContent.NPCType<GodSlime>());
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<GodSlime>());
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Gel);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}