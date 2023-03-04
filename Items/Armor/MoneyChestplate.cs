using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Body)]
public class MoneyChestplate : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Shiny.");
    }

    public override void SetDefaults() {
        Item.width = 30;
        Item.height = 20;
        Item.value = 10000;
        Item.rare = ItemRarityID.Lime;
        Item.defense = 40;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs) {
        return body.type == ItemType<MoneyChestplate>() && legs.type == ItemType<MoneyGreaves>();
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<MoneyShirt>());
        recipe.AddIngredient(ItemType<MoneySleeves>());
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}