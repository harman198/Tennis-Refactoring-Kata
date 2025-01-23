namespace Tennis;

public class TennisGame5(string player1Name, string player2Name) : ITennisGame
{
    private int _player1Score;
    private int _player2Score;
    private readonly string _player1Name = player1Name;
    private readonly string _player2Name = player2Name;

    public void WonPoint(string playerName)
    {
        if (playerName == _player1Name)
            _player1Score++;
        else if (playerName == _player2Name)
            _player2Score++;
        else
            throw new ArgumentException("Invalid player name.");
    }

    public string GetScore()
    {
        var deduction = (_player1Score > 4 || _player2Score > 4) ? (Math.Max(_player1Score, _player2Score) - 4) : 0;
        int p1 = _player1Score - deduction;
        int p2 = _player2Score - deduction;

        return (p1, p2) switch
        {
            (0, 0) => "Love-All",
            (0, 1) => "Love-Fifteen",
            (0, 2) => "Love-Thirty",
            (0, 3) => "Love-Forty",
            (0, 4) => $"Win for {_player2Name}",
            (1, 0) => "Fifteen-Love",
            (1, 1) => "Fifteen-All",
            (1, 2) => "Fifteen-Thirty",
            (1, 3) => "Fifteen-Forty",
            (1, 4) => $"Win for {_player2Name}",
            (2, 0) => "Thirty-Love",
            (2, 1) => "Thirty-Fifteen",
            (2, 2) => "Thirty-All",
            (2, 3) => "Thirty-Forty",
            (2, 4) => $"Win for {_player2Name}",
            (3, 0) => "Forty-Love",
            (3, 1) => "Forty-Fifteen",
            (3, 2) => "Forty-Thirty",
            (3, 3) => "Deuce",
            (3, 4) => $"Advantage {_player2Name}",
            (4, 0) => $"Win for {_player1Name}",
            (4, 1) => $"Win for {_player1Name}",
            (4, 2) => $"Win for {_player1Name}",
            (4, 3) => $"Advantage {_player1Name}",
            (4, 4) => "Deuce",
            _ => throw new ArgumentException("Invalid score.")
        };
    }
}