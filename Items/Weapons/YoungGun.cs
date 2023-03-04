using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class YoungGun : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Cyclone");
        Tooltip.SetDefault("'This gun embodies the speed of the Young Duke'");
    }

    public override void SetDefaults() {
        Item.CloneDefaults(ItemID.Tsunami);
        Item.damage = 5;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 44;
        Item.height = 32;
        Item.useTime = 2;
        Item.useAnimation = 2;
        Item.UseSound = SoundID.Item11;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true; //so the item's animation doesn't do damage
        Item.value = 23000;
        Item.rare = ItemRarityID.Green;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.useAmmo = AmmoID.Bullet;
        Item.shootSpeed = 19f;
    }

    public override bool CanConsumeAmmo(Item ammo, Player player) {
        return Main.rand.NextFloat() >= .38f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        var perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
        speedX = perturbedSpeed.X;
        speedY = perturbedSpeed.Y;
        return true;
    }
}