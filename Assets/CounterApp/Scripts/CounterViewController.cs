using QFramework;
using UnityEngine;
using UnityEngine.UI;
namespace CounterApp
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;


        void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();
            // ×¢²á
            mCounterModel.Count.Register(OnCountChanged);

            transform.Find("BtnAdd").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    this.SendCommand<AddCountCommand>();
                });

            transform.Find("BtnSub").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    this.SendCommand<SubCountCommand>();
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
            mCounterModel.Count.UnRegister(OnCountChanged);
            mCounterModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }

    public interface ICounterModel :IModel
    {
        public BindableProperty<int> Count { get; }
    }
    public class CounterModel : AbstractModel,ICounterModel
    {

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.Register(count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            });
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

    }
}

