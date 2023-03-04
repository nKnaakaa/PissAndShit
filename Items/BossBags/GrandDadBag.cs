using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags;

public class GrandDadBag : ModItem
{
    public override int BossBagNPC => ModContent.NPCType<GrandDad>();

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Treasure Bag");
        Tooltip.SetDefault("<right> to open");
    }

    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 32;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.rare = ItemRarityID.Expert;
        Item.expert = true;
    }

    public override void OpenBossBag(Player player) {
        int bossWeapon = Main.rand.Next(2);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.PlatinumCoin, 100);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.SuperHealingPotion, Main.rand.Next(10, 20));
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<the7>(), 1);
        if (bossWeapon == 0) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<SevenShortsword>(), 1);
        }

        if (bossWeapon == 1) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<DaedalusSevenbow>(), 1);
        }
    }
}