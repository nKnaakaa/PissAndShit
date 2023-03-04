using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class the7 : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("7");
        Tooltip.SetDefault("7");
    }

    public override void SetDefaults() {
        Item.width = 66;
        Item.height = 78;
        Item.rare = ItemRarityID.Expert;
        Item.damage = 1000000000;
        Item.crit = 1000;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
        Item.useTime = 3;
        Item.useAnimation = 3;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.scale = 3;
        Item.expert = true;
    }
}