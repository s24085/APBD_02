namespace Z_02;

public class GasContainer :ContainerGeneral, IHazardNotifier
{
    private int pressure;
    if(getWeight()> ConatinerShip.weight){
        throw Exception("Overloaded");
    }
}