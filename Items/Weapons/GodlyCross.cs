using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class GodlyCross : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Godly Cross");
        Tooltip.SetDefault("Rain godly vibes on your enemies");
    }

    public override void SetDefaults() {
        Item.width = 40;
        Item.height = 40;

        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.damage = 780;
        Item.knockBack = 2.5f;
        Item.useTime = 10;
        Item.useAnimation = 25;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.autoReuse = true;
        Item.rare = ItemRarityID.Red;
        Item.shoot = ModContent.ProjectileType<GodlyCrossProj>();
        Item.shootSpeed = 10.5f;
    }

    public override bool
        Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) //This lets you modify the firing of the item
    {
        int spread = 10;
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        float spreadMult = 0.1f;
        for (int i = 0; i < 10; i++) {
            float vX = speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
            float vY = speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;
            Projectile.NewProjectile(source, position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
        }

        return false;
    }
}