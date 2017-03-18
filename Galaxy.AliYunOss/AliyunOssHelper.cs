// ------------------------------------------------------------------------------
// Copyright   版权所有。 
// 项目名：Galaxy.AliYunOss 
// 文件名：AliyunOssHelper.cs
// 创建标识：梁桐铭  2017-03-18 18:18
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

#region 命名空间

using System;
using System.IO;
using System.Linq;
using Aliyun.OSS;
using Aliyun.OSS.Common;
using Galaxy.AliYunOss.Response;
using Galaxy.AliYunOss.Util;

#endregion

namespace Galaxy.AliYunOss
{
    public class OssHelper
    {
        private static readonly OssClient Client = new OssClient(Config.Endpoint, Config.AccessKeyId,
            Config.AccessKeySecret);

        /// <summary>
        ///     上传本地文件（本地路径）
        /// </summary>
        /// <param name="key">用于获取阿里云的中图片的唯一值</param>
        /// <param name="fileToUpload">本地路径</param>
        public static ServerResponse<FileData> UpLoad(string key, string fileToUpload)
        {
            //          var fileExtensionName = Path.GetExtension(fileToUpload); //文件扩展名
            //var upLoadPath = "/Upload/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/";
            var filePath = $"{key}"; //云文件保存路径  
            try
            {
                Client.PutObject(Config.BucketName, filePath, fileToUpload);
                var fielData = new FileData
                {
                    Url = Config.BucketName + "." + Config.Endpoint + "/" + filePath
                };
                return ResponseProvider.Success(fielData, "成功");
            }
            catch (Exception ex)
            {
                return ResponseProvider.Error<FileData>(ex.Message);
            }
        }

        /// <summary>
        ///     删除
        /// </summary>
        public static ServerResponse Remove(string key)
        {
            try
            {
                var listResult = Client.ListObjects(Config.BucketName);
                var ossObjectSummaries = listResult.ObjectSummaries.FirstOrDefault(x => x.Key == key);
                if (ossObjectSummaries != null) Client.DeleteObject(Config.BucketName, ossObjectSummaries.Key);

                return ResponseProvider.Success("成功");
            }
            catch (OssException ex)
            {
                return ResponseProvider.Error("失败" + ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseProvider.Error("失败" + ex.Message);
            }
        }

        /// <summary>
        ///     获取图片
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        public static Uri Get(string bucketName, string key)
        {
            var req = new GeneratePresignedUriRequest(bucketName, key, SignHttpMethod.Get)
            {
                Expiration = DateTime.Now.AddHours(1)
            };
            return Client.GeneratePresignedUri(req);
        }

        /// <summary>
        ///     从指定的OSS存储空间中获取指定的文件
        /// </summary>
        /// <param name="key">要获取的文件的名称</param>
        /// <param name="fileToDownload">文件保存的本地路径</param>
        public static ServerResponse Down(string key, string fileToDownload)
        {
            try
            {
                var info = Client.GetObject(Config.BucketName, key);
                using (var requestStream = info.Content)
                {
                    var buf = new byte[1024];
                    var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
                    var len = 0;
                    while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                        fs.Write(buf, 0, len);
                    fs.Close();
                }

                return ResponseProvider.Success("成功");
            }
            catch (Exception ex)
            {
                return ResponseProvider.Success("失败：" + ex.Message);
            }
        }
    }
}