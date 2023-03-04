using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Body)]
public class GodSlimeCostumeBody : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("God Slime Chain Mail");
        Tooltip.SetDefault("The holy slime is with you\nPart of efcawesome's dev set");
    }

    public override void SetDefaults() {
        Item.width = 24;
        Item.height = 24;
        Item.vanity = true;
        Item.rare = ItemRarityID.Red;
        Item.maxStack = 1;
    }
}