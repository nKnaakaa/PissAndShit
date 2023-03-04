using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class Mario7 : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Mario 7");
        Tooltip.SetDefault("Summons the 7 god himself");
    }

    public override void SetDefaults() {
        Item.width = 198;
        Item.height = 51;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Red;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(ModContent.NPCType<GrandDad>());
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<GrandDad>());
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.LunarBar, 20);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }
}