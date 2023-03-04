using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class StoneHat : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Hat.");
    }

    public override void SetDefaults() {
        Item.width = 24;
        Item.height = 22;
        Item.value = 10000;
        Item.rare = ItemRarityID.Pink;
        Item.defense = 25;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs) {
        return head.type == ItemType<StoneHat>();
    }

    public override void UpdateArmorSet(Player player) {
        player.setBonus = "Stone";
        player.maxRunSpeed = 0;
        player.runAcceleration = 0;
        player.wingTimeMax = 0;
        player.lifeRegen = 100;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemType<StoneBar>(), 10);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}