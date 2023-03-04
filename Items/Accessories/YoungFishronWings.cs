using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
public class YoungFishronWings : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Young Fishron Wings");
    }

    public override void SetDefaults() {
        Item.width = 22;
        Item.height = 20;
        Item.value = Item.sellPrice(gold: 1);
        Item.rare = ItemRarityID.Expert;
        Item.accessory = true;
        Item.expert = true;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.wingTimeMax = 60;
    }

    public override void VerticalWingSpeeds(
        Player player,
        ref float ascentWhenFalling,
        ref float ascentWhenRising,
        ref float maxCanAscendMultiplier,
        ref float maxAscentMultiplier,
        ref float constantAscend
    ) {
        ascentWhenFalling = 0.55f;
        ascentWhenRising = 0.05f;
        maxCanAscendMultiplier = 1f;
        maxAscentMultiplier = 1f;
        constantAscend = 0.135f;
    }

    public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
        speed = 3f;
        acceleration *= 1.1f;
    }
}