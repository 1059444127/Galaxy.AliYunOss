// ------------------------------------------------------------------------------
// Copyright   版权所有。 
// 项目名：Galaxy.AliYunOss 
// 文件名：Config.cs
// 创建标识：梁桐铭  2017-03-18 18:18
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Configuration;

namespace Galaxy.AliYunOss.Util
{
    public class Config
    {
        public static readonly string Endpoint = ConfigurationManager.AppSettings["Endpoint"];
        public static readonly string AccessKeyId = ConfigurationManager.AppSettings["AccessKeyId"];
        public static readonly string AccessKeySecret = ConfigurationManager.AppSettings["AccessKeySecret"];
        public static readonly string BucketName = ConfigurationManager.AppSettings["BucketName"];

        public static readonly string[] ExcExt = BusinessHelper.BreakUpOptions(
            ConfigurationManager.AppSettings["ExcExt"],
            ',');
    }
}