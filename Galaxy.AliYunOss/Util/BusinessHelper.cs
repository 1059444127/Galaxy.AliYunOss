// ------------------------------------------------------------------------------
// Copyright   版权所有。 
// 项目名：Galaxy.AliYunOss 
// 文件名：BusinessHelper.cs
// 创建标识：梁桐铭  2017-03-18 18:18
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

#region 命名空间

using System;

#endregion

namespace Galaxy.AliYunOss.Util
{
    /// <summary>
    ///     Cms业务帮助方法
    /// </summary>
    public static class BusinessHelper
    {
        /// <summary>
        ///     拆分数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int[] BreakUpStr(string str, char key)
        {
            var strArray = str.Split(new[] {key}, StringSplitOptions.RemoveEmptyEntries);
            return Array.ConvertAll(strArray, int.Parse);
        }


        /// <summary>
        ///     拆分数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] BreakUpOptions(string str, char key)
        {
            var strArray = str.Split(new[] {key}, StringSplitOptions.RemoveEmptyEntries);
            return strArray;
        }

        /// <summary>
        ///     首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FunctionStr(string str)
        {
            var functionStr = str.Substring(0, 1).ToLower() + str.Substring(1);
            return functionStr;
        }
    }
}