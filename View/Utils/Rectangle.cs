namespace View.Utils;

public class Rectangle
{
    public List<string> DrawConsoleRectangle(string content)
    {
        var lines = content.Split('\n');
        int maxLength = lines.Max(line => line.Replace("\r", "").Length);

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
    
    public List<string> DrawConsoleRectangle(string header, string? description)
    {
        if (description == null)
        {
            return DrawConsoleRectangle(header);
        }
        
        var descriptionLines = description.Split('\n').Select(line => line.Replace("\r", "")).ToList();
        var lines = new List<string> { header.Replace("\r", "") };
        lines.AddRange(descriptionLines);

        int maxLength = lines.Max(line => line.Length);

        List<string> result = new();
        result.Add("┌" + new string('─', maxLength + 2) + "┐");

        // Header line
        string headerLine = header.Replace("\r", "").PadRight(maxLength);
        result.Add($"│ {headerLine} │");

        // Separator line
        result.Add("├" + new string('─', maxLength + 2) + "┤");

        // Description lines
        foreach (string line in descriptionLines)
        {
            string paddedLine = line.PadRight(maxLength);
            result.Add($"│ {paddedLine} │");
        }

        result.Add("└" + new string('─', maxLength + 2) + "┘");
        return result;
    }

}

public static class RectangleExtensions
{
    public static string ConvertToString(this List<string> lines)
    {
        return string.Join("\r\n", lines);
    }
}

