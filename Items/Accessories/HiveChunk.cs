using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories;

public class HiveChunk : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Hive Chunk");
        Tooltip.SetDefault("Gives permanent honey buff\n+250 max life\n+50 defense");
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(gold: 50);
        Item.rare = ItemRarityID.Expert;
        Item.accessory = true;
        Item.expert = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.AddBuff(BuffID.Honey, 10, false);
        player.statLifeMax2 += 250;
        player.statDefense += 50;
    }
}