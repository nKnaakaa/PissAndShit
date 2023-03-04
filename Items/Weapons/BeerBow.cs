using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class BeerBow : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("BEER");
    }

    public override void SetDefaults() {
        Item.damage = 60;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 26;
        Item.height = 68;
        Item.useTime = 5;
        Item.useAnimation = 5;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true; //so the item's animation doesn't do damage
        Item.knockBack = 4.2f;
        Item.value = 48000;
        Item.rare = ItemRarityID.LightPurple;
        Item.UseSound = SoundID.Item34;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.Ale;
        Item.shootSpeed = 21f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        int numberProjectiles = 7;
        for (int i = 0; i < numberProjectiles; i++) {
            var perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
        }

        return false;
    }
}