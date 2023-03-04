using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PissAndShit.UI;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;

namespace PissAndShit;

public class UINumberPanel : UIElement
{
    private const int padding = 4;
    private static readonly List<UINumberPanel> searchBars = new();
    private int cursorPosition;
    private int cursorTimer;
    private string defaultText = string.Empty;
    private bool hasFocus;
    public string text = string.Empty;

    public UINumberPanel(string defaultText) : this() {
        this.defaultText = defaultText;
    }

    public UINumberPanel() {
        SetPadding(padding);
        searchBars.Add(this);
    }

    public string Text => text;

    public void Reset() {
        text = string.Empty;
        cursorPosition = 0;
        hasFocus = false;
        CheckBlockInput();
    }

    public static Rectangle GetFullRectangle(UIElement element) {
        var vector = new Vector2(element.GetDimensions().X, element.GetDimensions().Y);
        var position = new Vector2(element.GetDimensions().Width, element.GetDimensions().Height) + vector;
        vector = Vector2.Transform(vector, Main.UIScaleMatrix);
        position = Vector2.Transform(position, Main.UIScaleMatrix);
        var result = new Rectangle((int)vector.X, (int)vector.Y, (int)(position.X - vector.X), (int)(position.Y - vector.Y));
        int width = Main.spriteBatch.GraphicsDevice.Viewport.Width;
        int height = Main.spriteBatch.GraphicsDevice.Viewport.Height;
        result.X = Utils.Clamp(result.X, 0, width);
        result.Y = Utils.Clamp(result.Y, 0, height);
        result.Width = Utils.Clamp(result.Width, 0, width - result.X);
        result.Height = Utils.Clamp(result.Height, 0, height - result.Y);
        return result;
    }

    public override void Update(GameTime gameTime) {
        cursorTimer++;
        cursorTimer %= 60;

        var dim = GetFullRectangle(this);
        var mouse = DeathHandDamagePanel.curMouse;
        bool mouseOver = mouse.X > dim.X && mouse.X < dim.X + dim.Width && mouse.Y > dim.Y && mouse.Y < dim.Y + dim.Height;

        if (DeathHandDamagePanel.MouseClicked && Parent != null) {
            if (!hasFocus && mouseOver) {
                hasFocus = true;
                CheckBlockInput();
            }
            else if (hasFocus && !mouseOver) {
                hasFocus = false;
                CheckBlockInput();
                cursorPosition = text.Length;
            }
        }
        else if (DeathHandDamagePanel.curMouse.RightButton == ButtonState.Pressed && DeathHandDamagePanel.oldMouse.RightButton == ButtonState.Released && Parent != null && hasFocus && !mouseOver) {
            hasFocus = false;
            cursorPosition = text.Length;
            CheckBlockInput();
        }
        else if (DeathHandDamagePanel.curMouse.RightButton == ButtonState.Pressed && DeathHandDamagePanel.oldMouse.RightButton == ButtonState.Released && mouseOver) {
            if (text.Length > 0) {
                text = string.Empty;
                cursorPosition = 0;
            }
        }

        if (hasFocus) {
            PlayerInput.WritingText = true;
            Main.instance.HandleIME();
            string prev = text;

            if (cursorPosition < text.Length && text.Length > 0) {
                prev = prev.Remove(cursorPosition);
            }

            string newString = Main.GetInputText(prev);
            bool changed = false;

            if (!newString.Equals(prev)) {
                int newStringLength = newString.Length;
                if (prev != text) {
                    newString += text.Substring(cursorPosition);
                }

                text = newString;
                cursorPosition = newStringLength;
                changed = true;
            }

            if (KeyTyped(Keys.Delete) && text.Length > 0 && cursorPosition <= text.Length - 1) {
                text = text.Remove(cursorPosition, 1);
                changed = true;
            }

            if (KeyTyped(Keys.Left) && cursorPosition > 0) {
                cursorPosition--;
            }

            if (KeyTyped(Keys.Right) && cursorPosition < text.Length) {
                cursorPosition++;
            }

            if (KeyTyped(Keys.Home)) {
                cursorPosition = 0;
            }

            if (KeyTyped(Keys.End)) {
                cursorPosition = text.Length;
            }

            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && KeyTyped(Keys.Back)) {
                text = string.Empty;
                cursorPosition = 0;
                changed = true;
            }

            if (changed) { }

            if (KeyTyped(Keys.Enter) || KeyTyped(Keys.Tab) || KeyTyped(Keys.Escape)) {
                hasFocus = false;
                CheckBlockInput();
            }
        }

        base.Update(gameTime);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch) {
        Texture2D texture = ModContent.Request<Texture2D>("PissAndShit/UI/NumPanel").Value;
        var dim = GetDimensions();
        int innerWidth = (int)dim.Width - 2 * padding;
        int innerHeight = (int)dim.Height - 2 * padding;
        spriteBatch.Draw(texture, dim.Position(), new Rectangle(0, 0, padding, padding), Color.White);
        spriteBatch.Draw(texture, new Rectangle((int)dim.X + padding, (int)dim.Y, innerWidth, padding), new Rectangle(padding, 0, 1, padding), Color.White);
        spriteBatch.Draw(texture, new Vector2(dim.X + padding + innerWidth, dim.Y), new Rectangle(padding + 1, 0, padding, padding), Color.White);
        spriteBatch.Draw(texture, new Rectangle((int)dim.X, (int)dim.Y + padding, padding, innerHeight), new Rectangle(0, padding, padding, 1), Color.White);
        spriteBatch.Draw(texture, new Rectangle((int)dim.X + padding, (int)dim.Y + padding, innerWidth, innerHeight), new Rectangle(padding, padding, 1, 1), Color.White);
        spriteBatch.Draw(texture, new Rectangle((int)dim.X + padding + innerWidth, (int)dim.Y + padding, padding, innerHeight), new Rectangle(padding + 1, padding, padding, 1), Color.White);
        spriteBatch.Draw(texture, new Vector2(dim.X, dim.Y + padding + innerHeight), new Rectangle(0, padding + 1, padding, padding), Color.White);
        spriteBatch.Draw(texture, new Rectangle((int)dim.X + padding, (int)dim.Y + padding + innerHeight, innerWidth, padding), new Rectangle(padding, padding + 1, 1, padding), Color.White);
        spriteBatch.Draw(texture, new Vector2(dim.X + padding + innerWidth, dim.Y + padding + innerHeight), new Rectangle(padding + 1, padding + 1, padding, padding), Color.White);

        bool isEmpty = text.Length == 0;
        string drawText = isEmpty ? "" : text;
        var font = FontAssets.MouseText.Value;
        var size = font.MeasureString(drawText);
        float scale = innerHeight / size.Y;
        if (isEmpty && hasFocus) {
            drawText = string.Empty;
            isEmpty = false;
        }

        var color = Color.Black;
        if (isEmpty) {
            color *= 0.75f;
        }

        spriteBatch.DrawString(font, drawText, new Vector2(dim.X + padding, dim.Y + padding), color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        if (!isEmpty && hasFocus && cursorTimer < 30) {
            float drawCursor = font.MeasureString(drawText.Substring(0, cursorPosition)).X * scale;
            spriteBatch.DrawString(font, "|", new Vector2(dim.X + padding + drawCursor, dim.Y + padding), color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }

    public bool KeyTyped(Keys key) {
        return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
    }

    private static void CheckBlockInput() {
        Main.blockInput = false;
        foreach (var searchBar in searchBars) {
            if (searchBar.hasFocus) {
                Main.blockInput = true;
                break;
            }
        }
    }
}