using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class GoodBow : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Good Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
        Tooltip.SetDefault("Tip: It's good\nDoes more than it says");
    }

    public override void SetDefaults() {
        Item.damage = 1;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 26;
        Item.height = 26;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.channel = true; //Channel so that you can held the weapon [Important]
        Item.knockBack = 8;
        Item.autoReuse = true;
        Item.value = Item.sellPrice(silver: 50000);
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item9;
        Item.shoot = ProjectileID.WoodenArrowFriendly;
        Item.shootSpeed = 15f;
        Item.useAmmo = AmmoID.Arrow;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.LunarBar, 50);
        recipe.AddIngredient(ItemID.Phantasm);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }

    public override bool CanUseItem(Player player) {
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        type = 0;
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        var perturbedSpeed = new Vector2(speedX, speedY); // 30 degree spread.
        int projectile = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Main.rand.Next(1, 711), 1500, knockBack, player.whoAmI);
        Main.projectile[projectile].hostile = false;
        Main.projectile[projectile].friendly = true;
        return true;
    }
}