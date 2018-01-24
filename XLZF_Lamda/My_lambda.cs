using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLZF_Lambda
{
    public class My_lambda
    {
        //回顾委托
        public delegate void Noreturn_void();//声明不带返回值不带参数的委托
        public delegate string Noreturn_string();//声明无参数有返回值的委托
        public delegate void Noreturn(string name);//声明委托
        public delegate int Noreturn_Int(int x, int y);//声明有返回值的带参数的委托

        //lambda就是一个方法,演化过程
        public static void Show()
        {
            Console.WriteLine("委托咯~~~~");

            #region 委托+lambda 表达式演化过程

            Noreturn method = new Noreturn(Study);//实例化委托

            method.Invoke("张三");//调用委托

            Noreturn method1 = new Noreturn(
                delegate (string name)
                {
                    Console.WriteLine("{0}学习不停止", name);
                });//基于匿名方法完成委托的实例化

            method1.Invoke("张三");

            Noreturn method2 = new Noreturn(
                (string name) =>
                {
                    Console.WriteLine("{0}学习不停止", name);
                });//把delegate关键字去掉，换成=> 初步形成lambda表达式  => 的左边是参数列表，右边是方法体

            method2.Invoke("张三");

            Noreturn method3 = new Noreturn(
                (name) =>
                {
                    Console.WriteLine("{0}学习不停止", name);
                });//lambda 表达式 =>左侧的参数类型去掉，因为实例化委托的时候必须满足委托的约束，当前委托的约束是无返回值，一个参数 

            method3.Invoke("张三");

            //Noreturn method4 = Study;

            Noreturn method4 =
                (name) =>
                {
                    Console.WriteLine("{0}学习不停止", name);
                };//lambda 表达式 继续进化，去掉 new Noreturn() 因为委托本来就可以直接简写成 Noreturn method4= Study;

            method4.Invoke("张三");

            Noreturn method5 = (name) => Console.WriteLine("{0}学习不停止", name);
            //lambda 表达式 继续进化，去掉 {};（大括号） 前提条件是：方法体只有一行

            method5.Invoke("张三");

            //最终
            Noreturn method10 = (name) => Console.WriteLine("{0}学习不停止", name);//lambda示例 委托实例化

            method10.Invoke("张三");

            #endregion

            #region 委托+lambda表达式练习

            Noreturn_Int noreturn_Int = (x, y) => { return x + y; };//这是依据上面推到的方法写的

            noreturn_Int.Invoke(1, 2);

            Noreturn_Int noreturn_Int1 = (x, y) => x + y;//这是在上一行的基础上省略的写法，如果方法体只有一行可以 去掉return 还有大括号。

            noreturn_Int1.Invoke(11, 22);

            Noreturn_void noreturn_Void = () => { };//实例化该委托，这个委托没有返回值，没有参数

            noreturn_Void.Invoke();

            Noreturn_string noreturn_String = () => "1";//实例化委托，无参数，有返回值

            noreturn_String.Invoke();

            #endregion

            #region 泛型委托，有这个泛型委托，也就是不用再特意的去声明一个委托了

            //无返回值的用Action

            Action act1 = () => { };

            Action<string> act2 = s => { };
            //最多16个参数
            Action<int, string, Double, decimal, float, Action> act3 = (a, s, d, f, g, h) => { };

            //有返回值的用Func
            //最多16个参数
            //参数的最后一位就是返回值类型
            Func<string> fun = () => "123";

            Func<string, int, Double, Func<decimal>, Action, decimal> fun1 = (a, s, d, f, g) => Convert.ToDecimal(12.22);



            #endregion
        }

        /// <summary>
        /// linq 结合 lambda表达
        /// </summary>
        public static void LinqShow()
        {
            List<int> intlist = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                intlist.Add(i);
            }

            //找出大于55的
            foreach (int item in intlist.Where<int>(num => num > 55))
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 学习，很重要
        /// </summary>
        /// <param name="name"></param>
        public static void Study(string name)
        {
            Console.WriteLine("{0}学习不停止", name);
        }
    }
}
