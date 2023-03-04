using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit;

internal class PaSGlobalProjectile : GlobalProjectile
{
    public override void AI(Projectile projectile) {
        if (PaSSystem.endlessModeSave) {
            if (NPC.AnyNPCs(NPCID.DukeFishron)) {
                if (projectile.type == ProjectileID.Sharknado || projectile.type == ProjectileID.Cthulunado) {
                    projectile.timeLeft++;
                }
            }
        }
    }
}