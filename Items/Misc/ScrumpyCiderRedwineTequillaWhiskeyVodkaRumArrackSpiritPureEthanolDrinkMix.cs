﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc;

public class ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Does something horrifying to your liver.\n'You shouldn't drink this'");
    }

    public override void SetDefaults() {
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 16;
        Item.value = Item.buyPrice(0, 25);
        Item.rare = ItemRarityID.Orange;
        Item.useStyle = ItemUseStyleID.EatFood;
        Item.noMelee = true;
        Item.buffType = BuffID.Bleeding;
        Item.buffTime = 9001;
        // Set other item.X values here
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        player.AddBuff(BuffID.Poisoned, 9001);
        player.AddBuff(BuffID.OnFire, 9001);
        player.AddBuff(BuffID.Venom, 9001);
        player.AddBuff(BuffID.Darkness, 9001);
        player.AddBuff(BuffID.Silenced, 9001);
        player.AddBuff(BuffID.Cursed, 9001);
        player.AddBuff(BuffID.Confused, 9001);
        player.AddBuff(BuffID.Slow, 9001);
        player.AddBuff(BuffID.OgreSpit, 9001);
        player.AddBuff(BuffID.Weak, 9001);
        player.AddBuff(BuffID.BrokenArmor, 9001);
        player.AddBuff(BuffID.WitheredArmor, 9001);
        player.AddBuff(BuffID.WitheredWeapon, 9001);
        player.AddBuff(BuffID.CursedInferno, 9001);
        player.AddBuff(BuffID.Ichor, 9001);
        player.AddBuff(BuffID.Chilled, 9001);
        player.AddBuff(BuffID.Frozen, 9001);
        player.AddBuff(BuffID.Webbed, 9001);
        player.AddBuff(BuffID.Stoned, 9001);
        player.AddBuff(BuffID.Obstructed, 9001);
        player.AddBuff(BuffID.Electrified, 9001);
        player.AddBuff(BuffID.Tipsy, 9001);
        player.AddBuff(BuffID.Frostburn, 9001);
        player.AddBuff(BuffID.Oiled, 9001);
        player.AddBuff(BuffID.Daybreak, 9001);

        return true;
    }

    public override void AddRecipes() {
        // Recipes here. See Basic Recipe Guide
    }
}