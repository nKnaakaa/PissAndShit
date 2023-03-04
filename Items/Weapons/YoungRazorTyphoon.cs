using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class YoungRazorTyphoon : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Whirlpool");
    }

    public override void SetDefaults() {
        Item.damage = 25;
        Item.DamageType = DamageClass.Magic;
        Item.width = 22;
        Item.height = 24;
        Item.useTime = 15;
        Item.useAnimation = 45;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 0.5f;
        Item.value = Item.sellPrice(gold: 1, silver: 50);
        Item.rare = ItemRarityID.Green;
        Item.mana = 15;
        Item.UseSound = SoundID.Item84;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<YoungTyphoon>();
        Item.shootSpeed = 6;
    }
}