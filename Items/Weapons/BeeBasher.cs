using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BeeBasher : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Bee Basher");
        Tooltip.SetDefault("Bonk");
    }

    public override void SetDefaults() {
        Item.damage = 5000;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 180;
        Item.height = 180;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 99;
        Item.value = 9200;
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }
}