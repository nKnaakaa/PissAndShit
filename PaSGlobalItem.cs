using PissAndShit.Items.Armor.DevSets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit;

internal class PaSGlobalItem : GlobalItem
{
    public override void OnCreate(Item item, ItemCreationContext context) {
        base.OnCreate(item, context);
        if (item.type == ItemID.Lens) {
            var player = Main.LocalPlayer;

            if (player.HasItem(ItemID.Lens) && Main.rand.NextBool(6)) {
                Main.NewText("u hav lens, u die now >:]", 43, 255, 10);
                for (int i = 0; i < 4; i++) {
                    NPC.SpawnOnPlayer(player.whoAmI, NPCID.DemonEye);
                }
            }
        }
    }

    public override void OpenVanillaBag(string context, Player player, int arg) {
        if (Main.rand.NextBool(15) && Main.hardMode) {
            int devSetType = Main.rand.Next(3);
            switch (devSetType) {
                case 0:
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<GodSlimeCostumeHead>(), 1);
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<GodSlimeCostumeBody>(), 1);
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<GodSlimeCostumeLegs>(), 1);
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<FlyingCross>(), 1);
                    break;
                case 1:
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<DevShardionHat>(), 1);
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<DevShardionSuit>(), 1);
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<DevShardionLegs>(), 1);
                    break;
                case 2:
                    player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemType<ExitiumHead>(), 1);
                    break;
            }
        }
    }
}