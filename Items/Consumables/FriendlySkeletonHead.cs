using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class FriendlySkeletonHead : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Friendly Skeleton Head");
        Tooltip.SetDefault("Summons a dungeon guardian to *protect* you");
    }

    public override void SetDefaults() {
        Item.width = 14;
        Item.height = 20;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Gray;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(NPCID.DungeonGuardian);
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, NPCID.DungeonGuardian);
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Bone, 100);
        recipe.AddIngredient(ItemID.ObsidianSkull);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}