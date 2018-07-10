using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanCloud;

namespace TuNanNiao.LeanCloudStudy.Con.Model
{
    [AVClassName("Sport")]
    public class Sport : AVObject
    {
        [AVFieldName("name")]
        public string DisPlayName
        {
            get
            {
                return GetProperty<string>("name");
            }
            set
            {
                SetProperty<string>(value,"name");
            }
        }
        [AVFieldName("Position")]
        //public int totalTime { get; set; }
        public List<string> Position
        {
            get { return GetProperty<List<string>>("Position"); }
            set { SetProperty(value,"Position"); }
        }
    }
}
