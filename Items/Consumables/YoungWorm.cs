using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class YoungWorm : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Truffle Larva");
        Tooltip.SetDefault("use at the ocean unless you have a deathwish");
    }

    public override void SetDefaults() {
        Item.width = 198;
        Item.height = 51;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(ModContent.NPCType<YoungDuke>());
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<YoungDuke>());
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Bone, 20);
        recipe.AddIngredient(ItemID.GlowingMushroom, 20);
        recipe.AddTile(TileID.Hellforge);
        recipe.Register();
    }
}