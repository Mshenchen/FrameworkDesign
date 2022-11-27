using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;
        void RegisterModel<T>(T model) where T : IModel;
        void RegisterUtility<T>(T utility);
        T GetModel<T>() where T : class, IModel;
        T GetUtility<T>() where T : class;
    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化完成
        /// </summary>
        private bool mInited = false;
        private List<ISystem> mSystems = new List<ISystem>();
        private List<IModel> mModels = new List<IModel>();
        public static Action<T> OnRegisterPatch = architecture => { };
        private static T mArchitecture = null;
        static void MakeSureArchitecture()
        {
            if(mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
                OnRegisterPatch?.Invoke(mArchitecture);
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();
                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }
                mArchitecture.mSystems.Clear();
                mArchitecture.mInited = true;
            }
        }
        protected abstract void Init();
        protected IOCContainer mContainer = new IOCContainer();
        public static T Get<T>() where T: class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }
        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }
        public void RegisterModel<T>(T model) where T : IModel
        {
            model.Architecture = this;
            mContainer.Register<T>(model);
            if (!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
            
        } 
        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }

        public void RegisterUtility<T>(T utility)
        {
            mContainer.Register<T>(utility);
        }

        public void RegisterSystem<T>(T system) where T : ISystem
        {
            system.Architecture = this;
            mContainer.Register<T>(system);
            if (!mInited)
            {
                mSystems.Add(system);
            }
            else
            {
                system.Init();
            }
        }

        T IArchitecture.GetModel<T>()
        {
            return mContainer.Get<T>();
        }
    }
}

