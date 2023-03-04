using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class youngdukeyoyo : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Hurricane");
        Tooltip.SetDefault("Incredible Speed and Strength, Also Wet.");

        // These are all related to gamepad controls and don't seem to affect anything else
        ItemID.Sets.Yoyo[Item.type] = true;
        ItemID.Sets.GamepadExtraRange[Item.type] = 15;
        ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
    }

    public override void SetDefaults() {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 26;
        Item.height = 30;
        Item.useAnimation = 25;
        Item.useTime = 20;
        Item.shootSpeed = 16f;
        Item.knockBack = 4.5f;
        Item.damage = 40;
        Item.rare = ItemRarityID.Orange;

        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;

        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(silver: 0);
        Item.shoot = ModContent.ProjectileType<youngdukeyoyoproj>();
    }
}