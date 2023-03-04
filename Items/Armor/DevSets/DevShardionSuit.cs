using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Body)]
public class DevShardionSuit : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Shardion's Scorching Suit");
        Tooltip.SetDefault("'Imagine having power over Death while wearing this'");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 18;
        Item.vanity = true;
        Item.rare = -12;
    }
}