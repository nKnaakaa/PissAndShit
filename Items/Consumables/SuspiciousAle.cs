using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables;

public class SuspiciousAle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Suspsicious Looking Ale");
        Tooltip.SetDefault("Summons the drunken shroom");
    }

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 79;
        Item.maxStack = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.consumable = true;
        Item.rare = ItemRarityID.Red;
    }

    public override bool CanUseItem(Player player) {
        return !NPC.AnyNPCs(ModContent.NPCType<boozeshrume>());
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        SoundEngine.PlaySound(SoundID.WormDig, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<boozeshrume>());
        }

        return true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Ale, 20);
        recipe.AddIngredient(ItemID.SoulofLight, 10);
        recipe.AddIngredient(ItemID.SoulofNight, 10);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
    }
}