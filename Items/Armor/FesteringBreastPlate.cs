using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class FesteringBreastPlate : ModItem
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();
        DisplayName.SetDefault("Festering Breastplate");
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
        player.statDefense += 150;
        player.endurance += 130;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.SolarFlareBreastplate);
        recipe.AddIngredient(ItemID.NebulaBreastplate);
        recipe.AddIngredient(ItemID.StardustBreastplate);
        recipe.AddIngredient(ItemID.VortexBreastplate);
        recipe.AddIngredient(ItemID.LunarBar, 100);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }
}