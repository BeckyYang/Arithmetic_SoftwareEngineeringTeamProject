/*--------------------
功能：实现随机数生成
作者：谢蜜雪
日期：2019.01.14
--------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticGUI
{
    
    /******生成符合正态分布的随机数******/
    
    public class Normal_Distirbution
    {
        public int normal_dis;
        public int Normal_Dis(double u1, double u2, double e, double d)
        {
            double res = 0;
            int r;
            res = e + Math.Sqrt(d) * Math.Sqrt((-2) * (Math.Log(u1) / Math.Log(Math.E))) * Math.Sin(2 * Math.PI * u2);            
            r = (int)res;
            return r;
        }

    }
}


