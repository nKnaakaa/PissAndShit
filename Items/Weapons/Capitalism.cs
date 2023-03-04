using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons;

public class Capitalism : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Capitalism");
        Tooltip.SetDefault("Big and shinny and strong and epic and shinny");
    }

    public override void SetDefaults() {
        Item.width = 118;
        Item.height = 118;
        Item.rare = ItemRarityID.Lime;
        Item.damage = 100;
        Item.crit = 25;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item4;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.scale = 2;
        Item.autoReuse = true;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
        target.AddBuff(BuffID.Midas, 1200);
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<MoneyBar>(), 10);
        recipe.AddIngredient(ItemID.GoldCoin, 50);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}