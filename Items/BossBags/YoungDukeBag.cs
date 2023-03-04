using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags;

public class YoungDukeBag : ModItem
{
    public override int BossBagNPC => ModContent.NPCType<YoungDuke>();

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
        int bossWeapon = Main.rand.Next(5);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.GoldCoin, 30);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.HealingPotion, Main.rand.Next(5, 10));
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<YoungFishronWings>(), 1);
        if (bossWeapon == 0) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<YoungRazorTyphoon>());
        }

        if (bossWeapon == 1) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<YoungBow>());
        }

        if (bossWeapon == 2) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<youngdukeyoyo>());
        }

        if (bossWeapon == 3) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<YoungGun>());
        }
    }
}