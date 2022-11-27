using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;


namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private ICounterModel mCounterModel;

        void Start()
        {
            mCounterModel = CounterApp.Get<ICounterModel>();
            // ×¢²á
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    new AddCountCommand().Execute();
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    new SubCountCommand().Execute();
                });

            OnCountChanged(mCounterModel.Count.Value);
        }

        // ±íÏÖÂß¼­
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // ×¢Ïú
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
            mCounterModel = null;
        }
    }

    public interface ICounterModel :IModel
    {
        public BindableProperty<int> Count { get; }
    }
    public class CounterModel : ICounterModel
    {
        public void Init()
        {
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
        public IArchitecture Architecture { get ; set; }

    }
}

