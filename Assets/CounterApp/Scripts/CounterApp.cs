using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterModel<ICounterModel>(new CounterModel());
            Register<IStorage>(new PlayerPrefsStorage());
        }
    }
}
