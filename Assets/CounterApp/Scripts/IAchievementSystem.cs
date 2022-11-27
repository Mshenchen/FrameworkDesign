using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CounterApp;
namespace FrameworkDesign.Example 
{
    public interface IAchievementSystem : ISystem
    {
        
    }
    public class AchievementSystem : IAchievementSystem
    {
        public IArchitecture Architecture { get; set; }

        public void Init()
        {
            var counterModel = Architecture.GetModel<ICounterModel>();
            var previousCount = counterModel.Count.Value;
            counterModel.Count.OnValueChanged += newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("解锁点击10次成就");
                }else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("解锁点击20次成就");
                }
                previousCount = newCount;
            };
        }
    }
}

