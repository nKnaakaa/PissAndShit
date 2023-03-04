using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons;

public class poop : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Smells like poop");
        DisplayName.SetDefault("Festering Great Blade");
    }

    public override void SetDefaults() {
        Item.damage = 420;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 86;
        Item.height = 80;
        Item.useTime = 1;
        Item.useAnimation = 5;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 30;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.TerraBlade);
        recipe.AddIngredient(ItemID.Meowmere);
        recipe.AddIngredient(ItemID.StarWrath);
        recipe.AddIngredient(ItemID.InfluxWaver);
        recipe.AddIngredient(ItemID.TheHorsemansBlade);
        recipe.AddIngredient(ItemID.Seedler);
        recipe.AddIngredient(ItemID.Starfury);
        recipe.AddIngredient(ItemID.BeeKeeper);
        recipe.AddIngredient(ItemID.EnchantedSword);
        recipe.AddIngredient(ItemID.CopperShortsword);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }
}