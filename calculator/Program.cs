namespace calculator;

public class Program
{
    private readonly IInputHandler<string, int[]> _inputHandler;
    private readonly IComputer<OperationInput, int[]> _computer;
    private readonly IOutput<OperationOutput, string> _output;


    public Program(IInputHandler<string, int[]> inputHandler, IComputer<OperationInput, int[]> computer, IOutput<OperationOutput, string> output)
    {
        _inputHandler = inputHandler;
        _computer = computer;
        _output = output;
    }

    public void Run(string[] args)
    {
        var programArgs = getArgs(args);
        var input = _inputHandler.GetInput(programArgs.Filename);
        var res = _computer.Compute(new OperationInput(input, programArgs.OperationType));
        var output = _output.Get(new OperationOutput(programArgs.OperationType, input, res));
        Console.WriteLine(output);
    }

    private ProgramArgs getArgs(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Expected a filename and an operation type");
        }
        var filename = args[0];
        var operationType = OperationTypeExtensions.FromString(args[1]);

        return new ProgramArgs(filename, operationType);

    }
}

public class ProgramArgs
{
    public readonly string Filename;
    public readonly OperationType OperationType;

    public ProgramArgs(string filename, OperationType operationType)
    {
        Filename = filename;
        OperationType = operationType;
    }
}