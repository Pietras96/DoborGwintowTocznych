using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    interface IDobor
    {
        MechaniznySrubowoToczne WstepnyDoborMechanizmu();
        MechaniznySrubowoToczne KoncowyDoborMechanizmu();
       
    }
}
