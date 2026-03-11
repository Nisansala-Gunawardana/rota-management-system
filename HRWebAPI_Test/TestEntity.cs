using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurserySystem_HRWebAPI.Model;
namespace HRWebAPI_Test
{
    public class TestEntity :BaseEntity<int>
    {
        public string Name { get; set; } = "";
    }
}
