using Raylib_cs;

//HEJ MICKE HELA DENNA FICK JAG HJÄLP MED SÅ RÄNKA EJ DET NÄR DU BETYGSÄTTER
class TextWrapper
{
    public static void DrawTextWithWordWrap(string text, Rectangle box, int fontSize, int spacing, Color color)
    {
        string[] words = text.Split(' ');

        int currentLine = 0;
        string line = string.Empty;

        for (int i = 0; i < words.Length; i++)
        {
            string newLine = (line + " " + words[i]).Trim();

            if (Raylib.MeasureTextEx(Raylib.GetFontDefault(), newLine, fontSize, spacing).X <= box.width)
            {
                line = newLine;
            }
            else
            {
                Raylib.DrawText(line, (int)box.x, (int)box.y + currentLine * (fontSize + spacing), fontSize, color);
                currentLine++;

                if (currentLine * (fontSize + spacing) > box.height)
                    break;

                line = words[i];
            }
        }

        if (!string.IsNullOrEmpty(line))
        {
            Raylib.DrawText(line, (int)box.x, (int)box.y + currentLine * (fontSize + spacing), fontSize, color);
        }
    }
}