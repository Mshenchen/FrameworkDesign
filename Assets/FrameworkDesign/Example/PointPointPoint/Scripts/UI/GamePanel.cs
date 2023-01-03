using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    public class GamePanel : MonoBehaviour, IController
    {
        private ICountDownSystem mCountDownSystem;
        private IGameModel mGameModel;

        private void Awake()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();

            mGameModel = this.GetModel<IGameModel>();

            mGameModel.Gold.Register(OnGoldValueChanged);
            mGameModel.Life.Register(OnLifeValueChanged);
            mGameModel.Score.Register(OnScoreValueChanged);

            // ��һ����Ҫ����һ��
            OnGoldValueChanged(mGameModel.Gold.Value);
            OnLifeValueChanged(mGameModel.Life.Value);
            OnScoreValueChanged(mGameModel.Score.Value);
        }

        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "������" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            transform.Find("GoldText").GetComponent<Text>().text = "��ң�" + gold;
        }

        private void OnScoreValueChanged(int score)
        {
            transform.Find("ScoreText").GetComponent<Text>().text = "����:" + score;
        }

        private void Update()
        {
            // ÿ 20 ֡ ����һ��
            if (Time.frameCount % 20 == 0)
            {
                transform.Find("CountDownText").GetComponent<Text>().text =
                    mCountDownSystem.CurrentRemainSeconds + "s";

                mCountDownSystem.Update();
            }
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnRegister(OnGoldValueChanged);
            mGameModel.Life.UnRegister(OnLifeValueChanged);
            mGameModel.Score.UnRegister(OnScoreValueChanged);
            mGameModel = null;
            mCountDownSystem = null;
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}

