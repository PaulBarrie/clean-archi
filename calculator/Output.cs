namespace calculator;

public interface IOutput<in TO, out T>
{
    T Get(TO output);
}

public class Output : IOutput<OperationOutput, string>
{
    public string Get(OperationOutput output)
    {
        var result = $"\t{output.InputNumbers[0]}\n";
        for (int i = 1; i < output.InputNumbers.Length; i++)
        {
            result += $"{output.OperationType} {output.InputNumbers[i]} (={output.Results[i]})\n";
        }
        result += "-------\n";
        result += $"=  total {output.Results[output.Results.Length - 1]}";
        return result;
    }
}

/*
 *
 *   1
 +2 (=3)
 +3 (=6)
 */
public class OperationOutput
{
    public readonly OperationType OperationType;
    public readonly int[] InputNumbers;
    public readonly int[] Results;

    public OperationOutput(OperationType operationType, int[] inputNumbers, int[] results)
    {
        OperationType = operationType;
        InputNumbers = inputNumbers;
        Results = results;
    }
}