using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExcodeAuthor
{
    public class Gutter : Control
    {
        public Gutter() {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            OnEventHandler = new EventHandler(PaintOnEvent);
            BackColor = Color.Transparent;
        }

        private RichTextBox textBox = null;
        private EventHandler OnEventHandler;
        [Browsable(true)]
        public RichTextBox TextBox {
            get { return textBox; }
            set {
                if (textBox != null) {
                    textBox.VScroll -= OnEventHandler;
                    textBox.TextChanged -= OnEventHandler;
                    textBox.Resize -= OnEventHandler;
                }
                textBox = value;
                if (textBox != null) {
                    textBox.VScroll += OnEventHandler;
                    textBox.TextChanged += OnEventHandler;
                    textBox.Resize += OnEventHandler;
                }
            }
        }

        void PaintOnEvent(object sender, EventArgs e) {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (textBox != null && !textBox.IsDisposed) {
                int fontHeight = textBox.Font.Height;
                if (fontHeight == 0) return;
                int firstChar = textBox.GetCharIndexFromPosition(new Point(0, fontHeight));
                int line = textBox.GetLineFromCharIndex(firstChar) + 1;
                int y = textBox.GetPositionFromCharIndex(firstChar).Y;
                if (line > 1) {
                    y -= fontHeight;
                    line--;
                }
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Far;
                while (y < textBox.Height && line <= textBox.Lines.Length) {
                    e.Graphics.DrawString(line > 9999 ? "…" + (line % 1000).ToString("00#") : line.ToString(), textBox.Font, SystemBrushes.ControlText, new RectangleF(0f, (float)(y + 2), (float)(Width - 5), (float)fontHeight), format);
                    y = textBox.GetPositionFromCharIndex(textBox.GetFirstCharIndexFromLine(line++)).Y;
                }
            }
        }

        int startLineBegin = 0;
        int startLineEnd = 0;

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            int firstChar = textBox.GetCharIndexFromPosition(new Point(0, e.Y));
            int newline = textBox.Text.IndexOf("\n", firstChar) + 1;
            textBox.SelectionStart = startLineBegin = firstChar;
            if (newline == 0) newline = textBox.Text.Length;
            textBox.SelectionLength = newline - textBox.SelectionStart;
            startLineEnd = newline;
            Capture = true;
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (Capture && e.Button == MouseButtons.Left) {
                int firstChar = textBox.GetCharIndexFromPosition(new Point(0, e.Y));
                int newline = textBox.Text.IndexOf("\n", firstChar) + 1;
                if (newline == 0) newline = textBox.Text.Length;
                if (firstChar < startLineBegin)
                    textBox.SelectionStart = firstChar;
                else
                    textBox.SelectionStart = startLineBegin;
                if (newline > startLineEnd)
                    textBox.SelectionLength = newline - textBox.SelectionStart;
                else
                    textBox.SelectionLength = startLineEnd - textBox.SelectionStart;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            Capture = false;
            textBox.Focus();
        }
    }
}
