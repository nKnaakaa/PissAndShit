using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items;

public class DeathHand : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Death's Hand");
        //Tooltip.SetDefault("'Everything is under your control'\nClick an enemy or Town NPC to get info and control aspects of it");
        Tooltip.SetDefault("Does nothing yet, but keep this on you.\nWill do something cool in a later update.");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults() {
        Item.damage = -1;
        Item.width = 180;
        Item.height = 180;
        Item.useTime = 2;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 0;
        Item.value = Item.buyPrice(6, 24, 11, 2);
        Item.rare = ItemRarityID.Purple;
        Item.autoReuse = true;
    }

    public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */ {
        var location = Main.MouseWorld.ToPoint();
        bool mouseover = false;
        if (mouseover) {
            CombatText.NewText(player.Hitbox, Color.DarkRed, "Mouseover is true!", true);
        }

        for (int i = 0; i < Main.maxNPCs; i++) {
            var npc = Main.npc[i];
            if (npc.active) {
                var hitbox = npc.Hitbox;
                hitbox.Inflate(5, 5);
                if (hitbox.Contains(location)) {
                    mouseover = true;
                    PaSSystem.deathHandNPCType = npc.type;
                    PaSSystem.deathHandNPCIdentifier = npc.whoAmI;
                }
            }
        }

        return true;
    }
}