using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Model
{
    public interface IPersistance
    {
        List<Card> LoadData();
        void SaveData(List<Card> listCards);
    }
}
