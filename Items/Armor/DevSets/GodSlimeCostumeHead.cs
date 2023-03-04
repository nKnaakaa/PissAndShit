using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Head)]
public class GodSlimeCostumeHead : ModItem
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();
        DisplayName.SetDefault("God Slime Veil");
        Tooltip.SetDefault("Now you can look like a GOD\nPart of efcawesome's dev set");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 32;
        Item.rare = ItemRarityID.Red;
        Item.maxStack = 1;
        Item.vanity = true;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs) {
        return body.type == ModContent.ItemType<GodSlimeCostumeBody>() && legs.type == ModContent.ItemType<GodSlimeCostumeLegs>();
    }

    public override void UpdateArmorSet(Player player) {
        Main.NewText("Full Armor Set");
    }
}