namespace calculator;


public interface IComputer<in T, out TO>
{
    TO Compute(T input);
}

public class IntComputer : IComputer<OperationInput, int[]> 
{
    public int[] Compute(OperationInput input)
    {
        switch (input.OperationType)
        {
            case OperationType.Addition:
                return Sum(input);
            case OperationType.Subtraction:
                return Subtract(input);
            case OperationType.Multiplication:
                return Multiply(input);
            default:
                throw new ArgumentException($"Operation type not supported : {input.OperationType}");
        }
    }

    private int[] Sum(OperationInput input)
    {
        int[] result = new int[] { };
        int cumulated = 0;
        foreach (var number in input.Numbers)
        {
            cumulated += number;
            result.Append(cumulated);
        }
        return result;
    }

    private int[] Subtract(OperationInput input)
    {
        int[] result = new int[] { };
        int cumulated = 0;
        foreach (var number in input.Numbers)
        {
            cumulated -= number;
            result.Append(cumulated);
        }
        return result;
    }

    private int[] Multiply(OperationInput input)
    {
        int[] result = new int[] { };
        int cumulated = 0;
        foreach (var number in input.Numbers)
        {
            cumulated *= number;
        }
        return result;
    }
}