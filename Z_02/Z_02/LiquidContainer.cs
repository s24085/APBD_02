using System.ComponentModel;
using System.Linq.Expressions;

namespace Z_02;

public class LiquidContainer : ContainerGeneral,IHazardNotifier
{
    
   public bool isDangerous { get; private set; }


if( isDangerous)
    {
         NewWeight = getWeight() / 2;
    }if else
    {
        NewWeight=getWeight()*0,9;
    }else{
    throw Exception("The attempt to try dangerous operation");
}
}