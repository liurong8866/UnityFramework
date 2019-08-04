using UnityEngine;
using System;

namespace Framework
{
    public class TestReflector : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

            ReflectorTest();

        }

        public void ReflectorTest()
        {
            //动态绑定事件
            ReflectorUtility re = new ReflectorUtility();

            ReflectTest rt = new ReflectTest();

            TextBlock tb = new TextBlock();

            ////re.DynamicEventBinding<ReflectTest, DelegateReflectTest>(rt, "MouseLeftButtonUp", "DelegateReflectTest", "Lucky", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            //ReflectorBindInfo<TextBlock> reinfo = new ReflectorBindInfo<TextBlock>();

            //reinfo.BindInstance = tb;
            //reinfo.EventName = "MouseLeftButtonUp";
            //reinfo.DelegateName = "DelegateReflectTest";
            //reinfo.MethodName = "Lucky";
            //reinfo.BindingFlag = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;

            //ReflectorUtility.DynamicEventBind<TextBlock, DelegateReflectTest, ReflectTest>(reinfo);


            //tb.Add();

            //动态绑定代理
            //ReflectTest2 rt2 = new ReflectTest2();

            ReflectorBindInfo<TextBlock> reinfo1 = new ReflectorBindInfo<TextBlock>();

            reinfo1.BindInstance = tb;
            reinfo1.EventName = "";
            reinfo1.DelegateName = "onPress";
            reinfo1.MethodName = "LuckyHandler";
            reinfo1.BindingFlag = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static;


            ReflectorBindInfo<TextBlock> reinfo2 = new ReflectorBindInfo<TextBlock>();

            reinfo2.BindInstance = tb;
            reinfo2.EventName = "";
            reinfo2.DelegateName = "onPress";
            reinfo2.MethodName = "Lucky";
            reinfo2.BindingFlag = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;


            ReflectorUtility.DynamicDelegateBind<TextBlock, DelegateReflectTest, ReflectTest2>(reinfo1);

            tb.OnPress();


            ReflectorBindInfo<TextBlock> reinfo3 = new ReflectorBindInfo<TextBlock>();

            reinfo3.BindInstance = tb;
            reinfo3.EventName = "";
            reinfo3.DelegateName = "onHover";
            reinfo3.MethodName = "ShowBackGround";
            reinfo3.BindingFlag = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;


            ReflectorUtility.DynamicDelegateBind<TextBlock, DelegateBoolTest, ReflectTest2>(reinfo3);

            tb.OnHover();
        }
    }

    public delegate void DelegateReflectTest(object sender, EventArgs e);
    public delegate void DelegateBoolTest(object sender, bool state);

    public class TextBlock
    {
        public event DelegateReflectTest MouseLeftButtonUp;

        public DelegateReflectTest onPress;

        public DelegateReflectTest onClick;

        //public event DelegateReflectTest OnClick;

        public DelegateBoolTest onHover;

        public string Text;

        public void OnPress()
        {
            if (onPress != null)
            {
                onPress(null, null);
            }
        }

        public void OnHover()
        {
            if (onHover != null)
            {
                onHover(true, true);
            }
        }

        public void Add()
        {
            if (MouseLeftButtonUp != null)
            {
                MouseLeftButtonUp(this, null);
            }

            Console.WriteLine("this is TextBlock add method");
        }
    }

    public class ReflectTest : TextBlock
    {
        public ReflectTest()
        {

        }
        public ReflectTest(string name)
        {

        }
        public static void LuckyHandler(object sender, EventArgs e)
        {
            Console.WriteLine("hello test LuckyHandler");
        }

        private void Lucky(object sender, EventArgs e)
        {
            Console.WriteLine("hello test Lucky");
        }
    }

    public class ReflectTest2
    {
        public string Name { get; set; }

        public ReflectTest2()
        {

        }

        public ReflectTest2(string name)
        {

        }

        public static void LuckyHandler(object sender, EventArgs e)
        {
            Console.WriteLine("hello test LuckyHandler");
        }

        private void Lucky(object sender, EventArgs e)
        {
            Console.WriteLine("hello test Lucky");
        }

        private void ShowBackGround(object sender, bool state)
        {
            Console.WriteLine("hello test ShowBackGround");
        }

    }
}