using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        void Start()
        {
            // ×¢²á
            CounterModel.Instance.Count.OnValueChanged += OnCountChanged;

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

            OnCountChanged(CounterModel.Instance.Count.Value);
        }

        // ±íÏÖÂß¼­
        private void OnCountChanged(int newValue)
        {
            transform.Find("CountText").GetComponent<Text>().text = newValue.ToString();
        }

        private void OnDestroy()
        {
            // ×¢Ïú
            CounterModel.Instance.Count.OnValueChanged -= OnCountChanged;
        }
    }

    public class CounterModel:Singleton<CounterModel>
    {
        private CounterModel() { }
        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}

