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
        var validator = new InputValidator<string>(msg, new ValidString());
        var result = validator.Validate();
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
        var validator = new InputValidator<string>(msg, new ValidString());
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(name));
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid value"));
        });
    }

    [Test]
    public void IntTest()
    {
        var msg = "Please type a number";
        var input = "1";

        SetupUserResponses(input);
        var validator = new InputValidator<int>(msg, new ValidNumber());
        var result = validator.Validate();
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
        var validator = new InputValidator<int>(msg, new ValidNumber());
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid value"));
            Assert.That(lines[2], Is.EqualTo(msg));
            Assert.That(lines[3], Is.EqualTo("Invalid value"));
            Assert.That(result, Is.EqualTo(int.Parse(input)));
        });
    }

    [Test]
    public void IntTest_MinMax()
    {
        var msg = "Please type a number";
        var input = "1";

        SetupUserResponses("-100", "6", input);
        var validator = new InputValidator<int>(msg, new ValidNumber(-5, 5));
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid value"));
            Assert.That(lines[2], Is.EqualTo(msg));
            Assert.That(lines[3], Is.EqualTo("Invalid value"));
            Assert.That(result, Is.EqualTo(int.Parse(input)));
        });
    }

    [Test]
    public void FloatTest()
    {
        var msg = "Please type a number";
        var input = "1.1";

        SetupUserResponses(input);
        var validator = new InputValidator<float>(msg, new ValidFloat());
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(float.Parse(input)));
            Assert.That(lines[0], Is.EqualTo(msg));
        });
    }

    [Test]
    public void FloatTest_Ask_MultipleTimes()
    {
        var msg = "Please type a number";
        var input = "1.1";

        SetupUserResponses("", "adflkajdfkasdf", input);
        var validator = new InputValidator<float>(msg, new ValidFloat());
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid value"));
            Assert.That(lines[2], Is.EqualTo(msg));
            Assert.That(lines[3], Is.EqualTo("Invalid value"));
            Assert.That(result, Is.EqualTo(float.Parse(input)));
        });
    }

    [Test]
    public void FloatTest_MinMax()
    {
        var msg = "Please type a number";
        var input = "1.1";

        SetupUserResponses("-10", "100", input);
        var validator = new InputValidator<float>(msg, new ValidFloat(0, 10));
        var result = validator.Validate();
        var lines = GetConsoleOutput();

        Assert.Multiple(() =>
        {
            Assert.That(lines[0], Is.EqualTo(msg));
            Assert.That(lines[1], Is.EqualTo("Invalid value"));
            Assert.That(lines[2], Is.EqualTo(msg));
            Assert.That(lines[3], Is.EqualTo("Invalid value"));
            Assert.That(result, Is.EqualTo(float.Parse(input)));
        });
    }
}