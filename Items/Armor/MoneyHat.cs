using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class MoneyHat : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Shiny.");
    }

    public override void SetDefaults() {
        Item.width = 24;
        Item.height = 22;
        Item.value = 10000;
        Item.rare = ItemRarityID.Lime;
        Item.defense = 25;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs) {
        return body.type == ItemType<MoneyChestplate>() && legs.type == ItemType<MoneyGreaves>();
    }

    public override void UpdateArmorSet(Player player) {
        player.setBonus = "Dobble damage, more speed and flight time and money powers";
        player.GetDamage(DamageClass.Generic) += 1f;
        player.maxRunSpeed += 5;
        player.wingTimeMax += 5;
        player.goldRing = true;
        player.discount = true;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<MoneyHatScrap>(), 3);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}