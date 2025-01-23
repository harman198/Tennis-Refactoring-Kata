namespace Tennis;

public class TennisGame3(string player1Name, string player2Name) : ITennisGame
{
    private int _player2Score;
    private int _player1Score;

    private readonly string _player1Name = player1Name;
    private readonly string _player2Name = player2Name;

    private static readonly string[] _pointsNames = ["Love", "Fifteen", "Thirty", "Forty"];

    public string GetScore()
    {
        bool scoresLevel = _player1Score == _player2Score;
        if (scoresLevel)
        {
            return _player1Score switch
            {
                >= 3 => "Deuce",
                _ => _pointsNames[_player1Score] + "-All",
            };
        }

        bool isEndgame = _player1Score >= 4 || _player2Score >= 4;
        if (isEndgame)
        {
            string leader = _player1Score > _player2Score ? _player1Name : _player2Name;
            bool gameFinished = Math.Abs(_player1Score - _player2Score) > 1;

            return gameFinished ? "Win for " + leader : "Advantage " + leader;
        }
        else
        {
            return _pointsNames[_player1Score] + "-" + _pointsNames[_player2Score];
        }
    }

    public void WonPoint(string playerName)
    {
        if (playerName == _player1Name)
            _player1Score += 1;
        else
            _player2Score += 1;
    }

}