using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BeeBook : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Bee is death");
    }

    public override void SetDefaults() {
        Item.damage = 3000;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 26;
        Item.height = 68;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true; //so the item's animation doesn't do damage
        Item.knockBack = 4.2f;
        Item.value = 48000;
        Item.rare = ItemRarityID.LightPurple;
        Item.mana = 5;
        Item.UseSound = SoundID.Item34;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.Bee;
        Item.shootSpeed = 21f;
    }
}