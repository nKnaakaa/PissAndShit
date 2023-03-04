using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories;

public class GodSlimesGel : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("God Slime's Gel");
        Tooltip.SetDefault("Makes you jump H I G H");
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
        Player.jumpHeight += 400;
        Player.jumpSpeed += 50;
        player.noFallDmg = true;
    }
}