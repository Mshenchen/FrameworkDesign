using UnityEngine;
namespace QFramework.Example
{
    public interface IScoreSystem : ISystem
    {
        
    }
    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();
            this.RegisterEvent<GamePassEvent>(e => 
            {
                var countDownSystem = this.GetSystem<ICountDownSystem>();
                var timeScore = countDownSystem.CurrentRemainSeconds * 10;
                gameModel.Score.Value += timeScore;
                Debug.Log("Score:" + gameModel.Score.Value);
                Debug.Log("BestScore:" + gameModel.BestScore.Value);
                if (gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    gameModel.BestScore.Value = gameModel.Score.Value;
                    Debug.Log("新记录");
                }  
            });
            this.RegisterEvent<OnEnemyKillEvent>(e =>
            {
                gameModel.Score.Value += 10;
                Debug.Log("得分：10");
                Debug.Log("当前分数：" + gameModel.Score.Value);
            });
            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
                Debug.Log("得分：-5");
                Debug.Log("当前分数：" + gameModel.Score.Value);
            });
        }
    }
}
