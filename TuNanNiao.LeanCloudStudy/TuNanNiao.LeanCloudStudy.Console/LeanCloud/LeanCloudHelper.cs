using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanCloud;
using TuNanNiao.LeanCloudStudy.Con.Model;

namespace TuNanNiao.LeanCloudStudy.Con.LeanCloud
{
    public class LeanCloudHelper
    {
        public const string AppID = "d3wyAE39585C6G2A1NR1L17z-gzGzoHsz";
        public const string AppKey = "HaA1978eItDhTf9iCgCvWyhk";
        public const string MasterKey = "nVfieNY3t909GHw2UuEd94by";
        public static void InitLeanCloud() {
            
            //初始化LeanCloud
            AVClient.Initialize(AppID, AppKey);


            //指定服务节点（CN/US）
            //AVClient.Configuration configuration = new AVClient.Configuration()
            //{
            //    ApplicationId = AppID,
            //    ApplicationKey = AppKey,
            //    AdditionalHTTPHeaders = new Dictionary<string, string>(),
            //    EngineServer = new Uri(""),
            //    Region = AVClient.Configuration.AVRegion.Public_CN,
            //    VersionInfo = new AVClient.Configuration.VersionInformation() {
            //        BuildVersion = "V.1.0.0",
            //        DisplayVersion ="Client 1.0.0",
            //        OSVersion = "Windows7"
            //    }                
            //};
            //注册类映射
            AVObject.RegisterSubclass<Sport>();
        }
    }
}
