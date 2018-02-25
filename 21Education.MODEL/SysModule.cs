using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    public class SysModule : _21Education.IOC.IEntity
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string ParentId { get; set; }

        public string Url { get; set; }

        public string Iconic { get; set; }

        public int Sort { get; set; }

        public string Remark { get; set; }

        public bool State { get; set; }

        public string CreatePerson { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsLast { get; set; }

        public DateTime Version { get; set; }




    }
}
