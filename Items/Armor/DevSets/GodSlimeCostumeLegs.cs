using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Legs)]
public class GodSlimeCostumeLegs : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("God Slime Pants");
        Tooltip.SetDefault("May the slimes guide your way\nPart of efcawesome's dev set");
    }

    public override void SetDefaults() {
        Item.width = 24;
        Item.height = 24;
        Item.vanity = true;
        Item.rare = ItemRarityID.Red;
        Item.maxStack = 1;
    }
}