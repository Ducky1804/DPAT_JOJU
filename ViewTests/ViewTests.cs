using Model;
using View.Diagram;
using View.Printer;
using View.Utils;

namespace ViewTests;

public class Tests
{
    [Test]
    public void Render_WithOneStateAndOneTransition_ReturnsFormattedOutput()
    {
        // Arrange
        var diagram = new Diagram { Name = "TestDiagram" };
        var state = new SimpleState("S1", "Simple");
        var transition = new Transition("T1", "", "S1", "S2", null, "");
        state.Transitions.Add(transition);
        diagram.States.Add(state);
        
        var renderer = new StateDiagramRenderer();

        // Act
        var result = renderer.Render(diagram, new GraphRenderVisitor());

        // Assert
        StringAssert.Contains("Simple", result);
        StringAssert.Contains("S2", result);
    }
    
    [Test]
    public void DrawConsoleRectangle_WithHeaderAndDescription_RendersBoxCorrectly()
    {
        // Arrange
        var rectangle = new Rectangle();
        string header = "Title";
        string description = "Line 1\nLine 2";

        // Act
        var result = rectangle.DrawConsoleRectangle(header, description);

        // Assert
        var expected = new List<string>
        {
            "┌────────┐",
            "│ Title  │",
            "├────────┤",
            "│ Line 1 │",
            "│ Line 2 │",
            "└────────┘"
        };

        CollectionAssert.AreEqual(expected, result);
    }
    
    [Test]
    public void Print_WritesCenteredTextToConsole()
    {
        var printer = new ConsolePrinter();
        string testContent = "Hello, world!";
        var output = new StringWriter();
        Console.SetOut(output);

        printer.Print(testContent);

        string printed = output.ToString().TrimEnd(); // Remove \r\n
        Assert.IsTrue(printed.EndsWith("Hello, world!"));
    }
}