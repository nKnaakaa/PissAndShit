using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class WrenchMK2 : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Wrench MK2");
    }

    public override void SetDefaults() {
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.autoReuse = true;
        Item.useTurn = false;
        Item.width = 30;
        Item.height = 30;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.damage = 30;
        Item.knockBack = 2f;
        Item.value = Item.sellPrice(silver: 80);
        Item.rare = ItemRarityID.LightRed; // Not on VS so rip intelisense
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
    }
}