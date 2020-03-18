using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_Light
{
    public class TitleTextChangedMessenger
    {
        public string NewText { get; set; }
        // 用做返回值
        public string Result { get; set; }
    }
}
