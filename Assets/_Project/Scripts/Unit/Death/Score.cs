using _Project.Scripts.UI;

namespace _Project.Scripts.Unit.Death
{
    public sealed class Score
    {
        private readonly ScoreView _scoreView;

        private int _score;

        public Score(ScoreView scoreView)
        {
            _score = 0;
            _scoreView = scoreView;
        }

        public void Increment()
        {
            _score++;
            _scoreView.SetAmount(_score);
        }
    }
}