using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags;

public class HiveBag : ModItem
{
    public override int BossBagNPC => ModContent.NPCType<Hive>();

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Treasure Bag");
        Tooltip.SetDefault("<right> to open");
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.rare = ItemRarityID.Expert;
        Item.expert = true;
    }

    public override void OpenBossBag(Player player) {
        int bossWeapon = Main.rand.Next(3);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.PlatinumCoin, 5);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.SuperHealingPotion, Main.rand.Next(5, 10));
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<HiveChunk>(), 1);
        if (bossWeapon == 0) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BeeBasher>(), 1);
        }

        if (bossWeapon == 1) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BeeBook>(), 1);
        }

        if (bossWeapon == 2) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BeeTime>(), 1);
        }
    }
}