using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanCloud;
using TuNanNiao.LeanCloudStudy.Con.Model;

namespace TuNanNiao.LeanCloudStudy.Con.LeanCloud
{
    public class TestLeanCloud
    {

        public async void SaveObj()
        {
            //新建一个class结构 
            AVObject footballl = new AVObject("Sport");
            Console.WriteLine("footballl:" + footballl);

            //插入数据
            footballl["totalTime"] = 90;
            footballl["name"] = "Football";
            footballl.Add("grade", "1");

            //保存数据
            var saveTask = footballl.SaveAsync().ContinueWith((t) =>
            {
                //获取数据
                System.Console.WriteLine("ObjectId:" + footballl.ObjectId);
                Console.WriteLine("Id:" + t.Id);
                Console.WriteLine("AsyncState:" + t.AsyncState);
                Console.WriteLine("CreationOptions:" + t.CreationOptions);
                Console.WriteLine("Exception:" + t.Exception);
                Console.WriteLine("IsCompleted:" + t.IsCompleted);

                //更新对象的列值
                footballl["totalTime"] = 100;
                footballl["name"] = "Basketball";
                //footballl.Add("grade", "1"); //调用失败：不能再添加grade属性
                footballl.SaveAsync();


            });
            await saveTask;

        }

        public async void GetObjWithId()
        {
            AVObject character = AVObject.CreateWithoutData("Sport", "5b4464a49f5454003b178628");
            await character.FetchAsync().ContinueWith(t =>
            {
                if (character.IsKeyDirty("totalTime"))
                {
                    character.FetchAsync();
                }
                Console.WriteLine("name:" + character.Get<string>("name"));
                Console.WriteLine("totalTime:" + character.Get<double>("totalTime")); //此处用int取小数的话，不会报错，会自动被转化为int
                Console.WriteLine("grade:" + character.Get<string>("grade"));
                //if(character.is)
                // Console.WriteLine("noExist:" + character.Get<string>("noExist")); //报异常
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        public async void DeleteObjWithId()
        {
            AVObject character = AVObject.CreateWithoutData("Sport", "5b44644aee920a003b2eb726");
            await character.DeleteAsync().ContinueWith(t =>
            {
                Console.WriteLine("Delete:ID:" + t.Id);
                Console.WriteLine("character:ID:" + character.ObjectId);

                character.Remove("grage");
                character.SaveAsync();
            });
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        public async void DeletePropertiesWithId()
        {
            AVObject character = AVObject.CreateWithoutData("Sport", "5b446160fe88c20035fd9dcc");
            await character.FetchAsync().ContinueWith(t =>
            {
                Console.WriteLine("FetchAsync:ID:" + t.Id);
                Console.WriteLine("character:ID:" + character.ObjectId);

                character.Remove("grade");
                character.SaveAsync();
            });
        }

        //子类化数据
        public async void AddWithSubClass()
        {
            var sport = new Sport();
            var className = sport.ClassName;
            Console.WriteLine("className" + className);

            sport.Position = new List<string>() {
                "staff","VIP"
            };
            sport.DisPlayName = "Dovey";
            sport.ACL = new AVACL()
            {
                PublicReadAccess = true,
                PublicWriteAccess = false
            };
            await sport.SaveAsync();
        }
        /// <summary>
        /// 利用子类查询数据
        /// </summary>
        public async void GetWithSubClass()
        {
            try
            {
                var query = new AVQuery<Sport>();

                //await query.FindAsync().ContinueWith(t =>
                //{
                //    foreach (Sport sport in t.Result)
                //    {
                //        if (sport.Position == null)
                //        {
                //            Console.WriteLine($"{sport.Get<string>("name")}");
                //        }
                //        else
                //        {
                //            Console.WriteLine($"{sport.DisPlayName} - {sport.Position.Aggregate((i, j) => i + '和' + j)}");
                //        }
                //    }
                //});

                var results = await query.FindAsync();
                foreach (Sport sport in results)
                {
                    //此处无法通过属性取到对应的key中的值
                    if (sport.Position == null)
                    {
                        Console.WriteLine($"{sport.Get<string>("name")}");
                    }
                    else
                    {
                        Console.WriteLine($"{sport.DisPlayName} - {sport.Position.Aggregate((i, j) => i + '和' + j)}");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static void Show()
        {
            TestLeanCloud testLeanCloud = new TestLeanCloud();
            //testLeanCloud.SaveObj();
            //testLeanCloud.GetObjWithId();
            //testLeanCloud.DeleteObjWithId();
            //testLeanCloud.DeletePropertiesWithId();

            //用子类化的方法添加数据
            // testLeanCloud.AddWithSubClass();
            //用子类的方法查询数据
            testLeanCloud.GetWithSubClass();
        }
    }
}
