using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets;

[AutoloadEquip(EquipType.Legs)]
public class DevShardionLegs : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Shardion's Burning Bolters");
        Tooltip.SetDefault("'Run awaaaaay!'");
    }

    public override void SetDefaults() {
        Item.width = 22;
        Item.height = 18;
        Item.vanity = true;
        Item.rare = -12;
    }
}