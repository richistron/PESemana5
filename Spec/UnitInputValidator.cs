namespace Spec;

public class UnitInputValidator
{
    private StringWriter stringWriter;

    [SetUp]
    public void Setup()
    {
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
    }

    [Test]
    public void StringTest()
    {
        var name = "panchito";
        var msg = "Type the person name";

        var stringReader = new StringReader(name);
        Console.SetIn(stringReader);

        Assert.AreEqual(name, InputValidator.String(msg));
        Assert.AreEqual("Type the person name\r\n", stringWriter.ToString());
    }

    [Test]
    public void String_Ask_Multiple_Times()
    {
        var name = "panchito";
        var msg = "Type the person name";

        var stringReader1 = new StringReader("");
        Console.SetIn(stringReader1);

        var stringReader2 = new StringReader("");
        Console.SetIn(stringReader2);

        var stringReader3 = new StringReader(name);
        Console.SetIn(stringReader3);

        Assert.AreEqual(name, InputValidator.String(msg));
        Assert.AreEqual("Type the person name\r\n", stringWriter.ToString());
    }
}