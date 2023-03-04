using Microsoft.Xna.Framework;
using PissAndShit.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Tiles;

public class GrandBrick : ModTile
{
    public override void SetStaticDefaults() {
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        ;
        Main.tileBrick[Type] = true;
        DustType = DustID.BlueCrystalShard;
        ItemDrop = ModContent.ItemType<GrandBrickItem>();
        AddMapEntry(new Color(140, 184, 255));
        // Set other values here
    }
}