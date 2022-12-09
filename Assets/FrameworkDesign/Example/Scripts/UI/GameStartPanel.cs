using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;
using System;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour,IController
    {
        private IGameModel mGameModel;
        public GameObject Enemies;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }

        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    this.SendCommand<StartGameCommand>();
                });
            transform.Find("BtnBuyLife").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.SendCommand<BuyLifeCommand>();
            });
            mGameModel = this.GetModel<IGameModel>();
            mGameModel.Gold.RegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.RegisterOnValueChanged(OnLifeValueChanged);
            OnGoldValueChanged(mGameModel.Gold.Value);
            OnLifeValueChanged(mGameModel.Life.Value);
            transform.Find("BestScoreText").GetComponent<Text>().text = "最高分:" + mGameModel.BestScore.Value;
        }

        private void OnGoldValueChanged(int gold)
        {
            if (gold > 0)
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(false);
            }
            transform.Find("GoldText").GetComponent<Text>().text = "金币: " + gold;
        }

        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命:" + life;
        }
        private void OnDestroy()
        {
            mGameModel.Gold.UnRegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.UnRegisterOnValueChanged(OnLifeValueChanged);
            mGameModel = null;
        }
    }
}

