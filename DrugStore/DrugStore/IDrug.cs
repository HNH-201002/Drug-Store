using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public interface IDrug
    {
        string Name { get; set; }
        int ID { get; set; }

        string DrugTypes { get; set; }
    }

}
