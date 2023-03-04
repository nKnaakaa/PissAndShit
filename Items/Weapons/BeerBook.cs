using PissAndShit.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BeerBook : ModItem

{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Beer Book");
        Tooltip.SetDefault("Use this to make your enemies drunk");
    }

    public override void SetDefaults() {
        Item.damage = 44;
        Item.width = 15;
        Item.height = 15;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 8;
        Item.value = 9200;
        Item.rare = ItemRarityID.Pink;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<beertwo>();
        Item.shootSpeed = 8f;
    }
}