// ------------------------------------------------------------------------------
// Copyright   版权所有。 
// 项目名：Galaxy.AliYunOss 
// 文件名：ServerResponse.cs
// 创建标识：梁桐铭  2017-03-18 18:18
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

namespace Galaxy.AliYunOss.Response
{
    /// <summary>
    ///     接口返回值
    /// </summary>
    public class ServerResponse
    {
        /// <summary>
        ///     状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///     描述信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    ///     响应消息类
    /// </summary>
    public class ServerResponse<T> : ServerResponse
        where T : class, new()
    {
        /// <summary>
        ///     业务数据对象
        /// </summary>
        public T Data { get; set; }
    }
}