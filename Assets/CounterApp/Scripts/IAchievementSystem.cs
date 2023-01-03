using QFramework;
using UnityEngine;
namespace CounterApp
{
    public interface IAchievementSystem : ISystem
    {

    }
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {

        protected override void OnInit()
        {
            var counterModel = this.GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;
            counterModel.Count.Register(newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("�������10�γɾ�");
                }
                else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("�������20�γɾ�");
                }
                previousCount = newCount;
            });
        }
    }
}

