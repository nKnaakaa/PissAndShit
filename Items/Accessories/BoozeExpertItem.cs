using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories;

public class BoozeExpertItem : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("True Terra Ale of Truth and Power 2: Revenge of the Sith");
        Tooltip.SetDefault("Just dont get hit lol");
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(gold: 25);
        Item.rare = ItemRarityID.Expert;
        Item.accessory = true;
        Item.expert = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.GetDamage(DamageClass.Generic) *= 10;
        if (player.statLife < player.statLifeMax) {
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " got too drunk"), 10000, 1);
        }
    }
}