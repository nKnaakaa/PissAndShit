using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace PissAndShit.UI;

internal class DeathHandPanelDraw : UIState
{
    public static bool DeathHandPanelVisible;
    public DraggablePanel BackgroundPanel;

    public UIImage NPCBackgroundPanel;

    //public UIImage NPCImage;
    public override void OnInitialize() {
        BackgroundPanel = new DraggablePanel();
        BackgroundPanel.SetPadding(0);
        BackgroundPanel.Left.Set(400f, 0f);
        BackgroundPanel.Top.Set(100f, 0f);
        BackgroundPanel.Width.Set(600f, 0f);
        BackgroundPanel.Height.Set(400f, 0f);
        BackgroundPanel.BackgroundColor = new Color(73, 94, 171);

        var buttonKillTexture = ModContent.Request<Texture2D>("PissAndShit/UI/DeathHandKillButton");
        var killButton = new UIHoverImageButton(buttonKillTexture, "Kill NPC");
        killButton.Left.Set(10, 0f);
        killButton.Top.Set(10, 0f);
        killButton.Width.Set(40, 0f);
        killButton.Height.Set(40, 0f);
        killButton.OnClick += KillButtonClicked;
        BackgroundPanel.Append(killButton);

        var buttonDamageTexture = ModContent.Request<Texture2D>("PissAndShit/UI/DeathHandDamageButton");
        var damageButton = new UIHoverImageButton(buttonDamageTexture, "Damage NPC");
        damageButton.Left.Set(60, 0f);
        damageButton.Top.Set(10, 0f);
        damageButton.Width.Set(40, 0f);
        damageButton.Height.Set(40, 0f);
        damageButton.OnClick += DamageButtonClicked;
        BackgroundPanel.Append(damageButton);

        Append(BackgroundPanel);
    }

    private void KillButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
        var npc = Main.npc[PaSSystem.deathHandNPCIdentifier];
        npc.dontTakeDamage = false;
        npc.life = 1;
        npc.StrikeNPCNoInteraction(777, 0f, 0);
    }

    private void DamageButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
        var player = Main.player[Main.myPlayer];
        player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " got stuck in a custom UI box."), 1.0, 0);
    }
}