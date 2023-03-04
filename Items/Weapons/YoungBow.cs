using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class YoungBow : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("High Tide");
        Tooltip.SetDefault("'The Young Duke's wrath eminates from this bow'");
    }

    public override void SetDefaults() {
        Item.CloneDefaults(ItemID.Tsunami);
        Item.damage = 15;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 28;
        Item.height = 58;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true; //so the item's animation doesn't do damage
        Item.value = 23000;
        Item.rare = ItemRarityID.Green;
        Item.autoReuse = false;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.useAmmo = AmmoID.Arrow;
        Item.UseSound = SoundID.Item5;
        Item.shootSpeed = 19f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
        for (int i = 0; i < numberProjectiles; i++) {
            float speedX = velocity.X;
            float speedY = velocity.Y;
            float knockBack = knockback;
            var perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
            // If you want to randomize the speed to stagger the projectiles
            // float scale = 1f - (Main.rand.NextFloat() * .3f);
            // perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        }

        return false; // return false because we don't want tmodloader to shoot projectile
    }
}