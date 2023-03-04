using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class InvisibleSlammer : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Invisible Slammer");
        Tooltip.SetDefault("Now 100% invisible!");
    }

    public override void SetDefaults() {
        Item.damage = 2;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 1;
        Item.height = 1;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 0;
        Item.value = 9200;
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.alpha = 255;
    }
}