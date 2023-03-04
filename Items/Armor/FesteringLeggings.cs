using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Legs)]
public class FesteringLeggings : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Festering Leggings");
        Tooltip.SetDefault("it smells like poop." + "\nGives a ton of DR and defense'");
    }

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 18;
        Item.value = 10000;
        Item.rare = ItemRarityID.Purple;
        Item.defense = 60;
    }

    public override void UpdateEquip(Player player) {
        player.statDefense += 135;
        player.endurance += 110;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.SolarFlareLeggings);
        recipe.AddIngredient(ItemID.NebulaLeggings);
        recipe.AddIngredient(ItemID.StardustLeggings);
        recipe.AddIngredient(ItemID.VortexLeggings);
        recipe.AddIngredient(ItemID.LunarBar, 100);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }
}