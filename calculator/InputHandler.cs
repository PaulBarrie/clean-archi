namespace calculator;

public interface IInputHandler<in TO, out T>
{
    T GetInput(TO input);
}

public class FileInputHandler : IInputHandler<string, int[]>
{
    public int[] GetInput(string input)
    {
        if (!File.Exists(input))
        {
            throw new ArgumentException($"File {input} does not exist");
        }
        var lines = File.ReadAllLines(input);
        int[] res = new int[] { };
        foreach (var line in lines)
        {
            var formattedLine = line.Replace(" ", "");
            if (int.TryParse(formattedLine, out var number))
            {
                res.Append(number);
            }
            else
            {
                throw new ArgumentException($"Line {line} is not an integer");
            }
        }

        return res;
    }
}