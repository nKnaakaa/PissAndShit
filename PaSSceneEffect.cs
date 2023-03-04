using Terraria;
using Terraria.ModLoader;

namespace PissAndShit;

public class PaSSceneEffect : ModSceneEffect
{
    public override int Music { get; } = MusicLoader.GetMusicSlot($"{nameof(PissAndShit)}/Sounds/Music/boss");

    public override SceneEffectPriority Priority { get; } = SceneEffectPriority.BossHigh;

    public override bool IsSceneEffectActive(Player player) {
        return PaSSystem.endlesserModeSave &&
            !ModContent.GetInstance<PaSConfig>().disableBossOneMusic &&
            Main.myPlayer != -1 &&
            !Main.gameMenu &&
            Main.LocalPlayer.active;
    }
}