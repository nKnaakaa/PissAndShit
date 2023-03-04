using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.UI;

namespace PissAndShit.UI;

internal class DeathHandDamagePanel : UIState
{
    public static MouseState curMouse;
    public static MouseState oldMouse;
    public static bool DeathHandPanelVisible;
    public DraggablePanel BackgroundPanel;
    public UINumberPanel UINumPanel;

    public static bool MouseClicked => curMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released;

    public override void OnInitialize() {
        BackgroundPanel = new DraggablePanel();
        BackgroundPanel.SetPadding(0);
        BackgroundPanel.Left.Set(400f, 0f);
        BackgroundPanel.Top.Set(50f, 0f);
        BackgroundPanel.Width.Set(100f, 0f);
        BackgroundPanel.Height.Set(40f, 0f);
        BackgroundPanel.BackgroundColor = new Color(73, 94, 171);

        UINumPanel = new UINumberPanel();
        UINumPanel.SetPadding(0); // ?????
        UINumPanel.Left.Set(40f, 0f);
        UINumPanel.Top.Set(5f, 0f);
        UINumPanel.Width.Set(50f, 0f);
        UINumPanel.Height.Set(30f, 0f);
        BackgroundPanel.Append(UINumPanel);

        Append(BackgroundPanel);
    }

    /*private void HitButtonClicked(UIMouseEvent evt, UIElement listeningElement)
    {
        int damageToDeal = 0;
        Int32.TryParse(UINumPanel.text, out damageToDeal);
        NPC npc = Main.npc[PaSWorld.deathHandNPCIdentifier];
        npc.life =- 0;
    }*/
    public new static void Update(GameTime gameTime) {
        oldMouse = curMouse;
        curMouse = Mouse.GetState();
    }
}