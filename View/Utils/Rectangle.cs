namespace View.Utils;

public class Rectangle
{
    public List<string> DrawConsoleRectangle(string content)
    {
        var lines = content.Split('\n');
        int maxLength = lines.Max(line => line.Replace("\r", "").Length);
        int totalWidth = maxLength + 4;

        List<string> result = new();
        result.Add("┌" + new string('─', maxLength + 2) + "┐");

        foreach (string line in lines)
        {
            string trimmed = line.Replace("\r", "");
            string paddedLine = trimmed.PadRight(maxLength);
            result.Add($"│ {paddedLine} │");
        }

        result.Add("└" + new string('─', maxLength + 2) + "┘");
        return result;
    }
}

