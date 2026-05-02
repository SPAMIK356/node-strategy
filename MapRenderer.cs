using System;
using System.Drawing;
using System.Linq;

namespace NodeStrategy
{
    public static class MapRenderer
    {
        public static void DrawMap(Graphics g, TurnManager manager, int width, int height)
        {
            var nodes = manager.mapElements.Values.OfType<Node>().ToList();
            var edges = manager.mapElements.Values.OfType<Edge>().ToList();

            if (!nodes.Any()) return;

            // 1. Адаптивний масштаб
            // Увага: переконайся, що у класі Node (або MapElement) є властивості X та Y
            float minX = nodes.Min(n => n.X);
            float maxX = nodes.Max(n => n.X);
            float minY = nodes.Min(n => n.Y);
            float maxY = nodes.Max(n => n.Y);

            // Відступи від країв
            float padding = 40f;
            float drawWidth = width - padding * 2;
            float drawHeight = height - padding * 2;

            float rangeX = maxX - minX == 0 ? 1 : maxX - minX;
            float rangeY = maxY - minY == 0 ? 1 : maxY - minY;

            // Вибираємо мінімальний масштаб, щоб мапа влізла повністю без спотворень
            float scale = Math.Min(drawWidth / rangeX, drawHeight / rangeY);

            // Локальна функція для перекладу ігрових координат в екранні
            PointF GetScreenPos(Node n)
            {
                float screenX = (n.X - minX) * scale + padding;
                float screenY = (n.Y - minY) * scale + padding;

                // Центруємо мапу по тій осі, де залишилося вільне місце
                screenX += (drawWidth - rangeX * scale) / 2;
                screenY += (drawHeight - rangeY * scale) / 2;

                return new PointF(screenX, screenY);
            }

            // 2. Малюємо дороги (ребра) знизу
            using (Pen roadPen = new Pen(Color.Gray, 2f))
            {
                foreach (var edge in edges)
                {
                    var p1 = GetScreenPos(edge.a);
                    var p2 = GetScreenPos(edge.b);
                    g.DrawLine(roadPen, p1, p2);
                }
            }

            // 3. Малюємо міста (вершини) зверху
            int totalFactions = manager.factions.Count == 0 ? 1 : manager.factions.Count;
            float nodeRadius = 15f;
            Font font = new Font("Arial", 10, FontStyle.Bold);
            StringFormat textFormat = new StringFormat { Alignment = StringAlignment.Center };

            foreach (var node in nodes)
            {
                var pos = GetScreenPos(node);

                // Ділимо коло кольорів (360) на рівні частини для фракцій
                float hue = (360f / totalFactions) * node.controledBy;
                Color factionColor = ColorFromHSV(hue, 0.8, 0.9);

                // Заливка міста кольором фракції
                using (Brush nodeBrush = new SolidBrush(factionColor))
                {
                    g.FillEllipse(nodeBrush, pos.X - nodeRadius, pos.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                }

                // Обводка: червона товста, якщо бій, інакше — звичайна чорна
                if (node.isContested)
                {
                    using (Pen conflictPen = new Pen(Color.Red, 4f))
                    {
                        g.DrawEllipse(conflictPen, pos.X - nodeRadius, pos.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                    }
                }
                else
                {
                    using (Pen normalPen = new Pen(Color.Black, 2f))
                    {
                        g.DrawEllipse(normalPen, pos.X - nodeRadius, pos.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                    }
                }

                // Назва міста під вершиною
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    g.DrawString(node.Name, font, textBrush, pos.X, pos.Y + nodeRadius + 2, textFormat);
                }

                // Статус бою текстом над вершиною
                if (node.isContested)
                {
                    using (Brush statusBrush = new SolidBrush(Color.Red))
                    {
                        Font statusFont = new Font("Arial", 8, FontStyle.Italic);
                        g.DrawString("Бій!", statusFont, statusBrush, pos.X, pos.Y - nodeRadius - 15, textFormat);
                    }
                }
            }
        }

        // Трюк для перетворення HSV у звичний RGB
        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => Color.FromArgb(255, v, t, p),
                1 => Color.FromArgb(255, q, v, p),
                2 => Color.FromArgb(255, p, v, t),
                3 => Color.FromArgb(255, p, q, v),
                4 => Color.FromArgb(255, t, p, v),
                _ => Color.FromArgb(255, v, p, q)
            };
        }
    }
}