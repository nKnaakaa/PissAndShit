using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PissAndShit;

public class PaSConfig : ModConfig
{
    [DefaultValue(false)]
    [Label("Disable boss1 music in endlesser mode")]
    [Tooltip("Disables the track 'Boss1' from constantly playing while endlesser mode is active")]
    public bool disableBossOneMusic;

    [DefaultValue(false)]
    [Label("Disable zombie speaking enchant table")]
    [Tooltip("Removes zombies having the chance to make horrid screeching noises")]
    public bool disableZombieScreech;

    public override ConfigScope Mode => ConfigScope.ServerSide;
}