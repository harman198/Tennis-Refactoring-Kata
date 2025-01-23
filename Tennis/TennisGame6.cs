namespace Tennis;

public class TennisGame6(string player1Name, string player2Name) : ITennisGame
{
    private int _player1Score;
    private int _player2Score;
    private readonly string _player1Name = player1Name;
    private readonly string _player2Name = player2Name;

    public void WonPoint(string playerName)
    {
        if (playerName == _player1Name)
            _player1Score++;
        else
            _player2Score++;
    }

    public string GetScore()
    {
        if (_player1Score == _player2Score)
        {
            // tie score
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        if (_player1Score >= 4 || _player2Score >= 4)
        {
            // end-game score
            return (_player1Score - _player2Score) switch
            {
                1 => $"Advantage {_player1Name}",
                -1 => $"Advantage {_player2Name}",
                >= 2 => $"Win for {_player1Name}",
                _ => $"Win for {_player2Name}",
            };
        }

        // regular score
        return $"{GetScoreName(_player1Score)}-{GetScoreName(_player2Score)}";
    }

    private static string GetScoreName(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }
}