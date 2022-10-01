using System.Text;
using Moq;

namespace Spec;

public class UnitInputValidator
{
    StringBuilder _ConsoleOutput;
    Mock<TextReader> _ConsoleInput;

    [SetUp]
    public void Setup()
    {
        _ConsoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(_ConsoleOutput);
        _ConsoleInput = new Mock<TextReader>();
        Console.SetOut(consoleOutputWriter);
        Console.SetIn(_ConsoleInput.Object);
    }

    private void SetupUserResponses(params string[] userResponses)
    {
        var sequence = new MockSequence();
        foreach (var response in userResponses)
            _ConsoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
    }

    private string[] GetConsoleOutput() => _ConsoleOutput.ToString().Split("\r\n");

    [Test]
    public void StringTest()
    {
        var name = "panchito";
        var msg = "Type the person name";

        SetupUserResponses(name);
        var result = InputValidator.String(msg);
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(name));
            Assert.That(lines[0], Is.EqualTo(msg));
        });
    }

    [Test]
    public void String_Ask_Multiple_Times()
    {
        var name = "panchito";
        var msg = "Type the person name";

        SetupUserResponses("", name);
        var result = InputValidator.String(msg);
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(name));
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid string"));
        });
    }

    [Test]
    public void IntTest()
    {
        var msg = "Please type a number";
        var input = "1";

        SetupUserResponses(input);
        var result = InputValidator.Int(msg);
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(int.Parse(input)));
            Assert.That(lines[0], Is.EqualTo(msg));
        });
    }

    [Test]
    public void IntTest_Ask_MultipleTimes()
    {
        var msg = "Please type a number";
        var input = "1";

        SetupUserResponses("", "adflkajdfkasdf", input);
        var num = InputValidator.Int(msg);
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("\"\" is not an integer"));
            Assert.That(lines[2], Is.EqualTo(msg));
            Assert.That(lines[3], Is.EqualTo("\"adflkajdfkasdf\" is not an integer"));
            Assert.That(num, Is.EqualTo(int.Parse(input)));
        });
    }
}