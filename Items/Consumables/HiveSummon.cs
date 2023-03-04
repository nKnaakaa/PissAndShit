using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class HiveSummon : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("oBEEsity");
        Tooltip.SetDefault("Summons the protector of the bees");
    }

    public override void SetDefaults() {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Red;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(ModContent.NPCType<Hive>());
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Hive>());
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Hive, 50);
        recipe.AddIngredient(ItemID.FragmentNebula, 10);
        recipe.AddIngredient(ItemID.FragmentSolar, 10);
        recipe.AddIngredient(ItemID.FragmentStardust, 10);
        recipe.AddIngredient(ItemID.FragmentVortex, 10);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}