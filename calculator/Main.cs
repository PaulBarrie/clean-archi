namespace calculator;

public class Main
{
    public static void main(string[] args)
    {
        var program = new Program(new FileInputHandler(), new IntComputer(), new Output());
        program.Run(args);
    }
}





