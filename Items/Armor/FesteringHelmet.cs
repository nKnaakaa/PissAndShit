using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class FesteringHelmet : ModItem
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();
        DisplayName.SetDefault("Festering Helmet");
        Tooltip.SetDefault("it smells like poop." + "\nGives a ton of DR and defense'");
    }

    public override void SetDefaults() {
        Item.width = 18;
        Item.height = 18;
        Item.value = 10000;
        Item.rare = ItemRarityID.Purple;
        Item.defense = 60;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs) {
        return body.type == ItemType<FesteringBreastPlate>() && legs.type == ItemType<FesteringLeggings>();
    }

    public override void UpdateEquip(Player player) {
        player.statDefense += 125;
        player.endurance += 110;
    }

    public override void UpdateArmorSet(Player player) {
        player.statLifeMax2 += 500;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.SolarFlareHelmet);
        recipe.AddIngredient(ItemID.NebulaHelmet);
        recipe.AddIngredient(ItemID.StardustHelmet);
        recipe.AddIngredient(ItemID.VortexHelmet);
        recipe.AddIngredient(ItemID.LunarBar, 100);
        recipe.AddTile(TileID.LunarCraftingStation);
        recipe.Register();
    }
}