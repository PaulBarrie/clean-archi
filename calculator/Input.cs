namespace calculator;

public class OperationInput
{
    public readonly OperationType OperationType;
    public readonly int[] Numbers;

    public OperationInput(int[] numbers, OperationType operationType)
    {
        Numbers = numbers;
        OperationType = operationType;
    }
}

public enum OperationType
{
    Addition,
    Subtraction,
    Multiplication,
}

public static class OperationTypeExtensions
{
    public static OperationType FromString(string operationType)
    {
        switch (operationType)
        {
            case "+":
                return OperationType.Addition;
            case "-":
                return OperationType.Subtraction;
            case "*":
                return OperationType.Multiplication;
            default:
                throw new ArgumentException($"Operation type not supported : {operationType}");
        }
    }
}