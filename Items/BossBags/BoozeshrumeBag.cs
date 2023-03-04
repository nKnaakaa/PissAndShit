using PissAndShit.Items.Accessories;
using PissAndShit.Items.Misc;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags;

public class BoozeshrumeBag : ModItem
{
    public override int BossBagNPC => ModContent.NPCType<boozeshrume>();

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Treasure Bag");
        Tooltip.SetDefault("<right> to open");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 30;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.rare = ItemRarityID.Expert;
        Item.expert = true;
    }

    public override void OpenBossBag(Player player) {
        int bossWeapon = Main.rand.Next(4);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.GoldCoin, 60);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BoozeExpertItem>(), 1);
        player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix>(), 3);
        if (bossWeapon == 0) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BeerBook>(), 1);
        }

        if (bossWeapon == 1) {
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<BeerBow>(), 1);
        }

        if (bossWeapon == 2) { }

        if (bossWeapon == 3) { }
    }
}