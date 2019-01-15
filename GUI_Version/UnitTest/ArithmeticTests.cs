/*---------------------------------
 * 功能：实现单元测试
 * 作者：谢蜜雪、杨冰琪
 * 日期：2019.01.16
-----------------------------------*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArithmeticGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 100 +
// 101 -
// 102 *
// 103 /
// 104 ^
// 105 **
// 106 (
// 107 )
// 1030 分号

namespace ArithmeticGUI.Tests
{
    [TestClass()]
    public class ClassTests
    {
//----------------fraction.cs的单元测试------------------

        [TestMethod()]//正常情况
        public void FracionGetGCDTest1()
        {
            int x = 6;
            int y = 10;
            Assert.AreEqual(fraction.FracionGetGCD(x, y), 2);
        }
        [TestMethod()]//最大公因数为1
        public void FracionGetGCDTest2()
        {
            int x = 2;
            int y = 3;
            Assert.AreEqual(fraction.FracionGetGCD(x, y), 1);
        }
        [TestMethod()]//最大公因数为其中较小的数
        public void FracionGetGCDTest3()
        {
            int x = 5;
            int y = 10;
            Assert.AreEqual(fraction.FracionGetGCD(x, y), 5);
        }
//---------------N_Puzzle.cs的单元测试-----------------

        //--------------------题目查重测试------------------
        //加法交换+括号测试
        [TestMethod()]//测试1+2+3与3+(2+1)是否重复，预期结果为重复 -1
        public void CheckTest1()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 100, 2, 100, 3 };
            int[] puzzle2 = new int[] { 3, 100, 106, 2, 100, 1, 107 };
            int puzzle_len1 = 5;
            int puzzle_len2 = 7;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //加法顺序交换测试
        [TestMethod()]//测试1+2+3与3+2+1是否重复，预期结果为不重复 1
        public void CheckTest2()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 100, 2, 100, 3 };
            int[] puzzle2 = new int[] { 3, 100, 2, 100, 1 };
            int puzzle_len1 = 5;
            int puzzle_len2 = 5;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), 1);
        }
        //乘法顺序交换测试
        [TestMethod()]//测试1*2*3与3*2*1是否重复，预期结果为不重复 1
        public void CheckTest3()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 102, 2, 102, 3 };
            int[] puzzle2 = new int[] { 3, 102, 2, 102, 1 };
            int puzzle_len1 = 5;
            int puzzle_len2 = 5;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), 1);
        }
        //除法顺序交换测试
        [TestMethod()]//测试1/2/3与3/2/1是否重复，预期结果为不重复 1
        public void CheckTest4()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 103, 2, 103, 3 };
            int[] puzzle2 = new int[] { 3, 103, 2, 103, 1 };
            int puzzle_len1 = 5;
            int puzzle_len2 = 5;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), 1);
        }
        //乘法交换+括号测试
        [TestMethod()]//测试(1+2)*3与3*(2+1)是否重复，预期结果为重复 -1
        public void CheckTest5()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 106, 1, 100, 2, 107, 102, 3 };
            int[] puzzle2 = new int[] { 3, 102, 106, 2, 100, 1 ,107 };
            int puzzle_len1 = 7;
            int puzzle_len2 = 7;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //^乘方测试
        [TestMethod()]//测试1+2^3^1与2^3^1 + 1是否重复，预期结果为重复 -1
        public void CheckTest6()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 100, 2, 104, 3, 104, 1 };
            int[] puzzle2 = new int[] { 2, 104, 3, 104, 1, 100, 1 };
            int puzzle_len1 = 7;
            int puzzle_len2 = 7;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //括号嵌套测试
        [TestMethod()]//测试 (1+(1+2)*(3-2))+1 与 1+((3-2)*(1+2))+1) 是否重复，预期结果为不重复 1
        public void CheckTest7()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 106, 1, 100, 106, 1, 100, 2, 107, 102, 106, 3, 101, 2, 107, 107, 100, 1 };
            int[] puzzle2 = new int[] { 1, 100, 106, 106, 3, 101, 2, 107, 102, 106, 1, 100, 2, 107, 107, 100, 1 };
            int puzzle_len1 = 17;
            int puzzle_len2 = 17;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), 1);
        }
        //括号嵌套测试+乘法顺序变换
        [TestMethod()]//测试 (1+(1+2)*(3-2))+1 与 1+((1+2)*(3-2))+1) 是否重复，预期结果为重复 -1
        public void CheckTest8()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 106, 1, 100, 106, 1, 100, 2, 107, 102, 106, 3, 101, 2, 107, 107, 100, 1 };
            int[] puzzle2 = new int[] { 1, 100, 106, 106, 1, 100, 2, 107, 102, 106, 3, 101, 2, 107, 107, 100, 1 };
            int puzzle_len1 = 17;
            int puzzle_len2 = 17;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //**乘方测试
        [TestMethod()]//测试1+2**3**1与2**3**1 + 1是否重复，预期结果为重复 -1
        public void CheckTest9()
        {
            N_Puzzle.labels[0] = 0;
            N_Puzzle.labels[1] = 0;
            int[] puzzle1 = new int[] { 1, 100, 2, 105, 3, 105, 1 };
            int[] puzzle2 = new int[] { 2, 105, 3, 105, 1, 100, 1 };
            int puzzle_len1 = 7;
            int puzzle_len2 = 7;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 0;
            int num_type2 = 0;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //分数的加法+括号测试
        [TestMethod()]//测试 1/2 + （1/3 + 1/4） 与 1/4 + 1/3 + 1/2 是否重复，预期结果为重复 -1
        public void CheckTest10()
        {
            N_Puzzle.labels[0] = 1;
            N_Puzzle.labels[1] = 1;
            int[] puzzle1 = new int[] { 1, 1030, 2, 100, 106, 1, 1030, 3, 100, 1, 1030, 4, 107 };
            int[] puzzle2 = new int[] { 1, 1030, 4, 100, 1, 1030, 3, 100, 1, 1030, 2 };
            int puzzle_len1 = 13;
            int puzzle_len2 = 11;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 1;
            int num_type2 = 1;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }
        //分数的加法+乘法测试
        [TestMethod()]//测试 1/2 * （1/3 + 1/4） 与 （1/4 + 1/3） * 1/2 是否重复，预期结果为重复 -1
        public void CheckTest11()
        {
            N_Puzzle.labels[0] = 1;
            N_Puzzle.labels[1] = 1;
            int[] puzzle1 = new int[] { 1, 1030, 2, 102, 106, 1, 1030, 3, 100, 1, 1030, 4, 107 };
            int[] puzzle2 = new int[] { 106, 1, 1030, 4, 100, 1, 1030, 3, 107, 102, 1, 1030, 2 };
            int puzzle_len1 = 13;
            int puzzle_len2 = 13;
            int puzzle_num1 = 0;
            int puzzle_num2 = 1;
            int num_type1 = 1;
            int num_type2 = 1;
            N_Puzzle.Check(puzzle1, puzzle_len1, puzzle_num1, num_type1);
            Assert.AreEqual(N_Puzzle.Check(puzzle2, puzzle_len2, puzzle_num2, num_type2), -1);
        }

    //--------------运算符重载测试-------------------------

            [TestMethod()] //分数类 ^ 运算符重载
            public void CheckTest12()
            {
                bool z = false;
                fraction A = new fraction (2,3);
                fraction B = new fraction (0, 1);
                fraction C = A ^ B;
                fraction E = new fraction(1, 1);
                if (C == E) z = true;
                Assert.IsTrue(z);
            }

        [TestMethod()] //分数类 * 运算符重载
        public void CheckTest13()
        {
            bool z = false;
            fraction A = new fraction(2, 3);
            fraction B = new fraction(2, 3);
            fraction C = A * B;
            fraction E = new fraction(4, 9);
            if (C == E) z = true;
            Assert.IsTrue(z);
        }
        [TestMethod()] //分数类 / 运算符重载
        public void CheckTest14()
        {
            bool z = false;
            fraction A = new fraction(2, 3);
            fraction B = new fraction(1, 3);
            fraction C = A / B;
            fraction E = new fraction(2, 1);
            if (C == E) z = true;
            Assert.IsTrue(z);
        }
        [TestMethod()] //分数类 + 运算符重载
        public void CheckTest15()
        {
            bool z = false;
            fraction A = new fraction(2, 3);
            fraction B = new fraction(1, 1);
            fraction C = A + B;
            fraction E = new fraction(5, 3);
            if (C == E) z = true;
            Assert.IsTrue(z);
        }
        [TestMethod()] //分数类 - 运算符重载
        public void CheckTest16()
        {
            bool z = false;
            fraction A = new fraction(2, 3);
            fraction B = new fraction(1, 3);
            fraction C = A - B;
            fraction E = new fraction(1, 3);
            if (C == E) z = true;
            Assert.IsTrue(z);
        }

    } 
}