using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Head)]
public class DevShardionHat : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Shardion's Smissmas Stacker");
        Tooltip.SetDefault("'It makes you fearful'");
    }

    public override void SetDefaults() {
        Item.width = 26;
        Item.height = 23;
        Item.rare = -12;
        Item.vanity = true;
    }
}