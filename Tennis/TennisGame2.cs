namespace Tennis;

public class TennisGame2(string player1Name, string player2Name) : ITennisGame
{
    private int _player1Score = 0;
    private int _player2Score;

    private string _player1Name = player1Name;
    private string _player2Name = player2Name;

    public string GetScore()
    {
        if (_player1Score == _player2Score && _player1Score < 3)
        {
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                _ => "Thirty-All",
            };
        }
        if (_player1Score == _player2Score && _player1Score > 2)
        {
            return "Deuce";
        }
        if (_player1Score > 0 && _player1Score < 4 && _player2Score == 0)
        {
            return GetScoreName(_player1Score) + "-Love";
        }
        if (_player2Score > 0 && _player2Score < 4 && _player1Score == 0)
        {
            return "Love-" + GetScoreName(_player2Score);
        }
        if (_player1Score >= 4 && _player2Score >= 0 && (_player1Score - _player2Score) >= 2)
        {
            return $"Win for {_player1Name}";
        }
        if (_player2Score >= 4 && _player1Score >= 0 && (_player2Score - _player1Score) >= 2)
        {
            return $"Win for {_player2Name}";
        }
        if (_player1Score > _player2Score && _player2Score >= 3)
        {
            return $"Advantage {_player1Name}";
        }
        if (_player2Score > _player1Score && _player1Score >= 3)
        {
            return $"Advantage {_player2Name}";
        }
        return GetScoreName(_player1Score) + "-" + GetScoreName(_player2Score);
    }

    private static string GetScoreName(int score)
    {
        return score switch
        {
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty",
        };
    }

    private void P1Score()
    {
        _player1Score++;
    }

    private void P2Score()
    {
        _player2Score++;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == _player1Name)
            P1Score();
        else
            P2Score();
    }

}
